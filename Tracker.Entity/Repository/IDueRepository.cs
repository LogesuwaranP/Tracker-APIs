using Tracker.Data.Entities;

namespace Tracker.Domain.Repository
{
    public interface IDueRepository
    {
        Task<IEnumerable<Due>> GetAllTasksAsync();
        Task<Due> AddTaskAsync(Due due);
        Task<Due> GetTaskAsync(Guid id);
        Task<Due> UpdateTaskAsync(Due due);
        Task DeleteTaskAsync(Guid id);
        Task TestAsync();
    }
}
