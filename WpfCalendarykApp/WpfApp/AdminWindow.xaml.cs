using System.Windows;
using WpfApp.BLL.DTO;

namespace WpfApp
{
    public partial class AdminWindow : Window
    {
        private UserDTO _user;
        public AdminWindow(UserDTO user)
        {
            _user = user;
            InitializeComponent();
        }
    }
}
