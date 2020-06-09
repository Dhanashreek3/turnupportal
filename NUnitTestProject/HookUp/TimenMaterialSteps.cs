using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TurnUpPortal.HookUp
{
    [Binding]
    public class TimenMaterialSteps
    {
        IWebDriver driver;
        [Given(@"I have logged in to the turnup portal successfully")]
        public void GivenIHaveLoggedInToTheTurnupPortalSuccessfully()
        {
            driver = new ChromeDriver();

            //Creating instance of Login Page
            var loginPage = new Login(driver);
            loginPage.LoginSuccess();
        }
        
        [Given(@"I navigate to time and material page")]
        public void GivenINavigateToTimeAndMaterialPage()
        {
            var homePage = new Home(driver);
            homePage.ClickAdministration();
            homePage.ClickTimenMaterial();
        }
        
        [When(@"I create a time and material record")]
        public void WhenICreateATimeAndMaterialRecord()
        {
            Record turnupOptions = new Record(driver);
            turnupOptions.ClickCreateNew();
            turnupOptions.CreateNewRecord("qwerty", "qwerty");
                     
        }
        
        [When(@"I edit a time and material record in the page")]
        public void WhenIEditATimeAndMaterialRecordInThePage()
        {
            Record turnupOptions = new Record(driver);
            turnupOptions.EditRecord();
        }
        
        [When(@"I delete an existing time and material from the page")]
        public void WhenIDeleteAnExistingTimeAndMaterialFromThePage()
        {
            Record turnupOptions = new Record(driver);
            turnupOptions.DeleteRecord();
        }
        
        [When(@"I create time and material records for below (.*) and (.*)")]
        public void WhenICreateTimeAndMaterialRecordsForBelowAnd(string p0, string p1)
        {
            Record turnupOptions = new Record(driver);
            turnupOptions.ClickCreateNew();
            turnupOptions.CreateNewRecord(p0, p1);
            

        }
        
        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {

            Record turnupOptions = new Record(driver); 
            turnupOptions.ValidateRecord();
            driver.Quit();
        }
        
        [Then(@"the record should be edited successsfully")]
        public void ThenTheRecordShouldBeEditedSuccesssfully()
        {

            Record turnupOptions = new Record(driver);
            turnupOptions.ValidateEditRecord();
            driver.Quit();
        }
        
        [Then(@"The record should be deleted successsfully")]
        public void ThenTheRecordShouldBeDeletedSuccesssfully()
        {
            driver.Quit();
        }
        
        [Then(@"The records should be created with below values (.*) and (.*) successfully")]
        public void ThenTheRecordsShouldBeCreatedWithBelowValuesAndSuccessfully(string p0, string p1)
        {
            Record turnupOptions = new Record(driver);
           // turnupOptions.ClickCreateNew();
            turnupOptions.ValidateNewRecord(p0,p1);
            driver.Quit();
        }
    }
}
