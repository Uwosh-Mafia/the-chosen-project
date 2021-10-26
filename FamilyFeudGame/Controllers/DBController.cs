using System;
using System.Collections.Generic;

public class DBController
{
    public DBModel database;
    public int sectionCount;
    public List<Section> sections = new List<Section>();
    public DBController(DBModel database)
    {
        this.database = database;
    }

    public List<Section> GetSections()
    {
        return sections;
    }

    public Section GetSection(int id)
    {
        return null;
    }

    public Section CreateSection(String name)
    {
        return null;
    }

    public Question CreateQuestion(String name)
    {
        return null;
    }

    public Answer CreateAnswer(String text, int point)
    {
        return null;
    }

    public void AddAnswerToQuestion(Question currQuestion, Answer currAnswer)
    {

    }

    public void AddAnswersToQuestion(Question currQuestion, List<Answer> currAnswers)
    {

    }

    public void AddQuestionToSection(int sectionID, Question currQuestion)
    {

    }

    public void AddQuestionsToSection(int sectionID, List<Question> currQuestions)
    {

    }

    public void updateSection(int sectionID, String newName)
    {

    }

    public void UpdateQuestion(int sectionID, int QuestionID, String newName)
    {

    }

    public void UpdateQuestion(Question currQuestion, String newName)
    {

    }

    public void UpdateAnswer(int sectionID, int questionID, int answerID, String newText, int newPoints)
    {

    }

    public void UpdateAnswer(Question currQuestion, int answerID, String newText, int newPoints)
    {

    }

    public void UpdateAnswer(Answer currAnswer, String newText, int newPoints)
    {

    }
}

