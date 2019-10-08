
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

            IWebElement elem = driver.FindElement(By.XPath("//span[@id='optionVal']"));
            string myText = (string)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].firstChild.textContent;", elem);


            IWebElement oCheckBox = driver.FindElement(By.CssSelector($"input[value='{myText}']"));

            oCheckBox.Click();


            //IWebElement oCheckBox = driver.FindElement(By.CssSelector(input[value = '{myText}']`));



            //IWebElement oCheckBox = driver.FindElement(By.CssSelector("input[value='{myText}']"));

        }


    }
}


