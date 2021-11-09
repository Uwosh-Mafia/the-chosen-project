﻿using System;
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
        DBController dBController;
        Section section;
        public QuestionSelectionWindow(Section section, DBController controller) // Fix me - see SectionSelectionWindow Next_Click
        {
            InitializeComponent();
            this.dBController = controller;
            this.section = section;
            populateQuestions();
        }

        /// <summary>
        /// This method populates the questions
        /// </summary>
        public void populateQuestions()
        {
            List<Question> questions = section.GetQuestions();
            String[] sectionNames = new string[questions.Count];

            for (int i = 0; i < questions.Count; i++)
                sectionNames[i] = questions[i].Text;
            QuestionBox.ItemsSource = sectionNames;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeacherGameWindow teacherGameWindow = new(QuestionBox.SelectedItem, dBController);
            StudentGameWindow studentGameWindow = new();
            teacherGameWindow.Show();
            studentGameWindow.Show();
            Close(); // Do we want to close this window?
        }
    }
}
