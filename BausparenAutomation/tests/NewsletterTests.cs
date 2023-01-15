using BausparenAutomation.pageObjects;
using BausparenAutomation.utilities;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BausparenAutomation.tests
{
    public class NewsletterTests : Base
    {
        String email = GetDataParser().extractData("email");
        String subscriptionSuccessMessage = GetDataParser().extractData("subscriptionSuccessMessage");
        String invalidEmail = GetDataParser().extractData("invalidEmail");
        String subscriptionErrorMessage = GetDataParser().extractData("subscriptionErrorMessage");

        [Test]
        public void SubscribeToNewsletter() 
        {
            BausparenPage bausparenPage = LoadBausparenPage();
            GetActions().MoveToElement(bausparenPage.GetEmail()).Perform();

            bausparenPage.GetEmail().SendKeys(email);
            bausparenPage.GetAbsendenBtn().Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bausparenPage.GetSubscriptionCheckMarkLocator()));
            
            Assert.IsTrue(driver.FindElement(bausparenPage.GetSubscriptionCheckMarkLocator()).Displayed);
            Assert.IsTrue(bausparenPage.GetSubscriptionSuccessMessage().Contains(subscriptionSuccessMessage));
        }

        [Test]
        public void ShowErrorMessageForInvalidEmail()
        {
            BausparenPage bausparenPage = LoadBausparenPage();
            GetActions().MoveToElement(bausparenPage.GetEmail()).Perform();

            bausparenPage.GetEmail().SendKeys(invalidEmail);
            bausparenPage.GetAbsendenBtn().Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bausparenPage.GetSubscriptionFormValidationLocator()));

            Assert.IsTrue(bausparenPage.GetSubscriptionErrorMessage().Contains(subscriptionErrorMessage));
        }
    }
}
