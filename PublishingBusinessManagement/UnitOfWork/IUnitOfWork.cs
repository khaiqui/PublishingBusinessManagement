using PublishingBusinessManagement.Models;
using PublishingBusinessManagement.Repositories;

namespace PublishingBusinessManagement.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Store> StoreRepository { get; }
        GenericRepository<Title> TitleRepository { get; }
        GenericRepository<Employee> EmployeeRepository { get; }

        void Save();
        Task<int> SaveAsync();
    }
}
