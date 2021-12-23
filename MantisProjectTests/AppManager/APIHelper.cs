using MantisProjectTests.Mantis;
using System;
using System.Collections.Generic;

namespace MantisProjectTests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager){}

        public List<ProjectData> GetProjectsList(AccountData account)
        {
            List<ProjectData> ProjectList = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new  MantisConnectPortTypeClient("MantisConnectPort", "http://localhost/mantisbt-1.3.20/api/soap/mantisconnect.php?wsdl");

            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Pass);
            foreach (Mantis.ProjectData project in projects)
            {
                ProjectData projectName = new ProjectData(project.name);
                ProjectList.Add(projectName);
            }   
            return ProjectList;
        }

        public void CreateProject (AccountData account, ProjectData Project)
        {
            Mantis.MantisConnectPortTypeClient client = new
                MantisConnectPortTypeClient("MantisConnectPort", "http://localhost/mantisbt-1.3.20/api/soap/mantisconnect.php?wsdl");
            Mantis.ProjectData ProjectToAdd = new Mantis.ProjectData()
            {
                name = Project.Name
            };
            client.mc_project_add(account.Name, account.Pass, ProjectToAdd);
        }
    }
}
 