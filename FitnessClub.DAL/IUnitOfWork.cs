using System;
using FitnessClub.DAL.Models;

namespace FitnessClub.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        void EnsureDatabaseCreated();
        int Complete();
    }
}