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
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
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
        }
    }
}
