using System;
using System.Collections.Generic;


/// <summary>
/// Author: Nasir and Ryan 
/// This class handles in application database 
/// Here is where you get the database model, create questions and do things like that 
/// </summary>
public class DBController
{
    private DBModel _database;
    public DBController(DBModel database)
    {
        this._database = database;
    }

    /// <summary>
    /// This method returns the number of sections in the database 
    /// </summary>
    /// <returns></returns>
    public int GetSectionCount()
    {
        return _database.GetSectionCount();
    }

    /// <summary>
    /// This all the sections
    /// </summary>
    /// <returns></returns>
    public List<Section> GetSections()
    {
        return _database.GetSections();
    }

    /// <summary>
    /// This method gets the section of a given id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Section GetSection(int id)
    {
        return _database.GetSection(id);
    }

    /// <summary>
    /// This method adds a new section
    /// </summary>
    /// <param name="name"></param>
    public void AddSection(Section section)
    {
        if (section != null)
            _database.AddSection(section);
    }

    /// <summary>
    /// This method adds an anser to a given question
    /// </summary>
    /// <param name="currQuestion"></param>
    /// <param name="currAnswer"></param>
    public void AddAnswerToQuestion(Question currQuestion, Answer currAnswer)
    {
        currQuestion.AddAnswer(currAnswer);
    }

    /// <summary>
    /// This method adds questions to a given answer
    /// </summary>
    /// <param name="currQuestion"></param>
    /// <param name="currAnswers"></param>
    public void AddAnswersToQuestion(Question currQuestion, List<Answer> currAnswers)
    {
        currQuestion.AddAnswers(currAnswers);
    }

    /// <summary>
    /// This adds question to a section
    /// </summary>
    /// <param name="sectionID"></param>
    /// <param name="currQuestion"></param>
    public void AddQuestionToSection(int sectionId, Question currQuestion)
    {
        Section section = _database.GetSection(sectionId);
        if (section != null)
            section.AddQuestion(currQuestion);
    }

    /// <summary>
    /// This method adds questions to a section
    /// </summary>
    /// <param name="sectionID"></param>
    /// <param name="currQuestions"></param>
    public void AddQuestionsToSection(int sectionId, List<Question> currQuestions)
    {
        Section section = _database.GetSection(sectionId);
        if (section != null)
            section.AddQuestions(currQuestions);
    }

    /// <summary>
    /// This method updates a section
    /// </summary>
    /// <param name="sectionID"></param>
    /// <param name="newName"></param>
    public void UpdateSection(int sectionId, string newName)
    {
        Section section = _database.GetSection(sectionId);
        if (section != null)
            section.Name = newName;
    }
}

