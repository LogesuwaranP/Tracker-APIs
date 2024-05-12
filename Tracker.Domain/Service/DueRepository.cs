using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tracker.Data.Context;
using Tracker.Data.Entities;
using Tracker.Domain.Repository;

namespace Tracker.Domain.Service
{
    public class DueRepository : IDueRepository
    {
        private readonly TrackerContext _dbContextDue;
        private readonly IMapper _mapper;

        public DueRepository(TrackerContext dbContextExpense, IMapper mapper)
        {
            _dbContextDue = dbContextExpense;
            _mapper = mapper;
        }

        public async Task<Due> AddTaskAsync(Due due)
        {
            if (due == null) throw new ArgumentNullException(nameof(due));

            Data.Entities.Due dueNew = _mapper.Map<Due>(due);
            _dbContextDue.Dues.Add(dueNew);
            await _dbContextDue.SaveChangesAsync();
            
            return dueNew;
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            var dueToDelete = await _dbContextDue.Dues.FindAsync(id);

            if (dueToDelete != null)
            {
                _dbContextDue.Dues.Remove(dueToDelete);
                await _dbContextDue.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Due entry not found with the specified ID.", nameof(id));
            }
        }

        public async Task<IEnumerable<Due>> GetAllTasksAsync()
        {
            var data = await _dbContextDue.Dues.ToListAsync();

            if (data.Count > 0)
            {
                List<Due> responseDue = _mapper.Map<List<Due>>(data);

                return responseDue;

            }
            else
            {
                return null!;
            }
        }

        public async Task<Due> GetTaskAsync(Guid id)
        {
            Due? due = await _dbContextDue.Dues.FirstOrDefaultAsync(x => x.Id == id);
            if (due == null)
            {
                return null!;
            }
            
            return due;
        }

        public async Task TestAsync()
        {
            await _dbContextDue.SaveChangesAsync();
        }

        public async Task<Due> UpdateTaskAsync(Due due)
        {
            if (due == null) throw new ArgumentNullException(nameof(due));

            //Data.Entities.Due dueNew = _mapper.Map<Data.Entities.Due>(due);
            //_dbContextDue.Dues.Update(dueNew);
            await _dbContextDue.SaveChangesAsync();

            return due;

            //// Check if the entity with the given ID is already being tracked
            //var existingData = _dbContextDue.Dues.Local.FirstOrDefault(x => x.Id == due.Id);

            //if (existingData == null)
            //{
            //    // If the entity is not being tracked, query the database to check if it exists
            //    existingData = await _dbContextDue.Dues.FirstOrDefaultAsync(x => x.Id == due.Id);
            //}

            //if (existingData != null)
            //{
            //    // Data exists, perform the update
            //    existingData = _mapper.Map<Data.Entities.Due>(due);
            //    //_dbContextDue.Dues.Update(existingData);
            //    await _dbContextDue.SaveChangesAsync();

            //    return due;
            //}
            //else
            //{
            //    // Data does not exist, return a message
            //    throw new KeyNotFoundException($"Unable to find Due with Id: {due.Id.ToString()}");
            //    //return null!;
            //}
        }
    }
}
