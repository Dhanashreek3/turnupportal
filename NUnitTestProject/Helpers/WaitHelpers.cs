﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TurnUpPortal
{
    public class WaitHelpers
    {
        public static void ForElement(By by, IWebDriver driver, TimeSpan timeSpan)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            wait.Until(ExpectedConditions.ElementExists(by));
        }

    }
}
