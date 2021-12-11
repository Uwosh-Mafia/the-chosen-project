using FamilyFeudGame;
using FamilyFeudGame.Models;
using System;
using System.Collections.Generic;

public class GameLogicController
{
<<<<<<< HEAD
    private Team[] _teams = new Team[2];
    public List<Question> questions = new();
    public Boolean showAnswers { get; set; }
    private int currentTeamIndex { get; set; }
    private Question playingQuestion { get; set; }
    private Round round { get; set; }
=======
    private Team[] _teams;
    private Section _theChosenSection { get; set; }
    public List<Question> questions = new();
    public bool showAnswers { get; set; }
    private int _currentQuestionIndex { get; set; }
    public bool isGameOver { get; set; }
    private int _currentTeamIndex { get; set; }
    private Round _currRound { get; set; }
>>>>>>> 57ed2c1f8eb73478fde67380bb88f2acf19ee048

    public GameLogicController(Section currSection, Team[] teams, int currentTeamIndex)
    {
<<<<<<< HEAD
        _teams[0] = teamOne;
        _teams[1] = teamTwo;
        questions = currSection.GetQuestions();
        showAnswers = false;
        this.currentTeamIndex = currentTeamIndex;
=======
        _teams = teams;
        _theChosenSection = currSection;
        questions = _theChosenSection.GetQuestions();
        showAnswers = false;
        _currentQuestionIndex = 0;
        isGameOver = false;
        _currentTeamIndex = currentTeamIndex;
>>>>>>> 57ed2c1f8eb73478fde67380bb88f2acf19ee048
    }

    public Team[] GetTeams()
    {
        return _teams;
<<<<<<< HEAD
    }

    /// <summary>
    /// This method gives you current playing team index
    /// </summary>
    /// <returns></returns>
    public int GetCurrentPlayingTeamIndex()
    {
        return currentTeamIndex;
=======
>>>>>>> 57ed2c1f8eb73478fde67380bb88f2acf19ee048
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
        DeleteCurrentQuestionFromTheList();
        if (!IsFirstRound()) TogglePlayingTeam();
    }

    /// <summary>
    /// This will switch what team is currently playing
    /// </summary>
    public void TogglePlayingTeam()
    {
        currentTeamIndex = currentTeamIndex == 0 ? 1 : 0;
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
<<<<<<< HEAD
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
=======
        _currentTeamIndex = _currentTeamIndex == 0 ? 1 : 0;
>>>>>>> 57ed2c1f8eb73478fde67380bb88f2acf19ee048
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
    /// This will delete the question at an index
    /// </summary>
<<<<<<< HEAD
    /// <param name="questionIndex"></param>
    private void DeleteCurrentQuestionFromTheList()
=======
    private void IsCurrGameOverManual()
>>>>>>> 57ed2c1f8eb73478fde67380bb88f2acf19ee048
    {
        questions.Remove(playingQuestion);
    }

    /// <summary>
    /// This will determine if the round is over. 
    /// It does this by counting how many quesitons are left in the questions list. 
    /// </summary>
<<<<<<< HEAD
    public bool IsGameOver()
=======
    private void IsCurrGameOver()
>>>>>>> 57ed2c1f8eb73478fde67380bb88f2acf19ee048
    {
        return questions.Count == 0;
    }

    public bool GameIsNotOver()
    {
        return !IsGameOver();
    }
    /// <summary>
    /// This will open the results window and in turn, end the game.
    /// </summary>
    /// <returns></returns>
    public void EndGame()
    {
<<<<<<< HEAD
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

=======
        ResultWindow resultWindow = new(_teams);
        resultWindow.Show();
>>>>>>> 57ed2c1f8eb73478fde67380bb88f2acf19ee048
    }
    /// <summary>
    /// This will add points to the playing team.
    /// The starting team or the three question team will be the _currentTeam
    /// </summary>
    /// <param name="points"></param>
    private void AddPoints(int points)
    {
<<<<<<< HEAD
        _teams[currentTeamIndex].AddPoints(points);
=======
        _teams[_currentTeamIndex].AddPoints(points);
>>>>>>> 57ed2c1f8eb73478fde67380bb88f2acf19ee048
    }
    /// <summary>
    ///This will add points to the stealing team.
    ///The stealing team is the team that is NOT given the three chances. 
    /// </summary>
    /// <param name="points"></param>
    private void AddPointsToStealingTeam(int points)
    {
<<<<<<< HEAD
        if (currentTeamIndex == 0)
=======
        if (_currentTeamIndex == 0)
>>>>>>> 57ed2c1f8eb73478fde67380bb88f2acf19ee048
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
        this.round = new Round(question);
    }

    public bool IsRoundOver()
    {
<<<<<<< HEAD
        return round.IsRoundOver();
=======
        this._currRound = new(SetCurrentQuestion(questionId));
>>>>>>> 57ed2c1f8eb73478fde67380bb88f2acf19ee048
    }

}