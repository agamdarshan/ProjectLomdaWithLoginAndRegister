/*
using ProjectLomdaWithLoginAndRegister.ViewModel;
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
   /// Interaction logic for LoginView.xaml
   /// </summary>

   public partial class LoginView : Window
   {
       public LoginView()
       {
           InitializeComponent();
       }

       private void RegisterButton_Click(object sender, RoutedEventArgs e)
       {
           // Open the RegistrationView when the "Register" button is clicked
           RegistrationView registrationView = new RegistrationView();
           registrationView.Show();
       }
   }


     public partial class LoginView : Window
   {
       private SharedViewModel _sharedViewModel;
       private UserViewModel _userViewModel;

       public LoginView(SharedViewModel sharedViewModel)
       {
           InitializeComponent();

           _sharedViewModel = sharedViewModel;
           _userViewModel = new UserViewModel(_sharedViewModel);
           //Unloaded += MainPage_Unloaded;
           //Loaded += MainPage_Loaded;

           DataContext = _userViewModel;
       }

       private void RegisterButton_Click(object sender, RoutedEventArgs e)
       {
           // Open the RegistrationView when the "Register" button is clicked
           RegistrationView registrationView = new RegistrationView();
           registrationView.Show();
       }
   }






}
     */


using ProjectLomdaWithLoginAndRegister.Model;
using ProjectLomdaWithLoginAndRegister.ViewModel;
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

//זה עמוד לוגין שנמצא בויו
//כל קובץ WPF בנוי מעיצוב ומהקוד של מה קורה במידה ולוחצים על כפתורים וכו

namespace ProjectLomdaWithLoginAndRegister.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>

    public partial class LoginView : Window
    {


        private SharedViewModel _sharedViewModel;

        public LoginView()
        {
            InitializeComponent();
            // Initialize the shared view models
            _sharedViewModel = new SharedViewModel();
            // Set the data context for data binding
            DataContext = _sharedViewModel;

        }

  


        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the RegistrationView when the "Register" button is clicked
            RegistrationView registrationView = new RegistrationView();
            registrationView.Show();
            Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string enteredEmail = EmailTextBox.Text;
            string enteredPassword = PasswordTextBox.Text;

            //מכיוון שהגדרנו את הליסט של היוזרים שנמצאת במחלקה שארד ויו מודל להיות משותפת
            //ניתן לקרוא פונקציה הסטטית שמחזירה את הרפרנס של הרשימה שלנו
            // Check if there is a user with the entered email and password
            User foundUser = SharedViewModel.UsersList.FirstOrDefault(user => user.Email == enteredEmail && user.Password == enteredPassword);

            //אם מצאנו יוזר אז המשתנה שונה מנאל
            if (foundUser != null)
            {
                //ניקח את השם הפרטי של היוזר בכדי שנשלח אותו לחלון הבא הרלוונטי לומדה
                // User found, store the first name
                string userFirstName = foundUser.FirstName;

                //יצירה ופתיחה של החלון של הלומדה
                // Open MainWindow
                OptionsWindow ow = new OptionsWindow(userFirstName); 
                ow.Show();

                // Close the LoginView
                Close();

                MessageBox.Show($"Welcome, {userFirstName}!");
            }
            //אם המשתנה יוזר שווה לנאל המשמעות זה שלא נמצא היוזר הרלוונטי ונפתח חלון שגיאה
            else
            {
                MessageBox.Show("User not found!");
            }
        }


        /*
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string enteredEmail = EmailTextBox.Text;
            string enteredPassword = PasswordTextBox.Text;

            // Check if there is a user with the entered email and password
            bool userFound = SharedViewModel.UsersList.Any(user => user.Email == enteredEmail && user.Password == enteredPassword);

            if (userFound)
            {
                MessageBox.Show("User found!");
            }
            else
            {
                MessageBox.Show("User not found!");
            }
        }
        */


        // Unloaded and Loaded event handlers can be added here if needed
        // private void MainPage_Unloaded(object sender, RoutedEventArgs e) { }
        // private void MainPage_Loaded(object sender, RoutedEventArgs e) { }
    }
}
