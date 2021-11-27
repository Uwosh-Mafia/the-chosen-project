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
using System.Windows.Threading;

namespace FamilyFeudGame
{
    /// <summary>
    /// Interaction logic for StudentGameWindow.xaml
    /// </summary>
    public partial class StudentGameWindow : Window
    {
        GameLogicController gameController;
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
                case 1:
                    StudentAnswer1.Text = answer.Text;
                    break;
                case 2:
                    StudentAnswer2.Text = answer.Text;
                    break;
                case 3:
                    StudentAnswer3.Text = answer.Text;
                    break;
                case 4:
                    StudentAnswer4.Text = answer.Text;
                    break;
                case 5:
                    StudentAnswer5.Text = answer.Text;
                    break;
                case 6:
                    StudentAnswer6.Text = answer.Text;
                    break;
                case 7:
                    StudentAnswer7.Text = answer.Text;
                    break;
                case 8:
                    StudentAnswer8.Text = answer.Text;
                    break;
            }
            UpdatePoints();
        }

        private void UpdatePoints()
        {
            Team[] teams = gameController.GetTeams();
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
            time.Interval = TimeSpan.FromSeconds(3);
            time.Start();
            time.Tick += delegate
            {
                time.Stop();
                wrongPopup.Visibility = Visibility.Collapsed;
            };
        }

    }
}
