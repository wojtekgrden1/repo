using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace HelloWeb
{
    internal class NotePage : WordPressPage
    {
        public NotePage(IWebDriver driver) : base(driver)
        {
        }

        internal  void CheckIfNoteExists(ExampleNote testNote)

        {
            System.Threading.Thread.Sleep(4000);
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");

            IReadOnlyCollection<IWebElement> entryTitle = _driver.FindElements(By.CssSelector("article[id]"));
            var CheckEntryTitle = entryTitle.Where(c => c.FindElement(By.TagName("a")).Text.Contains(testNote.egNote));
            var numberOfElements = CheckEntryTitle.Count();
            //if (numberOfElements == 0) 

            Assert.Single(CheckEntryTitle);

            var ReplayNote = CheckEntryTitle.First().FindElements(By.CssSelector("[class='entry-content']"));
            var OneNote = ReplayNote.Where(r => r.FindElement(By.TagName("p")).Text.Contains(testNote.egText));
            Assert.Single(OneNote);
        }
    }
}