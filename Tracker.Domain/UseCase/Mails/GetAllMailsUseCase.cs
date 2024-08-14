using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Entities;
using Tracker.Data.Repository;

namespace Tracker.Domain.UseCase.Mails
{
    public class GetAllMailsRequest : IRequest<List<ExpenseMail>>
    {
    }

    public class GetAllMailsUseCase : IRequestHandler<GetAllMailsRequest, List<ExpenseMail>>
    {
        private readonly IExpenseMailRepository _expenseMailRepository;

        public GetAllMailsUseCase(IExpenseMailRepository expenseMailRepository)
        {
            _expenseMailRepository = expenseMailRepository;
        }

        public async Task<List<ExpenseMail>> Handle(GetAllMailsRequest request, CancellationToken cancellationToken)
        {

            List<ExpenseMail>  mails = await _expenseMailRepository.GetAllExpenseMailAsync();

            if (mails.Any())
            {
                return mails;
            }

            throw new InvalidOperationException("No expense mails found.");
        }
    }

}
