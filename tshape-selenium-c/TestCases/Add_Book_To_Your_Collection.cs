using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
    class Add_Book_To_Your_Collection
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
        public void TC01_Add_Book_Store_To_Your_Collection()
        {
            HomePage homePage = new HomePage();
            homePage.open();
            homePage.goToLoginPage();

            LoginPage loginPage = new LoginPage();
            loginPage.login(Constant.Constant.USERNAME, Constant.Constant.PASSWORD);

            homePage.goToCartPage();
            CartPage cartPage = new CartPage();
            cartPage.clickToAddToYourCollectionButton();
            System.Threading.Thread.Sleep(6000);
            //WebDriverWait wait = new WebDriverWait(Constant.Constant.WEBDRIVER, TimeSpan.FromSeconds(10));
            IAlert alert = Constant.Constant.WEBDRIVER.SwitchTo().Alert();
            String alertText = alert.Text;
            Console.WriteLine("Alert text is " + alertText);
            //alert.Accept();

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor) Constant.Constant.WEBDRIVER;

            jsExecutor.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
            
            cartPage.clickToBookStoreApplicationItem("Profile");
            Assert.AreEqual("Git Pocket Guide", Constant.Constant.WEBDRIVER.FindElement(By.Id("see-book-Git Pocket Guide")).Text);
        }

    }
}
