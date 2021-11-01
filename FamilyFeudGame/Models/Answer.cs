﻿using System;

public class Answer
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Count { get; set; }
    public int Points => Count * Multiplier;

    public Answer(int id, string text, int count)
    {
        Id = id;
        Text = text;
        Count = count;
    }
}
