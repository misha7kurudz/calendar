using System.Linq;
using AutoMapper;
using WpfApp.BLL.DTO;
using WpfApp.BLL.Interfaces;
using WpfApp.DAL.Entities;
using WpfApp.DAL.Interfaces;

namespace WpfApp.BLL.Services
{
    public class Authorization : IAuthorization
    {
        private readonly IUnitOfWork _db;
        public Authorization(IUnitOfWork db)
        {
            _db = db;
        }

        public UserDTO LogIn(string email, string password)
        {
            var value = _db.Users.Find(item => item.Email == email && item.Password == password).FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<ApplicationUser, UserDTO>()
                    .ForMember(item => item.Role, opt => opt.MapFrom(x => x.Role.Type)));
            var mapper = new Mapper(config);
            return mapper.Map<ApplicationUser, UserDTO>(value);
        }

        public RegistrationResult Register(string email, string password)
        {
            if (!_db.Users.Find(user => user.Email.Equals(email)).Any())
            {
                var role = _db.Roles.Find(applicationRole => applicationRole.Type == "user").First();
                _db.Users.Create(new ApplicationUser { Email = email, Password = password, RoleId = role.Id});
                _db.Save();
                return RegistrationResult.Successfully;
            }

            return RegistrationResult.Failed;
        }
    }
}