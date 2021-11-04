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

    public Section(int id, String name)
    {
        Name = name;
        Id = id;
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
    public Question GetQuestion(int id)
    {
        return _questions.Find(question => question.Id == id);
    }

    /// <summary>
    /// Adds a single question to the section
    /// </summary>
    /// <param name="currQuestion"> the question to add </param>
    public void AddQuestion(Question currQuestion)
    {
        _questions.Add(currQuestion);
    }

    /// <summary>
    /// Adds a list of questions to the section
    /// </summary>
    /// <param name="currQuestionsList"> the list of questions to add </param>
    public void AddQuestions(List<Question> currQuestionsList)
    {
        foreach (Question question in currQuestionsList)
            _questions.Add(question);
    }

    /**
     * Updates a Question from the given section with the new Question information
     */
    public void UpdateQuestion(int questID, Question newQuestion)
    {
        string query = "UPDATE Question SET question_id = " + newQuestion.ID + ", name = " + newQuestion.Name + ", num_answers = " + newQuestion.AnswersCount + ", section_id = " + ID + " WHERE question_id = " + questID;
        SubmitQuery(query, "update question");
    }

    /**
     * Submits a query to DBController to delete a Question from the this Section
     */
    public void DeleteQuestion(int questID)
    {
        string query = "DELETE FROM Question WHERE question_id = " + questID + " AND section_id = " + ID;
        SubmitQuery(query, "update question list");
    }
    /**
     * This will return the section id.
     **/
    public int GetSectionID()
    {
        return Id;
    }
}
