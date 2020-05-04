using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.Solution;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.Solution
{
    public class SolutionDetailQueryHandler:IRequestHandler<SolutionDetailQuery,DomainEntity.Solution>
    {
        private readonly ISolutionRepository _solutionRepository;

        public SolutionDetailQueryHandler(ISolutionRepository solutionRepository)
        {
            _solutionRepository = solutionRepository;
        }

        public async Task<DomainEntity.Solution> Handle(SolutionDetailQuery request, CancellationToken cancellationToken)
        {
            return await _solutionRepository.GetAsync(request.Id);
        }
    }
}
