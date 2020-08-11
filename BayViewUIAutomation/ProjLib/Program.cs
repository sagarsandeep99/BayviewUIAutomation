﻿using System;
using System.Threading;
using BayViewUIAutomation.ActionClasses;
using BayViewUIAutomation.CommonLibs;
using BayViewUIAutomation.GlobalParam;
using OpenQA.Selenium;

namespace BayViewUIAutomation.ProjLib
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Decleration
            Xq2PageSetup xq2 = new Xq2PageSetup();
            ProjBuildingAndDoorsNavigationFlowForDataMigration projNavigation =
                new ProjBuildingAndDoorsNavigationFlowForDataMigration();

            //Read data(projectId) from excel
            GetExcelData getExcelData = new GetExcelData();
            var projectIdList = getExcelData.GetProjectIdList(1, "ProjectId");
            var pro = projectIdList.ToString().Split(',');
            


            //Delete existing csv result file
           // getExcelData.DeleteFile();

            //Login to application
            xq2.LoginToApplication();

            var rowId = 1;
            //Building & Doors flow
            foreach (string projectId in pro)
            {
                Thread.Sleep(3000);
                ObjectRepo.Driver.Url = "http://xq-test.azurewebsites.net/" + "#!/project/" + projectId;
                var emptyBid = "";
                var _result = "";
                var executionStatus = "";
                Thread.Sleep(10000);

                //Check Bid is present or not
                By byNoBid = By.XPath("//div[@ng-if=\'pcBids.length == 0 && !addingBid\']");
                bool elementDisplayedAndVisible = UiActions.IsElementDisplayedAndVisible(byNoBid, null);
                if (elementDisplayedAndVisible)
                {
                    Thread.Sleep(3000);
                    emptyBid = ObjectRepo.Driver.FindElement(byNoBid).Text.Trim();
                }

                var emptyBidString = ("              There are no current bids for selected customer.        ").Trim();
                if (emptyBid != emptyBidString)
                {
                    var noOfBids =
                        ObjectRepo.Driver.FindElements(
                            By.XPath("//li[@select=\'tabSelected(bid)\']/a//div[contains(text(),\'Bid\')]"));

                    if (noOfBids.Count > 0)
                    {
                        for (int iBid = 1; iBid <= noOfBids.Count; iBid++)
                        {
                            Thread.Sleep(10000);
                            ObjectRepo.Driver
                                .FindElement(By.XPath("//li[@select=\'tabSelected(bid)\'][" + iBid +
                                                      "]/a//div[contains(text(),\'Bid\')]")).Click();
                            //var projStatus = ObjectRepo.Driver
                            //    .FindElement(By.XPath("//li[@select=\'tabSelected(bid)\'][" + iBid + "]/a//span")).Text;

                            // Project Status = Lead
                            //if (projStatus.Equals("Lead"))
                            //{
                            //    Thread.Sleep(5000);
                                
                            //    var noOfMods = ObjectRepo.Driver.FindElements(
                            //        By.XPath(
                            //            "//div[@ng-click=\'checkAndCollapseProjectDetails(building.isOpen)\']//a"));

                            //    bool moDisplayedAndVisible = UiActions.IsElementDisplayedAndVisible(By.XPath(
                            //        "//div[@ng-click=\'checkAndCollapseProjectDetails(building.isOpen)\']//a"), null);
                            //    if (moDisplayedAndVisible)
                            //    {
                            //        for (int iModIndex = 1; iModIndex <= noOfMods.Count; iModIndex++)
                            //        {
                            //            By modElement =
                            //                By.XPath(
                            //                    "//div[@ng-click=\'checkAndCollapseProjectDetails(building.isOpen)\'][" +
                            //                    iModIndex + "]//a");
                            //            executionStatus = projNavigation.ProjBuildingFlow(modElement);
                            //            if (executionStatus != "Passed")
                            //            {
                            //                _result = executionStatus;
                            //            }
                            //        }

                            //        executionStatus = projNavigation.ProjDoorsFlow();
                            //        if (executionStatus != "Passed")
                            //        {
                            //            _result = executionStatus;
                            //        }
                            //    }
                            //     //Project Status = Quote or Sales Order
                            //    else if (projStatus.Equals("Quote") || projStatus.Equals("Sales Order"))
                            //    {
                            //        Thread.Sleep(5000);
                            //    }
                                
                            //}
                            executionStatus = projNavigation.ViewReports();
                            if (executionStatus != "Passed")
                            {
                                _result = executionStatus;
                            }
                            getExcelData.ResultOfProjectId(rowId++, executionStatus, _result, projectId, "Bid[" + iBid +"]");
                        }
                        
                    } 
                }
                else
                {
                    executionStatus = "Passed";
                    _result = emptyBidString;
                    getExcelData.ResultOfProjectId(rowId++, executionStatus, _result, projectId, "No Bid");
                }
                
            }

            ObjectRepo.Driver.Quit();

                //for (int rowId = 1; rowId < pro.Length; rowId++)
                //{
                //    getExcelData.ResultOfProjectId(rowId, "Pass", "Failedexception", pro[rowId]);
                //}
            }
        }
    }