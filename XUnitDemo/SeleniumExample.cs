using System.Runtime.CompilerServices;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Abstractions;

namespace XUnitDemo
{
    public class SeleniumExample
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly FirefoxDriver _firefoxDriver;

        public SeleniumExample(ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            var driver = new DriverManager().SetUpDriver(new FirefoxConfig());
            this._firefoxDriver = new FirefoxDriver();
        }
        [Fact]
        public void Test1()
        {
            //Console.WriteLine("First Test");
            _testOutputHelper.WriteLine("First Test");
            _firefoxDriver.Navigate().GoToUrl("http://eaapp.somee.com");
        }
    }
}