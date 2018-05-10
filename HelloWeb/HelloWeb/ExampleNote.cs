using System;

internal class ExampleNote
{
    public string login { get; }
    public string password { get; }
    public string egNote { get; }
    public string egText { get; }

    public ExampleNote()
    {
        login = "autotestdotnet@gmail.com";
        password = "codesprinters2018";
        egNote = GenerateNote();
        egText = GenerateText();
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

