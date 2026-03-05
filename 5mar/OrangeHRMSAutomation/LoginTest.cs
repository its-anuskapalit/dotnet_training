using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace OrangeHRMSAutomation
{
    public class LoginTest
    {
        IWebDriver? driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [Test]
        public void LoginToOrangeHRMS()
        {
            WebDriverWait wait = new WebDriverWait(driver!, TimeSpan.FromSeconds(10));

            wait.Until(d => d.FindElement(By.Name("username"))).SendKeys("Admin");
            driver!.FindElement(By.Name("password")).SendKeys("admin123");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            wait.Until(d => d.Url.Contains("dashboard"));

            Assert.That(driver.Url.Contains("dashboard"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}