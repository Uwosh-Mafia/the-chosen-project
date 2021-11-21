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
        DBController dBController;
        GameLogicController gameController;
        StudentGameWindow studentGameWindow;
        Section section;
        Question question;
        public QuestionSelectionWindow(Section section, DBController controller, GameLogicController gameController, StudentGameWindow studentGameWindow) 
        {
            InitializeComponent();
            this.dBController = controller;
            this.gameController = gameController;
            this.section = section;
            this.studentGameWindow = studentGameWindow;
            populateQuestions();
        }

        /// <summary>
        /// This method populates the questions
        /// </summary>
        private void populateQuestions()
        {
            List<Question> questions = section.GetQuestions();
            String[] sectionNames = new string[questions.Count];

            for (int i = 0; i < questions.Count; i++)
                sectionNames[i] = questions[i].Text;
            QuestionBox.ItemsSource = sectionNames;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearAnswers();
            int index = (sender as ListBox).SelectedIndex;
            this.question = section.GetQuestions()[index];
            FillAnswers(question.GetAnswers());
            question_text.Text = question.Text;
        }
        private void ClearAnswers()
        {
            answer1.Content = "";
            answer2.Content = "";
            answer3.Content = "";
            answer4.Content = "";
            answer5.Content = "";
            answer6.Content = "";
            answer7.Content = "";
            answer8.Content = "";
        }

        private void FillAnswers(List<Answer> answers)
        {
            for(int i = 0; i < answers.Count; i++)
            {
                switch(i)
                {
                    case 0:
                        answer1.Content = answers[i].Text;
                        break;
                    case 1:
                        answer2.Content = answers[i].Text;
                        break;
                    case 2:
                        answer3.Content = answers[i].Text;
                        break;
                    case 3:
                        answer4.Content = answers[i].Text;
                        break;
                    case 4:
                        answer5.Content = answers[i].Text;
                        break;
                    case 5:
                        answer6.Content = answers[i].Text;
                        break;
                    case 6:
                        answer7.Content = answers[i].Text;
                        break;
                    case 7:
                        answer8.Content = answers[i].Text;
                        break;
                }
            }
        }

        private void CorrectAnswer(object sender, RoutedEventArgs e)
        {
            int index = (sender as Answer).Id;
            gameController.CorrectAnswer(index);
        }

        private void Play_Question(object sender, RoutedEventArgs e)
        {
            gameController.SetCurrentQuestion(question.Id);
            studentGameWindow.question_box.Text = question.Text;
        }
    }
}
