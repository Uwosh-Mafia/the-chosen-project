using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace L8QuestionTesting
{
    [TestClass]
    public class QuestionTests
    {
        Answer answer1, answer2, answer3, answer4, answer5, answer6, answer7, answer8;
        List<Answer> answers;

        [TestInitialize]
        public void SetUp()
        {
            answer1 = new(1, "Nevada", 20);
            answer2 = new(2, "South Dakota", 19);
            answer3 = new(3, "Colorado", 16);
            answer4 = new(4, "North Dakota", 15);
            answer5 = new(5, "New York", 10);
            answer6 = new(6, "Wyoming", 8);
            answer7 = new(7, "Oregon", 6);
            answer8 = new(8, "Louisiana", 2);
            answers = new() { answer1, answer2, answer3, answer4, answer5, answer6, answer7, answer8 };
        }

        [TestMethod]
        public void TestEmptyGetAnswerCount()
        {
            Question question = new(1, "Name a state in the U.S. that is the most fun to visit");
            int expected = 0;
            int actual = question.GetAnswerCount();
            Assert.AreEqual(expected, actual, "The count of answers should be 0");
        }

        [TestMethod]
        public void TestNonEmptyGetAnswerCount()
        {
            Question question = new(1, "Name a state in the U.S. that is the most fun to visit");
            question.AddAnswer(answer1);
            question.AddAnswer(answer2);
            int expected = 2;
            int actual = question.GetAnswerCount();
            Assert.AreEqual(expected, actual, "The count of answers should be 2");
        }

        [TestMethod]
        public void TestAddAnswer()
        {
            Question question = new(1, "Name a state in the U.S. that is the most fun to visit");
            question.AddAnswer(answer1);
            Answer expected = answer1;
            Answer actual = question.GetAnswer(answer1.Id);
            Assert.AreEqual(expected, actual, "The answers added and the answer in question are not the same");
        }

        [TestMethod]
        public void TestNullGetAnswer()
        {
            Question question = new(1, "Name a state in the U.S. that is the most fun to visit");
            Answer expected = null;
            Answer actual = question.GetAnswer(answer1.Id);
            Assert.AreEqual(expected, actual, "There should be no answer returned");
        }

        [TestMethod]
        public void TestNonNullGetAnswer()
        {
            Question question = new(1, "Name a state in the U.S. that is the most fun to visit");
            question.AddAnswer(answer1);
            question.AddAnswer(answer2);
            Answer expected = answer2;
            Answer actual = question.GetAnswer(answer2.Id);
            Assert.AreEqual(expected, actual, "The answers returned should be the same");
        }

        [TestMethod]
        public void TestAddAnswers()
        {
            Question question = new(1, "Name a state in the U.S. that is the most fun to visit");
            question.AddAnswers(answers);
            int expected = answers.Count;
            int actual = question.GetAnswerCount();
            Assert.AreEqual(expected, actual, "The number of answers added and the number of answer in the question are not the same");
        }

        [TestMethod]
        public void TestEmptyGetAnswers()
        {
            Question question = new(1, "Name a state in the U.S. that is the most fun to visit");
            List<Answer> expected = question.GetAnswers();
            int actual = 0;
            Assert.AreEqual(expected.Count, actual, "The question answer list should be empty");
        }

        [TestMethod]
        public void TestNonEmptyGetAnswers()
        {
            Question question = new(1, "Name a state in the U.S. that is the most fun to visit");
            question.AddAnswers(answers);
            List<Answer> expected = question.GetAnswers();
            int actual = 8;
            Assert.AreEqual(expected.Count, actual, "The question answer list should contain 8 answers");
        }
    }
}
