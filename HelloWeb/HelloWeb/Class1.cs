using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


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
        }
        //close
        public void Dispose()
        {
            try
            {
                browser.Quit();
            }
            catch
            {
            }
        }
    }
}
