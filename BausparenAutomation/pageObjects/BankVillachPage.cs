using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BausparenAutomation.pageObjects
{
    public class BankVillachPage
    {
        IWebDriver driver;

        public BankVillachPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("h1")));
        }

        [FindsBy(How = How.TagName, Using = "h1")]
        private IWebElement bankVillahHeader;
        public String GetBankVillahHeader()
        {
            return bankVillahHeader.Text;
        }
    }
}
