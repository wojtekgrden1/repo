using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectProject
{
    internal class GoogleMainPage
    {
        private const string GoogleMainPageUrl = "https://www.google.com/";
        private readonly IWebDriver _driver;

        public GoogleMainPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl(GoogleMainPageUrl);

            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "lst-ib")]
        public IWebElement QueryBox;


        public ResultPage Search(string query)
        {
            QueryBox.SendKeys(query);
            QueryBox.Submit();

            return new ResultPage(_driver);
        }
    }
}