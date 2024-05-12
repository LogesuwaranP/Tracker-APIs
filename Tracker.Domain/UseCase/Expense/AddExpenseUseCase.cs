using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Entities;
using Tracker.Domain.Repository;

namespace Tracker.Domain.UseCase.Expense
{
    public class AddExpenseRequest: IRequest<List<Due>?>
    {

    }

    public class AddExpenseUseCase : IRequestHandler<AddExpenseRequest, List<Due>?>
    {

        public Task<List<Due>?> Handle(AddExpenseRequest request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            return null!;
        }
    }
}

