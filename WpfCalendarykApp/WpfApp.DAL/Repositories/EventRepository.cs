using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfApp.DAL.EF;
using WpfApp.DAL.Entities;
using WpfApp.DAL.Interfaces;

namespace WpfApp.DAL.Repositories
{
    public class EventRepository: IRepository<Event>
    {
        private readonly CalendarykContext _db;

        public EventRepository(CalendarykContext db)
        {
            _db = db;
        }

        public IEnumerable<Event> GetAll()
        {
            return _db.Events;
        }

        public Event Get(int id)
        {
            return _db.Events.Find(id);
        }

        public IEnumerable<Event> Find(Func<Event, bool> predicate)
        {
            return _db.Events.Where(predicate).ToList();
        }

        public void Create(Event item)
        {
            if(item != null)
                _db.Events.Add(item);
        }

        public void Update(Event item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var value = _db.Events.Find(id);
            if (value != null)
                _db.Events.Remove(value);
        }
    }
}