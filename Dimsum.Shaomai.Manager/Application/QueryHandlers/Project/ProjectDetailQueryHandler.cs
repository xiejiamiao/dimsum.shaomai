using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.Project;
using Dimsum.Shaomai.ManagerDto.User;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.Project
{
    public class ProjectDetailQueryHandler:IRequestHandler<ProjectDetailQuery,SolutionProject>
    {
        private readonly ISolutionProjectRepository _solutionProjectRepository;

        public ProjectDetailQueryHandler(ISolutionProjectRepository solutionProjectRepository)
        {
            _solutionProjectRepository = solutionProjectRepository;
        }

        public async Task<SolutionProject> Handle(ProjectDetailQuery request, CancellationToken cancellationToken)
        {
            return await _solutionProjectRepository.GetAsync(request.ProjectId);
        }
    }
}
