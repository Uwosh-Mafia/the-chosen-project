using FamilyFeudGame.Models;
using System;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace FamilyFeudGame
{
    /// <summary>
    /// Interaction logic for StudentGameWindow.xaml
    /// </summary>
    public partial class StudentGameWindow : Window
    {
        GameLogicController gameController;
        private SoundPlayer soundPlayer;
        public StudentGameWindow(GameLogicController gameController)
        {
            InitializeComponent();
            this.gameController = gameController;
            UpdatePoints();
        }

        public void FillAnswer(Answer answer)
        {
            switch (answer.Id) // ID's start at 1
            {
                case 1: // Still need to style --> maybe second box?
                    StudentAnswer1.Content = answer.Text + "\t" + answer.Points;
                    break;
                case 2:
                    StudentAnswer2.Content = answer.Text + "\t" + answer.Points;
                    break;
                case 3:
                    StudentAnswer3.Content = answer.Text + "\t" + answer.Points;
                    break;
                case 4:
                    StudentAnswer4.Content = answer.Text + "\t" + answer.Points;
                    break;
                case 5:
                    StudentAnswer5.Content = answer.Text + "\t" + answer.Points;
                    break;
                case 6:
                    StudentAnswer6.Content = answer.Text + "\t" + answer.Points;
                    break;
                case 7:
                    StudentAnswer7.Content = answer.Text + "\t" + answer.Points;
                    break;
                case 8:
                    StudentAnswer8.Content = answer.Text + "\t" + answer.Points;
                    break;
            }
            RoundPointsUpdate();
            UpdatePoints();
        }
        
        private void RoundPointsUpdate()
        {
            RoundScore.Text = gameController.GetRoundPoints().ToString();
        }

        private void UpdatePoints()
        {
            Team[] teams = gameController.GetTeams();
            if (teams[0].Name.Length >= 15) 
            {
                Team1Score.FontSize = 20;
                Team1Score.Margin = new Thickness(0, 23, 0, 0);
            }

            if (teams[1].Name.Length >= 15)
            {
                Team2Score.FontSize = 20;
                Team2Score.Margin = new Thickness(0, 23, 0, 0);
            }

            Team1Score.Text = teams[0].Name + ": " + teams[0].Points;
            Team2Score.Text = teams[1].Name + ": " + teams[1].Points;
        }

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

        private void PopupTimer(TextBlock wrongPopup)
        {
            DispatcherTimer time = new();
            string fileName = "Family Feud Sound Effects - #1 Main Game - #2 Strike.wav";
            string directory = Environment.CurrentDirectory;
            directory = directory.Substring(0, directory.IndexOf("\\bin")); // To get rid of bin\Debug\net5.0-windows\ part 
            string path = Path.Combine(directory, @"Windows\Sounds\", fileName);
            soundPlayer = new(path);
            soundPlayer.Load();
            soundPlayer.Play();
            time.Interval = TimeSpan.FromSeconds(1.2);
            time.Start();
            time.Tick += delegate
            {
                time.Stop();
                wrongPopup.Visibility = Visibility.Collapsed;
            };
        }

    }
}
