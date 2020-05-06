using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.Project;
using Dimsum.Shaomai.ManagerDto.Project;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.Project
{
    public class ProjectPropertyQueryHandler:IRequestHandler<ProjectPropertyQuery,List<PropertyListItem>>
    {
        private readonly ISolutionProjectPropertyRepository _solutionProjectPropertyRepository;

        public ProjectPropertyQueryHandler(ISolutionProjectPropertyRepository solutionProjectPropertyRepository)
        {
            _solutionProjectPropertyRepository = solutionProjectPropertyRepository;
        }

        public async Task<List<PropertyListItem>> Handle(ProjectPropertyQuery request, CancellationToken cancellationToken)
        {
            var dbProperties = string.IsNullOrEmpty(request.ParentId)
                ? await _solutionProjectPropertyRepository.GetTopLevelByProjectId(request.ProjectId)
                : await _solutionProjectPropertyRepository.GetByParentId(Guid.Parse(request.ParentId));
            return dbProperties.Select(x => new PropertyListItem()
            {
                Id = x.Id.ToString(),
                Level = x.Level,
                Type = x.Type.ToString(),
                Key = x.Key,
                Value = x.Type == PropertyType.Group ? "" : x.Value,
                IsObsolete = x.IsObsolete,
                CreatedOn = x.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss"),
                LastUpdatedOn = x.LastUpdatedOn.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToList();
        }
    }
}
