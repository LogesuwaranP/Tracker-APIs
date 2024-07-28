using Tracker.Data.Entities;

namespace Tracker.Domain.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<object>> GetAllData();
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(Guid id);
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task UpdateSpent(Guid id, decimal amount);
        Task DeleteCategory(Guid id);
    }
}
