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
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("app-login-card")));
        }

        [FindsBy(How = How.CssSelector, Using = "form>app-login-card")]
        private IWebElement loginForm;
        public IWebElement GetLoginForm()
        {
            return loginForm;
        }
    }
}
