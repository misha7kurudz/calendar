using System.Windows;
using WpfApp.BLL.DTO;

namespace WpfApp
{
    public partial class UserWindow : Window
    {
        private readonly UserDTO _user;
        public UserWindow(UserDTO user)
        {
            _user = user;
            InitializeComponent();
        }
    }
}
