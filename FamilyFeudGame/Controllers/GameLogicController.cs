﻿using FamilyFeudGame.Models;
using System;
using System.Collections.Generic;

public class GameLogicController
{
    private Team[] _theTwoTeams = new Team[2];
    private Section _theChosenSection { get; set; }
    public List<Question> questions = new();
    public Boolean showAnswers { get; set; }
    public Boolean isGameOver { get; set; }
    private int _currentTeam { get; set; }
    private Round _currRound { get; set; }

    public GameLogicController(Section currSection, Team teamOne, Team teamTwo, int currentTeamIndex)
    {
        _theTwoTeams[0] = teamOne;
        _theTwoTeams[1] = teamTwo;
        _theChosenSection = currSection;
        questions = _theChosenSection.GetQuestions();
        showAnswers = false;
        isGameOver = false;
        _currentTeam = currentTeamIndex;
    }
    public Team[] GetTeams()
    {
        return _theTwoTeams;
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
    public void SelectQuestion(int id)
    {
        var question =  _theChosenSection.GetQuestion(id);
        StartRound(question);
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
        _currentTeam = _currentTeam == 0 ? 1 : 0;
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
    private void isCurrGameOverManual()
    {
        isGameOver = true;
    }
    /// <summary>
    /// This will determine if the round is over. 
    /// It does this by counting how many quesitons are left in the questions list. 
    /// </summary>
    private void isCurrGameOver()
    {
        if (questions.Count == 0)
        {
            isGameOver = true;
        }
    }

    public bool GameIsNotOver()
    {
        return !isGameOver;
    }
    /// <summary>
    /// This will determine if there is a winner and it will return who it is or null if it is a tie.
    /// </summary>
    /// <returns></returns>
    public Team EndGame()
    {
        int teamOnePoints = _theTwoTeams[0].GetPoints();
        int teamTwoPoints = _theTwoTeams[1].GetPoints();
        if (teamOnePoints == teamTwoPoints)
        {
            return null;
        }
        else
        {
            return teamOnePoints > teamTwoPoints ? _theTwoTeams[0] : _theTwoTeams[1];
        }

    }
    /// <summary>
    /// This will add points to the starting team.
    /// The starting team or the three question team will be the _currentTeam
    /// </summary>
    /// <param name="points"></param>
    private void AddPoints(int points)
    {
        _theTwoTeams[_currentTeam].AddPoints(points);
    }
    /// <summary>
    ///This will add points to the stealing team.
    ///The stealing team is the team that is NOT given the three chances. 
    /// </summary>
    /// <param name="points"></param>
    private void AddPointsToStealingTeam(int points)
    {
        if (_currentTeam == 0)
        {
            _theTwoTeams[1].AddPoints(points);
        }
        else
        {
            _theTwoTeams[0].AddPoints(points);
        }
    }
    /// <summary>
    /// This will start the game.
    /// Please not I'm a little confused on what this is suppose to do
    /// </summary>
    /// <param name="currRound"></param>
    public void StartRound(Question question)
    {
        this._currRound = new Round(question);
    }

    public bool RoundIsNotOver()
    {
        return !_currRound.isRoundOver;
    }


}
