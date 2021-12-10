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
        private DBController _dBController;
        public TeamCreationWindow(DBController controller)
        {
            InitializeComponent();
            _dBController = controller;
        }
        /// <summary>
        /// This will upload both teams and allow the first team to play first. 
        /// This will close the window and go to the next stage of the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTeam1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (Team, Team) teams = CreateTeamsInOrder(team1First: true);
                CallSelectionWindow(teams.Item1, teams.Item2);
                Close();
            }
            catch (Exception)
            {
               ShowInvalidMassage();
            }
        }
        /// <summary>
        /// This will upload both teams and allow the second team to play first. 
        /// This will close the current window and go to the next stage of the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTeam2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (Team, Team) teams = CreateTeamsInOrder(team1First: false);
                CallSelectionWindow(teams.Item1, teams.Item2);
                Close();
            }
            catch (Exception)
            {
                ShowInvalidMassage();
            }
        }
        /// <summary>
        /// This will show a message box saying the user inputed name is in valid.
        /// </summary>
        private void ShowInvalidMassage()
        {
            MessageBox.Show($"Team Name Length must be more than 2 characters long and at max 20 characters.");
        }
        /// <summary>
        /// This will create the teams based on the user input.
        /// </summary>
        /// <param name="team1First"></param>
        /// <returns></returns>
        private (Team, Team) CreateTeamsInOrder(bool team1First)
        {
            if (!IsNameValid(txtTeam1.Text))
                throw new Exception("Invalid Name");

            if (!IsNameValid(txtTeam2.Text))
                throw new Exception("Invalid Name");

            Team team1 = new(txtTeam1.Text, team1First);
            Team team2 = new(txtTeam2.Text, !team1First);

            return team1First ? (team1, team2) : (team2, team1);
        }
        /// <summary>
        /// This will pull up the next window in the program. 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        private void CallSelectionWindow(Team first, Team second)
        {
            SectionSelectionWindow sectionSelectionWindow = new(first, second, _dBController);
            sectionSelectionWindow.Show();
        }
        /// <summary>
        /// This will test if the user input names are valid.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool IsNameValid(string name)
        {
            return name.Length > 2 && name.Length < 21 ;
        }

    }
}
