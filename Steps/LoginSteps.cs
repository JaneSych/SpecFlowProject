using System;
using TechTalk.SpecFlow.NUnit;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject
{
    [Binding]
    public class LogInSteps
    {
        public static IWebDriver driver;

        [Given(@"I open ""(.*)"" url")]
        public void GivenIOpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [When(@"I enters login=""(.*)"", password=""(.*)""")]
        public void WhenIEntersLoginPassword(string login, string password)
        {
            LogInPage loginPage = new LogInPage(driver);
            MainPage mainPage = loginPage.logIn(login, password);
        }

        [Then(@"the current page should be ""(.*)""")]
        public void ThenTheCurrentPageShouldBe(string currentPage)
        {
            Assert.AreEqual(driver.FindElement(By.TagName("h2")).Text, currentPage);
            driver.Close();
        }

    }
}