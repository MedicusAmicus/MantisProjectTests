namespace MantisProjectTests
{
   public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToProjectsPage()
        {
            driver.Navigate().GoToUrl(baseURL + "manage_proj_page.php");  
        }
    }
}
