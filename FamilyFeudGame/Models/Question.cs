using System;
using System.Collections.Generic;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public Section Section { get; set; }
    public List<Answer> questionAnswers = new();
    public int AnswersCount { get; set; }

    public Question(int id, string text, Section section)
    {
        Id = id;
        Text = text;
        Section = section;
        AnswersCount = 0;
    }

    public List<Answer> GetAnswers()
    {
        string query = $"SELECT * FROM Answer WHERE Question.question_id == Answer.question_id AND question_id == {Id}";
        questionAnswers = SubmitQuery(query);
        return questionAnswers;
    }

    public Answer GetAnswer(int id)
    {
        string query = $"SELECT * FROM Answer WHERE answer_id == {id}";
        Answer answerToGet = SubmitQuery(query);
        return answerToGet;
    }

    public void AddAnswer(Answer currAnswer)
    {
        string query = $"INSERT INTO Answer VALUES('{currAnswer.Id}', '{currAnswer.Text}', {currAnswer.Count}', '{Id}')";
        SubmitQuery(query);
    }

    public void AddAnswers(List<Answer> currAnswersList)
    {
        string query;
        foreach (Answer answer in currAnswersList)
        {
            query = $"INSERT INTO Answer VALUES ('{answer.Id}', '{answer.Text}', {answer.Count}', '{Id}')";
            SubmitQuery(query);
        }
    }

    public void UpdateAnswer(int oldId, Answer newAnswer)
    {
        string query = $"UPDATE Answer SET answer_id = '{newAnswer.Id}', answer_text = '{newAnswer.Text}', count = '{newAnswer.Count}', question_id = '{Id}' WHERE answer_id = {oldId}";
        SubmitQuery(query);
    }

    public void DeleteAnswer(int deleteId)
    {
        string query = $"DELETE FROM Answer WHERE answer_id = '{deleteId}'";
        SubmitQuery(query);
    }

}
