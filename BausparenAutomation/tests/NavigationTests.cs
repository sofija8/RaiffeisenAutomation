using BausparenAutomation.pageObjects;
using BausparenAutomation.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace BausparenAutomation.tests
{
    public class NavigationTests : Base
    {
        String gewinnHeader = GetDataParser().extractData("gewinnHeader");
        String servicesHeader = GetDataParser().extractData("servicesHeader");
        String loginUrl = GetDataParser().extractData("loginUrl");
        String mixZinsHeader = GetDataParser().extractData("mixZinsHeader");
        String kontaktHeader = GetDataParser().extractData("kontaktHeader");
        String gesundheitHeader = GetDataParser().extractData("gesundheitHeader");

        [Test]
        public void OpenGewinntabellenPage()
        {
            BausparenPage bausparenPage = LoadBausparenPage();

            GewinntabellenPage gewinntabellenPage = bausparenPage.GoToGewinntabellen();
            gewinntabellenPage.WaitForPageToDisplay();

            IList<IWebElement> gewinnTables = gewinntabellenPage.GetGewinnTables();

            foreach(IWebElement el in gewinnTables) 
            {
               Assert.IsTrue(el.Displayed);
            }

            Assert.That(gewinnTables.Count, Is.EqualTo(4));
            Assert.That(gewinntabellenPage.GetGewinnHeader().ToLower, Is.EqualTo(gewinnHeader));
        }

        [Test]
        public void OpenServicesPage()
        {
            BausparenPage bausparenPage = LoadBausparenPage();

            ServicesPage servicesPage = bausparenPage.GoToServices();
            servicesPage.WaitForPageToDisplay();

            Assert.That(servicesPage.GetServicesHeader().ToLower, Is.EqualTo(servicesHeader));
        }

        [Test]
        public void OpenLoginPage()
        {
            BausparenPage bausparenPage = LoadBausparenPage();
            GetActions().MoveToElement(bausparenPage.GetBausparenNavbarItem()).Perform();


            LoginPage loginPage = bausparenPage.GoToLogin();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            loginPage.WaitForPageToDisplay();

            Assert.IsTrue(driver.Url.Contains(loginUrl));
            Assert.IsTrue(loginPage.GetLoginForm().Displayed);
        }

        [Test]
        public void OpenMixZinsPage()
        {
            BausparenPage bausparenPage = LoadBausparenPage();
            GetActions().MoveToElement(bausparenPage.GetCarousel()).Perform();

            bausparenPage.slideNext();
            MixZinsPage mixZinsPage = bausparenPage.GoToMixZins();
            mixZinsPage.WaitForPageToDisplay();

            Assert.IsTrue(mixZinsPage.GetMixZinsHeader().ToLower().Contains(mixZinsHeader));
        }

        [Test]
        public void OpenContactForm()
        {
            BausparenPage bausparenPage = LoadBausparenPage();
            GetActions().ScrollToElement(bausparenPage.GetFooter()).Perform();

            KontaktPage kontaktPage = bausparenPage.GoToKontakt();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            kontaktPage.WaitForPageToDisplay();

            Assert.IsTrue(kontaktPage.GetKontaktForm().Displayed);
            Assert.That(kontaktPage.GetKontaktHeader().ToLower, Is.EqualTo(kontaktHeader));
        }

        [Test]
        public void OpenGesundheitPage()
        {
            BausparenPage bausparenPage = LoadBausparenPage();
            GetActions().MoveToElement(bausparenPage.GetFinanzierenNavbarItem()).Perform();

            GesundheitPage gesundheitPage = bausparenPage.GoToGesundheit();
            gesundheitPage.WaitForPageToDisplay();

            Assert.IsTrue(gesundheitPage.GetGesundheitHeader().ToLower().Contains(gesundheitHeader));
        }
    }
}