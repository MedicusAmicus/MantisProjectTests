using System.Collections.Generic;
using NUnit.Framework;

namespace MantisProjectTests
{
    [TestFixture]
    public class ProjectCreationTests:AuthTestBase
    {
        [Test]
        public void ProjectCreateTest()
        {
            ProjectData project = new ProjectData(GenerateRandomString(10));
            AccountData account = new AccountData("administrator", "root");

            List<ProjectData> OldProjects = app.API.GetProjectsList(account);

            app.Projects.Create(project);

            List<ProjectData> NewProjects = app.API.GetProjectsList(account);

            OldProjects.Add(project);
            OldProjects.Sort();
            NewProjects.Sort();
            Assert.AreEqual(OldProjects,NewProjects);
        }
    }
}
