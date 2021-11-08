using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FamilyFeudGame
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        DBModel dbmodel = new();
        DBController dBController;
        public WelcomeWindow()
        {
            InitializeComponent();
            dBController = new(dbmodel);
         //   DBReader dBReader = new("a", dBController);
        }

        /// <summary>
        /// This method instantiats reading data from excel 
        /// </summary>
        private void loadExcelFileData(String fileName)
        {
            FileInfo file = new FileInfo(fileName: fileName);
            DBReader reader = new DBReader(file, dBController);
        }

        private void BtnWelcome_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Text documents (.xlsx)|*.xlsx"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                loadExcelFileData(dialog.FileName);
            }

            TeamCreationWindow teamCreationWindow = new(dBController);
            teamCreationWindow.Show();
            Close();
        }
    }
}
