﻿using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using BayViewUIAutomation.ActionClasses;
using BayViewUIAutomation.CommonLibs;
using BayViewUIAutomation.GlobalParam;
using OpenQA.Selenium;

namespace BayViewUIAutomation.ProjLib
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch

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

            //var rowId = 1;
            //Building & Doors flow
            for (int projectIndex = 0; projectIndex < pro.Length-1; projectIndex++)
            {
                var emptyBid = "";
                var _result = "";
                int iBid = 0;
                var executionStatus = "";
                var xqOneProjectId = "";
                var projectId = pro[projectIndex];
                try
                {

                    Thread.Sleep(3000);
                    ObjectRepo.Driver.Url = "http://xq-perf.azurewebsites.net/" + "#!/project/" + projectId;
                    Thread.Sleep(10000);

                    //Get XQ1 Project number
                    //var migratedProjectText = ObjectRepo.Driver
                    //    .FindElement(By.XPath("//div[@ng-if=\'project.dataMigrationLogId\']")).Text;
                    //var firstMigratedProjectText = migratedProjectText.Split('#');
                    //var secondMigratedProjectText = firstMigratedProjectText[1].Split(',');
                    //xqOneProjectId = secondMigratedProjectText[0].Trim();

                    //Check Bid is present or not
                    By byNoBid = By.XPath("//div[@ng-if=\'pcBids.length == 0 && !addingBid\']");
                    bool elementDisplayedAndVisible = UiActions.IsElementDisplayedAndVisible(byNoBid, null);
                    if (elementDisplayedAndVisible)
                    {
                        Thread.Sleep(3000);
                        emptyBid = ObjectRepo.Driver.FindElement(byNoBid).Text.Trim();
                    }

                    var emptyBidString =
                        ("              There are no current bids for selected customer.        ").Trim();
                    if (emptyBid != emptyBidString)
                    {
                        var noOfBids =
                            ObjectRepo.Driver.FindElements(
                                By.XPath("//li[@select=\'tabSelected(bid)\']/a//div[contains(text(),\'Bid\')]"));

                        if (noOfBids.Count > 0)
                        {
                            for (iBid = 1; iBid <= noOfBids.Count; iBid++)
                            {
                                Thread.Sleep(7000);
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

                                //getExcelData.ResultOfProjectId(executionStatus, _result, projectId, xqOneProjectId,
                                 //   "Bid[" + iBid + "]");
                                getExcelData.ResultOfProjectId(executionStatus, _result, projectId,
                                    "Bid[" + iBid + "]");
                            }

                        }
                    }
                    else
                    {
                        executionStatus = "Passed";
                        _result = emptyBidString;
                        //getExcelData.ResultOfProjectId(executionStatus, _result, projectId, xqOneProjectId, "No Bid");
                        getExcelData.ResultOfProjectId(executionStatus, _result, projectId, "No Bid");
                    }
                }
                catch (Exception e)
                {
                    //getExcelData.ResultOfProjectId("Project Loading Failed", _result, projectId, xqOneProjectId,
                     //   "Bid[" + iBid + "]");
                    getExcelData.ResultOfProjectId("Project Loading Failed", _result, projectId,
                        "Bid[" + iBid + "]");
                }
            }      

    ObjectRepo.Driver.Quit();
            Thread.Sleep(5000);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //getExcelData.ResultOfProjectId("", "", stopwatch.Elapsed.TotalMinutes.ToString(),"", "Total Execution Time in minutes");
            getExcelData.ResultOfProjectId("", "", stopwatch.Elapsed.TotalMinutes.ToString(), "Total Execution Time in minutes");

            //for (int rowId = 1; rowId < pro.Length; rowId++)
            //{
            //    getExcelData.ResultOfProjectId(rowId, "Pass", "Failedexception", pro[rowId]);
            //}
        }
    }
}