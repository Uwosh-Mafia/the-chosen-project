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
    /// Interaction logic for TeamCreationWindow.xaml
    /// </summary>
    public partial class TeamCreationWindow : Window
    {
        private DBController dBController;
        public TeamCreationWindow(DBController controller)
        {
            InitializeComponent();
            dBController = controller;
        }

        private void BtnTeam1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (Team, Team) teams = createTeamsInOrder(team1First: true);
                CallSelectionWindow(teams.Item1, teams.Item2);
                Close();
            }
            catch (Exception)
            {
               showInvalidMassage();
            }
        }

        private void BtnTeam2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (Team, Team) teams = createTeamsInOrder(team1First: false);
                CallSelectionWindow(teams.Item1, teams.Item2);
                Close();
            }
            catch (Exception)
            {
                showInvalidMassage();
            }
        }

        private void showInvalidMassage()
        {
            MessageBox.Show($"Team Name Length must be more than 2 characters long and at max 20 characters.");
        }

        private (Team, Team) createTeamsInOrder(bool team1First)
        {
            if (!isNameValid(txtTeam1.Text))
                throw new Exception("Invalid Name");

            if (!isNameValid(txtTeam2.Text))
                throw new Exception("Invalid Name");

            Team team1 = new(txtTeam1.Text, team1First);
            Team team2 = new(txtTeam2.Text, !team1First);

            return team1First ? (team1, team2) : (team2, team1);
        }

        private void CallSelectionWindow(Team first, Team second)
        {
            SectionSelectionWindow sectionSelectionWindow = new(first, second, dBController);
            sectionSelectionWindow.Show();
        }

        private bool isNameValid(string name)
        {
            return name.Length > 2 && name.Length < 21 ;
        }

    }
}
