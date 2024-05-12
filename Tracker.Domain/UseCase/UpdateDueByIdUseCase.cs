using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using Tracker.Data.Entities;
using Tracker.Domain.Repository;

namespace Tracker.Domain.UseCase
{
    public class UpdateCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Due? DueData { get; set; }
    }

    public class UpdateDueByIdUseCase : IRequestHandler<UpdateCommand, Guid>
    {
        private readonly IDueRepository _dueRepository;
        private readonly IMapper _mapper;

        public UpdateDueByIdUseCase(IDueRepository dueRepository, IMapper mapper)
        {
            _dueRepository = dueRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.DueData == null)
            {
                throw new ArgumentNullException("Update data is required. Due");
            }

            if (request.Id == Guid.Empty)
            {
                throw new ArgumentException("Invalid Id. Id must be a valid guid.");
            }

            Data.Entities.Due due = await _dueRepository.GetTaskAsync(request.Id);

            if (due == null)
            {
                throw new KeyNotFoundException($"Unable to find Due with Id: {request.DueData.Id.ToString()}");
            }

            UpdateDue(due, request.DueData);
            await _dueRepository.TestAsync();

            return due.Id;
        }

        public static void UpdateDue(Data.Entities.Due due, Due request)
        {
            due.Title = request.Title;
            due.TotalAmount = request.TotalAmount;
            due.AmountPaid = request.AmountPaid;
            due.AmountPlannedToPaidPerPeriod = request.AmountPlannedToPaidPerPeriod;
            due.DueDate = request.DueDate;

            due.DueDate = request.DueDate;
            due.PaymentFrequency = request.PaymentFrequency;
            due.Status = request.Status;
            due.PaymentMethod = request.PaymentMethod;
            due.ReminderDate = request.ReminderDate;
            due.Notes = request.Notes;
            due.LastUpdatedDate = DateTime.Now;
        }
    }
}
