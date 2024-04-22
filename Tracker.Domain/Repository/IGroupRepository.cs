using Tracker.Data.Entities;

namespace Tracker.Domain.Repository
{
    public interface IGroupRepository
    {
        Task<IEnumerable<object>> GetAllGroups();
        Task<Group> GetGroupById(Guid id);
        Task AddGroup(Group category);
        Task UpdateGroup(Group category);
        Task DeleteGroup(Guid id);
    }
}
