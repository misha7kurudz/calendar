using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfApp.DAL.EF;
using WpfApp.DAL.Entities;
using WpfApp.DAL.Interfaces;

namespace WpfApp.DAL.Repositories
{
    public class RoleRepository: IRepository<ApplicationRole>
    {
        private readonly CalendarykContext _db;

        public RoleRepository(CalendarykContext db)
        {
            _db = db;
        }

        public IEnumerable<ApplicationRole> GetAll()
        {
            return _db.Roles.ToList();
        }

        public ApplicationRole Get(int id)
        {
            return _db.Roles.Find(id);
        }

        public IEnumerable<ApplicationRole> Find(Func<ApplicationRole, bool> predicate)
        {
            return _db.Roles.Where(predicate).ToList();
        }

        public void Create(ApplicationRole item)
        {
            if (item != null)
                _db.Roles.Add(item);
        }

        public void Update(ApplicationRole item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var value = _db.Roles.Find(id);
            if (value != null)
                _db.Roles.Remove(value);
        }
    }
}