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
    public class CreateNewProductSteps
    {
        public static IWebDriver driver;

        [Given(@"I open products list page")]
        public void GivenIOpenProductsListPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Login");
            LogInPage loginPage = new LogInPage(driver);
            MainPage mainPage = loginPage.logIn("user", "user");
        }
        
        [When(@"I create new product with param ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void WhenICreateNewProductWithParam(string Name, string Category, string Supplier, string UnitPrice, string Quantity, string UnitsInStock, string UnitsOnOrder, bool Discontinued)
        {
            ProductObj product = new ProductObj(Name, Category, Supplier, UnitPrice, Quantity, UnitsInStock, UnitsOnOrder, Discontinued);

            ProductBL productPage = new ProductBL(driver);
            productPage.createNewProduct(product);
        }
        
        [Then(@"the list of products should contained ""(.*)"" position")]
        public void ThenTheListOfProductsShouldContainedPosition(string Name)
        {
            Assert.AreEqual(driver.Url, "http://localhost:5000/Product");
            Assert.IsTrue(driver.FindElements(By.LinkText(Name)).Count != 0);
            driver.Close();
        }
    }
}
