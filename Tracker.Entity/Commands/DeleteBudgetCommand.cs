using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data.Commands
{
    public class DeleteBudgetCommand : IRequest
    {
        public Guid BudgetId { get; set; }
    }
}
