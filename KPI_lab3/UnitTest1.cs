using NUnit.Framework;
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace KPI_lab3
{
    public class Tests
    {
        private IWebDriver _webDriver;
        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            
        }

        [Test]
        public void TestCase1_Id()
        {
            _webDriver.Navigate().GoToUrl(@"https://djinni.co/signup");
            _webDriver.Manage()
                .Window.Maximize();
            _webDriver.FindElement(By.Id("email")).SendKeys("lookingforajob@gmail.com");
            _webDriver.FindElement(By.Id("password")).SendKeys("BHJBHbs67sfwj");
            _webDriver.FindElement(By.ClassName("radio")).FindElement(By.Name("account_type")).Click();
            //_webDriver.FindElement(By.CssSelector("#main-wrap > main > form > div.one-factor > button")).Click();
            Thread.Sleep(300);
        }
        [Test]
        public void TestCase2_Name()
        {
            _webDriver.Navigate().GoToUrl(@"https://djinni.co/signup");
            _webDriver.Manage()
                .Window.Maximize();
            _webDriver.FindElement(By.Name("email")).SendKeys("hireme");
            _webDriver.FindElement(By.Name("password")).SendKeys("Xhjs57ehebgj");
            //_webDriver.FindElement(By.CssSelector("#main-wrap > main > form > div.one-factor > button")).Click();
            Thread.Sleep(300);
        }
        [Test]
        public void TestCase3_Link()
        {
            _webDriver.Navigate().GoToUrl(@"https://www.spotify.com/us/");
            _webDriver.Manage()
                .Window.Maximize();
            _webDriver.FindElement(By.LinkText("Get 3 months free, click to find out more")).Click();
        }
        [Test]
        public void TestCase4_XPath()
        {
            _webDriver.Navigate().GoToUrl(@"https://lichess.org/");
            _webDriver.Manage()
                .Window.Maximize();
            _webDriver.FindElement(By.XPath("//*[@id=\"main-wrap\"]/main/div[1]/div[2]/a[1]")).Click();
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(
                By.XPath("//*[@id=\"modal-wrap\"]/div/form/div[3]/button[2]")));
            _webDriver.FindElement(By.XPath("//*[@id=\"modal-wrap\"]/div/form/div[3]/button[2]")).Click();
        }
        [Test]
        public void TestCase5_Css()
        {
            _webDriver.Navigate().GoToUrl(@"https://lichess.org/");
            _webDriver.Manage()
                .Window.Maximize();
            _webDriver.FindElement(By.CssSelector("#topnav > section:nth-child(2) > a")).Click();
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(
                By.CssSelector("#main-wrap > main > div.puzzle__tools > div.puzzle__feedback.play > div.view_solution.show > a")));
            _webDriver.FindElement(By.CssSelector("#main-wrap > main > div.puzzle__tools > div.puzzle__feedback.play > div.view_solution.show > a")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Dispose();
        }
    }
}