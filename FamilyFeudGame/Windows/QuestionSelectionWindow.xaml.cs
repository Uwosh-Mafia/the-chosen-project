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
    /// Interaction logic for QuestionSelectionWindow.xaml
    /// </summary>
    public partial class QuestionSelectionWindow : Window
    {
        DBController controller;
        Section section;
        public QuestionSelectionWindow(object selectedSection, DBController controller) // Fix me - see SectionSelectionWindow Next_Click
        {
            InitializeComponent();
            this.controller = controller;
            this.section = (Section)selectedSection;
            QuestionBox.ItemsSource = section.GetQuestions();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            TeacherGameWindow teacherGameWindow = new(QuestionBox.SelectedItem, controller);
            StudentGameWindow studentGameWindow = new();
            teacherGameWindow.Show();
            studentGameWindow.Show();
            Close(); // Do we want to close this window?
        }
    }
}
