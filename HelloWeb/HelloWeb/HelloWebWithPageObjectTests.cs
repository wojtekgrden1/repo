using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

public class HelloWebWithPageObjectTests : IDisposable
{
    private const string FirstNoteUrl = "https://autotestdotnet.wordpress.com/2018/05/07/witamy-na-warsztatach-automatyzacji-testow";
    private const string LoginPageUrl = "https://autotestdotnet.wordpress.com/wp-admin";
    private IWebDriver driver;
    private readonly ExampleComment testComment;
    private readonly ExampleNote testNote;

    public HelloWebWithPageObjectTests()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        testComment = new ExampleComment();
        testNote = new ExampleNote();
    }

    [Fact]
    public void Can_add_comment_to_existing_note()
    {
        //arrange
        var welcomeNote = new Note(driver, FirstNoteUrl);

        // act
        welcomeNote.AddComment(testComment);

        //assert
        var comments = welcomeNote.SearchCommentsByText(testComment);
        Assert.Single(comments);

        welcomeNote.AddCommentToCommentAndCheck(testComment);
    }



    [Fact]
    public void Add_and_check_note_test()
    {
        var login = new LoginPage(driver, LoginPageUrl);

        login.DoLogin(testNote);
        login.AddNote(testNote);

    }

    public void Dispose()
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        {

            throw;
        }
    }
}