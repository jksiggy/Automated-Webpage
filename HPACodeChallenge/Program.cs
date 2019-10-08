
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

            //Approval for Alert step3//
            IAlert alert4 = driver.SwitchTo().Alert();
            alert4.Accept();


            //Form Step5 incomplete only choose the first four beacuse of sharing same id//
            IWebElement forDate = driver.FindElement(By.Id("formDate"));
            forDate.Clear();
            forDate.SendKeys("2017-05-04");

            IWebElement forCity = driver.FindElement(By.Id("formCity"));
            forCity.Clear();
            forCity.SendKeys("Nashville");

            IWebElement forState = driver.FindElement(By.Id("formState"));
            forState.Clear();
            forState.SendKeys("Tennessee");

            IWebElement forCountry = driver.FindElement(By.Id("formCountry"));
            forCountry.Clear();
            forCountry.SendKeys("USA");

            //IWebElement ofDate = driver.FindElement(By.XPath($"//div[@class='FormPlaceholder']/table[@id='FormTable']/input[5]"));

            IWebElement ofDate = driver.FindElement(By.Id("formDate"));
            ofDate.Clear();
            ofDate.SendKeys("2009-08-26");

            IWebElement ofCity = driver.FindElement(By.Id("formCity"));
            ofCity.Clear();
            ofCity.SendKeys("Seattle");

            IWebElement ofState = driver.FindElement(By.Id("formState"));
            ofState.Clear();
            ofState.SendKeys("Washington");

            IWebElement ofCountry = driver.FindElement(By.Id("formCountry"));
            ofCountry.Clear();
            ofCountry.SendKeys("USA");

            IWebElement onDate = driver.FindElement(By.Id("formDate"));
            onDate.Clear();
            onDate.SendKeys("2007-10-10");










        }


    }
}


