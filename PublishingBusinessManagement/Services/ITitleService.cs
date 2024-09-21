using PublishingBusinessManagement.Models;
using PublishingBusinessManagement.Repositories.UnitOfWork;

namespace PublishingBusinessManagement.Services
{
    public interface ITitleService
    {
        Task<IEnumerable<Title>> GetAllTittlesAsync();
        Task<Title> GetTitlleByIdAsync(string id);
        Task AddTitleAsync(Title title);
        Task UpdateTitleAsync(Title title);
        Task DeleteTitleAsync(string id);
    }

    public class TitleService : ITitleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TitleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Title>> GetAllTittlesAsync()
        {
            return await _unitOfWork.TitleRepository.GetAsync();
        }

        public async Task<Title> GetTitlleByIdAsync(string id)
        {
            return await _unitOfWork.TitleRepository.GetByIDAsync(id);
        }

        public async Task AddTitleAsync(Title title)
        {
            await _unitOfWork.TitleRepository.InsertAsync(title);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateTitleAsync(Title title)
        {
            _unitOfWork.TitleRepository.Update(title);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteTitleAsync(string id)
        {
            await _unitOfWork.TitleRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
