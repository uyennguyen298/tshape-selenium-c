using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tshape_selenium_c.DataObjects
{
    class MyProfilePage
    {
        private By searchTextbox = By.Id("searchBox");
        private By deleteButton = By.XPath("//span[@title='Delete']");
        private By okButtonInDeleteBookPopup = By.Id("closeSmallModal-ok");
        private By bookItemsAfterSearch = By.XPath("//div[@class='action-buttons']//a");


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
        protected IWebElement getDeleteButton()
        {
            return Constant.Constant.WEBDRIVER.FindElement(deleteButton);
        }

        public void clickToDeleteButton()
        {
            this.getDeleteButton().Click();
        }

        protected IWebElement getOkButtonInDeletePopup()
        {
            return Constant.Constant.WEBDRIVER.FindElement(okButtonInDeleteBookPopup);
        }

        public void clickToOkbuttonInDeletePopup()
        {
            this.getOkButtonInDeletePopup().Click();
        }
    }
}
