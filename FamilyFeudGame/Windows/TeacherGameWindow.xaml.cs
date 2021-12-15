using FamilyFeudGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Main Contributor: Bentley Epple
    /// Interaction logic for TeacherGameWindow.xaml
    /// </summary>
    public partial class TeacherGameWindow : Window
    {
        GameLogicController gameController;
        StudentGameWindow studentGameWindow;
        Question playingQuestion;
        private int _wrongAnswerCount = 0;
        private int _answerCount;
        private bool firstClick = true;
        private SoundPlayer _soundPlayer;

        public TeacherGameWindow(GameLogicController gameController, StudentGameWindow studentGameWindow)
        {
            InitializeComponent();
            this.gameController = gameController;
            this.studentGameWindow = studentGameWindow;
            PopulateQuestions(); // Displays the question and answers to teacher
            ToggleAnswers(false); // Disables answer buttons
            Incorrect_Button.IsEnabled = false;
            Play_Button.IsEnabled = false;
        }

        /// <summary>
        /// This method populates the questions
        /// </summary>
        private void PopulateQuestions()
        {
            
            List<Question> questions = gameController.questions;
            string[] questionNames = new string[questions.Count];

            for (int i = 0; i < questions.Count; i++)
                questionNames[i] = questions[i].Text;
            QuestionBox.ItemsSource = questionNames;
        }
        /// <summary>
        /// This will allow the game host to change the question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Incorrect_Button.IsEnabled == false || firstClick == true)
            {
                Play_Button.IsEnabled = true;
                firstClick = false;
            }
            
            int index = (sender as ListBox).SelectedIndex;
            if (index > -1 && Play_Button.IsEnabled == true)
            {
                ClearAnswers();
                this.playingQuestion = gameController.SetPlayingQuestion(index);
                FillAnswers(playingQuestion.GetAnswers());
                question_text.Text = playingQuestion.Text;
            }
            
        }
        /// <summary>
        /// This will clear the answers on each of the buttons once the round is over. 
        /// </summary>
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
        /// <summary>
        /// Once a question is selected and being played this will fill in the buttons the game host can select from. 
        /// </summary>
        /// <param name="answers"></param>
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
        /// <summary>
        /// This will allow the game host to select the correct answer once.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CorrectAnswer(object sender, RoutedEventArgs e)
        {
            // Get answer number fromt the name of the button
            string answerNumber = (sender as Button).Name;
            int.TryParse(answerNumber.Substring(6), out int index);

            /* Sound Effects */
            string fileName = "Family Feud Sound Effects - #1 Main Game - #2 Revealing Answer.wav";
            string directory = Environment.CurrentDirectory;
            directory = directory.Substring(0, directory.IndexOf("\\bin")); // To get rid of bin\Debug\net5.0-windows\ part 
            string path = System.IO.Path.Combine(directory, @"Windows\Sounds\", fileName);
            _soundPlayer = new(path);
            _soundPlayer.Load();
            _soundPlayer.Play();
            /* Sound Effects */

            // Send answer to student view
            Answer correctAnswer = gameController.CorrectAnswer(index);
            studentGameWindow.FillAnswer(correctAnswer);
            DisableAnswer(correctAnswer.Id); // Disable the answer
            if(gameController.IsRoundOver())
            {
                // Check if round is over
                RoundOver();
            }
            if (gameController.IsGameOver())
            {
                // Check if game is over
                ShowResultWindow();
            }
        }

        /// <summary>
        /// This method shows the result window and closes the teacher and student view
        /// </summary>
        private void ShowResultWindow()
        {
            Team[] teams = gameController.GetTeams();
            ResultWindow resultWindow = new ResultWindow(teams[0], teams[1]);
            resultWindow.Show();
            studentGameWindow.Close();
            Close();
        }

        /// <summary>
        /// The game host will select this when the playing team says a wrong answer. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wrong_Answer(object sender, RoutedEventArgs e)
        {
            gameController.WrongAnswer();
            _wrongAnswerCount++;

            /* Sound Effects */
            string fileName = "Family Feud Sound Effects - #1 Main Game - #2 Strike.wav";
            string directory = Environment.CurrentDirectory;
            directory = directory.Substring(0, directory.IndexOf("\\bin")); // To get rid of bin\Debug\net5.0-windows\ part 
            string path = System.IO.Path.Combine(directory, @"Windows\Sounds\", fileName);
            _soundPlayer = new(path);
            _soundPlayer.Load();
            _soundPlayer.Play();
            /* Sound Effects */

            if (gameController.Round.IsStealing)
            {
                // Switch to stealing team if the round is stolen
                studentGameWindow.SetTeamColor(true);
            }

            studentGameWindow.DisplayWrong(_wrongAnswerCount);
            if (gameController.IsRoundOver())
            {
                // Check if round is over
                RoundOver();
            }
            if(gameController.IsGameOver())
            {
                // Check if game is over
                ShowResultWindow();
            }
        }

        /// <summary>
        /// This method disables all answers 
        /// </summary>
        private void DisableAllAnswers()
        {
            for (int i = 1; i < 9; i++)
                DisableAnswer(i);
        }

        /// <summary>
        /// This function disables select answers
        /// </summary>
        private void DisableAnswer(int id)
        {
            switch (id)
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
                default:
                    break;
            }
        }
        /// <summary>
        /// This method will allow the game host to play the selected question.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Play_Question(object sender, RoutedEventArgs e)
        {
            // Start round with question
            gameController.PlayCurrentQuestion();
            // Display question on student view
            studentGameWindow.question_box.Text = playingQuestion.Text;
            // Disable Play and enable Incorrect buttons
            Play_Button.IsEnabled = false;
            Incorrect_Button.IsEnabled = true;
            // Enable Answer buttons
            ToggleAnswers(true);
            // Repopulate question list with currently playing question removed
            PopulateQuestions();
            _wrongAnswerCount = 0;
            studentGameWindow.ClearAnswers();
            studentGameWindow.FillAnswerAmount(playingQuestion.GetAnswerCount());
            studentGameWindow.RoundScore.Text = "0";
            studentGameWindow.SetTeamColor(false);
        }
        /// <summary>
        /// This method allows the buttons to be toggled on and off.
        /// It acts like a filter. 
        /// It allows all the falses and only the required number of trues. 
        /// </summary>
        /// <param name="toggle"></param>
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

        /// <summary>
        /// This will allow the game host to manually end the game before every question has been answered. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            ShowResultWindow();
        }

        /// <summary>
        /// This will allow us to see all the final results once the round has ended.
        /// </summary>
        private void RoundOver()
        {
            // Award points
            gameController.AwardPoints();
            // Disable Incorrect and Answer buttons
            Incorrect_Button.IsEnabled = false;
            DisableAllAnswers();
            List<Answer> finalAnswerList = playingQuestion.GetAnswers();
            for (int i = 0; i < finalAnswerList.Count; i++)
            {
                // Fill in answers on student view
                studentGameWindow.FillAnswer(finalAnswerList[i]);
            }
        }
    }
}