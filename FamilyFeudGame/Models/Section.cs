using System;
using System.Collections.Generic;

public class Section
{
    public int Id { get; set; }
    public string Name { get; set; }
    private List<Question> questions = new();
    public int QuestionsCount { get; set; }

    public Section(int id, string name)
    {
        Name = name;
        Id = id;
        QuestionsCount = 0;
    }

    public List<Question> GetQuestions()
    {
        List<Question> questions;
        string query = "SELECT * FROM Question WHERE section_id=" + Id;
        questions = SubmitQuery(query, "question list");
        return questions;
    }

    public Question GetQuestion(int id)
    {
        string query = "SELECT * FROM Question WHERE question_id=" + id;
        Question questionToGet = SubmitQuery(query, "question");
        return questionToGet;
    }

    public void AddQuestion(Question currQuestion)
    {
        string query = "UPDATE Question SET question_id = " + currQuestion.Id + ", name = " + currQuestion.Name + ", num_answers = " + currQuestion.AnswersCount + ", section_id = " + Id;
        QuestionsCount++;
        SubmitQuery(query);
    }

    public void AddQuestions(List<Question> currQuestions)
    {
        for (int i = 0; i < currQuestions.Count; i++)
        {
            string query = "UPDATE Question SET question_id = " + currQuestions[i].Id + ", name = " + currQuestions[i].Name + ", num_answers = " + currQuestions[i].AnswersCount + ", section_id = " + Id;
            QuestionsCount++;
        }
        SubmitQuery(query);
    }

    public void UpdateQuestion(int oldId, Question newQuestion)
    {
        string query = "UPDATE Question SET question_id = " + newQuestion.Id + ", name = " + newQuestion.Name + ", num_answers = " + newQuestion.AnswersCount + ", section_id = " + Id + " WHERE question_id = " + oldId;
        SubmitQuery(query);
    }

    public void DeleteQuestion(int id)
    {
        string query = "DELETE FROM Question WHERE question_id = " + id;
        SubmitQuery(query);
    }
    /**
     * This will return the section id.
     **/
    public int GetSectionID()
    {
        return Id;
    }
}
