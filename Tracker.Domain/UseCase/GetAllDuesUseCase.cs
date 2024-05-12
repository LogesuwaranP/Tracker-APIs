using MediatR;
using System.Collections.Generic;
using Tracker.Data.Entities;
using Tracker.Data.Repository;
using Tracker.Domain.Repository;

namespace Tracker.Domain.UseCase
{
    public class GetAllDuesRequest : IRequest<List<Due>?>
    {
        public int Id { get; set; }
    }

    public class GetAllDuesUseCase : IRequestHandler<GetAllDuesRequest, List<Due>?>
    {
        private readonly IDueRepository _dueRepository;
        private readonly ITestRepository _testRepository;

        public GetAllDuesUseCase(IDueRepository dueRepository, ITestRepository testRepository)
        {
            _dueRepository = dueRepository;
            _testRepository = testRepository;
        }

        public async Task<List<Due>?> Handle(GetAllDuesRequest request, CancellationToken cancellationToken)
        {
            var data = await _dueRepository.GetAllTasksAsync();

            return (List<Due>?)data;
        }

    }
}
