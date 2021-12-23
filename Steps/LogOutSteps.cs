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
    public class LogOutSteps
    {
        public static IWebDriver driver;

        [Given(@"I open app as an authorized user")]
        public void GivenIOpenAppAsAnAuthorizedUser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Login");
            LogInPage loginPage = new LogInPage(driver);
            MainPage mainPage = loginPage.logIn("user", "user");
        }
        
        [When(@"I click on ""(.*)"" btn")]
        public void WhenIClickOnBtn(string btn)
        {
            driver.FindElement(By.LinkText(btn)).Click();
        }

        [Then(@"the current page is ""(.*)""")]
        public void ThenTheCurrentPageIs(string currentPage)
        {
            Assert.AreEqual(driver.FindElement(By.TagName("h2")).Text, currentPage);
            driver.Close();
        }
    }
}
