using System.Runtime.CompilerServices;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Abstractions;

namespace XUnitDemo
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly ChromeDriver _chromeDriver;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            var driver = new DriverManager().SetUpDriver(new ChromeConfig());
            this._chromeDriver = new ChromeDriver();
        }
        [Fact]
        public void Test1()
        {
            //Console.WriteLine("First Test");
            _testOutputHelper.WriteLine("First Test");
            _chromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
        }
    }
}