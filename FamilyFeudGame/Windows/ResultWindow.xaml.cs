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
using FamilyFeudGame.Models;

namespace FamilyFeudGame
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow(Team team1, Team team2)
        {
            InitializeComponent();
            Team1TB.Text = team1.Name;
            Team1PointsTB.Text = team1.GetPoints().ToString();

            Team2TB.Text = team2.Name;
            Team2PointsTB.Text = team2.GetPoints().ToString();
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}