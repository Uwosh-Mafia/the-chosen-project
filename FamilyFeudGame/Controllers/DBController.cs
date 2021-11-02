using System;
using System.Collections.Generic;


/// <summary>
/// This class controlles the local database 
/// </summary>
public class DBController
{
    private DBModel database;
    public int sectionCount;
    private List<Section> sections = new();
    public DBController(DBModel database)
    {
        this.database = database;
    }

    /// <summary>
    /// This all the sections
    /// </summary>
    /// <returns></returns>
    public List<Section> GetSections()
    {
        return sections;
    }

    /// <summary>
    /// This method gets the section of a given id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Section GetSection(int id)
    {
      return sections.Find(section => section.Id == id);
    }

    /// <summary>
    /// This method creates a new section
    /// </summary>
    /// <param name="name"></param>
    public Section CreateSection(string name)
    {
        Section section = new Section(sectionCount, name);
        sections.Add(section);
        return section;
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
    public void AddQuestionToSection(int sectionID, Question currQuestion)
    {
        Section section = sections.Find(section => section.Id == sectionID);
        if (section != null) section.AddQuestion(currQuestion);

    }

    /// <summary>
    /// This method adds questions to a section
    /// </summary>
    /// <param name="sectionID"></param>
    /// <param name="currQuestions"></param>
    public void AddQuestionsToSection(int sectionID, List<Question> currQuestions)
    {
        Section section = sections.Find(section => section.Id == sectionID);
        if (section != null) section.AddQuestions(currQuestions);
    }

    /// <summary>
    /// This method updates a section
    /// </summary>
    /// <param name="sectionID"></param>
    /// <param name="newName"></param>
    public void UpdateSection(int sectionID, String newName)
    {
        Section section = sections.Find(section => section.Id == sectionID);
        if (section != null) section.Name = newName;
    }
}

