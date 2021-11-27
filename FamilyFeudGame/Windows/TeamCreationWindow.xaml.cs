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
            Team team1 = new(txtTeam1.Text, true);
            Team team2 = new(txtTeam2.Text, false);
            SectionSelectionWindow sectionSelectionWindow = new(team1, team2, dBController);
            sectionSelectionWindow.Show();
            Close();
        }

        private void BtnTeam2_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtTeam1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtTeam2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
