using System;
using OpenQA.Selenium;
using NUnit.Framework;

namespace TurnUpPortal
{
    internal class Home
    {
        private IWebDriver driver;

        IWebElement Administration => driver.FindElement(By.ClassName("dropdown-toggle"));
        IWebElement Timematerial => driver.FindElement(By.XPath("//a[@href = '/TimeMaterial']"));

        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void ClickAdministration()
        {
            //Identify and Click on Administration
           Administration.Click();
        }

        internal void ClickTimenMaterial()
        {
            //Identify and Click on Time & Material
            Timematerial.Click();
        }
    }
}