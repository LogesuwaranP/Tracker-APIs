using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Entities;
using Tracker.Data.Repository;
using Tracker.Domain.Repository;

namespace Tracker.Domain.UseCase.Mails
{
    public class AddMailsCommand : IRequest<Unit>
    {
        public List<ExpenseMail>? ExpenseMails { get; set; }
    }

    public class AddMailsUseCase : IRequestHandler<AddMailsCommand, Unit>
    {
        private readonly IExpenseMailRepository _expenseMailRepository;

        public AddMailsUseCase(IExpenseMailRepository expenseMailRepository)
        {
            _expenseMailRepository = expenseMailRepository;
        }

        public async Task<Unit> Handle(AddMailsCommand request, CancellationToken cancellationToken)
        {
            if (request.ExpenseMails == null)
            {
                throw new ArgumentNullException("Mail list cannot be null.");
            }

            if (!request.ExpenseMails.Any())
            {
                throw new ArgumentNullException("Mail list cannot be empty.");
            }

            await _expenseMailRepository.AddExpenseAsync(request.ExpenseMails);

            return Unit.Value;
        }
    }

}
