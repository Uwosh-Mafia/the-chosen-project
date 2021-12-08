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
    /// Interaction logic for QuestionSelectionWindow.xaml
    /// </summary>
    public partial class QuestionSelectionWindow : Window
    {
        GameLogicController controller;
        StudentGameWindow studentGameWindow;
        public QuestionSelectionWindow(GameLogicController gameController, StudentGameWindow studentGameWindow)
        {
            InitializeComponent();
            this.controller = gameController;
            this.studentGameWindow = studentGameWindow;
            PopulateQuestions();
        }

        /// <summary>
        /// This method populates the questions
        /// </summary>
        private void PopulateQuestions()
        {
            List<Question> questions = controller.questions;
            String[] questionNames = new string[questions.Count];

            for (int i = 0; i < questions.Count; i++)
                questionNames[i] = questions[i].Text;
            QuestionBox.ItemsSource = questionNames;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = (sender as ListBox).SelectedIndex;
            SelectNewQuestion(index);
        }

        private void SelectNewQuestion(int index)
        {
            if (controller.RoundIsNotOver() && controller.GameIsNotOver())
                controller.SelectQuestion(index);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            studentGameWindow.Close();
        }

        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            controller.EndGame();
            Close();
            studentGameWindow.Close();
        }
    }
}
