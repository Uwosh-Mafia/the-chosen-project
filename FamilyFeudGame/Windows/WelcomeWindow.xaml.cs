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
    /// Main Contributor: Bentley Epple
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
        }

        /// <summary>
        /// This method instantiats reading data from excel 
        /// </summary>
        private async Task loadExcelFileData(String fileName)
        {
            FileInfo file = new FileInfo(fileName: fileName);
            DBReader reader = new DBReader(file, dBController);
            await reader.loadExcelFile();
        }

        /// <summary>
        /// The welcome bottom is the frist button user calls to start the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnWelcome_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Configure open file dialog box
                var dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.Filter = "Text documents (.xlsx)|*.xlsx"; // Filter files by extension

                // Show open file dialog box
                bool? result = dialog.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    await loadExcelFileData(dialog.FileName);
                    TeamCreationWindow teamCreationWindow = new(dBController);
                    teamCreationWindow.Show();
                    Close();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Please close the excel file first");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, something went wrong");
            }
        }
    }
}
