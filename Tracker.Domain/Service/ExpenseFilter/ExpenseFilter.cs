using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Context;
using Tracker.Data.Entities;

namespace Tracker.Domain.Service.ExpenseFilter
{
    public class ExpenseFilter : IExpenseFilter
    {
        private readonly TrackerContext _dbContextExpense;
        private readonly IMapper _mapper;
        public ExpenseFilter(TrackerContext dbContextExpense, IMapper mapper)
        {
            _dbContextExpense = dbContextExpense;
            _mapper = mapper;
        }
        public IEnumerable<ExpenseResponseDto> FilterDates(DateTime startDate, DateTime endDate)
        {

            var data = _dbContextExpense.Expense.Where(e => e.ExpenseCreatedDate >= startDate && e.ExpenseCreatedDate <= endDate)
                         .ToList();
            if(data.Count > 0 )
            {
                List<ExpenseResponseDto> responseDto = _mapper.Map<List<ExpenseResponseDto>>(data);

                return responseDto;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ExpenseResponseDto> FilterByMonth(int month)
        {

            var data = _dbContextExpense.Expense.Where(e => e.ExpenseCreatedDate.Month == month)
                         .ToList();
            if (data.Count > 0)
            {
                List<ExpenseResponseDto> responseDto = _mapper.Map<List<ExpenseResponseDto>>(data);

                return responseDto;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ExpenseResponseDto> FilterByType(Guid type)
        {

            var data = _dbContextExpense.Expense.Where(e => e.ExpenseType == type)
                         .ToList();
            if (data.Count > 0)
            {
                List<ExpenseResponseDto> responseDto = _mapper.Map<List<ExpenseResponseDto>>(data);

                return responseDto;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<dynamic> Groupbytype()
        {

            var data = _dbContextExpense.Expense.GroupBy(d => d.ExpenseType).Select(group => new 
                            {
                                type = group.Key,
                                data = _mapper.Map<List<ExpenseResponseDto>>(group.ToList())
            // Add other aggregations or properties as needed
        })
                         .ToList();
            if (data.Count > 0)
            {               
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}
