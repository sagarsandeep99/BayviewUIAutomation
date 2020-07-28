using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BayViewUIAutomation.GlobalParam;
using OpenQA.Selenium;

namespace BayViewUIAutomation.CommonLibs
{
    public class PageBase
    {
        public IWebDriver Driver = ObjectRepo.Driver;
    }
}
