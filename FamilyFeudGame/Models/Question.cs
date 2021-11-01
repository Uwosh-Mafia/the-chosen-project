using System;
using System.Collections.Generic;

public class Question
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Section Section { get; set; }
    public List<Answer> questionAnswers = new();
    public int answersCount;

    public Question(int id, string name, Section section)
    {
        Id = id;
        Name = name;
        Section = section;
        answersCount = 0;
    }

    public List<Answer> GetAnswers()
    {
        string query = $"SELECT * FROM Answer WHERE Question.question_id == Answer.question_id AND question_id == {Id}";
        questionAnswers = SubmitQuery(query, "answer list");
        return questionAnswers;
    }

    public Answer GetAnswer(int id)
    {
        string query = $"SELECT * FROM Answer WHERE answer_id == {id}";
        Answer answerToGet = SubmitQuery(query, "answer to get");
        return answerToGet;
    }

    public void AddAnswer(Answer currAnswer)
    {

    }

    public void AddAnswers(List<Answer> currAnswersList)
    {

    }

    public void UpdateAnswer(int oldId, Answer newAnswer)
    {

    }

    public void DeleteAnswer(int deleteID)
    {

    }

}
