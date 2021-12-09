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
        public DBController dBController;
        public GameLogicController gameController;
        public SectionSelectionWindow(Team team1, Team team2, DBController controller)
        {
            InitializeComponent();
            this.team1 = team1;
            this.team2 = team2;
            dBController = controller;
            populateSelection();
        }

        /// <summary>
        /// This method populates the selections
        /// </summary>
        public void populateSelection()
        {
            List<Section> sections = dBController.GetSections();
            string[] sectionNames = new string[sections.Count];

            for (int i = 0; i < sections.Count; i++)
                sectionNames[i] = sections[i].Name;
            SectionBox.ItemsSource = sectionNames;
        }

        /// <summary>
        /// This method handles when we select a section.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lbx = sender as ListBox;
            Section section = dBController.GetSection(lbx.SelectedIndex + 1); // there is no 0 section id. it starts 1
            gameController = new(section, team1, team2, 0);

            StudentGameWindow studentGameWindow = new(gameController);
            QuestionSelectionWindow questionSelectionWindow = new(section, dBController, gameController, studentGameWindow);

            questionSelectionWindow.Show();
            studentGameWindow.Show();
            Close();
        }
    }
}
