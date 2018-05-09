using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Windows;


namespace HelloWeb
{
    public class HelloWebTests : IDisposable

    {
        private readonly string BlogUrl = "https://autotestdotnet.wordpress.com/";
        private IWebDriver browser;
        public HelloWebTests()
        {
            browser = new ChromeDriver();
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
            name1.SendKeys("Wojtek");
            browser.FindElement(By.CssSelector("#comment-submit")).Click();
            System.Threading.Thread.Sleep(3000);
            IReadOnlyCollection<IWebElement> comments = browser.FindElements(By.CssSelector("article.comment-body"));
            var largeNumbersQuery = comments.Where(c => c.FindElement(By.TagName("p")).Text.Contains(RandomText));
            Assert.Single(largeNumbersQuery);
            System.Threading.Thread.Sleep(3000);

        }
        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@nonexistent.test.com";
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
