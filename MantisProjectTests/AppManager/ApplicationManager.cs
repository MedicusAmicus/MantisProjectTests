using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MantisProjectTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;       

        public string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected ProjectHelper projects;
        public APIHelper API { get;  set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/mantisbt-1.3.20/";
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            projects = new ProjectHelper(this);
            API = new APIHelper(this);
        }
        

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;                
            }
            return app.Value;
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }
        public ProjectHelper Projects
        {
            get
            {
                return projects;
            }
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}
