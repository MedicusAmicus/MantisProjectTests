using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MantisProjectTests
{
    public class ProjectHelper:HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) {}

        
            public List<ProjectData> GetProjectsList()
            {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.GoToProjectsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//*[contains(@href,'manage_proj_edit_page.php?project_id=')]"));            
            foreach(IWebElement element in elements)
            {
                ProjectData project = new ProjectData(element.Text);
                projects.Add(project);
            }
            return projects;
            }

        public void Remove(ProjectData project)
        {
            manager.Navigator.GoToProjectsPage();
            SelectProject(project);
            RemoveProject();
        }

        private void RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }


        private void SelectProject(ProjectData project)
        {
            driver.FindElement(By.LinkText(project.Name) ).Click();
        }

        public void Create(ProjectData project)
        {
            manager.Navigator.GoToProjectsPage();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            WebDriverWait.ReferenceEquals(driver.Url, manager.baseURL + "manage_proj_page.php");
        }



        private void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
        }

        private void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-white btn-round']")).Click();
        }
        
    }
    }
