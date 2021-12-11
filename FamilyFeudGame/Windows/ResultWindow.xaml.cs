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
using FamilyFeudGame.Models;

namespace FamilyFeudGame
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
<<<<<<< HEAD:FamilyFeudGame/Windows/ResultWindow.xaml.cs
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
=======
        private Team[] _teams;
        public ResultWindow(Team[] teams)
        {
            InitializeComponent();
            this._teams = teams;
            ShowResults();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowResults()
        {
            Team1.Text = _teams[0].Name.ToUpper();
            Team2.Text = _teams[1].Name.ToUpper();

            Team1Score.Text = _teams[0].Points.ToString();
            Team2Score.Text = _teams[1].Points.ToString();
>>>>>>> 57ed2c1f8eb73478fde67380bb88f2acf19ee048:FamilyFeudGame/ResultWindow.xaml.cs
        }
    }
}
