using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Tracker.Data.Context;
using Tracker.Data.Entities;
using Tracker.Domain.Service.ExpenseService;

namespace Tracker.Domain.Service.ExpenseService
{
    public class ExpenseService : IExpenseService
    {
        private readonly TrackerContext _dbContextExpense; 
        private readonly IMapper _mapper;

        public ExpenseService(TrackerContext dbContextExpense, IMapper mapper)
        {
            _dbContextExpense = dbContextExpense;
            _mapper = mapper;
        }

        public IEnumerable<ExpenseResponseDto> GetExpenseList()
        {
            var data = _dbContextExpense.Expense.ToList();

            if(data.Count > 0)
            {
                List<ExpenseResponseDto> responseDto = _mapper.Map<List<ExpenseResponseDto>>(data);

                return responseDto;

            }
            else
            {
                return null!;
            }
        }

        public Expense AddExpense(ExpenseRequestDto expense)
        {
            if (expense == null)
            {
                return null!;
            }
            
            Expense newExpense = _mapper.Map<Expense>(expense);
            newExpense.ExpenseCreatedDate = DateTime.Now;
            newExpense.ExpenseModifiedDate = DateTime.Now;
            _dbContextExpense.Expense.Add(newExpense);

            _dbContextExpense.SaveChanges();

            return newExpense;

        }

        public Expense GetExpenseById(Guid id)
        {
            Expense expense = _dbContextExpense.Expense.FirstOrDefault(x => x.ExpenseId == id);
            if (expense == null)
            {
                return null!;
            }
            return expense;
        }

        public Expense UpdateExpense(Guid id, ExpenseRequestDto expense)
        {
            if (expense == null || id == null)
            {
                return null;
            }

            Expense newExpense = _mapper.Map<Expense>(expense);
            Expense exById = GetExpenseById(id);
            if (exById == null)
            {
                return null;
            }

            newExpense.ExpenseId = id;
            newExpense.ExpenseCreatedDate = exById.ExpenseCreatedDate;
            newExpense.ExpenseModifiedDate = DateTime.Now;
            _dbContextExpense.Expense.Update(newExpense);

            _dbContextExpense.SaveChanges();

            return newExpense;

        }


        public Expense DeleteExpense()
        {
            throw new NotImplementedException();
        }
    }
}
