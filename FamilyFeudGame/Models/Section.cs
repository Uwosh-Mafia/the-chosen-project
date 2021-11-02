using System;
using System.Collections.Generic;

public class Section
{
    public int Id { get; set; }
    public string Name { get; set; }
    private List<Question> questions = new();
    public int QuestionsCount { get; set; }

    /**
     * Creates a section with a given ID and Name. Start question count is 0.
     */
    public Section(int id, String name)
    {
        Name = name;
        Id = id;
        QuestionsCount = 0;
    }

    /**
     * Gets a list of Questions from the given section
     */
    public List<Question> GetQuestions()
    {
        List<Question> questions;
        string query = "SELECT * FROM Question WHERE section_id=" + Id;
        questions = SubmitQuery(query, "question list");
        return questions;
    }

    /**
     * Gets a Question from the given section
     */
    public Question GetQuestion(int questID)
    {
        string query = "SELECT * FROM Question WHERE question_id=" + questID + " AND section_id = " + ID;
        Question questionToGet = SubmitQuery(query, "question");
        return questionToGet;
    }

    /**
     * Adds a single Question to the given section
     */
    public void AddQuestion(Question currQuestion)
    {
        string query = "UPDATE Question SET question_id = " + currQuestion.ID + ", name = " + currQuestion.Name + ", num_answers = " + currQuestion.AnswersCount + ", section_id = " + ID;
        questionsCount++;
        SubmitQuery(query, "add question");
    }

    /**
     * Adds a list of Questions - one by one - to the given section
     */
    public void AddQuestions(List<Question> currQuestions)
    {
        for (int i = 0; i < currQuestions.Count; i++)
        {
            string query = "UPDATE Question SET question_id = " + currQuestions[i].Id + ", name = " + currQuestions[i].Text + ", num_answers = " + currQuestions[i].AnswersCount + ", section_id = " + Id;
            QuestionsCount++;
        }
        SubmitQuery(query, "add question list");
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
}
