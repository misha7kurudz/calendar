using WpfApp.BLL.DTO;

namespace WpfApp.BLL.Interfaces
{
    public enum RegistrationResult 
    {
        Successfully,
        Failed
    }

    public interface IAuthorization
    {
        public UserDTO LogIn(string email, string password);
        public RegistrationResult Register(string email, string password);
    }
}
