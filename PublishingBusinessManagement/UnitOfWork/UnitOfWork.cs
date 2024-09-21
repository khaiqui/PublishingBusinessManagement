using PublishingBusinessManagement.Models;
using PublishingBusinessManagement.Repositories;

namespace PublishingBusinessManagement.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private PubsContext _context;
        private GenericRepository<Store> _storeRepo;
        private GenericRepository<Title> _titleRepo;
        private GenericRepository<Employee> _employeeRepo;

        public UnitOfWork(PubsContext context)
        {
            _context = context;
        }

        public GenericRepository<Store> StoreRepository
        {
            get
            {
                if (_storeRepo == null)
                {
                    _storeRepo = new GenericRepository<Store>(_context);
                }
                return _storeRepo;
            }
        }

        public GenericRepository<Title> TitleRepository
        {
            get
            {
                if (_titleRepo == null)
                {
                    _titleRepo = new GenericRepository<Title>(_context);
                }
                return _titleRepo;
            }
        }

        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (_employeeRepo == null)
                {
                    _employeeRepo = new GenericRepository<Employee>(_context);
                }
                return _employeeRepo;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
