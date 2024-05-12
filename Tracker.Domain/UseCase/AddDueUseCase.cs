using MediatR;
using Tracker.Data.Entities;
using Tracker.Domain.Repository;

namespace Tracker.Domain.UseCase
{
    public class AddDueCommand: IRequest<Guid>
    {
        public Due? dueRequst { get; set; }
    }

    public class AddDueUseCase : IRequestHandler<AddDueCommand, Guid> 
    {
        private readonly IDueRepository _dueRepository;

        public AddDueUseCase(IDueRepository dueRepository)
        {
            _dueRepository = dueRepository;
        }

        public async Task<Guid> Handle(AddDueCommand request, CancellationToken cancellationToken)
        {
            if (request.dueRequst == null) { return Guid.Empty; }

            request.dueRequst.Id = Guid.NewGuid();
            var data = await _dueRepository.AddTaskAsync(request.dueRequst);

            return request.dueRequst.Id;
        }
    }

}
