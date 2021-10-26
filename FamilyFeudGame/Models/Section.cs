using System;
using System.Collections.Generic;

public class Section
{
	public int id;
    public String name;
	public List<Question> questions = new List<Question>();
	public int questionsCount;

	public Section(int id, String name)
	{
		this.name = name;
		this.id = id;
		questionsCount = 0;
	}

	public List<Question> GetQuestions()
    {
		return questions;
    }

	public Question GetQuestion(int id)
    {
		return null;
    }

	public void AddQuestion(Question currQuestion)
    {

    }

	public void AddQuestions(List<Question> currQuestions)
    {

    }

	public void UpdateQuestion(int oldID, Question newQuestion)
    {

    }

	public void DeleteQuestion(int id)
    {

    }
}
