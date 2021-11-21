using System;

public class Round
{
    private int _TotalPoints { get; set; }
    public int PointBucket { get; set; }
    private Question _CurrQuestion { get; set; }
    private int _CorrectAnswerCount { get; set; }
    private int _WrongAnswerCounter { get; set; }
    private Boolean _isStealing { get; set; }
    private Boolean _isRoundOver { get; set; }
    public Round(Question _CurrQuestion)
    {
        this._CurrQuestion = _CurrQuestion;
        _CorrectAnswerCount = _CurrQuestion.GetAnswerCount();
        _TotalPoints = _CurrQuestion.GetPointTotal();
        PointBucket = 0;
        _WrongAnswerCounter = 0;
        _isStealing = false;
        _isRoundOver = false;
    }
    /// <summary>
    /// This will will increase the _WrongAnswerCounter.
    /// If the there are three wrong answers from the first team then the _isStealing boolean will become true.
    /// </summary>
    public void WrongAnswer()
    {
        _WrongAnswerCounter++;
        if (_WrongAnswerCounter >= 3 && !_isRoundOver)
        {
            _isStealing = true;
        }
    }
    /// <summary>
    /// This will return the selected Answer.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Answer CorrectAnswer(int id)
    {
        Answer correctAnswer = _CurrQuestion.GetAnswer(id + 1);
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
    private void IsCurrentRoundOver()
    {
        if ((_WrongAnswerCounter >= 3 && _isStealing == false) || PointBucket == _TotalPoints)
        {
            _isRoundOver = true;
        }
    }
}
