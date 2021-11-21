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
    /// Interaction logic for StudentGameWindow.xaml
    /// </summary>
    public partial class StudentGameWindow : Window
    {
        GameLogicController gameController;
        public StudentGameWindow(GameLogicController gameController)
        {
            InitializeComponent();
            this.gameController = gameController;
            Team[] teams = gameController.GetTeams();
            Team1Score.Text = teams[0].Name + ": " + teams[0].Points;
            Team2Score.Text = teams[1].Name + ": " + teams[1].Points;
        }

        public void FillAnswer(Answer answer)
        {
            switch (answer.Id)
            {
                case 0:
                    StudentAnswer1.Text = answer.Text;
                    break;
                case 1:
                    StudentAnswer2.Text = answer.Text;
                    break;
                case 2:
                    StudentAnswer3.Text = answer.Text;
                    break;
                case 3:
                    StudentAnswer4.Text = answer.Text;
                    break;
                case 4:
                    StudentAnswer5.Text = answer.Text;
                    break;
                case 5:
                    StudentAnswer6.Text = answer.Text;
                    break;
                case 6:
                    StudentAnswer7.Text = answer.Text;
                    break;
                case 7:
                    StudentAnswer8.Text = answer.Text;
                    break;
            }
        }

    }
}
