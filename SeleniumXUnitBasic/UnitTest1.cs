using Autofac;
using Autofac.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumXUnitBasic.Driver;
using System;
using System.ComponentModel;
using Xunit;
using IContainer = Autofac.IContainer;

namespace SeleniumXUnitBasic
{
    public class UnitTest1 : IDisposable
    {
        IWebDriver driver;
        IContainer container;
        public UnitTest1()
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
        public void Test1()
        {
            driver.FindElement(By.LinkText("Product")).Click();
            driver.FindElement(By.LinkText("Create")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("Table");
            driver.FindElement(By.Id("Description")).SendKeys("Standing Table");
            driver.FindElement(By.Id("Price")).SendKeys("100");
            var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
            select.SelectByValue("2");
            driver.FindElement(By.Id("Create")).Submit();
        }

        [Fact]
        public void Test2()
        {
            driver.FindElement(By.LinkText("Product")).Click();
            driver.FindElement(By.LinkText("Create")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("Desk");
            driver.FindElement(By.Id("Description")).SendKeys("Standing Desk");
            driver.FindElement(By.Id("Price")).SendKeys("100");
            var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
            select.SelectByValue("2");
            driver.FindElement(By.Id("Create")).Submit();
        }

        [Fact]
        public void Test3()
        {
            driver.FindElement(By.LinkText("Product")).Click();
            driver.FindElement(By.LinkText("Create")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("Chair");
            driver.FindElement(By.Id("Description")).SendKeys("Sitting Chair");
            driver.FindElement(By.Id("Price")).SendKeys("100");
            var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
            select.SelectByValue("3");
            driver.FindElement(By.Id("Create")).Submit();
        }
    }
}