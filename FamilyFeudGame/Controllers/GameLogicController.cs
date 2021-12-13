using FamilyFeudGame;
using FamilyFeudGame.Models;
using System;
using System.Collections.Generic;
/// <summary>
/// Built by Nasir Muhumed and Ryan Schauer 
/// This will handle all the functions dealing with the game.
/// The class will handle point additions, getting team info, switch the playing team, award points, and determine if the game is over.
/// </summary>
public class GameLogicController
{
    private Team[] _teams = new Team[2];
    public List<Question> questions = new();
    public bool showAnswers { get; set; }
    private int _currentTeamIndex { get; set; }
    private Question _playingQuestion { get; set; }
    public Round Round { get; set; }

    public GameLogicController(Section currSection, Team[] teams)
    {
        _teams = teams;
        questions = currSection.GetQuestions();
        showAnswers = false;
    }
    /// <summary>
    /// This will return the array that stores the two teams.
    /// </summary>
    /// <returns></returns>
    public Team[] GetTeams()
    {
        return _teams;
    }

    /// <summary>
    /// This method gives you current playing team index
    /// </summary>
    /// <returns></returns>
    public int GetCurrentPlayingTeamIndex() // Not in use!
    {
        return _currentTeamIndex;
    }
    /// <summary>
    /// This will return the round points
    /// </summary>
    /// <returns></returns>
    public int GetRoundPoints()
    {
        return Round.GetRoundPoints();
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
        _teams[0].IsPlaying = !_teams[0].IsPlaying;
        _teams[1].IsPlaying = !_teams[1].IsPlaying;
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
    public Answer CorrectAnswer(int id)
    {
        return Round.CorrectAnswer(id);
    }
    /// <summary>
    /// This will determine who gets the points added under the circumstances of the round ending.
    /// </summary>
    public void AwardPoints()
    {
        if (Round.IsRoundOver())
        {
            if (Round.IsRoundStolen())
            {
                AddPointsToStealingTeam(Round.GetRoundPoints());
            }
            else
            {
                AddPoints(Round.GetRoundPoints());
            }
        }
    }

    public Answer GetAnswer(int id) // Not in use!!
    {
        return _playingQuestion.GetAnswer(id);
    }
    /// <summary>
    /// This will call the WrongAnswer method in the round.
    /// </summary>
    public void WrongAnswer()
    {
        Round.WrongAnswer();
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
        return questions.Count == 0 && Round.IsRoundOver();
    }

    public bool GameIsNotOver() // What is this even for?
    {
        return !IsGameOver();
    }

    /// <summary>
    /// This will determine if there is a winner and it will return who it is or null if it is a tie.
    /// </summary>
    /// <returns></returns>
    public Team EndGame() // Not in use!
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
        if (_teams[0].IsPlaying)
        {
            _teams[0].AddPoints(points);
        }
        else
        {
            _teams[1].AddPoints(points);
        }
    }
    /// <summary>
    ///This will add points to the stealing team.
    ///The stealing team is the team that is NOT given the three chances. 
    /// </summary>
    /// <param name="points"></param>
    private void AddPointsToStealingTeam(int points)
    {
        if (_teams[0].IsPlaying)
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
        this.Round = new Round(question);
    }
    /// <summary>
    /// This will return if the round has ended or not.
    /// </summary>
    /// <returns></returns>
    public bool IsRoundOver()
    {
        return Round.IsRoundOver();
    }

}