using MediatR;
using Tracker.Domain.Repository;

namespace Tracker.Domain.UseCase
{

    public class DeleteCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }

    public class DeleteDueByIdUseCase : IRequestHandler<DeleteCommand, Guid>
    {
        private readonly IDueRepository _dueRepository;

        public DeleteDueByIdUseCase(IDueRepository dueRepository)
        {
            _dueRepository = dueRepository;
        }

        public async Task<Guid> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Id == Guid.Empty)
            {
                throw new ArgumentException("Invalid Id. Id must be a valid guid.");
            }

            await _dueRepository.DeleteTaskAsync(request.Id);

            return request.Id;
        }
    }
}
