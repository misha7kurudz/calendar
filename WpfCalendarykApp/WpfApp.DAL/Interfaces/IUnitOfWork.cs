using System;
using WpfApp.DAL.Entities;

namespace WpfApp.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Calendar> Calendars { get; }
        IRepository<Event> Events { get; }
        IRepository<ApplicationRole> Roles { get; }
        IRepository<ApplicationUser> Users { get; }

        void Save();
    }
}