using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Context;
using Tracker.Data.Entities;
using Tracker.Data.Repository;

namespace Tracker.Domain.Service
{
    public class TestRepository : ITestRepository
    {
        private readonly TrackerContext _dbContextDue;

        public TestRepository (TrackerContext dbContextDue)
        {
            _dbContextDue = dbContextDue;
        }
        public async Task<IEnumerable<Due>> GetAllTasksAsync()
        {
            List<Due> data = await _dbContextDue.Dues.ToListAsync();

            if (data.Count > 0)
            {
                return data;
            }
            else
            {
                return null!;
            }
        }
    }
}
