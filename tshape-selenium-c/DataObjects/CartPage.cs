using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tshape_selenium_c.DataObjects
{
    class CartPage
    {
        private By addToYourCollectionButton = By.XPath("//button[text()='Add To Your Collection']");

        private By bookStoreApplicationItem(string pageItem)
        {
            return By.XPath(string.Format("//div[@class='element-list collapse show']//span[text()='{0}']", pageItem));
        }

        protected IWebElement getAddToYourCollectionButton()
        {
            return Constant.Constant.WEBDRIVER.FindElement(addToYourCollectionButton);
        }

        protected IWebElement getBookStoreApplicationItem(string pageItem)
        {
            return Constant.Constant.WEBDRIVER.FindElement(bookStoreApplicationItem(pageItem));
        }

        public void clickToAddToYourCollectionButton()
        {
            this.getAddToYourCollectionButton().Click();
        }

        public void clickToBookStoreApplicationItem(string pageItem)
        {
            this.getBookStoreApplicationItem(pageItem).Click();
        }


    }
}
