﻿using OpenQA.Selenium;

namespace MantisProjectTests
{
   public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsElementPresent(By.CssSelector("span.user-info")))
            {
                Logout();
            }
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            Type(By.Name("password"), account.Pass);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }   

        public void Logout()
        {
            driver.Navigate().GoToUrl(manager.baseURL + "logout_page.php");
        }
    }
}
