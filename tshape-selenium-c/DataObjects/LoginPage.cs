using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tshape_selenium_c.DataObjects
{
    class LoginPage : GeneralPage
    {
        private By usernameTextBox = By.Id("userName");
        private By passwordTextBox = By.Id("password");

        protected IWebElement getUsernameTextBox()
        {
            return Constant.Constant.WEBDRIVER.FindElement(usernameTextBox);
        }

        protected IWebElement getPasswordTextBox()
        {
            return Constant.Constant.WEBDRIVER.FindElement(passwordTextBox);
        }

        public void login(String username, String password)
        {
            this.getUsernameTextBox().SendKeys(username);
            this.getPasswordTextBox().SendKeys(password);
            this.getLoginButton().Click();
        }
    }
}
