using System;
using System.Collections.Generic;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public Section Section { get; set; }
    public List<Answer> questionAnswers;
    public int AnswersCount { get; set; }

    public Question(int id, string text, Section section)
    {
        Id = id;
        Text = text;
        Section = section;
        AnswersCount = 0;
        questionAnswers = new();
    }

    /// <summary>
    /// Gets the liste of answers associated with the question
    /// </summary>
    /// <returns>list of answers</returns>
    public List<Answer> GetAnswers()
    {
        string query = $"SELECT * FROM Answer WHERE Question.question_id == Answer.question_id AND question_id == {Id}";
        questionAnswers = SubmitQuery(query, true);
        return questionAnswers;
    }

    /// <summary>
    /// Gets a single answer based on the Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Answer for the id given</returns>
    public Answer GetAnswer(int id)
    {
        string query = $"SELECT * FROM Answer WHERE answer_id == {id}";
        Answer answerToGet = SubmitQuery(query, true);
        return answerToGet;
    }

    /// <summary>
    /// Adds a single answer to the question
    /// </summary>
    /// <param name="currAnswer"> the answer to add </param>
    public void AddAnswer(Answer currAnswer)
    {
        string query = $"INSERT INTO Answer VALUES('{currAnswer.Id}', '{currAnswer.Text}', {currAnswer.Count}', '{Id}')";
        SubmitQuery(query, false);
    }

    /// <summary>
    /// Adds a list of answers to the question
    /// </summary>
    /// <param name="currAnswersList"> the list of answers to add </param>
    public void AddAnswers(List<Answer> currAnswersList)
    {
        string query;
        foreach (Answer answer in currAnswersList)
        {
            query = $"INSERT INTO Answer VALUES ('{answer.Id}', '{answer.Text}', {answer.Count}', '{Id}')";
            SubmitQuery(query, false);
        }
    }

    /// <summary>
    /// Changes the old answer to a new answer
    /// </summary>
    /// <param name="oldId"> id of the old answer </param>
    /// <param name="newAnswer"> new answer </param>
    public void UpdateAnswer(int oldId, Answer newAnswer)
    {
        string query = $"UPDATE Answer SET answer_id = '{newAnswer.Id}', answer_text = '{newAnswer.Text}', count = '{newAnswer.Count}', question_id = '{Id}' WHERE answer_id = {oldId}";
        SubmitQuery(query, false);
    }

    /// <summary>
    /// Deletes an answer
    /// </summary>
    /// <param name="deleteId"> id of answer to delete </param>
    public void DeleteAnswer(int deleteId)
    {
        string query = $"DELETE FROM Answer WHERE answer_id = '{deleteId}'";
        SubmitQuery(query, false);
    }

    /// <summary>
    /// Submits query to database
    /// </summary>
    /// <param name="query">query to execute</param>
    public void SubmitQuery(string query, bool isRetrieve)
    {
        //here to make compiler happy.
        //Need to implement a submit query method in database
        //and in our business logic of our program
    }

}
