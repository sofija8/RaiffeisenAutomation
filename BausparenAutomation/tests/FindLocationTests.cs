using BausparenAutomation.pageObjects;
using BausparenAutomation.utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BausparenAutomation.tests
{
    public class FindLocationTests : Base
    {
        String location = GetDataParser().extractData("location");
        String unsupportedLocation = GetDataParser().extractData("unsupportedLocation");

        [Test]
        public void FindBankLocationAndOpenDetails()
        {
            BausparenPage bausparenPage = LoadBausparenPage();
            GetActions().ScrollToElement(bausparenPage.GetFooter()).Perform();

            bausparenPage.typeAndSearchLocation(location);
            bausparenPage.GetLocationResultItem().Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bausparenPage.GetLocationItemDetailsLocator()));

            String bankName = bausparenPage.GetLocationResultDetailHeader();

            BankVillachPage bankVillachPage = bausparenPage.GoToVillachBankPage();
            bankVillachPage.WaitForPageToDisplay();

            Assert.That(bankVillachPage.GetBankVillahHeader().ToLower(), Is.EqualTo(bankName.ToLower()));
        }

        [Test]
        public void PassUnsupportedLocation()
        {
            BausparenPage bausparenPage = LoadBausparenPage();
            GetActions().ScrollToElement(bausparenPage.GetFooter()).Perform();

            bausparenPage.GetLocationSearchField().Clear();
            bausparenPage.GetLocationSearchField().SendKeys(unsupportedLocation);

            Assert.IsTrue(bausparenPage.GetLocationSearchErrorMessage().Displayed);
            Assert.That(bausparenPage.GetLocationSearchErrorMessage().Text, Is.EqualTo(String.Format(@"Ihre Suche nach “{0}” ergab leider keine Ergebnisse. Sie können nach Bundesländern, Städten, Postleitzahlen, Straßennamen und Filialen suchen.", unsupportedLocation)));
        }
    }
}
