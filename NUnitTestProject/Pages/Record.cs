using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;

namespace TurnUpPortal
{
    internal class Record
    {
        private IWebDriver driver;
        
        public Record(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void ClickCreateNew()
        {
            try
            {
                //Identify and Click on Create New button
                IWebElement createNew = driver.FindElement(By.ClassName("btn-primary"));
                createNew.Click();
                Console.WriteLine("Assertion true");
            }
            
            catch (Exception message)
            {
                Console.WriteLine(message.ToString());
                Assert.Fail();
            }
            
        }

       
        internal void CreateNewRecord(string code, string description)
        {
            //Identify and Enter Code
            IWebElement firstfield = driver.FindElement(By.Id("Code"));
            firstfield.SendKeys(code);

            //Identify and enter Description
            driver.FindElement(By.Name("Description")).SendKeys(description);

            //Identify and enter Price
            IWebElement price = driver.FindElement(By.CssSelector("input.k-formatted-value.k-input"));
            price.SendKeys("2000");

            //Identify and click on Save button
            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();

        }

        internal void EditRecord()
        {
            Thread.Sleep(3000);
            //Click on Edit
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[1]")).Click();
            //Identify and Enter Code
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.Clear();
            code.SendKeys("sky");

            //Identify and enter Description
            IWebElement description = driver.FindElement(By.Name("Description"));
            description.Clear();
            description.SendKeys("Testxyz");
            {
                IWebElement price = driver.FindElement(By.CssSelector("input.k-formatted-value.k-input"));
                price.Click();
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string script = "return document.getElementById(\"Price\").value = 2222;";
                js.ExecuteScript(script);
            }
            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();

        }

        internal void DeleteRecord()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();
            IAlert text = driver.SwitchTo().Alert();
            string alertmessage = text.Text;
            Console.WriteLine(alertmessage);
            {
                if (alertmessage.Equals("Are you sure you want to delete this record?"))

                {
                    Console.WriteLine("Correct message");
                }
                else
                {
                    Console.WriteLine("InCorrect message");
                }
            }
            text.Dismiss();
        }

        internal void ValidateRecord()
        {
            Thread.Sleep(3000);

            try
            {
                while (true)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        var CodeColumn = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]"));
                        Console.WriteLine(CodeColumn.Text);
                        if(CodeColumn.Text == "qwerty")
                        {
                            Console.WriteLine("Newly created Record Found");
                            return;
                        }
                        //Assert.That(CodeColumn, Is.EqualTo("qwerty"));
                        //Console.WriteLine("Record Found");
                        //break;
                    }
                    //Go to next page
                    driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[3]/span")).Click();
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Record not Found");
            }

        }

        internal void ValidateNewRecord(string code, string description)
        {
            Thread.Sleep(3000);

            try
            {
                while (true)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        var CodeColumn1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]"));
                        Console.WriteLine(CodeColumn1.Text);
                        if(CodeColumn1.Text == code)
                        {
                            Console.WriteLine("Record Found");
                            return;
                        }
                       // Assert.That(CodeColumn1, Is.EqualTo(code));
                        //Console.WriteLine("Record Found");
                        //break;
                    }
                    //Go to next page
                    driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[3]/span")).Click();
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Record not Found");
            }

        }



        internal void ValidateEditRecord()
        {
            Thread.Sleep(3000);

            try
            {
                while (true)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        var editCheck = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]"));
                        Console.WriteLine(editCheck.Text);

                        if(editCheck.Text == "sky")
                        {
                            Console.WriteLine("Record Found");
                            break;
                        }
                        //Go to next page
                        driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[3]/span")).Click();
                    }
                    
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Record not Found");
            }

        }

        
       
            
    }
}