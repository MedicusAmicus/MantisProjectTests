using System.Collections.Generic;
using NUnit.Framework;

namespace MantisProjectTests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemoveTest()
        {
            AccountData account = new AccountData("administrator", "root");

            if (app.API.GetProjectsList(account).Count == 0)
            {
                app.API.CreateProject(account, new ProjectData(GenerateRandomString(10)));
            }
            
            List<ProjectData> oldProjects = app.API.GetProjectsList(account);

            app.Projects.Remove(oldProjects[0]);

            List<ProjectData> newProjects = app.API.GetProjectsList(account);

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

