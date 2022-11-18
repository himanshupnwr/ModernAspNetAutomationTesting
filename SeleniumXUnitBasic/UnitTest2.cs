using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumXUnitBasic.Driver;
using System;
using System.ComponentModel;
using Xunit;
using IContainer = Autofac.IContainer;

namespace SeleniumXUnitBasic
{
    public class UnitTest2 : IDisposable
    {
        IWebDriver driver;
        IContainer container;
        public UnitTest2()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BrowserDriver>().As<IBrowserDriver>();
            container = builder.Build();

            var driverFixture = new DriverFixture(container, Driver.BrowserType.Firefox);
            driver = driverFixture.Driver;
            driver.Navigate().GoToUrl(new Uri("https://localhost:7221/"));
        }


        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void Test4()
        {
            driver.FindElement(By.LinkText("Product")).Click();
            driver.FindElement(By.LinkText("Create")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("Motherboard");
            driver.FindElement(By.Id("Description")).SendKeys("Computer board");
            driver.FindElement(By.Id("Price")).SendKeys("5000");
            var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
            select.SelectByValue("1");
            driver.FindElement(By.Id("Create")).Submit();
        }

        [Fact]
        public void Test5()
        {
            driver.FindElement(By.LinkText("Product")).Click();
            driver.FindElement(By.LinkText("Create")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("Speakers");
            driver.FindElement(By.Id("Description")).SendKeys("Speakers sound system");
            driver.FindElement(By.Id("Price")).SendKeys("400");
            var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
            select.SelectByValue("3");
            driver.FindElement(By.Id("Create")).Submit();
        }

    }
}