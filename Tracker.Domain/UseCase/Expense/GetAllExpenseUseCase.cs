using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Entities;
using Tracker.Data.Repository;
using Tracker.Domain.Repository;
using Tracker.Domain.Service;
using Tracker.Domain.Service.ExpenseService;

namespace Tracker.Domain.UseCase.Expense
{
    public class GetAllExpenseRequest : IRequest<List<ExpenseResponseDto>?>
    {
        public int Id { get; set; }
    }

    public class GetAllExpenseUseCase : IRequestHandler<GetAllExpenseRequest, List<ExpenseResponseDto>?>
    {
        private readonly IExpenseService _expenseService;

        public GetAllExpenseUseCase(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public Task<List<ExpenseResponseDto>?> Handle(GetAllExpenseRequest request, CancellationToken cancellationToken)
        {
            var data = _expenseService.GetExpenseList();

            if (data == null)
            {
                return null!;
            }

            return null!;
        }
    }
}
