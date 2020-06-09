using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TurnUpPortal

{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEachTest()
        {
             driver = new ChromeDriver();

            //Creating instance of Login Page
            var loginPage = new Login(driver);
            loginPage.LoginSuccess();

            
        }

        [Test]
        [TestCaseSource(typeof(TestDataClass), "TestCases")]
        public void CreatenValidate(string code, string description)
            {
            //Creating instance of Administration and Time & Material
                         
                var homePage = new Home(driver);
                homePage.ClickAdministration();
                homePage.ClickTimenMaterial();


                Record turnupOptions = new Record(driver);
                turnupOptions.ClickCreateNew();
                turnupOptions.CreateNewRecord(code,description);
                //turnupOptions.ValidateRecord();
                turnupOptions.ValidateNewRecord(code, description);

        }

        [Test]
        public void EditnValidate()
        {
            //Creating instance of Administration and Time & Material
            var homePage = new Home(driver);
            homePage.ClickAdministration();
            homePage.ClickTimenMaterial();


            Record turnupOptions = new Record(driver);
            turnupOptions.EditRecord();
            turnupOptions.ValidateEditRecord();
        }

        [Test]
        public void DeletenValidate()
        {
            //Creating instance of Administration and Time & Material
            var homePage = new Home(driver);
            homePage.ClickAdministration();
            homePage.ClickTimenMaterial();


            Record turnupOptions = new Record(driver);
            turnupOptions.DeleteRecord();

         }
         
        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }

    }
    }