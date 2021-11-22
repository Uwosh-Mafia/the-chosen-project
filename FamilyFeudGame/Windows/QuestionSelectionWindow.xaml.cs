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
        bool _isPlaying = false;
        int _wrongAnswerCount = 0;
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
            String[] sectionNames = new string[questions.Count];

            for (int i = 0; i < questions.Count; i++)
                sectionNames[i] = questions[i].Text;
            QuestionBox.ItemsSource = sectionNames;
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
            answer1.IsEnabled = toggle;
            answer2.IsEnabled = toggle;
            answer3.IsEnabled = toggle;
            answer4.IsEnabled = toggle;
            answer5.IsEnabled = toggle;
            answer6.IsEnabled = toggle;
            answer7.IsEnabled = toggle;
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
