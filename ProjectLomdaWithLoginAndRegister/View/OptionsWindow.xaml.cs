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

namespace ProjectLomdaWithLoginAndRegister.View
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        private string userFirstName;
        public OptionsWindow(string userFirstName)
        {
            InitializeComponent();
            WellcomeLabel.Content = "Wellcome " + userFirstName + " Enjoy Your GAME !";
            this.userFirstName = userFirstName;
        }

        private void redirectToSpacielCalculator(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(userFirstName);
            mw.Show();

            // Close the LoginView
            Close();

        }

        private void redirectToWordsGame(object sender, RoutedEventArgs e)
        {
            WordsGameView wg = new WordsGameView(userFirstName);
            wg.Show();

            // Close the LoginView
            Close();
        }
    }
}
