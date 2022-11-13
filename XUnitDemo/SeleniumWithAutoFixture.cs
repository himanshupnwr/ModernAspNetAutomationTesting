using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit.Abstractions;

namespace XUnitDemo
{
    public class SeleniumWithAutoFixture: IClassFixture<WebDriverFixture>
    {
        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public SeleniumWithAutoFixture(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ClassFixtureTestFillDataRegister()
        {
            testOutputHelper.WriteLine("First test");
            webDriverFixture.firefoxDriver.Navigate().GoToUrl("http://www.eaapp.somee.com");

            var username = new Fixture().Create<string>();
            var password = new Fixture().Create<string>();
            var email = new Fixture().Create<MailAddressGenerator>();

            webDriverFixture.firefoxDriver.FindElement("link text", "Register").Click();
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='UserName']")).SendKeys("username");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("password");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='ConfirmPassword']")).SendKeys("password");
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

        [Fact]
        public void ClassFixtureTestFillDataRegisterWithType()
        {
            testOutputHelper.WriteLine("First test");
            webDriverFixture.firefoxDriver.Navigate().GoToUrl("http://www.eaapp.somee.com");

            //var dataModel = new Fixture().Create<RegisterUserModel>();

            //user autofixture with builder pattern
            //var dataModel = new Fixture().Build<RegisterUserModel>()
            //                                                            .Without(x=>x.Email)
            //                                                            .Create();

            var dataModel = new Fixture().Build<RegisterUserModel>()
                .Do(x => x.Email = "Karthik@gmail.com")
                .Create();

            webDriverFixture.firefoxDriver.FindElement("link text", "Register").Click();
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='UserName']")).SendKeys("dataModel.UserName");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("dataModel.Password");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='ConfirmPassword']")).SendKeys("dataModel.ConfirmPassword");
            webDriverFixture.firefoxDriver.FindElement(By.XPath("//input[@id='Email']")).SendKeys("dataModel.Email");
            webDriverFixture.firefoxDriver.FindElement(By.ClassName("btn-default")).Click();


            //check if an element does not exist and write test case assertion for that scenario
            var exception = Assert.Throws<NoSuchElementException>(() =>
                webDriverFixture.firefoxDriver.FindElement(By.ClassName("btn-defa")).Click());

            Assert.Contains("Unable to locate element:", exception.Message);

            //Fluent Assertions
            exception.Message.Should().Contain("Unable to locate element:");

            testOutputHelper.WriteLine("test completed");
        }
    }
}
