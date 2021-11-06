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
    /// Interaction logic for SectionSelectionWindow.xaml
    /// </summary>
    public partial class SectionSelectionWindow : Window
    {
        private Team team1;
        private Team team2;
        private DBModel model;
        public DBController controller;
        public SectionSelectionWindow(Team team1, Team team2)
        {
            InitializeComponent();
            this.team1 = team1;
            this.team2 = team2;
            model = new();
            controller = new(model);
            SectionBox.ItemsSource = controller.GetSections();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            QuestionSelectionWindow questionSelectionWindow = new(SectionBox.SelectedItem, controller); // Fix me - Object required, didn't allow Section in QuestionSelectionWindow
            questionSelectionWindow.Show();
            Close();
        }
    }
}
