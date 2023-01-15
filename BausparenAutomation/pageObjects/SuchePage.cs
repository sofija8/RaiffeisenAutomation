using AngleSharp.Text;
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
    public class SuchePage
    {
        IWebDriver driver;

        public SuchePage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitForPageToDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("button[title='Suchen']")));
        }

        [FindsBy(How = How.CssSelector, Using = "a[class='btn btn-primary cta']")]
        IList<IWebElement> mehrErfahrenBtn;
        public IList<IWebElement> GetMehrErfahren()
        {
            return mehrErfahrenBtn;
        }

        [FindsBy(How = How.CssSelector, Using = "li[class='selection-list_item active']>a")]
        IWebElement selectionItemAlle;
        public int numberOfSearchResults()
        {
            String selectAll = selectionItemAlle.Text.Split(' ')[1];
            return Int32.Parse(selectAll[1].ToString());
        }

        [FindsBy(How = How.CssSelector, Using = ".no-results>p")]
        IWebElement noResults;
        public String GetNoResulst()
        {
            return noResults.Text;
        }
    }
}
