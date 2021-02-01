using System.Collections.Generic;

namespace WpfApp.DAL.Entities
{
    public class Calendar
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public Calendar()
        {
            Event = new List<Event>();
        }
    }
}
