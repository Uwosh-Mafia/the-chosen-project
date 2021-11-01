using System;
using System.Collections.Generic;

public class Question
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Section Section { get; set; }
    public List<Answer> questionsAnswers = new();
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
        return questionsAnswers;
    }

    public Answer GetAnswer(int id)
    {
        return null;
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
