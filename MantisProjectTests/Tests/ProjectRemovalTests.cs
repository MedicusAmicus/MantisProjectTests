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

            if (app.Projects.GetProjectsList().Count == 0)
            {
                ProjectData project = new ProjectData(GenerateRandomString(10));
                app.Projects.Create(project);
            }
            
            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            app.Projects.Remove(oldProjects[0]);

            List<ProjectData> newProjects = app.Projects.GetProjectsList();

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

