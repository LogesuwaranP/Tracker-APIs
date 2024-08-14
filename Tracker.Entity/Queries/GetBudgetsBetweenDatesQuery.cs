using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Entities;
using Tracker.Data.ResponseModels;

namespace Tracker.Data.Queries
{
    public class GetBudgetsBetweenDatesQuery : IRequest<IEnumerable<BudgetWithCategoryDetails>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public GetBudgetsBetweenDatesQuery(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
