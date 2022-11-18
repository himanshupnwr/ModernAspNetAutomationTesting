using Autofac;
using OpenQA.Selenium;
using SeleniumXUnitBasic.Driver;
using System;

namespace SeleniumXUnitBasic;
public class DriverFixture : IDisposable
{
    IWebDriver driver;
    private readonly IContainer container;

    public DriverFixture(IContainer container, BrowserType browserType)
    {
        this.container = container;
        driver = GetWebDriver(browserType);
    }

    public IWebDriver Driver => driver;

    private IWebDriver GetWebDriver(BrowserType browserType)
    {
        var driver = container.Resolve<IBrowserDriver>();
        return browserType switch
        {
            BrowserType.Chrome => driver.GetChromeDriver(),
            BrowserType.Firefox => driver.GetFirefoxDriver(),
            _ => driver.GetChromeDriver()
        };
    }


    public void Dispose()
    {
        driver.Quit();
    }
}