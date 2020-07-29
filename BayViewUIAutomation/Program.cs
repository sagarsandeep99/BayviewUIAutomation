using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BayViewUIAutomation.GlobalParam;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BayViewUIAutomation.ActionClasses;
using BayViewUIAutomation.CommonLibs;

namespace BayViewUIAutomation
{
    public class Program
    {
        static void Main(string[] args)
        {


            GetExcelData getExcelData = new GetExcelData();
            var projectIdList = getExcelData.GetProjectIdList(1, "ProjectId");
            var pro = projectIdList.ToString().Split(',');

            //foreach (string projectId in pro)
            //{
            //    getExcelData.ResultOfProjectId("Pass", projectId);
            //}

            for (int rowId = 0; rowId < pro.Length; rowId++)
            {
                getExcelData.ResultOfProjectId(rowId+1, "Pass", pro[rowId]);
            }


            ////set up browser
            //IWebDriver driver = new ChromeDriver();
            //driver.Url = "http://xq-test.azurewebsites.net/";
            //driver.Manage().Window.Maximize();

            //Thread.Sleep(5000);

            //driver.FindElement(By.Name("username")).SendKeys("sagar.sandeep@wipfli.com");
            //driver.FindElement(By.Name("password")).SendKeys("Password@1234");
            //driver.FindElement(By.XPath("//input[@ng-click='doLogin()']")).Click();
            //Thread.Sleep(5000);

            //driver.Url = "http://xq-test.azurewebsites.net/" + "#!/project/1126";

            //Thread.Sleep(7000);

            //driver.FindElement(By.XPath("//span[text()='Mod 1']/preceding-sibling::i")).Click();

            //Thread.Sleep(5000);
            //driver.FindElement(By.XPath("//form[@name='buildingDimensionsForm']//button[@ng-click='checkAndSave(true)']")).Click();

            //Thread.Sleep(3000);
            //try
            //{
            //    driver.FindElement(By.XPath("//button[@ng-click='ok()']")).Click();
            //}
            //catch (Exception)
            //{
            //}

            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//div[@id='roofDetailsContainer']//button[2]")).Click();

            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//button[text()='Save for all walls']")).Click();

            //Thread.Sleep(3000);
            //try
            //{
            //    driver.FindElement(By.XPath("//button[ng-click=\"ok()\"]")).Click();
            //}
            //catch (Exception)
            //{
            //}

            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//button[@id='quote-button']")).Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//li[@ng-click='generateMaterialList(bid)']/a")).Click();
            //Thread.Sleep(5000);
            //driver.FindElement(By.XPath("//button[@ng-click='close()']")).Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//button[@id='quote-button']")).Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//li[@ng-click='getQuote(bid, false)']/a")).Click();
            //Thread.Sleep(3000);

            //try
            //{
            //    driver.FindElement(By.XPath("//button[ng-click=\"ok()\"]")).Click();
            //}
            //catch (Exception)
            //{
            //}

            //Thread.Sleep(5000);
            //driver.FindElement(By.XPath("//button[@ng-click='close()']")).Click();


        }
    }
}
