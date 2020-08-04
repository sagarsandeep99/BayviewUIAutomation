using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BayViewUIAutomation.ActionClasses;
using BayViewUIAutomation.CommonLibs;
using BayViewUIAutomation.GlobalParam;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BayViewUIAutomation.ProjLib
{
    public class ProjBuildingAndDoorsNavigationFlowForDataMigration
    {
        string _result = "";
        public void ProjBuildingFlow(string projectId)
        {
            
            try
            {
               
                ObjectRepo.Driver.Url = "http://xq-test.azurewebsites.net/" + "#!/project/" + projectId;
                Thread.Sleep(10000);

                By element = By.XPath("//span[text()='Mod 1']/preceding-sibling::i");
                try
                {
                    UiActions.WebDriverWait(ObjectRepo.Driver, element, 30, "not found");
                }
                catch (Exception)
                {
                    ObjectRepo.Driver.FindElement(By.XPath("//span[text()='Mod 1']/preceding-sibling::i")).Click();
                }


                Thread.Sleep(5000);
                ObjectRepo.Driver.FindElement(
                    By.XPath("//form[@name='buildingDimensionsForm']//button[@ng-click='checkAndSave(true)']")).Click();

                Thread.Sleep(3000);
                try
                {
                    ObjectRepo.Driver.FindElement(By.XPath("//button[@ng-click='ok()']")).Click();
                }
                catch (Exception)
                {
                }

                Thread.Sleep(3000);
                ObjectRepo.Driver.FindElement(By.XPath("//div[@id='roofDetailsContainer']//button[2]")).Click();

                Thread.Sleep(3000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[text()='Save for all walls']")).Click();

                Thread.Sleep(3000);
                try
                {
                    ObjectRepo.Driver.FindElement(By.XPath("//button[@ng-click=\"ok()\"]")).Click();
                }
                catch (Exception)
                {
                }       
                _result = "Pass";

            }
            catch (Exception e)
            {
                _result = "Fail" + e;

            }
        }

        public void ProjDoorsFlow()
        {

        }

        public void ViewReports()
        {
            try
            {
                Thread.Sleep(10000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[@id='quote-button']")).Click();
                Thread.Sleep(5000);
                ObjectRepo.Driver.FindElement(By.XPath("//li[@ng-click='generateMaterialList(bid)']/a")).Click();
                Thread.Sleep(7000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[@ng-click='close()']")).Click();
                Thread.Sleep(5000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[@id='quote-button']")).Click();
                Thread.Sleep(5000);
                ObjectRepo.Driver.FindElement(By.XPath("//li[@ng-click='getQuote(bid, false)']/a")).Click();
                Thread.Sleep(15000);

                try
                {
                    ObjectRepo.Driver.FindElement(By.XPath("//button[ng-click=\"ok()\"]")).Click();
                }
                catch (Exception)
                {
                }

                Thread.Sleep(5000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[@ng-click='close()']")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //result;
            }
           
        }

    }
}
