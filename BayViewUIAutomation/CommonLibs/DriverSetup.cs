using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BayViewUIAutomation.CustomExceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace BayViewUIAutomation.CommonLibs
{
    public class DriverSetup
    {

       // IWebDriver driver = new ChromeDriver();

        //public static string DownloadDirectory => ConfigurationManager.AppSettings["DownloadDirectory"];
        //private IWebDriver GetFirefoxDriver()
        //{

        //    FirefoxBinary binary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
        //    var profile = new FirefoxProfile();
        //    IWebDriver driver = new FirefoxDriver(binary, profile);
        //    //IWebDriver driver = new FirefoxDriver();
        //    return driver;
        //}
       public IWebDriver GetChromeDriver()
       {
            //    ChromeOptions chromeOptions = new ChromeOptions();
            //    chromeOptions.AddUserProfilePreference("download.default_directory", DownloadDirectory);
            //    chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            //    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            //    IWebDriver driver = new ChromeDriver(chromeOptions);
           IWebDriver driver = new ChromeDriver();
                return driver;
            }

            //private IWebDriver GetIncognitoChromeDriver()
            //{
            //    var capabilities = DesiredCapabilities.Chrome();
            //    var options = new ChromeOptions();

            //    options.AddArgument(@"--incognito");
            //    options.AddArgument(@"--start-maximized");
            //    capabilities.SetCapability(ChromeOptions.Capability, options);
            //    IWebDriver driver = new ChromeDriver(options);
            //    return driver;
            //}
            //private IWebDriver GetIEDriver()
            //{
            //    IWebDriver driver = new InternetExplorerDriver();
            //    return driver;
            //}

            //public IWebDriver InitDriver(IWebDriver driver, Iconfig config)
            //{
            //    switch (config.GetBrowser())
            //    {
            //        case BrowserType.Firefox:
            //            driver = GetFirefoxDriver();
            //            break;

            //        case BrowserType.Chrome:
            //            driver = GetChromeDriver();
            //            break;

            //        case BrowserType.iChrome:
            //            driver = GetIncognitoChromeDriver();
            //            break;

            //        case BrowserType.IExplorer:
            //            driver = GetIEDriver();
            //            break;

            //        default:
            //            throw new NoDriverFound("Driver not found : " + config.GetBrowser());
            //    }


            public IWebDriver InitDriver(IWebDriver driver)
            {
                driver = GetChromeDriver();
                return driver;
            }
        }

    
}
