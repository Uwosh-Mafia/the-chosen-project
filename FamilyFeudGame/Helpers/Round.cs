﻿using System;
/// <summary>
/// Built by Ryan Schauer and Nasir Muhumed.
/// This class handles each the required functions of each round.
/// </summary>
public class Round
{
    public int PointBucket { get; set; }
    private Question _question { get; set; }
    private int _answerCount { get; set; }
    private int _WrongAnswerCounter { get; set; }
    private Boolean _isStealing { get; set; }
    private Boolean isRoundOver { get; set; }
    public Round(Question question)
    {
        this._question = question;
        _answerCount = question.GetAnswerCount();
        PointBucket = 0;
        _WrongAnswerCounter = 0;
        _answerCount = 0;
        _isStealing = false;
        isRoundOver = false;
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
            _isStealing = true;
            //isRoundOver = true; //ALso this maybe it 
        } else if(_WrongAnswerCounter > 3)
        {
            isRoundOver = true;
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
            isRoundOver = true;
        } else if(_isStealing)
        {
            isRoundOver = true;
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
    public Boolean IsRoundOver() // Do we need this method since we don't call it 
    {
        return isRoundOver;
    }

    public Boolean IsRoundStolen()
    {
        return _isStealing;
    }
}