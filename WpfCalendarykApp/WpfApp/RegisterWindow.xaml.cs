using System.Windows;
using Castle.Core.Internal;
using WpfApp.BLL.Interfaces;

namespace WpfApp
{
    public partial class RegisterWindow : Window
    {
        private readonly IAuthorization _authorization;
        public RegisterWindow(IAuthorization authorization)
        {
            _authorization = authorization;
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (Email.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Email is empty", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if (Password.Password.IsNullOrEmpty())
            {
                MessageBox.Show("Password is empty", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if (Password.Password.Trim().Equals(ConfrimPassword.Password.Trim()))
            {
                var result = _authorization.Register(Email.Text, Password.Password);
                switch (result)
                {
                    case RegistrationResult.Successfully:
                        {
                            MainWindow window = new MainWindow(_authorization);
                            window.Show();
                            Close();
                            break;
                        }
                    case RegistrationResult.Failed:
                        {
                            MessageBox.Show("User with such email is already exist", "Error", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Passwords are not the same", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}