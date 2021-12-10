using FamilyFeudGame;
using FamilyFeudGame.Models;
using System;
using System.Collections.Generic;

public class GameLogicController
{
    private Team[] _teams;
    private Section _theChosenSection { get; set; }
    public List<Question> questions = new();
    public bool showAnswers { get; set; }
    private int _currentQuestionIndex { get; set; }
    public bool isGameOver { get; set; }
    private int _currentTeamIndex { get; set; }
    private Round _currRound { get; set; }

    public GameLogicController(Section currSection, Team[] teams, int currentTeamIndex)
    {
        _teams = teams;
        _theChosenSection = currSection;
        questions = _theChosenSection.GetQuestions();
        showAnswers = false;
        _currentQuestionIndex = 0;
        isGameOver = false;
        _currentTeamIndex = currentTeamIndex;
    }

    public Team[] GetTeams()
    {
        return _teams;
    }
    /// <summary>
    /// This will return the round points
    /// </summary>
    /// <returns></returns>
    public int GetRoundPoints()
    {
        return _currRound.GetRoundPoints();
    }
    /// <summary>
    /// This will set the _currentQuestionIndex and retrive the current Question.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private Question SetCurrentQuestion(int id)
    {
        _currentQuestionIndex = id;
        return _theChosenSection.GetQuestion(id);
    }

    /// <summary>
    /// This returns the Correct Answer for the unput id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Answer CorrectAnswer(int id)
    {
        return _currRound.CorrectAnswer(id);
    }
    /// <summary>
    /// This will call the WrongAnswer method in the round.
    /// </summary>
    public void WrongAnswer()
    {
        _currRound.WrongAnswer();
    }
    /// <summary>
    /// This will switch what team is currently playing
    /// </summary>
    public void TogglePlayingTeam()
    {
        _currentTeamIndex = _currentTeamIndex == 0 ? 1 : 0;
    }
    /// <summary>
    /// This will delete the question at an index
    /// </summary>
    /// <param name="questionIndex"></param>
    private void DeleteQuestion(int questionIndex)
    {
        questions.RemoveAt(questionIndex);
    }
    /// <summary>
    /// This will enable the user to manually to end the game
    /// </summary>
    private void IsCurrGameOverManual()
    {
        isGameOver = true;
    }
    /// <summary>
    /// This will determine if the round is over. 
    /// It does this by counting how many quesitons are left in the questions list. 
    /// </summary>
    private void IsCurrGameOver()
    {
        if (questions.Count == 0)
        {
            isGameOver = true;
        }
    }
    /// <summary>
    /// This will open the results window and in turn, end the game.
    /// </summary>
    /// <returns></returns>
    public void EndGame()
    {
        ResultWindow resultWindow = new(_teams);
        resultWindow.Show();
    }
    /// <summary>
    /// This will add points to the playing team.
    /// The starting team or the three question team will be the _currentTeam
    /// </summary>
    /// <param name="points"></param>
    private void AddPoints(int points)
    {
        _teams[_currentTeamIndex].AddPoints(points);
    }
    /// <summary>
    ///This will add points to the stealing team.
    ///The stealing team is the team that is NOT given the three chances. 
    /// </summary>
    /// <param name="points"></param>
    private void AddPointsToStealingTeam(int points)
    {
        if (_currentTeamIndex == 0)
        {
            _teams[1].AddPoints(points);
        }
        else
        {
            _teams[0].AddPoints(points);
        }
    }
    /// <summary>
    /// This will start the game.
    /// Please not I'm a little confused on what this is suppose to do
    /// </summary>
    /// <param name="currRound"></param>
    public void StartRound(int questionId)
    {
        this._currRound = new(SetCurrentQuestion(questionId));
    }
}
