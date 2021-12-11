using FamilyFeudGame.Models;
using System;
using System.Collections.Generic;
/// <summary>
/// Created by Nasir Muhumed and Ryan Schauer 
/// This is the controller that interacts with the teacher view. 
/// Its responible for anything related to playing the game.
/// </summary>
public class GameLogicController
{
    private Team[] _teams = new Team[2];
    public List<Question> questions = new();
    public bool showAnswers { get; set; }
    private int _currentTeamIndex { get; set; }
    private Question _playingQuestion { get; set; }
    private Round _round { get; set; }

    public GameLogicController(Section currSection, Team[] teams)
    {
        _teams = teams;
        questions = currSection.GetQuestions();
        showAnswers = false;
    }
    public Team[] GetTeams()
    {
        return _teams;
    }

    /// <summary>
    /// This method gives you current playing team index
    /// </summary>
    /// <returns></returns>
    public int GetCurrentPlayingTeamIndex()
    {
        return _currentTeamIndex;
    }
    /// <summary>
    /// This will return the round points
    /// </summary>
    /// <returns></returns>
    public int GetRoundPoints()
    {
        return _round.GetRoundPoints();
    }

    public Question SetPlayingQuestion(int index)
    {
        _playingQuestion = questions[index];
        return _playingQuestion;
    }

    /// <summary>
    /// This will set the SelectQuestion and retrive the current Question.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public void PlayCurrentQuestion()
    {
        StartRound(_playingQuestion);
        DeleteCurrentQuestionFromTheList();
        if (!IsFirstRound()) TogglePlayingTeam();
    }

    /// <summary>
    /// This will switch what team is currently playing
    /// </summary>
    public void TogglePlayingTeam()
    {
        _currentTeamIndex = _currentTeamIndex == 0 ? 1 : 0;
    }

    /// <summary>
    /// This method checks if it is the first round 
    /// </summary>
    /// <returns></returns>
    private bool IsFirstRound()
    {
        return _teams[0].GetPoints() == 0 && _teams[1].GetPoints() == 0;
    }

    /// <summary>
    /// This returns the Correct Answer for the unput id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public void CorrectAnswer(int id)
    {
        if (_round.IsRoundOver())
        {
            if (_round.didRoundEndNormally())
            {
                _round.CorrectAnswer(id);
                AddPoints(_round.GetRoundPoints());
            }
            else
            {
                _round.CorrectAnswer(id);
                AddPointsToStealingTeam(_round.GetRoundPoints());
            }
        }
        else
        {
            _round.CorrectAnswer(id);
        }
    }

    public Answer getAnswer(int id)
    {
        return _playingQuestion.GetAnswer(id);
    }
    /// <summary>
    /// This will call the WrongAnswer method in the round.
    /// </summary>
    public void WrongAnswer()
    {
        if (_round.IsRoundOver())
        {
            AddPoints(_round.GetRoundPoints());
        }
        else
        {
            _round.WrongAnswer();
        }
    }

    /// <summary>
    /// This will delete the question at an index
    /// </summary>
    /// <param name="questionIndex"></param>
    private void DeleteCurrentQuestionFromTheList()
    {
        questions.Remove(_playingQuestion);
    }

    /// <summary>
    /// This will determine if the round is over. 
    /// It does this by counting how many quesitons are left in the questions list. 
    /// </summary>
    public bool IsGameOver()
    {
        return questions.Count == 0;
    }

    public bool GameIsNotOver()
    {
        return !IsGameOver();
    }
    /// <summary>
    /// This will determine if there is a winner and it will return who it is or null if it is a tie.
    /// </summary>
    /// <returns></returns>
    public Team EndGame()
    {
        int teamOnePoints = _teams[0].GetPoints();
        int teamTwoPoints = _teams[1].GetPoints();
        if (teamOnePoints == teamTwoPoints)
        {
            return null;
        }
        else
        {
            return teamOnePoints > teamTwoPoints ? _teams[0] : _teams[1];
        }

    }
    /// <summary>
    /// This will add points to the starting team.
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
    public void StartRound(Question question)
    {
        this._round = new Round(question);
    }

    public bool IsRoundOver()
    {
        return _round.IsRoundOver();
    }

}