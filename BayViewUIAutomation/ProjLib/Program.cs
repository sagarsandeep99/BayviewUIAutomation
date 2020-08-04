using BayViewUIAutomation.CommonLibs;
using BayViewUIAutomation.GlobalParam;

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
            getExcelData.DeleteFile();

            //Login to application
            xq2.LoginToApplication();

            //Building & Doors flow
            foreach (string projectId in pro)
            {
                projNavigation.ProjBuildingFlow(projectId);
                projNavigation.ProjDoorsFlow();
                projNavigation.ViewReports();
            }

            ObjectRepo.Driver.Quit();

            for (int rowId = 0; rowId < pro.Length; rowId++)
            {
                getExcelData.ResultOfProjectId(rowId+1, "Pass", pro[rowId]);
            }
        }
    }
}
