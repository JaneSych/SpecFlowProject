﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace SpecFlowProject
{ 
    class ProductBL : AbstractPage
    {
        public ProductBL (IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool isElementPresent(By locator)
        {
            Thread.Sleep(100);
            return driver.FindElements(locator).Count != 0;
        }

        public void createNewProduct(ProductObj product)
        {
            MainPage mainPage = new MainPage(driver);
            ProductsListPage productsListPage = mainPage.goToProductsListPage();
            ProductPage createProductPage = productsListPage.createNewProduct();

            createProductPage.createProduct(product.productName, product.productCategory, product.productSupplier, product.productPrice, 
                product.productQuantity, product.productInStock, product.productOnOrder,  product.productDiscontinued);
        }

        public bool productCheck(ProductObj product)
        {
            MainPage mainPage = new MainPage(driver);
            ProductsListPage productsListPage = mainPage.goToProductsListPage();

            Assert.IsTrue(isElementPresent(By.LinkText(product.productName)));

            ProductPage productPage = productsListPage.goToProductPage(product.productName);

            return ((product.productName == productPage.getProductName())
            || (product.productCategory == productPage.getProductCategory())
            || (product.productSupplier == productPage.getProductSupplier())
            || (product.productPrice == productPage.getProductPrice())
            || (product.productQuantity == productPage.getProductQuantity())
            || (product.productInStock == productPage.getProductInStock())
            || (product.productOnOrder == productPage.getProductOnOrder())
            || (product.productDiscontinued == productPage.getProductDiscontinuedState()));
        }

        public void deleteProduct(string Name)
        {
            MainPage mainPage = new MainPage(driver);
            ProductsListPage productsListPage = mainPage.goToProductsListPage();

            Assert.IsTrue(isElementPresent(By.LinkText(Name)));
            productsListPage.deleteProduct(Name);
        }

    }
}
