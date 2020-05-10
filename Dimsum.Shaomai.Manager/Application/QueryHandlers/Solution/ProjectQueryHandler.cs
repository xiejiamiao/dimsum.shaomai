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
    public class ProjectQueryHandler:IRequestHandler<ProjectQuery, List<ProjectListItem>>
    {
        private readonly ISolutionProjectRepository _solutionProject;

        public ProjectQueryHandler(ISolutionProjectRepository solutionProject)
        {
            _solutionProject = solutionProject;
        }

        public async Task<List<ProjectListItem>> Handle(ProjectQuery request, CancellationToken cancellationToken)
        {
            var dbProjects = await _solutionProject.GetProjectBySolutionId(request.SolutionId);
            return dbProjects.Select(x => new ProjectListItem()
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                CName = x.CName
            }).ToList();
        }
    }
}
