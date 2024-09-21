using Microsoft.EntityFrameworkCore;
using PublishingBusinessManagement.Models;
using PublishingBusinessManagement.Repositories.UnitOfWork;
using System.Linq.Expressions;

namespace PublishingBusinessManagement.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(
            string? filter = null,
            string? sortBy = null,
            bool ascending = true,
            int pageIndex = 1,
            int pageSize = 10);
        Task<Employee> GetEmployeeByIdAsync(string id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(string id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(
    string? filter = null,
    string? sortBy = null,
    bool ascending = true,
    int pageIndex = 1,
    int pageSize = 10)
        {
            Expression<Func<Employee, bool>>? filterExpression = null;

            if (!string.IsNullOrEmpty(filter))
            {
                filterExpression = e => EF.Functions.Like(e.Fname, $"%{filter}%") || EF.Functions.Like(e.Lname, $"%{filter}%");
            }

            Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? orderByFunc = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (ascending)
                {
                    orderByFunc = q => q.OrderBy(e => EF.Property<object>(e, sortBy));
                }
                else
                {
                    orderByFunc = q => q.OrderByDescending(e => EF.Property<object>(e, sortBy));
                }
            }

            // Gọi đến repository để lấy dữ liệu đã được xử lý
            return await _unitOfWork.EmployeeRepository.GetAsync(
                filter: filterExpression,
                orderBy: orderByFunc,
                pageIndex: pageIndex,
                pageSize: pageSize
            );
        }

        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            return await _unitOfWork.EmployeeRepository.GetByIDAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _unitOfWork.EmployeeRepository.InsertAsync(employee);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteEmployeeAsync(string id)
        {
            await _unitOfWork.EmployeeRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }

}
