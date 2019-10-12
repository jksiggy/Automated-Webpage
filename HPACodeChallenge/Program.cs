
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HPACodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {



            //Create the ref. of the browser
            IWebDriver driver = new ChromeDriver(@"C:\Users\jksig\Downloads\chromedriver_win32");


            //Navigate to URL//
            driver.Navigate().GoToUrl("http://hpadevtest.azurewebsites.net/");

            //By Name of the Element and operation step 1//
            IWebElement button = driver.FindElement(By.Id("Box1"));
            button.Click();

            //Approval for Alert for step1//
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            //By Name of the Element and operation step 2//
            IWebElement box2 = driver.FindElement(By.Id("Box3"));
            box2.Click();
            box2.SendKeys(Keys.Tab);

            //Approval for Alert step2//
            IAlert alert2 = driver.SwitchTo().Alert();
            alert2.Accept();


            //find the span Id//
            IWebElement elem = driver.FindElement(By.XPath("//span[@id='optionVal']"));

            //Extract the TextContent From SpanTag and put it in a Var//
            string myText = (string)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].firstChild.textContent;", elem);

            //Target the Var as Value//
            IWebElement oCheckBox = driver.FindElement(By.CssSelector($"input[value='{myText}']"));
            oCheckBox.Click();

            //Approval for Alert step3//
            IAlert alert3 = driver.SwitchTo().Alert();
            alert3.Accept();


            IWebElement rob = driver.FindElement(By.XPath("//span[@id='selectionVal']"));

            //Extract the TextContent From SpanTag and put it in a Var//
            string myDrop = (string)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].firstChild.textContent;", rob);

            //Narrow it downt to drop down element and click ops//
            IWebElement dropDown = driver.FindElement(By.XPath($"//div[@id='Box4']/p[1]/select[1]"));
            dropDown.Click();

            //choose the right value match the string  and click ops//
            IWebElement dropDown1 = driver.FindElement(By.CssSelector($"option[value='{myDrop}']"));
            dropDown1.Click();

            //Approval for Alert step4//
            IAlert alert4 = driver.SwitchTo().Alert();
            alert4.Accept();


            //Step Five get the value from the placeholder attribute
            List<IWebElement> dateof = driver.FindElements(By.Id("formDate")).ToList();
            foreach (var date in dateof)
            {
                var dateVal = date.GetAttribute("placeholder").ToString();
                date.SendKeys($"{dateVal}");
            }

            List<IWebElement> cityOf = driver.FindElements(By.Id("formCity")).ToList();
            foreach (var city in cityOf)
            {
                var cityIn = city.GetAttribute("placeholder").ToString();
                city.SendKeys($"{cityIn}");
            }

            List<IWebElement> stateOf = driver.FindElements(By.Id("formState")).ToList();
            foreach (var state in stateOf)
            {
                var stateOn = state.GetAttribute("placeholder").ToString();
                state.SendKeys($"{stateOn}");
            }

            List<IWebElement> countryOf = driver.FindElements(By.Id("formCountry")).ToList();
            foreach (var country in countryOf)
            {
                var countryIn = country.GetAttribute("placeholder").ToString();
                country.SendKeys($"{countryIn}");
            }
            ///submit the form//
            var getSubmitButton = driver.FindElement(By.TagName("button"));
            getSubmitButton.Click();

            //Approval for Alert step5//
            IAlert alert5 = driver.SwitchTo().Alert();
            alert5.Accept();

            //step6 get the result id, and get the lind id to insert the result value//
            var resultValue = driver.FindElement(By.Id("formResult")).Text;
            var insertLine = driver.FindElement(By.Id("lineNum")).Text;

            //get the specific line and delete the previous value and inster the result value//
            var rowValue = driver.FindElement(By.XPath($"//*[@id='inputTable']/tbody/tr[{insertLine}]/td[2]/input"));
            rowValue.Clear();
            rowValue.SendKeys($"{resultValue}");
            rowValue.SendKeys(Keys.Enter);

            //Approval for Alert step6//
            IAlert alert6 = driver.SwitchTo().Alert();
            alert6.Accept();

            bool IsAlertShown(IWebDriver drv)
            {
                try
                {
                    drv.SwitchTo().Alert();
                }
                catch (NoAlertPresentException ex)
                {
                    return false;
                }
                return true;
            }

            //List of step number
            List<int> numbers = new List<int>()
            {
                7, 8, 9, 10
            };

            //Run through a foreach for each number that is in the list
            foreach (var number in numbers)
            {
                //Find each element by id ex. Box7, Box8, Box9, Box10
                var steps = driver.FindElements(By.Id($"Box{number}"));

                //Run through another foreach loop to click on each element, await the delay, then accept the alert
                foreach (var step in steps)
                {
                    step.Click();
                    var awaitAlert = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    awaitAlert.Until(drv => IsAlertShown(drv));
                    alert.Accept();




                }
            }
        }

    }
}


