using System;
using System.Collections.Generic;

public class Question
{
	public int id;
	public String name;
	public List<Answer> questionsAnswers = new List<Answer>();
	public int answersCount;

	public Question(int id, String name)
	{
		this.id = id;
		this.name = name;
		answersCount = 0;
	}

	public List<Answer> GetAnswers()
	{
		return questionsAnswers;
	}

	public Answer GetAnswer(int ID)
    {
		return null;
    }

	public void AddAnswer(Answer currAnswer)
    {
	
    }

	public void AddAnswers(List<Answer> currAnswersList)
    {

    }

	public void UpdateAnswer(int oldID, Answer newAnswer)
    {

    }

	public void DeleteAnswer(int deleteID)
    {

    }

}
