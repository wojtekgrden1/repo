using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Xunit;

namespace HelloWeb
{
    internal class LoginPage 
    {
        private IWebDriver _driver;
        private readonly string _url;

        public LoginPage(IWebDriver driver, string url)
        {
            _driver = driver;
            _url = url;
            _driver.Navigate().GoToUrl(url);
        }

        internal void DoLogin(ExampleNote testNote)
        {
            WaitForVisable(By.CssSelector("[id='usernameOrEmail']"), 10);
            var loginField = _driver.FindElement(By.CssSelector("[id='usernameOrEmail']"));
            loginField.Click();
            loginField.SendKeys(testNote.Login);
            _driver.FindElement(By.CssSelector("[type='submit']")).Click();

            WaitForVisable(By.CssSelector("#password"), 10);
            var passwordField = _driver.FindElement(By.CssSelector("#password"));
            passwordField.Click();
            passwordField.SendKeys(testNote.Password);

            _driver.FindElement(By.CssSelector("#primary > div > main > div > div.wp-login__container > div > form > div.card.login__form > div.login__form-action > button")).Click();
        }
        private void WaitForVisable(By by, int seconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}