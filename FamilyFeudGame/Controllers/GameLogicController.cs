using FamilyFeudGame.Models;
using System;
using System.Collections.Generic;

public class GameLogicController
{
    private Team[] _theTwoTeams = new Team[2];
    private Section _theChosenSection { get; set; }
    public List<Question> questions = new();
    public Boolean showAnswers { get; set; }
    public Boolean isGameOver { get; set; }
    private Boolean isRoundOver { get; set; }
    private Boolean isRoundNormal { get; set; }
    private int currentTeamIndex { get; set; }
    private Question playingQuestion { get; set; }
    private Round round { get; set; }

    public GameLogicController(Section currSection, Team teamOne, Team teamTwo, int currentTeamIndex)
    {
        _theTwoTeams[0] = teamOne;
        _theTwoTeams[1] = teamTwo;
        _theChosenSection = currSection;
        questions = _theChosenSection.GetQuestions();
        showAnswers = false;
        isGameOver = false;
        this.currentTeamIndex = currentTeamIndex;
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
        return round.GetRoundPoints();
    }

    public Question SetPlayingQuestion(int index)
    {
        playingQuestion = questions[index];
        return playingQuestion;
    }

    /// <summary>
    /// This will set the SelectQuestion and retrive the current Question.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public void PlayCurrentQuestion()
    {
        StartRound(playingQuestion);
        isRoundOver = false;
        DeleteCurrentQuestionFromTheList();
    }

    /// <summary>
    /// This returns the Correct Answer for the unput id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public void CorrectAnswer(int id)
    {
        if(round.IsRoundOver())
        {
            if (round.didRoundEndNormally())
            {
                round.CorrectAnswer(id);
                AddPoints(round.GetRoundPoints());
            }
            else
            {
                round.CorrectAnswer(id);
                AddPointsToStealingTeam(round.GetRoundPoints());
            }
        }
        else
        {
            round.CorrectAnswer(id);
        }
    }

    public Answer getAnswer(int id)
    {
        return playingQuestion.GetAnswer(id);
    }
    /// <summary>
    /// This will call the WrongAnswer method in the round.
    /// </summary>
    public void WrongAnswer()
    {
        if(round.IsRoundOver())
        {
            AddPoints(round.GetRoundPoints());
        } else
        {
            round.WrongAnswer();
        }
    }
    /// <summary>
    /// This will switch what team is currently playing
    /// </summary>
    public void TogglePlayingTeam()
    {
        currentTeamIndex = currentTeamIndex == 0 ? 1 : 0;
    }
    /// <summary>
    /// This will delete the question at an index
    /// </summary>
    /// <param name="questionIndex"></param>
    private void DeleteCurrentQuestionFromTheList()
    {
        questions.Remove(playingQuestion);
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
        _theTwoTeams[currentTeamIndex].AddPoints(points);
    }
    /// <summary>
    ///This will add points to the stealing team.
    ///The stealing team is the team that is NOT given the three chances. 
    /// </summary>
    /// <param name="points"></param>
    private void AddPointsToStealingTeam(int points)
    {
        if (currentTeamIndex == 0)
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
        this.round = new Round(question);
    }

    public bool IsRoundOver()
    {
        return round.IsRoundOver();
    }

}