using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

internal class Note
{
    private IWebDriver _driver;
    private readonly string _url;

    public Note(IWebDriver driver, string url)
    {
        _driver = driver;
        _url = url;
        _driver.Navigate().GoToUrl(url);
    }

    internal void AddComment(ExampleComment comment)
    {
        var commentElement = _driver.FindElement(By.Id("comment"));
        commentElement.SendKeys(comment.Text);

        var emailElement = _driver.FindElement(By.Id("email"));
        emailElement.SendKeys(comment.Email);

        var userElement = _driver.FindElement(By.Id("author"));
        userElement.SendKeys(comment.Name);

        var submitElement = _driver.FindElement(By.Id("comment-submit"));

        submitElement.Click();
    }

    internal IEnumerable<IWebElement> SearchCommentsByText(ExampleComment comment)
    {
        var comments = _driver.FindElements(By.ClassName("comment-content"));

        return comments.Where(c => c.Text.Contains(comment.Text));
    }

    internal void AddCommentToCommentAndCheck(ExampleComment comment)
    {
        _driver.FindElement(By.CssSelector("[aria-label*='" + comment.Name + "']")).Click();

        var Replay = _driver.FindElement(By.CssSelector("[id='comment'][name='comment']"));
        WaitForClickable(Replay, 5);
        Replay.Click();
        Replay.SendKeys(comment.ReplayComment);

        var EmailReplay = _driver.FindElement(By.Id("email"));
        EmailReplay.Click();
        EmailReplay.Clear();
        EmailReplay.SendKeys(comment.ReplayEmail);

        var AuthorReplay = _driver.FindElement(By.Id("author"));
        AuthorReplay.Click();
        AuthorReplay.Clear();
        AuthorReplay.SendKeys(comment.ReplayName);

        WaitForClickable(_driver.FindElement(By.Id("comment-submit")), 5);
        _driver.FindElement(By.Id("comment-submit")).Click();

        var CommentBlocks = _driver.FindElements(By.CssSelector("li[class*='comment']"));
        var CheckReplayAfterComment = CommentBlocks.Where(c => c.FindElement(By.TagName("p")).Text.Contains(comment.Text));
        Assert.Single(CheckReplayAfterComment);
        var ReplayBlocks = CheckReplayAfterComment.First().FindElements(By.CssSelector("ul[class='children']"));
        var OneBlock = ReplayBlocks.Where(r => r.FindElement(By.TagName("p")).Text.Contains(comment.ReplayComment));
        Assert.Single(OneBlock);
        
    }
    private void WaitForClickable(IWebElement element, int seconds)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
    }
}