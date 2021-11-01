using System;
using System.Collections.Generic;

public class Section
{
    public int ID { get; set; }
    public string Name { get; set; }
    private List<Question> questions = new List<Question>();
    public int QuestionsCount { get; set; }

    public Section(int id, String name)
    {
        Name = name;
        ID = id;
        QuestionsCount = 0;
    }

    public List<Question> GetQuestions()
    {
        List<Question> questions;
        string query = "SELECT * FROM Question WHERE section_id=" + ID;
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
        string query = "UPDATE Question SET question_id = " + currQuestion.ID + ", name = " + currQuestion.Name + ", num_answers = " + currQuestion.AnswersCount + ", section_id = " + ID;
        questionsCount++;
        SubmitQuery(query);
    }

    public void AddQuestions(List<Question> currQuestions)
    {
        for (int i = 0; i < currQuestions.Count(); i++)
        {
            string query = "UPDATE Question SET question_id = " + currQuestions[i].ID + ", name = " + currQuestion[i].Name + ", num_answers = " + currQuestion[i].AnswersCount + ", section_id = " + ID;
            QuestionsCount++;
        }
        SubmitQuery(query);
    }

    public void UpdateQuestion(int oldID, Question newQuestion)
    {
        string query = "UPDATE Question SET question_id = " + newQuestion.ID + ", name = " + newQuestion.Name + ", num_answers = " + newQuestion.AnswersCount + ", section_id = " + ID + " WHERE question_id = " + oldID;
        SubmitQuery(query);
    }

    public void DeleteQuestion(int id)
    {
        string query = "DELETE FROM Question WHERE question_id = " + id;
        SubmitQuery(query);
    }
}
