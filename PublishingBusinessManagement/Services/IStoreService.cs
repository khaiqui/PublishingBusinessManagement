using PublishingBusinessManagement.Models;
using PublishingBusinessManagement.Repositories.UnitOfWork;

namespace PublishingBusinessManagement.Services
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> GetAllStoresAsync();
        Task<Store> GetStoreByIdAsync(string id);
        Task AddStoreAsync(Store store);
        Task UpdateStoreAsync(Store store);
        Task DeleteStoreAsync(string id);
    }
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Store>> GetAllStoresAsync()
        {

            return await _unitOfWork.StoreRepository.GetAsync();
        }

        public async Task<Store> GetStoreByIdAsync(string id)
        {
            return await _unitOfWork.StoreRepository.GetByIDAsync(id);
        }

        public async Task AddStoreAsync(Store store)
        {
            await _unitOfWork.StoreRepository.InsertAsync(store);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateStoreAsync(Store store)
        {
            _unitOfWork.StoreRepository.Update(store);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteStoreAsync(string id)
        {
            await _unitOfWork.StoreRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
