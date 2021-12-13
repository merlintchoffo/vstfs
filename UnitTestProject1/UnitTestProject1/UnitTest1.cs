using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using SeleniumExtras.WaitHelpers;

namespace UnitTestProject1
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }

    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(option);
            //IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl("https://www.google.lk/");
            WebDriverExtensions.FindElement(driver, By.XPath("//*[@id='L2AGLb']/div"), 10).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Name("q")));
            WebDriverExtensions.FindElement(driver, By.Name("q"), 10).SendKeys("UFT");
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("input[value='Recherche Google']")));
            //IWebElement searchButton = driver.FindElement(By.Name("btnK"));
            IWebElement searchButton = WebDriverExtensions.FindElement(driver, By.Name("btnK"), 30);
            //IWebElement searchButton = driver.FindElement(By.CssSelector("input[value='Recherche Google']"));
            searchButton.Click();
            Assert.AreEqual(true, wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("UFT - Recherche Google")));
            driver.Dispose();
        }

        [TestMethod]
        public void TestMethod11()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(option);
            //IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl("https://www.google.lk/");
            //Thread.Sleep(2000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("q")));
            IWebElement textField = driver.FindElement(By.Name("q"));
            //IWebElement textField = driver.FindElement(By.Id("lst-ib"));
            textField.SendKeys("UFT");
            //Thread.Sleep(2000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[value='Recherche Google']")));
            IWebElement searchButton = driver.FindElement(By.Name("btnK"));
            //IWebElement searchButton = driver.FindElement(By.CssSelector("input[value='Recherche Google']"));
            searchButton.Click();
            Assert.AreEqual(true, wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("UFT - Recherche Google")));
            driver.Dispose();
        }

        [TestMethod]
        public void TestMethodPass()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(option);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl("https://www.google.lk/");
            Thread.Sleep(2000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("q")));
            IWebElement textField = driver.FindElement(By.Name("q"));
            textField.SendKeys("Selenium");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[value='Google Search']")));
            IWebElement searchButton = driver.FindElement(By.Name("btnK"));
            //IWebElement searchButton = driver.FindElement(By.CssSelector("input[value='Google Search']"));
            searchButton.Click();
            Assert.AreEqual(true, wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("Selenium - Google Search")));
            driver.Dispose();
        }

        [TestMethod]
        public void TestMethodfail()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(option);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl("https://www.google.lk/");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("q")));
            IWebElement textField = driver.FindElement(By.Name("q"));
            textField.SendKeys("Selenium");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[value='Google Search']")));
            IWebElement searchButton = driver.FindElement(By.CssSelector("input[value='Google Search1']"));
            searchButton.Click();
            Assert.AreEqual(true, wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("Selenium - Google Search")));
            driver.Dispose();
        }

        [TestMethod]
        public void TestMethodFail2()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(option);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl("https://www.google.lk/");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("q")));
            IWebElement textField = driver.FindElement(By.Name("q"));
            textField.SendKeys("Selenium");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[value='Google Search']")));
            IWebElement searchButton = driver.FindElement(By.CssSelector("input[value='Google Search1']"));
            searchButton.Click();
            Assert.AreEqual(true, wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("Selenium - Google Search")));
            driver.Dispose();
        }
    }
}
