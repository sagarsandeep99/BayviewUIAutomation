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
        string failedException = "";
        public string ProjBuildingFlow(By modElement)
        {          
            try
            {                     
                try
                {
                    UiActions.WebDriverWait(ObjectRepo.Driver, modElement, 30, "not found");
                    ObjectRepo.Driver.FindElement(modElement).Click();
                }
                catch (Exception)
                {
                    ObjectRepo.Driver.FindElement(modElement).Click();
                }

                Thread.Sleep(5000);
                ObjectRepo.Driver.FindElement(
                    By.XPath("//form[@name='buildingDimensionsForm']//button[@ng-click='checkAndSave(true)']")).Click();

                Thread.Sleep(6000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[@ng-click='ok()']")).Click();

                Thread.Sleep(3000);
                ObjectRepo.Driver.FindElement(By.XPath("//div[@id='roofDetailsContainer']//button[2]")).Click();

                Thread.Sleep(3000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[text()='Save for all walls']")).Click();

                Thread.Sleep(6000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[@ng-click=\"ok()\"]")).Click();
            }
            catch (Exception e)
            {
                failedException = "Fail"+e;
                return failedException;
            }
            return "Passed";
        }

        public string ProjDoorsFlow()
        {
            Thread.Sleep(10000);
          //  By element = By.XPath("//span[text()=\'Doors\']/preceding-sibling::i");

            //try
            //{
            //    UiActions.WebDriverWait(ObjectRepo.Driver, element, 30, "not found");
            //}
            //catch (NoSuchElementException)
            //{
                ObjectRepo.Driver.FindElement(By.XPath("//span[text()=\'Doors\']/preceding-sibling::i")).Click();
                    // }
            try
            {
                Thread.Sleep(10000);
                var noOfDors =
                    ObjectRepo.Driver.FindElements(
                        By.XPath("//span[@ng-click=\'grid.appScope.addEditDoor(row.entity)\']"));

                if (noOfDors.Count > 0)
                {
                    for (int iDoorRow = 1; iDoorRow <= noOfDors.Count; iDoorRow++)
                    {
                        Thread.Sleep(10000);
                        ObjectRepo.Driver
                            .FindElement(By.XPath("//div" + iDoorRow +
                                                  "/div[@row-render-index='rowRenderIndex']//span[@ng-click='grid.appScope.addEditDoor(row.entity)']"))
                            .Click();

                        Thread.Sleep(30000);
                        ObjectRepo.Driver.FindElement(By.XPath("//button[@ng-click=\'save();\']")).Click();

                        Thread.Sleep(6000);
                        ObjectRepo.Driver.FindElement(By.XPath("//button[@ng-click=\"ok()\"]")).Click();

                        Thread.Sleep(10000);
                    }
                }
                else
                {
                    failedException = "No Doors available";
                    return failedException;
                }
            }
            catch (NoSuchElementException elementException)
            {
                Console.WriteLine(elementException);
                throw;
            }
            catch (Exception e)
            {
                failedException = "Fail" + e;
                return failedException;
            }
            return "Passed";
        }

        public string ViewReports()
        {
            try
            {
                Thread.Sleep(10000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[@id='quote-button']")).Click();
                Thread.Sleep(10000);
                ObjectRepo.Driver.FindElement(By.XPath("//li[@ng-click='generateMaterialList(bid)']/a")).Click();
                Thread.Sleep(10000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[@ng-click='close()']")).Click();
                Thread.Sleep(10000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[@id='quote-button']")).Click();
                Thread.Sleep(10000);
                ObjectRepo.Driver.FindElement(By.XPath("//li[@ng-click='getQuote(bid, false)']/a")).Click();
                Thread.Sleep(10000);
                ObjectRepo.Driver.FindElement(By.XPath("//button[@ng-click='close()']")).Click();
            }
            catch (ArgumentNullException elementException)
            {
                Console.WriteLine(elementException);
                throw;
            }
            catch (NoSuchElementException elementException)
            {
                Console.WriteLine(elementException);
                throw;
            }
            catch (Exception e)
            {
                failedException = "Fail" + e;
                return failedException;
            }

            return "Passed";

        }

    }
}
