using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace HelloWeb
{
    internal class AdminPage : WordPressPage
    {
        public AdminPage(IWebDriver driver) : base(driver)
        {
        }

        internal void AddNote(ExampleNote testNote)
        {
            {
                WaitForVisable(By.CssSelector("#menu-posts > a > div.wp-menu-name"), 10);
                _driver.FindElement(By.CssSelector("#menu-posts > a > div.wp-menu-name")).Click();

                WaitForVisable(By.CssSelector("[class='page-title-action']"), 10);
                _driver.FindElement(By.CssSelector("[class='page-title-action']")).Click();

                WaitForVisable(By.CssSelector("[id='title-prompt-text']"), 10);
                var enterTitle = _driver.FindElement(By.CssSelector("[id='title-prompt-text']"));
                enterTitle.Click();
                _driver.FindElement(By.CssSelector("[id='title']")).SendKeys(testNote.egNote);

                var content = _driver.FindElement(By.CssSelector("[id='content']"));
                content.Click();
                content.SendKeys(testNote.egText);

                WaitForVisable((By.CssSelector("[type='button'][aria-label='Edit permalink']")), 10);
                _driver.FindElement(By.CssSelector("[id='publish']")).Click();

                _driver.FindElement(By.CssSelector("[class='avatar avatar-32']")).Click();

                _driver.FindElement(By.CssSelector("[class='ab-sign-out']")).Click();
            }
        }
    }
}