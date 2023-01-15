using BausparenAutomation.pageObjects;
using BausparenAutomation.utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BausparenAutomation.tests
{
    public class SearchTests : Base
    {
        String keyword = GetDataParser().extractData("searchKeyword");
        String nonexistentSearchKeyword = GetDataParser().extractData("nonexistentSearchKeyword");

        [Test]
        public void SearchBasedOnEnteredKeyword() 
        {
            BausparenPage bausparenPage = LoadBausparenPage();

            SuchePage suchePage = bausparenPage.typeAndSearch(keyword);

            IList<IWebElement> readArticles = suchePage.GetMehrErfahren();

            foreach (IWebElement el in readArticles)
            {
                el.Click();
                String pageContent = driver.PageSource;
                Assert.IsTrue(pageContent.Contains(keyword));
                driver.Navigate().Back();
            }

            Assert.That(readArticles.Count(), Is.EqualTo(suchePage.numberOfSearchResults()));
        }

        [Test]
        public void GetZeroSearchResults()
        {
            BausparenPage bausparenPage = LoadBausparenPage();

            SuchePage suchePage = bausparenPage.typeAndSearch(nonexistentSearchKeyword);

            Assert.That(suchePage.GetNoResulst(), Is.EqualTo(String.Format(@"Ihr Suchbegriff “{0}” ergab keine Treffer.", nonexistentSearchKeyword)));
        }
    }
}
