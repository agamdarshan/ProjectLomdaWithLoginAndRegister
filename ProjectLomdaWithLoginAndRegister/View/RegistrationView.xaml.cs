using ProjectLomdaWithLoginAndRegister.Model;
using ProjectLomdaWithLoginAndRegister.ViewModel;
using System;
using System.Linq;
using System.Windows;

namespace ProjectLomdaWithLoginAndRegister.View
{
    public partial class RegistrationView : Window
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            //שואבים ושומרים את כל הערכים שנרשמו בטקסט בוקסס בתוך משתנים מסוך מחרוזת
            // Get values from text boxes
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string childFirstName = ChildFirstNameTextBox.Text;
            string childAgeStr = ChildAgeTextBox.Text;

            //בדיקות תיקון קלט בדיקה האם המייל כבר קיים ברשימה שלנו
            //כל בדיקות הוולדיציה הן בנוסח שלילה במידה ויש בעיה אנא להציג הודעה ולעשות ריטורן מסיים את הפונקציה
            // Validate email
            if (SharedViewModel.UsersList.Exists(u => u.Email == email))
            {
                MessageBox.Show("Email already exists. Please use a different email.");
                return;
            }

            // Validate password
            if (password.Length < 6 || password.Length > 10 || !password.Any(char.IsUpper) || !password.Any(char.IsDigit))
            {
                MessageBox.Show("Invalid password. Password must be between 6-10 characters, contain at least one capital letter, and one number.");
                return;
            }

            // Validate child age
            if (!int.TryParse(childAgeStr, out int childAge) || childAge < 0)
            {
                MessageBox.Show("Invalid child age. Please enter a valid age.");
                return;
            }

            //במידה והגענו לקטע הזה בקוד ולא נכנסנו לאחד מהאיפים למעלה של בדיקות תקינות הקלט אז ניתן ליצור יוזר חדש ולהכניס אותו לרשימת היוזרים הקיימת
            //ניתן לגשת לליסט שלנו שנמצא בקלאס אחרדרך שן הקלאס וקריאה לפונקציה גאט שמחזירה את הכתובת של הרשימה
            // Create new user and add to the static user list in sharedViewModel
            SharedViewModel.UsersList.Add(new User
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                ChildFirstName = childFirstName,
                ChildAge = childAge
            });

            MessageBox.Show("Registration successful!");
            // Show login view and close the current registration view
            LoginView loginView = new LoginView();
            loginView.Show();
            Close();
        }
    }
}
