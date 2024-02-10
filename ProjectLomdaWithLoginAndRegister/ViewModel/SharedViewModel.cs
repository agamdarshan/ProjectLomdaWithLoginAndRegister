using ProjectLomdaWithLoginAndRegister.Model;
using System.Collections.Generic;

namespace ProjectLomdaWithLoginAndRegister.ViewModel
{

    public class SharedViewModel
    {
        //יצרנו רשימה שהיא סטטית מכיוון שהיא תהיה משותפת מחלקתית לכל אובייקט שיווצר ממחלקה זו
        //ברגע שמגדירים רשימה שתהיה סטטית אנו נוכל לגשת אליה בכל המקומות הרלוונטיים בפרויקט שלנו 
        //דרך שם המחלקה וקריאה לשם הפונקציה שמחזירה רפרנס לרשימה
        private static List<User> _usersList = new List<User>
                {
                    new User
                    {
                        Email = "admin@gmail.com",
                        Password = "admin",
                        FirstName = "YourFirstName",
                        LastName = "YourLastName",
                        ChildFirstName = "ChildFirstName",
                        ChildLastName = "ChildLastName",
                        ChildAge = 5
                    },
                    new User
                    {
                        Email = "agam@gmail.com",
                        Password = "agam",
                        FirstName = "agam",
                        LastName = "AnotherLastName",
                        ChildFirstName = "AnotherChildFirstName",
                        ChildLastName = "AnotherChildLastName",
                        ChildAge = 8
                    },
                };


        public static List<User> UsersList
        {
            get { return _usersList; }
            set { _usersList = value; }
        }
    }
}

/*
 using ProjectLomdaWithLoginAndRegister.Model;
using System.Collections.Generic;

namespace ProjectLomdaWithLoginAndRegister.ViewModel
{
    public class SharedViewModel
    {
        private List<User> _usersList;

        public SharedViewModel()
        {
            _usersList = new List<User>();
        }

        public List<User> UsersList
        {
            get { return _usersList; }
            set { _usersList = value; }
        }
    }
}
 */




