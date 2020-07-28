using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BayViewUIAutomation.CommonLibs;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BayViewUIAutomation.GlobalParam
{
    public class ObjectRepo
    {
        //public static Iconfig Config { get; set; }
        public static IWebDriver Driver { get; set; }
        public static DriverSetup SetDriver { get; set; }
        public static WebDriverWait Wait { get; set; }
    }
}
