using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tshape_selenium_c.DataObjects;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace tshape_selenium_c.TestCases
{
    class Search_Book_With_Multiple_Results
    {
        [SetUp]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Constant.Constant.WEBDRIVER = new ChromeDriver();
            Constant.Constant.WEBDRIVER.Manage().Window.Maximize();
            Constant.Constant.WEBDRIVER.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Constant.Constant.WEBDRIVER.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [TearDown]
        public void TearDown()
        {
            Constant.Constant.WEBDRIVER.Quit();
        }

        public void SC02_Search_Book_With_Mutiple_Results()
        {
            HomePage homePage = new HomePage();
            homePage.open();
            homePage.sendKeysToSearchTextbox(TestData.TestData.SEARCH_BOOK_ITEM_LOWER_CASE);
            Assert.AreEqual(true, homePage.verifyBookItemAfterSearch(TestData.TestData.SEARCH_BOOK_ITEM_LOWER_CASE));

            homePage.sendKeysToSearchTextbox(TestData.TestData.SEARCH_BOOK_ITEM_UPPER_CASE_FIRST_CHAR);
            Assert.AreEqual(true, homePage.verifyBookItemAfterSearch(TestData.TestData.SEARCH_BOOK_ITEM_UPPER_CASE_FIRST_CHAR));
        }
    }
}
