using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BayViewUIAutomation.CommonLibs;
using BayViewUIAutomation.GlobalParam;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BayViewUIAutomation.ProjLib
{
    public class Xq2PageSetup
    {
        public void LoginToApplication()
        {
            //ObjectRepo.Config = new AppConfigReader();
            ObjectRepo.SetDriver = new DriverSetup();
            ObjectRepo.Driver = ObjectRepo.SetDriver.InitDriver(ObjectRepo.Driver);



            ObjectRepo.Driver.Url = "http://xq-perf.azurewebsites.net/";
            ObjectRepo.Driver.Manage().Window.Maximize();

            Thread.Sleep(5000);

            ObjectRepo.Driver.FindElement(By.Name("username")).SendKeys("sagar.sandeep@wipfli.com");
            ObjectRepo.Driver.FindElement(By.Name("password")).SendKeys("Password@1234");
            ObjectRepo.Driver.FindElement(By.XPath("//input[@ng-click='doLogin()']")).Click();
            Thread.Sleep(5000);

        }
    }
}
