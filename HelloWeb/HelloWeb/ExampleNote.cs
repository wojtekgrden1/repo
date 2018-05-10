using System;

internal class ExampleNote
{
    public string Login { get; }
    public string Password { get; }
    public string egNote { get; }
    public string egText { get; }

    public ExampleNote()
    {
        Login = "autotestdotnet@gmail.com";
        Password = "codesprinters2018";
        egNote = GenerateNote() + "TEST";
        egText = GenerateText() + "TEST";
    }
    private string GenerateNote()
    {
        return Guid.NewGuid().ToString();
    }
    private string GenerateText()
    {
        return Guid.NewGuid().ToString();
    }
}

