using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
        loginField.SendKeys(testNote.login);
        _driver.FindElement(By.CssSelector("[type='submit']")).Click();

        WaitForVisable(By.CssSelector("#password"), 10);
        var passwordField = _driver.FindElement(By.CssSelector("#password"));
        passwordField.Click();
        passwordField.SendKeys(testNote.password);

        _driver.FindElement(By.CssSelector("#primary > div > main > div > div.wp-login__container > div > form > div.card.login__form > div.login__form-action > button")).Click();
    }
    private void WaitForVisable(By by, int seconds)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
        wait.Until(ExpectedConditions.ElementIsVisible(by));
    }

    internal void AddNote(ExampleNote testNote)
    {
        WaitForVisable(By.CssSelector("#menu-posts > a > div.wp-menu-name"), 10);
        _driver.FindElement(By.CssSelector("#menu-posts > a > div.wp-menu-name")).Click();

        WaitForVisable(By.CssSelector("[class='page-title-action']"), 10);
        _driver.FindElement(By.CssSelector("[class='page-title-action']")).Click();

        WaitForVisable(By.CssSelector("[id='title-prompt-text']"), 10);
        var enterTitle =_driver.FindElement(By.CssSelector("[id='title-prompt-text']"));
        enterTitle.Click();
        _driver.FindElement(By.CssSelector("[id='title']")).SendKeys(testNote.egNote);

        var content = _driver.FindElement(By.CssSelector("[id='content']"));
        content.Click();
        content.SendKeys(testNote.egText);

        _driver.FindElement(By.CssSelector("[id='publish']")).Click();

        _driver.FindElement(By.CssSelector("[class='avatar avatar-32']")).Click();

        _driver.FindElement(By.CssSelector("[class='ab-sign-out']")).Click();

    }
}