using System;

/// <summary>
/// This class represents the answer
/// </summary>
public class Answer
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Points { get; set; }
    public Answer(int id, string text, int points)
    {
        this.Id = id;
        this.Text = text;
        this.Points = points;
    }
}
