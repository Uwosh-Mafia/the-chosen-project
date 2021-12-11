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
                CallSelectionWindow(CreateTeams(true));
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
                CallSelectionWindow(CreateTeams(false));
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

        private Team[] CreateTeams(bool isTeamOnePlaying)
        {
            if (!IsNameValid(txtTeam1.Text))
                throw new Exception("Invalid Name");

            if (!IsNameValid(txtTeam2.Text))
                throw new Exception("Invalid Name");

            Team[] teams = new Team[2];

            if (isTeamOnePlaying)
            {
                teams[0] = new(txtTeam1.Text, true);
                teams[1] = new(txtTeam2.Text, false);
            } else
            {
                teams[0] = new(txtTeam1.Text, false);
                teams[1] = new(txtTeam2.Text, true);
            }

            return teams;
        }

        /// <summary>
        /// This will pull up the next window in the program. 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        private void CallSelectionWindow(Team[] teams)
        {
            SectionSelectionWindow sectionSelectionWindow = new(teams, _dBController);
            sectionSelectionWindow.Show();
        }
        /// <summary>
        /// This will test if the user input names are valid.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool IsNameValid(string name)
        {
            return name.Length > 2 && name.Length < 21;
        }

    }
}
