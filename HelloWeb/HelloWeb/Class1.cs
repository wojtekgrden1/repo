using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Windows;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace HelloWeb
{
    public class HelloWebTests : IDisposable

    {
        private readonly string BlogUrl = "https://autotestdotnet.wordpress.com/";
        private IWebDriver browser;
        public HelloWebTests()
        {
            browser = new ChromeDriver();
            browser.Manage().Window.Maximize();
        }
        [Fact]
        public void Can_open_blog_and_hello_exists()
        {
            //open browser
            browser.Navigate().GoToUrl(BlogUrl);
            //open blog
            var element = browser.FindElement(By.CssSelector("#post-3096>header>h1>a")).Text;
            //check note exist
            Assert.Equal("Witamy na warsztatach automatyzacji testów!", element);
            browser.FindElement(By.CssSelector("#post-3096 > footer > span.comments-link > a")).Click();
            browser.FindElement(By.CssSelector("#comment")).Click();
            System.Threading.Thread.Sleep(3000);

        }

        [Fact]
        public void Can_add_comment_to_existing_note()
        {
            var RandomText = Guid.NewGuid().ToString();
            var user = Guid.NewGuid().ToString();

            browser.Navigate().GoToUrl(BlogUrl);

            browser.FindElement(By.CssSelector("#post-3096 > footer > span.comments-link > a")).Click();
            var comment = browser.FindElement(By.CssSelector("#comment"));
            comment.Click();
            comment.SendKeys(RandomText);

            var email = browser.FindElement(By.CssSelector("#comment-form-guest>div>div.comment-form-fields>div.comment-form-field.comment-form-email>label"));
            email.Click();
            var email1 = browser.FindElement(By.Id("email"));
            email1.SendKeys("przykladowyemail1@emailasdlas.com");

            var name = browser.FindElement(By.CssSelector("#comment-form-guest > div > div.comment-form-fields > div.comment-form-field.comment-form-author > label"));
            name.Click();
            var name1 = browser.FindElement(By.Id("author"));
            name1.SendKeys(user);
            browser.FindElement(By.CssSelector("#comment-submit")).Click();

            IReadOnlyCollection<IWebElement> comments = browser.FindElements(By.CssSelector("article.comment-body"));

            var largeNumbersQuery = comments.Where(c => c.FindElement(By.TagName("p")).Text.Contains(RandomText));
            Assert.Single(largeNumbersQuery);

            var usercheck = comments.Where(c => c.FindElement(By.TagName("cite")).Text.Contains(user));
            Assert.Single(usercheck);

            browser.FindElement(By.CssSelector("[aria-label*='" + user + "']")).Click();

            var RandomReplay = Guid.NewGuid().ToString();
            var Replay = browser.FindElement(By.CssSelector("[id='comment'][name='comment']"));
            WaitForClickable(Replay, 5);
            Replay.Click();
            Replay.SendKeys(RandomReplay);

            var EmailReplay = browser.FindElement(By.Id("email"));
            EmailReplay.Click();
            EmailReplay.Clear();
            var useremail = Guid.NewGuid().ToString() + "@nonexistent.test.com";
            EmailReplay.SendKeys(useremail);

            var AuthorReplay = browser.FindElement(By.Id("author"));
            AuthorReplay.Click();
            AuthorReplay.Clear();
            var userReplay = Guid.NewGuid().ToString();
            AuthorReplay.SendKeys(userReplay);

            WaitForClickable(browser.FindElement(By.Id("comment-submit")), 5);
            browser.FindElement(By.Id("comment-submit")).Click();

            IReadOnlyCollection<IWebElement> replay = browser.FindElements(By.CssSelector("[class='comment-content']"));
            var checkreplay = replay.Where(c => c.FindElement(By.TagName("p")).Text.Contains(RandomReplay));
            Assert.Single(checkreplay);

            //IReadOnlyCollection<IWebElement> ReplayAfterComment = browser.FindElements(By.TagName("li"));
            //var CheckReplayAfterComment = ReplayAfterComment.Where(c => c.FindElement(By.TagName("p")).Text.Contains(RandomReplay));






            System.Threading.Thread.Sleep(3000);

        }
        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@nonexistent.test.com";
        }
        private void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
        private void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        //close
        public void Dispose()
        {
            try
            {
                browser.Quit();
            }
            catch(Exception)
            {
            }
        }
    }
}
