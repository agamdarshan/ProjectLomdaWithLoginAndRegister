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
    /// Interaction logic for WordsGameView.xaml
    /// </summary>
    public partial class WordsGameView : Window
    {
        private static int curIndex = 0;
        private static int countOK = 0;
        private static int countWrong = 0;
        private static double gradeValue;

        private string userFirstName;

        public WordsGameView(string userFirstName)
        {
            InitializeComponent();
            this.userFirstName = userFirstName;
            titleLabel.Content = $"Spaciel Agam Calculator - Hello, {userFirstName}!";

            // Call the initialization method
            Initialize();
        }

        private void Initialize()
        {
            gameImage.Visibility = Visibility.Collapsed;

            okCountLabel.Content = 0;
            wrongCountLabel.Content = 0;
            gradeNumberLabel.Content = 0;

            // Access the first GameData item from the list
            var firstGameData = ViewModel.GameDataBase.GameDataList[curIndex];

            // Set the wordLabel content to the first element in the list
            wordLabel.Content = firstGameData.WordEnglish;

            // Shuffle the list of translations
            List<string> shuffledTranslations = ViewModel.GameDataBase.GameDataList
                .OrderBy(g => Guid.NewGuid())
                .Select(g => g.TranslationHebrew)
                .ToList();

            // Set the RadioButton options with shuffled TranslationHebrew values
            option1RadioButton.Content = shuffledTranslations[0];
            option2RadioButton.Content = shuffledTranslations[1];
            option3RadioButton.Content = shuffledTranslations[2];
            option4RadioButton.Content = shuffledTranslations[3];
            option5RadioButton.Content = shuffledTranslations[4];

            // Dynamically set the image source based on the ImageUrl property
            gameImage.Source = new BitmapImage(new Uri(firstGameData.ImageUrl));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {


            // Check if any radio button is checked
            if (!(option1RadioButton.IsChecked == true || option2RadioButton.IsChecked == true ||
                  option3RadioButton.IsChecked == true || option4RadioButton.IsChecked == true ||
                  option5RadioButton.IsChecked == true))
            {
                MessageBox.Show("Please select an option before submitting your answer.");
                return; // Exit the method if no option is selected
            }

            // Access the current GameData item from the list
            var currentGameData = ViewModel.GameDataBase.GameDataList[curIndex];

            // Check the selected radio button's content against the correct translation
            if (option1RadioButton.IsChecked == true && option1RadioButton.Content.ToString() == currentGameData.TranslationHebrew)
            {
                // Answer is correct
                countOK++;
            }
            else if (option2RadioButton.IsChecked == true && option2RadioButton.Content.ToString() == currentGameData.TranslationHebrew)
            {
                countOK++;
            }
            else if (option3RadioButton.IsChecked == true && option3RadioButton.Content.ToString() == currentGameData.TranslationHebrew)
            {
                countOK++;
            }
            else if (option4RadioButton.IsChecked == true && option4RadioButton.Content.ToString() == currentGameData.TranslationHebrew)
            {
                countOK++;
            }
            else if (option5RadioButton.IsChecked == true && option5RadioButton.Content.ToString() == currentGameData.TranslationHebrew)
            {
                countOK++;
            }
            else
            {
                // Answer is wrong
                countWrong++;
            }

            okCountLabel.Content = countOK;
            wrongCountLabel.Content = countWrong;
            gradeValue = (double)countOK / (countOK + countWrong) * 100;
            gradeNumberLabel.Content = gradeValue;

            // Reset radio button states and visibility of the image
            option1RadioButton.IsChecked = false;
            option2RadioButton.IsChecked = false;
            option3RadioButton.IsChecked = false;
            option4RadioButton.IsChecked = false;
            option5RadioButton.IsChecked = false;


            gameImage.Visibility = Visibility.Collapsed;

            // Increment the index
            curIndex++;

            // Check if the game is finished
            if (curIndex == 5)
            {
                OptionsWindow ow = new OptionsWindow(userFirstName);
                ow.Show();

                // Close the LoginView
                Close();
                
                MessageBox.Show("Game Finished! OK: " + countOK + ", Wrong: " + countWrong + " Your Grade is: "+ gradeValue);
            }
            else
            {
                // Access the current GameData item from the list
                currentGameData = ViewModel.GameDataBase.GameDataList[curIndex];

                // Set the wordLabel content to the current element in the list
                wordLabel.Content = currentGameData.WordEnglish;

                // Shuffle the list of translations
                List<string> shuffledTranslations = ViewModel.GameDataBase.GameDataList
                    .OrderBy(g => Guid.NewGuid())
                    .Select(g => g.TranslationHebrew)
                    .ToList();

                // Set the RadioButton options with shuffled TranslationHebrew values
                option1RadioButton.Content = shuffledTranslations[0];
                option2RadioButton.Content = shuffledTranslations[1];
                option3RadioButton.Content = shuffledTranslations[2];
                option4RadioButton.Content = shuffledTranslations[3];
                option5RadioButton.Content = shuffledTranslations[4];

                // Dynamically set the image source based on the ImageUrl property
                gameImage.Source = new BitmapImage(new Uri(currentGameData.ImageUrl));
            }
        }


        private void getHintButton_Click(object sender, RoutedEventArgs e)
        {
            gameImage.Visibility = Visibility.Visible;

        }
    }
}
