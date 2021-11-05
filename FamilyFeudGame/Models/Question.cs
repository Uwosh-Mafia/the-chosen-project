using System;
using System.Collections.Generic;

/// <summary>
/// This class retrieves and adds answers that are associated
/// with a certain question.
/// </summary>
public class Question
{
    public int Id { get; }
    public string Text { get; set; }
    private List<Answer> _answers;

    public Question(int id, string text)
    {
        this.Id = id;
        this.Text = text;
        _answers = new();
    }

    /// <summary>
    /// Gets the liste of answers associated with the question
    /// </summary>
    /// <returns>list of answers</returns>
    public List<Answer> GetAnswers()
    {
        return _answers;
    }

    /// <summary>
    /// Returns the number of answers for a question
    /// </summary>
    /// <returns> number of answers </returns>
    public int GetAnswerCount()
    {
        return _answers.Count;
    }

    /// <summary>
    /// Gets a single answer based on the Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Answer for the id given</returns>
    public Answer GetAnswer(int id)
    {
        return _answers.Find(answer => answer.Id == id);
    }

    /// <summary>
    /// Adds a single answer to the question
    /// </summary>
    /// <param name="currAnswer"> the answer to add </param>
    public void AddAnswer(Answer currAnswer)
    {
        _answers.Add(currAnswer);
    }

    /// <summary>
    /// Adds a list of answers to the question
    /// </summary>
    /// <param name="currAnswersList"> the list of answers to add </param>
    public void AddAnswers(List<Answer> currAnswersList)
    {
        foreach (Answer answer in currAnswersList)
            _answers.Add(answer);
    }
}
