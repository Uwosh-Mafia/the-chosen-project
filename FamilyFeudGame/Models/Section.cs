using System;
using System.Collections.Generic;

/// <summary>
/// This class retrieves and adds questions that are associated
/// with a certain section.
/// </summary>
public class Section
{
    public int Id { get; set; }
    public string Name { get; set; }
    private List<Question> _questions;

    public Section(int id, string name)
    {
        this.Name = name;
        this.Id = id;
        _questions = new();
    }

    /// <summary>
    /// Gets the list of questions associated with the section
    /// </summary>
    /// <returns>list of answers</returns>
    public List<Question> GetQuestions()
    {
        return _questions;
    }

    /// <summary>
    /// Gets a single question based on the Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Question for the id given</returns>
    //public Question GetQuestion(int id)
    //{
    //    return _questions.Find(question => question.Id == id);
    //}

    /// <summary>
    /// Adds a single question to the section
    /// </summary>
    /// <param name="currQuestion"> the question to add </param>
    public void AddQuestion(Question currQuestion)
    {
        _questions.Add(currQuestion);
    }

    /// <summary>
    /// This methods clears the list
    /// </summary>
    public void Clear()
    {
        _questions.Clear();
    }

}
