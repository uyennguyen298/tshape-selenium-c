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
    class Delete_Book_Successfully
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

        [Test]
        public void SC03_Delete_Book_Successfully()
        {
            HomePage homePage = new HomePage();
            homePage.open();
            homePage.scrollToElementByJS(homePage.loginButton);

            homePage.goToLoginPage();
            LoginPage loginPage = new LoginPage();
            loginPage.login(Constant.Constant.USERNAME, Constant.Constant.PASSWORD);

            homePage.selectBookItem(Constant.Constant.WEBDRIVER, By.Id("see-book-Learning JavaScript Design Patterns"));
            CartPage cartPage = new CartPage();
            homePage.scrollToBottomPageByJS();
            cartPage.clickToAddToYourCollectionButton();

            homePage.waitForAlertIsVisible();
            IAlert alert = Constant.Constant.WEBDRIVER.SwitchTo().Alert();
            alert.Accept();

            homePage.scrollToBottomPageByJS();
            cartPage.clickToBookStoreApplicationItem("Profile");
            Assert.AreEqual("Learning JavaScript Design Patterns", Constant.Constant.WEBDRIVER.FindElement(By.Id("see-book-Learning JavaScript Design Patterns")).Text);

            MyProfilePage myProfilePage = new MyProfilePage();
            myProfilePage.sendKeysToSearchTextbox(TestData.TestData.SEARCH_BOOK_ITEM_IN_PROFILE_PAGE);
            myProfilePage.clickToDeleteButton();
            myProfilePage.clickToOkbuttonInDeletePopup();

            homePage.waitForAlertIsVisible();
            alert = Constant.Constant.WEBDRIVER.SwitchTo().Alert();
            Assert.AreEqual("Book deleted.", alert.Text);
        }
    }
}
