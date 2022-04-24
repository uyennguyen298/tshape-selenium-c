using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
        public By loginButton = By.Id("login");
        //private By bookItemToAdd = By.Id("see-book-Git Pocket Guide");
        //private By bookItemToDelete = By.Id("see-book-Learning JavaScript Design Patterns");
        private By searchTextbox = By.Id("searchBox");
        private By bookItemsAfterSearch = By.XPath("//div[@class='action-buttons']//a");

        public void waitForAlertIsVisible()
        {
            WebDriverWait wait = new WebDriverWait(Constant.Constant.WEBDRIVER, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

        protected IWebElement getLoginButton()
        {
            return Constant.Constant.WEBDRIVER.FindElement(loginButton);
        }

        public IWebElement getBookItem(IWebDriver driver, By element)
        {
            return driver.FindElement(element);
        }

        protected IWebElement getUsernameLabel()
        {
            return Constant.Constant.WEBDRIVER.FindElement(usernameLabel);
        }

        protected IWebElement getSearchTextbox()
        {
            return Constant.Constant.WEBDRIVER.FindElement(searchTextbox);
        }

        public void sendKeysToSearchTextbox(string searchValue)
        {
            IWebElement element = getSearchTextbox();
            element.Clear();
            element.SendKeys(searchValue);

        }

        public void goToLoginPage()
        {
            this.getLoginButton().Click();
        }

        public void selectBookItem(IWebDriver driver, By element)
        {
            getBookItem(driver, element).Click();
        }

        public String getUsernameLabelValue()
        {
            return this.getUsernameLabel().Text;
        }

        public bool verifyBookItemAfterSearch(string expected)
        {
            bool result = true;
            IReadOnlyCollection<IWebElement> listBooks = Constant.Constant.WEBDRIVER.FindElements(bookItemsAfterSearch);
            foreach (IWebElement element in listBooks)
            {
                return result &= element.Text.ToLower().Contains(expected.ToLower());
            }
            return false;
        }

        public void scrollToBottomPageByJS()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Constant.Constant.WEBDRIVER;
            jsExecutor.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
        }

        public void scrollToElementByJS(By element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor) Constant.Constant.WEBDRIVER;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", Constant.Constant.WEBDRIVER.FindElement(element));
        }

    }
}
