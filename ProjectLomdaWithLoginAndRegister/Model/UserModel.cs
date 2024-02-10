// UserModel.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLomdaWithLoginAndRegister.Model
{
    public class User : INotifyPropertyChanged
    {
        private string eMail;
        private string password;
        private string firstName;
        private string lastName;
        private string childFirstName;
        private string childLastName;
        private int childAge;

        public string Email
        {
            get { return eMail; }
            set { eMail = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        public string ChildFirstName
        {
            get { return childFirstName; }
            set { childFirstName = value; OnPropertyChanged(nameof(ChildFirstName)); }
        }

        public string ChildLastName
        {
            get { return childLastName; }
            set { childLastName = value; OnPropertyChanged(nameof(ChildLastName)); }
        }

        public int ChildAge
        {
            get { return childAge; }
            set { childAge = value; OnPropertyChanged(nameof(ChildAge)); }
        }

        //קטע קוד הבא משתמשים בו כאשר יש העברה של נתונים לתוך מסד נתונים כלשהו ושמירתו תוך כדי שהנתונים מסתנכרנים ונשמרים להם לנושא זה קוראים דאטא בינדינג 
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
