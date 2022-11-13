using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoFixture;
using FluentAssertions;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace XUnitDemo
{
    //using selenium with web driver fixture
    //[Collection("Sequence")] to run test in sequence as xunit by default is parallel
    public class SeleniumUsingFixture : IClassFixture<WebDriverFixture>
    {
        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public SeleniumUsingFixture(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ClassFixtureTestNavigate()
        {
            testOutputHelper.WriteLine("First Test");
            webDriverFixture.firefoxDriver.Navigate().GoToUrl("http://www.eaapp.somee.com");

            var anchor = webDriverFixture.firefoxDriver.FindElement(By.TagName("a"));
            //anchor.Should().HaveCountGreaterThan(2);
        }

        //note - Xunit by default runs all test methods in parallel

        //simple test with fact
        //[Fact]
        //public void ClassFixtureTestFillData()
        //{
        //    testOutputHelper.WriteLine("First test");
        //    webDriverFixture.firefoxDriver.Navigate().GoToUrl("http://www.eaapp.somee.com");
        //    webDriverFixture.firefoxDriver.FindElement("link text","Login").Click();
        //    webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='UserName']")).SendKeys("admin");
        //    webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("password");
        //    webDriverFixture.firefoxDriver.FindElement(By.ClassName("btn-default")).Click();
        //    testOutputHelper.WriteLine("test completed");
        //}

        //using inline data in xunit
        [Theory]
        [InlineData("admin","passowrd")]
        [InlineData("admin1", "passowrd1")]
        public void ClassFixtureTestFillData(string username, string password)
        {
            testOutputHelper.WriteLine("First test");
            webDriverFixture.firefoxDriver.Navigate().GoToUrl("http://www.eaapp.somee.com");
            webDriverFixture.firefoxDriver.FindElement("link text", "Login").Click();
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='UserName']")).SendKeys("username");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("password");
            webDriverFixture.firefoxDriver.FindElement(By.ClassName("btn-default")).Click();
            testOutputHelper.WriteLine("test completed");
        }


        //passing data using member data attribute
        [Theory]
        [MemberData(nameof(TestData))]
        public void ClassFixtureTestFillDataRegister(string username, string password, string cpassword, string email)
        {
            testOutputHelper.WriteLine("First test");
            webDriverFixture.firefoxDriver.Navigate().GoToUrl("http://www.eaapp.somee.com");
            webDriverFixture.firefoxDriver.FindElement("link text", "Register").Click();
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='UserName']")).SendKeys("username");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("password");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='ConfirmPassword']")).SendKeys("cpassword");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='Email']")).SendKeys("email");
            webDriverFixture.firefoxDriver.FindElement(By.ClassName("btn-default")).Click();


            //check if an element does not exist and write test case assertion for that scenario
            var exception = Assert.Throws<NoSuchElementException>(() =>
                webDriverFixture.firefoxDriver.FindElement(By.ClassName("btn-defa")).Click());

            Assert.Contains("Unable to locate element:", exception.Message);

            //Fluent Assertions
            exception.Message.Should().Contain("Unable to locate element:");

            testOutputHelper.WriteLine("test completed");
        }

        [Theory, AutoData]
        public void ClassFixtureTestFillDataRegisterWithAutoData(RegisterUserModel model)
        {
            testOutputHelper.WriteLine("First test");
            webDriverFixture.firefoxDriver.Navigate().GoToUrl("http://www.eaapp.somee.com");

            var dataModel = new Fixture().Build<RegisterUserModel>()
                .Do(x => x.Email = "Karthik@gmail.com")
                .Create();

            webDriverFixture.firefoxDriver.FindElement("link text", "Register").Click();
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='UserName']")).SendKeys("model.UserName");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("model.Password");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='ConfirmPassword']")).SendKeys("model.ConfirmPassword");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='Email']")).SendKeys("model.Email");
            webDriverFixture.firefoxDriver.FindElement(By.ClassName("btn-default")).Click();


            //check if an element does not exist and write test case assertion for that scenario
            var exception = Assert.Throws<NoSuchElementException>(() =>
                webDriverFixture.firefoxDriver.FindElement(By.ClassName("btn-defa")).Click());

            Assert.Contains("Unable to locate element:", exception.Message);

            //Fluent Assertions
            exception.Message.Should().Contain("Unable to locate element:");

            testOutputHelper.WriteLine("test completed");
        }

        public static IEnumerable<object[]> TestData => new List<object[]>()
        {
            new object[]
            {
                "Karthik",
                "KartPassword",
                "KartPassword",
                "Karthik@gmailc.com"
            },
            new object[]
            {
                "Prashanth",
                "PrasPassword",
                "PrasPassword",
                "Prashanth@gmail.com"
            }
        };
    }
}
