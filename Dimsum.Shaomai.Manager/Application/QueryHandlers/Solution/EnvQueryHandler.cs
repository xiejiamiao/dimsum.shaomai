using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.Solution;
using Dimsum.Shaomai.ManagerDto.Solution;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.Solution
{
    public class EnvQueryHandler:IRequestHandler<EnvQuery,List<EnvListItem>>
    {
        private readonly ISolutionEnvRepository _solutionEnvRepository;

        public EnvQueryHandler(ISolutionEnvRepository solutionEnvRepository)
        {
            _solutionEnvRepository = solutionEnvRepository;
        }

        public async Task<List<EnvListItem>> Handle(EnvQuery request, CancellationToken cancellationToken)
        {
            var envs = await _solutionEnvRepository.GetBySolutionId(request.SolutionId);
            return envs.Select(x => new EnvListItem()
            {
                Id = x.Id.ToString(),
                EnvName = x.EnvName
            }).ToList();
        }
    }
}
