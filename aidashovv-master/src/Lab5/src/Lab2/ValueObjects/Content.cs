namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class Content
{
    public string Text { get; set; }

    public Content(string text)
    {
        if (text.Length == 0)
        {
            throw new ArgumentException("Content aren't being empty");
        }

        Text = text;
    }

    public Content Copy()
    {
        return new Content(Text);
    }
}