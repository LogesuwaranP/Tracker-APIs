using MediatR;
using Tracker.Data.Entities;
using Tracker.Domain.Repository;

namespace Tracker.Domain.UseCase
{
    public class GetDueByIdRequest : IRequest<Due>
    {
        public Guid Id { get; set; }
    }

    public class GetDueByIdUseCase : IRequestHandler<GetDueByIdRequest, Due>
    {
        private readonly IDueRepository _dueRepository;

        public GetDueByIdUseCase(IDueRepository dueRepository)
        {
            _dueRepository = dueRepository;
        }

        public async Task<Due> Handle(GetDueByIdRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Id == Guid.Empty)
            {
                throw new ArgumentException("Invalid Id. Id must be a valid guid.");
            }

            Due due = await _dueRepository.GetTaskAsync(request.Id);

            if (due == null)
            {
                throw new KeyNotFoundException($"Unable to find Due with Id: {request.Id.ToString()}");
            }

            return due;
        }
    }
}
