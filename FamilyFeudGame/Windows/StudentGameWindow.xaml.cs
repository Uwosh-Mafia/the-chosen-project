using FamilyFeudGame.Models;
using System;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace FamilyFeudGame
{
    /// <summary>
    /// Interaction logic for StudentGameWindow.xaml
    /// </summary>
    public partial class StudentGameWindow : Window
    {
        GameLogicController gameController;
        private SoundPlayer _soundPlayer;
        private Team[] _teams;
        public StudentGameWindow(GameLogicController gameController)
        {
            InitializeComponent();
            this.gameController = gameController;
            _teams = gameController.GetTeams();
            ShowTeamNames();
            UpdatePoints();
            SetBackgroundColor();
        }

        /// <summary>
        /// This will take in the answer ID from the Teacher Game window. 
        /// Once an answer is selected from the answer and point value will be visible to the class.
        /// </summary>
        /// <param name="answer"></param>
        public void FillAnswer(Answer answer)
        {
            switch (answer.Id)
            {
                case 1:
                    StudentAnswer1.Content = answer.Text;
                    Answer1PointsImg.Visibility = Visibility.Hidden;
                    Answer1Points.Content = answer.Points.ToString();
                    break;
                case 2:
                    StudentAnswer2.Content = answer.Text;
                    Answer2PointsImg.Visibility = Visibility.Hidden;
                    Answer2Points.Content = answer.Points.ToString();
                    break;
                case 3:
                    StudentAnswer3.Content = answer.Text;
                    Answer3PointsImg.Visibility = Visibility.Hidden;
                    Answer3Points.Content = answer.Points.ToString();
                    break;
                case 4:
                    StudentAnswer4.Content = answer.Text;
                    Answer4PointsImg.Visibility = Visibility.Hidden;
                    Answer4Points.Content = answer.Points.ToString();
                    break;
                case 5:
                    StudentAnswer5.Content = answer.Text;
                    Answer5PointsImg.Visibility = Visibility.Hidden;
                    Answer5Points.Content = answer.Points.ToString();
                    break;
                case 6:
                    StudentAnswer6.Content = answer.Text;
                    Answer6PointsImg.Visibility = Visibility.Hidden;
                    Answer6Points.Content = answer.Points.ToString();
                    break;
                case 7:
                    StudentAnswer7.Content = answer.Text;
                    Answer7PointsImg.Visibility = Visibility.Hidden;
                    Answer7Points.Content = answer.Points.ToString();
                    break;
                case 8:
                    StudentAnswer8.Content = answer.Text;
                    Answer8PointsImg.Visibility = Visibility.Hidden;
                    Answer8Points.Content = answer.Points.ToString();
                    break;
            }
            RoundPointsUpdate();
            if(gameController.IsRoundOver())
            {
                UpdatePoints();
            }
        }


        /// <summary>
        /// This method clears all answers 
        /// </summary>
        public void ClearAnswers()
        {
            StudentAnswer1.Content = "";
            Answer1PointsImg.Visibility = Visibility.Visible;
            Answer1Points.Content = "";
  
             StudentAnswer2.Content = "";
            Answer2PointsImg.Visibility = Visibility.Visible;
            Answer2Points.Content = "";
     
            StudentAnswer3.Content = "";
            Answer3PointsImg.Visibility = Visibility.Visible;
            Answer3Points.Content = "";
 
            StudentAnswer4.Content = "";
            Answer4PointsImg.Visibility = Visibility.Visible;
            Answer4Points.Content = "";

            StudentAnswer5.Content = "";
            Answer5PointsImg.Visibility = Visibility.Visible;
            Answer5Points.Content = "";
           
            StudentAnswer6.Content = "";
            Answer6PointsImg.Visibility = Visibility.Visible;
            Answer6Points.Content = "";
          
            StudentAnswer7.Content = "";
            Answer7PointsImg.Visibility = Visibility.Visible;
            Answer7Points.Content = "";
           
            StudentAnswer8.Content = "";
            Answer8PointsImg.Visibility = Visibility.Visible;
            Answer8Points.Content = "";
        }
        /// <summary>
        /// This will update the point total for the round.
        /// These points are not assigned to a team yet, but they what the team that wins the round will recieve. 
        /// </summary>
        private void RoundPointsUpdate()
        {
            RoundScore.Text = gameController.GetRoundPoints().ToString();
        }
        /// <summary>
        /// This will show the team names on the student view.
        /// It will modify the size and location of the text if its character count is higher.
        /// </summary>
        private void ShowTeamNames()
        {
            Team1.Text = _teams[0].Name.ToUpper();
            Team2.Text = _teams[1].Name.ToUpper();
        }

        /// <summary>
        /// Changes the team that is playing
        /// </summary>
        private void ToggleTeamPlaying()
        {
            _teams[0].IsPlaying = !_teams[0].IsPlaying;
            _teams[1].IsPlaying = !_teams[1].IsPlaying;
            SetBackgroundColor();
        }

        /// <summary>
        /// Changes the background color to the team that is playing
        /// </summary>
        private void SetBackgroundColor()
        {
            var bc = new BrushConverter();

            if (_teams[0].IsPlaying)
            {
                Team1.Background = (Brush)bc.ConvertFrom("#fc0");
                Team1.Foreground = Brushes.Black;
            }
            else
            {
                Team2.Background = (Brush)bc.ConvertFrom("#fc0");
                Team2.Foreground = Brushes.Black;
            }
        }
        /// <summary>
        /// This will update the team points once the round is completed.
        /// </summary>
        public void UpdatePoints()
        {
            Team1Score.Text = $"{_teams[0].Points}";
            Team2Score.Text = $"{_teams[1].Points}";
        }
        /// <summary>
        /// This method displays the Xs on the screen.
        /// It will also call the method that plays the worng answer buzzer. 
        /// </summary>
        /// <param name="amountWrong"></param>
        public void DisplayWrong(int amountWrong)
        {
            switch(amountWrong)
            {
                case 1:
                    OneWrong.Visibility = Visibility.Visible;
                    PopupTimer(OneWrong);
                    break;
                case 2:
                    TwoWrong.Visibility = Visibility.Visible;
                    PopupTimer(TwoWrong);
                    break;
                case 3:
                    ThreeWrong.Visibility = Visibility.Visible;
                    PopupTimer(ThreeWrong);
                    break;
            }
        }
        /// <summary>
        /// This will play the wrong answer buzz. 
        /// </summary>
        /// <param name="wrongPopup"></param>
        private void PopupTimer(TextBlock wrongPopup)
        {
            DispatcherTimer time = new();
            string fileName = "Family Feud Sound Effects - #1 Main Game - #2 Strike.wav";
            string directory = Environment.CurrentDirectory;
            directory = directory.Substring(0, directory.IndexOf("\\bin")); // To get rid of bin\Debug\net5.0-windows\ part 
            string path = Path.Combine(directory, @"Windows\Sounds\", fileName);
            _soundPlayer = new(path);
            _soundPlayer.Load();
            _soundPlayer.Play();
            time.Interval = TimeSpan.FromSeconds(1.2);
            time.Start();
            time.Tick += delegate
            {
                time.Stop();
                wrongPopup.Visibility = Visibility.Collapsed;
            };
        }
        /// <summary>
        /// This will show all the info needed on the the screen once a round is over
        /// </summary>
        public void RoundOverFill()
        {
            RoundPointsUpdate();
            UpdatePoints();

        }

    }
}
