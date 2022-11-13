using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace XUnitDemo
{
    public class WebDriverFixture : IDisposable
    {
        public FirefoxDriver firefoxDriver { get; private set; }

        public WebDriverFixture()
        {
            //WebDriverManager
            //var driver = new DriverManager().SetUpDriver(new ChromeConfig());
            var driver = new DriverManager().SetUpDriver(new FirefoxConfig());
            firefoxDriver = new FirefoxDriver();
        }

        public void Dispose()
        {
            firefoxDriver.Quit();
            firefoxDriver.Dispose();
        }
    }
}
