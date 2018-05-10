using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWeb
{
    class WordPressPage
    {
        protected IWebDriver _driver;

        public WordPressPage(IWebDriver driver)
        {
            _driver = driver;
        }
        protected void WaitForVisable(By by, int seconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

    }
}
