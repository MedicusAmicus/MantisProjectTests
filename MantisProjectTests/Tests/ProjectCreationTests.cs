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

            List<ProjectData> OldProjects = app.Projects.GetProjectsList();

            app.Projects.Create(project);

            List<ProjectData> NewProjects = app.Projects.GetProjectsList();

            OldProjects.Add(project);
            OldProjects.Sort();
            NewProjects.Sort();
            Assert.AreEqual(OldProjects,NewProjects);
        }
    }
}
