using BausparenAutomation.pageObjects;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace BausparenAutomation.utilities
{
    
    public class Base
    {
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();

            driver.Url = ConfigurationManager.AppSettings["url"];
        }

        public void InitBrowser(string browserName)
        {
            switch(browserName) 
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public static JsonReader GetDataParser()
        {
            return new JsonReader();
        }

        public Actions GetActions() 
        {
            Actions actions = new Actions(driver);
            return actions;
        }

        public BausparenPage LoadBausparenPage()
        {
            BausparenPage bausparenPage = new BausparenPage(GetDriver());
            bausparenPage.WaitForPageToDisplay();
            bausparenPage.AcceptCookies();

            return bausparenPage;
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}
