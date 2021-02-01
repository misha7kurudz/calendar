using System;
using System.ComponentModel;

namespace WpfApp.PL.ViewModel
{
    public class AuthorizationView :  IDataErrorInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Error { get; set; }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Email":
                        if (string.IsNullOrWhiteSpace(Email))
                            error = "Email is empty";
                        break;
                    case "Password":
                        if (string.IsNullOrWhiteSpace(Password))
                            error = "Password is empty";
                        break;
                }
                return error;
            }
        }
    }
}
