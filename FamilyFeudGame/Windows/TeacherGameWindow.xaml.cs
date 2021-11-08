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
    /// Interaction logic for TeacherGameWindow.xaml
    /// </summary>
    public partial class TeacherGameWindow : Window
    {
        Question question;
        DBController controller;
        public TeacherGameWindow(object selectedQuestion, DBController controller)
        {
            InitializeComponent();
            this.question = (Question)selectedQuestion;
            this.controller = controller;
        }

       
    }
}
