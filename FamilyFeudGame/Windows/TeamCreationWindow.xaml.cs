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
    /// Interaction logic for TeamCreationWindow.xaml
    /// </summary>
    public partial class TeamCreationWindow : Window
    {
        private DBController dBController;
        public TeamCreationWindow(DBController controller)
        {
            InitializeComponent();
            dBController = controller;
        }
    }
}
