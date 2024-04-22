using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Entities;

namespace Tracker.Domain.Service.ExpenseFilter
{
    public interface IExpenseFilter
    {
        public IEnumerable<ExpenseResponseDto> FilterDates(DateTime startDate, DateTime endDate);
        public IEnumerable<ExpenseResponseDto> FilterByMonth(int month);
        public IEnumerable<ExpenseResponseDto> FilterByType(Guid type);
        public IEnumerable<dynamic> Groupbytype();
    }
}
