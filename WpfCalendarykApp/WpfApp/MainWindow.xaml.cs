using System.Windows;
using System.Windows.Media.Animation;
using Castle.Core.Internal;
using WpfApp.BLL.Interfaces;
using WpfApp.PL.ViewModel;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly IAuthorization _authorization;
        private readonly AuthorizationView _model = new AuthorizationView();

        public MainWindow(IAuthorization authorization)
        {
            _authorization = authorization;
            DataContext = _model;
            InitializeComponent();
        }

        private void OpenWindow(Window window)
        {
            window.Show();
            Close();
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            var emailValidation = _model["Email"];

            if (!emailValidation.IsNullOrEmpty())
            {
                MessageBox.Show(emailValidation, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Password.Password.IsNullOrEmpty())
            {
                MessageBox.Show("Password is empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = _authorization.LogIn(Email.Text, Password.Password);
            if (result == null)
            {
                MessageBox.Show("User with such email is not exist", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (result.Role.Equals("user"))
            {
               OpenWindow(new UserWindow(result));
               return;
            }

            if (result.Role.Equals("admin"))
            {
                OpenWindow(new AdminWindow(result));
                return;
            }
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow window = new RegisterWindow(_authorization);
            Close();
            window.Show();
        }
    }
}