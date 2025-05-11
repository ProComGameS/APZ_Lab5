using FitnessClub.DAL.Models;

namespace FitnessClub.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FitnessClubContext _context;

        public UnitOfWork(FitnessClubContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public void EnsureDatabaseCreated()
        {
            _context.Database.EnsureCreated();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}