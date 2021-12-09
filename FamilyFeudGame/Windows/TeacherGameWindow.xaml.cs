using FamilyFeudGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FamilyFeudGame
{
    /// <summary>
    /// Interaction logic for QuestionSelectionWindow.xaml
    /// </summary>
    public partial class QuestionSelectionWindow : Window
    {
        DBController dBController;
        GameLogicController gameController;
        StudentGameWindow studentGameWindow;
        Section section;
        Question question;
        private bool _isPlaying = false;
        private int _wrongAnswerCount = 0;
        private int _answerCount;

        public QuestionSelectionWindow(Section section, DBController controller, GameLogicController gameController, StudentGameWindow studentGameWindow)
        {
            InitializeComponent();
            this.dBController = controller;
            this.gameController = gameController;
            this.section = section;
            this.studentGameWindow = studentGameWindow;
            PopulateQuestions();
            ToggleAnswers(false);
            Wrong_Button.IsEnabled = false;
        }

        /// <summary>
        /// This method populates the questions
        /// </summary>
        private void PopulateQuestions()
        {
            List<Question> questions = section.GetQuestions();
            string[] questionNames = new string[questions.Count];

            for (int i = 0; i < questions.Count; i++)
                questionNames[i] = questions[i].Text;
            QuestionBox.ItemsSource = questionNames;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_isPlaying)
            {
                ClearAnswers();
                int index = (sender as ListBox).SelectedIndex;
                this.question = section.GetQuestions()[index];
                FillAnswers(question.GetAnswers());
                question_text.Text = question.Text;
            }
        }
        private void ClearAnswers()
        {
            answer1.Content = "";
            answer2.Content = "";
            answer3.Content = "";
            answer4.Content = "";
            answer5.Content = "";
            answer6.Content = "";
            answer7.Content = "";
            answer8.Content = "";
        }

        private void FillAnswers(List<Answer> answers)
        {
            _answerCount = answers.Count;
            for (int i = 0; i < answers.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        answer1.Content = answers[i].Text;
                        break;
                    case 1:
                        answer2.Content = answers[i].Text;
                        break;
                    case 2:
                        answer3.Content = answers[i].Text;
                        break;
                    case 3:
                        answer4.Content = answers[i].Text;
                        break;
                    case 4:
                        answer5.Content = answers[i].Text;
                        break;
                    case 5:
                        answer6.Content = answers[i].Text;
                        break;
                    case 6:
                        answer7.Content = answers[i].Text;
                        break;
                    case 7:
                        answer8.Content = answers[i].Text;
                        break;
                }
            }
        }

        private void CorrectAnswer(object sender, RoutedEventArgs e)
        {
            string answerNumber = (sender as Button).Name;
            int.TryParse(answerNumber.Substring(6), out int index); // Add a check to see if parse succeeded
            Answer correctAnswer = gameController.CorrectAnswer(index);
            studentGameWindow.FillAnswer(correctAnswer);
            switch (correctAnswer.Id)
            {
                case 1:
                    answer1.IsEnabled = false;
                    break;
                case 2:
                    answer2.IsEnabled = false;
                    break;
                case 3:
                    answer3.IsEnabled = false;
                    break;
                case 4:
                    answer4.IsEnabled = false;
                    break;
                case 5:
                    answer5.IsEnabled = false;
                    break;
                case 6:
                    answer6.IsEnabled = false;
                    break;
                case 7:
                    answer7.IsEnabled = false;
                    break;
                case 8:
                    answer8.IsEnabled = false;
                    break;
            }
        }

        private void Play_Question(object sender, RoutedEventArgs e)
        {
            gameController.StartRound(question.Id);
            studentGameWindow.question_box.Text = question.Text;
            Play_Button.IsEnabled = false;
            _isPlaying = true;
            Wrong_Button.IsEnabled = true;
            ToggleAnswers(true);
        }

        private void ToggleAnswers(bool toggle)
        {
            if (_answerCount >= 1 || toggle == false)
                answer1.IsEnabled = toggle;

            if (_answerCount >= 2 || toggle == false)
                answer2.IsEnabled = toggle;

            if (_answerCount >= 3 || toggle == false)
                answer3.IsEnabled = toggle;

            if (_answerCount >= 4 || toggle == false)
                answer4.IsEnabled = toggle;

            if (_answerCount >= 5 || toggle == false)
                answer5.IsEnabled = toggle;

            if (_answerCount >= 6 || toggle == false)
                answer6.IsEnabled = toggle;

            if (_answerCount >= 7 || toggle == false)
                answer7.IsEnabled = toggle;

            if (_answerCount >= 8 || toggle == false)
                answer8.IsEnabled = toggle;
        }

        private void Wrong_Answer(object sender, RoutedEventArgs e)
        {
            gameController.WrongAnswer();
            _wrongAnswerCount++;
            studentGameWindow.DisplayWrong(_wrongAnswerCount);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Team[] teams = gameController.GetTeams();
            SectionSelectionWindow selectionWindow = new(teams[0], teams[1], dBController);
            Close();
            studentGameWindow.Close();
        }

        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            gameController.EndGame();
            Close();
            studentGameWindow.Close();
        }
    }
}
