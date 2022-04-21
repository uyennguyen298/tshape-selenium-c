using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tshape_selenium_c.DataObjects
{
    class GeneralPage
    {
        private By usernameLabel = By.Id("userName-value");
        private By loginButton = By.Id("login");

        protected IWebElement getLoginButton()
        {
            return Constant.Constant.WEBDRIVER.FindElement(loginButton);
        }

        protected IWebElement getUsernameLabel()
        {
            return Constant.Constant.WEBDRIVER.FindElement(usernameLabel);
        }

        public void goToLoginPage()
        {
            this.getLoginButton().Click();
        }

        public String getUsernameLabelValue()
        {
            return this.getUsernameLabel().Text;
        }
    }
}
