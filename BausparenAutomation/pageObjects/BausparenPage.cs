using AngleSharp.Common;
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
    public class BausparenPage
    {
        IWebDriver driver;

        public BausparenPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("main-content")));
        }

        public void AcceptCookies() 
        {
            // zustimmen button
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
        }

        public String CreateUniqueNumber()
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            long unixTimeMilliseconds = now.ToUnixTimeMilliseconds();

            return unixTimeMilliseconds.ToString();
        }

        // WEB ELEMENTS
        // search field at the top of the page
        [FindsBy(How = How.Id, Using = "search--input-header")]
        IWebElement searchField;
        public IWebElement GetSearchField()
        {
            return searchField;
        }

        public SuchePage typeAndSearch(String keyword) 
        {
            searchField.Clear();
            searchField.SendKeys(keyword);
            searchField.SendKeys(Keys.Enter);
            return new SuchePage(driver);
        }

        // navbar item which leads to Bausparen page
        [FindsBy(How = How.CssSelector, Using = "#main-navigation>ul>li>a[href='/de/bausparen.html']")]
        IWebElement bausparenNavbarItem;
        public IWebElement GetBausparenNavbarItem()
        {
            return bausparenNavbarItem;
        }

        // button which leads to Login page
        [FindsBy(How = How.XPath, Using = "//nav[@id='main-navigation']//a[@href='https://mein.elba.raiffeisen.at/bankingquer-routing-app/routing-app-ui/e2e/BAUSPAREN']")]
        IWebElement jetztBausparenBtn;
        public LoginPage GoToLogin()
        {
            jetztBausparenBtn.Click();
            return new LoginPage(driver);
        }

        // button which leads to Gewinntabellen page
        [FindsBy(How = How.CssSelector, Using = "a[href='/de/bausparen/gewinntabellen.html'][class='btn btn-default']")]
        IWebElement produkteVergleichenBtn;
        public GewinntabellenPage GoToGewinntabellen()
        {
            produkteVergleichenBtn.Click();
            return new GewinntabellenPage(driver);
        }

        // navbar item which leads to Services page
        [FindsBy(How = How.CssSelector, Using = "#main-navigation>ul>li>a[href='/de/services.html']")]
        IWebElement servicesNavbarItem;
        public ServicesPage GoToServices()
        {
            servicesNavbarItem.Click();
            return new ServicesPage(driver);
        }

        // navbar item which leads to Finanzieren page
        [FindsBy(How = How.CssSelector, Using = "#main-navigation>ul>li>a[href='/de/finanzieren.html']")]
        IWebElement finanzierenNavbarItem;
        public IWebElement GetFinanzierenNavbarItem() 
        {
            return finanzierenNavbarItem;
        }

        // navbar sub-item which leads to Gesundheit page
        [FindsBy(How = How.CssSelector, Using = ".nav-vertical>li>a[href='/de/finanzieren/gesundheit.html']")]
        IWebElement gesundheitPflegeLink;
        public GesundheitPage GoToGesundheit()
        {
            gesundheitPflegeLink.Click();
            return new GesundheitPage(driver);
        }

        //carousel
        [FindsBy(How = How.ClassName, Using = "carousel")]
        IWebElement carousel;
        public IWebElement GetCarousel()
        {
            return carousel;
        }

        // carousel - next slide arrow
        [FindsBy(How = How.CssSelector, Using = "button[class='stage-arrow-next slick-arrow']")]
        IWebElement carouselArrowNext;
        public void slideNext()
        {
            carouselArrowNext.Click();
        }

        // button inside carousel item which leads to MixZins page
        [FindsBy(How = How.XPath, Using = "//div[@id='slick-slide03']//a[@href='/de/bausparen/mixzins.html'][@class='btn btn-primary']")]
        IWebElement zumProductMixZinsBtn;
        public MixZinsPage GoToMixZins() 
        {
            zumProductMixZinsBtn.Click();
            return new MixZinsPage(driver);
        }

        // button which leads to FAQs page
        [FindsBy(How = How.CssSelector, Using = "a[href='/de/bausparen/faqs.html'][class='btn btn-default']")]
        IWebElement jetztNachlesenBtn;
        public IWebElement GetJetztNachlesenBtn()
        {
            return jetztNachlesenBtn;
        }

        // link which leads to Kontaktformular
        [FindsBy(How = How.CssSelector, Using = "a[title='Kontaktformular']")]
        IWebElement kontaktformularLink;
        public KontaktPage GoToKontakt()
        {
            kontaktformularLink.Click();
            return new KontaktPage(driver);
        }

        // footer
        [FindsBy(How = How.ClassName, Using = "footer-main")]
        IWebElement footer;
        public IWebElement GetFooter()
        {
            return footer;
        }


        // YouTube video
        [FindsBy(How = How.CssSelector, Using = "div[id='vjs_video_3'][data-src='https://youtu.be/lWeQEm6ePTw']")]
        IWebElement youtubeVideo;
        public IWebElement GetYoutubeVideo()
        {
            return youtubeVideo;
        }


        // email field
        [FindsBy(How = How.Name, Using = "emailAddress")]
        IWebElement email;
        public IWebElement GetEmail() 
        {
            return email;
        }

        // absenden button
        [FindsBy(How = How.XPath, Using = "//div[@class='form-container']/a/span[text()='Absenden']")]
        IWebElement absendenBtn;
        public IWebElement GetAbsendenBtn() 
        {
            return absendenBtn;
        }

        // subscription error message
        [FindsBy(How = How.ClassName, Using = "parsley-type")]
        IWebElement subscriptionErrorMessage;
        public String GetSubscriptionErrorMessage() 
        {
            return subscriptionErrorMessage.Text;
        }

        // subscription success message
        [FindsBy(How = How.CssSelector, Using = ".newsletter-subscription-success>p")]
        IWebElement subscriptionSuccessMessage;
        public String GetSubscriptionSuccessMessage()
        {
            return subscriptionSuccessMessage.Text;
        }

        
        // bankomaten location search field at the bottom of the page
        [FindsBy(How = How.Id, Using = "location-search-form")]
        IWebElement locationSearchField;
        public IWebElement GetLocationSearchField()
        {
            return locationSearchField;
        }

        By locationSearchAutocompleteLocator = By.ClassName("search-autocomplete");
        public By GetLocationSearchAutocompleteLocator()
        {
            return locationSearchAutocompleteLocator;
        }

        public void typeAndSearchLocation(String location)
        {
            locationSearchField.Clear();
            locationSearchField.SendKeys(location);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locationSearchAutocompleteLocator));

            locationSearchField.SendKeys(Keys.Down);
            locationSearchField.SendKeys(Keys.Enter);
        }

        // location search error message
        [FindsBy(How = How.ClassName, Using = "location-search-error")]
        IWebElement locationSearchErrorMessage;
        public IWebElement GetLocationSearchErrorMessage()
        {
            return locationSearchErrorMessage;
        }

        // location search results - first result
        [FindsBy(How = How.CssSelector, Using = "li:first-child>a>result-item>article")]
        IWebElement locationResultItem;
        public IWebElement GetLocationResultItem() 
        {
            return locationResultItem;
        }

        // location result details - h3
        [FindsBy(How = How.CssSelector, Using = "result-details>article>div[class='general-info']>h3")]
        IWebElement locationResultDetailHeader;
        public String GetLocationResultDetailHeader()
        {
            return locationResultDetailHeader.Text;
        }

        // location item detailseiteAufrufen button
        [FindsBy(How = How.CssSelector, Using = "a[href='https://www.raiffeisen.at/ktn/villach/de/meine-bank/bankstellen/villach.html'][class='btn btn-default']")]
        IWebElement detailseiteAufrufenBtn;
        public BankVillachPage GoToVillachBankPage()
        {
            detailseiteAufrufenBtn.Click();
            return new BankVillachPage(driver);
        }

        By locationItemDetailsLocator = By.TagName("result-details");
        public By GetLocationItemDetailsLocator()
        {
            return locationItemDetailsLocator;
        }

        By subscriptionFormValidationLocator = By.ClassName("component-form-validation");
        public By GetSubscriptionFormValidationLocator()
        {
            return subscriptionFormValidationLocator;
        }

        By subscriptionCheckMarkLocator = By.ClassName("icon-check");
        public By GetSubscriptionCheckMarkLocator()
        {
            return subscriptionCheckMarkLocator;
        }
    }
}
