using System;

namespace WpfApp.DAL.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public int CalendarId { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Notification { get; set; }
        public virtual Calendar Calendar { get; set; }
    }
}
