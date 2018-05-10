using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageObjectProject
{
    public class ResultPage
    {
        private IWebDriver _driver;

        public ResultPage(IWebDriver driver)
        {
            _driver = driver;

            WaitForClickable(By.CssSelector("h3.r"));
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h3.r")]
        public IList<IWebElement> SearchResults;


        public bool Contains(string expected)
        {
            return SearchResults.Any(s => s.Text.Contains(expected));
        }

        private void WaitForClickable(By by, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}