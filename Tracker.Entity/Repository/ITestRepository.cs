using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Entities;

namespace Tracker.Data.Repository
{
    public interface ITestRepository
    {
        Task<IEnumerable<Due>> GetAllTasksAsync();
    }
}
