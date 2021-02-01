namespace WpfApp.DAL.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
