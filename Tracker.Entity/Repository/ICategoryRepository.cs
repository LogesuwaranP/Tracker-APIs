using Tracker.Data.Entities;

namespace Tracker.Domain.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<object>> GetAllData();
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(Guid id);
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Guid id);
    }
}
