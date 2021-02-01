using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfApp.DAL.EF;
using WpfApp.DAL.Entities;
using WpfApp.DAL.Interfaces;

namespace WpfApp.DAL.Repositories
{
    public class UserRepository: IRepository<ApplicationUser>
    {
        private readonly CalendarykContext _db;

        public UserRepository(CalendarykContext db)
        {
            _db = db;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _db.Users.ToList();
        }

        public ApplicationUser Get(int id)
        {
            return _db.Users.Find(id);
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, bool> predicate)
        {
            return _db.Users.Where(predicate).ToList();
        }

        public void Create(ApplicationUser item)
        {
            if (item != null)
                _db.Users.Add(item);
        }

        public void Update(ApplicationUser item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var value = _db.Users.Find(id);
            if (value != null)
                _db.Users.Remove(value);
        }
    }
}