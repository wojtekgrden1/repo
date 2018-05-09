using System;

internal class ExampleComment
{
    public string Name { get; }
    public string Email { get; }
    public string Text { get; }
    public string ReplayComment { get; }
    public string ReplayEmail { get; }
    public string ReplayName { get; }

    public ExampleComment()
    {
        Name = GenerateUserName();
        Email = GenerateEmail();
        Text = GenerateComment();
        ReplayComment = GenerateReplayComment();
        ReplayEmail = GenerateReplayEmail();
        ReplayName = GenerateReplayName();
    }

    private string GenerateComment()
    {
        return Guid.NewGuid().ToString();
    }

    private string GenerateUserName()
    {
        return Guid.NewGuid().ToString();
    }

    private string GenerateEmail()
    {
        var user = Guid.NewGuid().ToString();
        return $"{user}@nonexistent.test.com";
    }

    private string GenerateReplayComment()
    {
        return Guid.NewGuid().ToString();
    }

    private string GenerateReplayEmail()
    {
        var user = Guid.NewGuid().ToString();
        return $"{user}@nonexistent.test.com";
    }

    private string GenerateReplayName()
    {
        return Guid.NewGuid().ToString();
    }
}