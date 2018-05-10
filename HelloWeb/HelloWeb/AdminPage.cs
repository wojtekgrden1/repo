using OpenQA.Selenium;

internal class AdminPage
{
    private IWebDriver driver;

    public AdminPage(IWebDriver driver)
    {
        this.driver = driver;
    }
}