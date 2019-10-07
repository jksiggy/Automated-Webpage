
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

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

            //By Name of the Element and operation
            IWebElement button = driver.FindElement(By.Id("Box1"));
            button.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            IWebElement box2 = driver.FindElement(By.Id("Box3"));
            box2.Click();
            box2.SendKeys("%{Tab}");



        }
    }
}
