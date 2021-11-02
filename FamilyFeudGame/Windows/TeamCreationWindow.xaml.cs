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
    /// Interaction logic for TeamCreationWindow.xaml
    /// </summary>
    public partial class TeamCreationWindow : Window
    {
        public TeamCreationWindow()
        {
            InitializeComponent();
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            if (txtTeam1.Text != "Enter team name")
            {
                if (txtTeam2.Text != "Enter team name")
                {
                    if ((bool)rbTeam1.IsChecked && (bool)rbTeam2.IsChecked)
                    {
                        SectionSelectionWindow sectionSelectionWindow = new();
                        sectionSelectionWindow.Show();
                        Close();
                    } else
                    {
                        MessageBox.Show("Select a team to go first");
                    }
                } else
                {
                    MessageBox.Show("Enter a team name for team 2");
                }
            } else
            {
                MessageBox.Show("Enter a team name for team 1");
            }
        }
    }
}
