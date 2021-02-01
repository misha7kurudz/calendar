using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfApp.DAL.EF;
using WpfApp.DAL.Entities;
using WpfApp.DAL.Interfaces;

namespace WpfApp.DAL.Repositories
{
    public class CalendarRepository : IRepository<Calendar>
    {
        private readonly CalendarykContext _db;

        public CalendarRepository(CalendarykContext db)
        {
            _db = db;
        }

        public IEnumerable<Calendar> GetAll()
        {
            return _db.Calendars.ToList();
        }

        public Calendar Get(int id)
        {
            return _db.Calendars.Find(id);
        }

        public IEnumerable<Calendar> Find(Func<Calendar, bool> predicate)
        {
            return _db.Calendars.Where(predicate);
        }

        public void Create(Calendar item)
        {
            if (item != null)
                _db.Calendars.Add(item);
        }

        public void Update(Calendar item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var value = _db.Calendars.Find(id);
            if (value != null)
                _db.Calendars.Remove(value);
        }
    }
}