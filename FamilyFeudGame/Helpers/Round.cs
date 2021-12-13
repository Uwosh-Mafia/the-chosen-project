using FamilyFeudGame;
using System;

public class Round
{
    // private int _TotalPoints { get; set; }
    public int PointBucket { get; set; }
    private Question _question { get; set; }
    private int _answerCount { get; set; }
    private int _WrongAnswerCounter { get; set; }
    public bool IsStealing { get; set; }
    private bool _isRoundOver { get; set; }
    public Round(Question question)
    {
        this._question = question;
        _answerCount = question.GetAnswerCount();
        // _TotalPoints = question.GetPointTotal();
        PointBucket = 0;
        _WrongAnswerCounter = 0;
        _answerCount = 0;
        IsStealing = false;
        _isRoundOver = false;

    }
    /// <summary>
    /// This will will increase the _WrongAnswerCounter.
    /// If the there are three wrong answers from the first team then the _isStealing boolean will become true.
    /// </summary>
    public void WrongAnswer()
    {
        _WrongAnswerCounter++;
        //_answerCount++;//This maybe the issue
        if (_WrongAnswerCounter == 3)
        {
            IsStealing = true;
            //isRoundOver = true; //ALso this maybe it 
        } else if(_WrongAnswerCounter > 3)
        {
            _isRoundOver = true;
        }
    }
    /// <summary>
    /// This will return the selected Answer.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Answer CorrectAnswer(int id)
    {
        _answerCount++;
        if (_answerCount == _question.GetAnswerCount())
        {
            _isRoundOver = true;
        } else if(IsStealing)
        {
            _isRoundOver = true;
        }
        Answer correctAnswer = _question.GetAnswer(id);
        PointBucket += correctAnswer.ReturnPoints();
        return correctAnswer;
    }
    /// <summary>
    /// This will return the total value of the point bucket
    /// </summary>
    /// <returns></returns>
    public int GetRoundPoints()
    {
        return PointBucket;
    }
    /// <summary>
    /// This will determine if the current round is over. 
    /// </summary>
    public bool IsRoundOver() // Do we need this method since we don't call it 
    {
        return _isRoundOver;
    }

    public bool IsRoundStolen()
    {
        return IsStealing;
    }
}