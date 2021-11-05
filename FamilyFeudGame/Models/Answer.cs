using System;

public class Answer
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Count { get; set; }

    public Answer(int id, string text, int count)
    {
        this.Id = id;
        this.Text = text;
        this.Count = count;
    }
}
