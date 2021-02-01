using System.Collections.Generic;

namespace WpfApp.DAL.Entities
{
    public class ApplicationRole
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public ApplicationRole()
        {
            Users = new List<ApplicationUser>();
        }
    }
}