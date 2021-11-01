using System;

public class Answer
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Points { get; set; }

    public Answer(int id, string text, int points)
    {
        Id = id;
        Text = text;
        Points = points;
    }
}
