using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.Project;
using Dimsum.Shaomai.ManagerDto.Project;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.Project
{
    public class PropertyGroupQueryHandler:IRequestHandler<PropertyGroupQuery,List<GroupPropertyListItem>>
    {
        private readonly ISolutionProjectPropertyRepository _solutionProjectPropertyRepository;
        private readonly ILogger<PropertyGroupQueryHandler> _logger;

        public PropertyGroupQueryHandler(ISolutionProjectPropertyRepository solutionProjectPropertyRepository,ILogger<PropertyGroupQueryHandler> logger)
        {
            _solutionProjectPropertyRepository = solutionProjectPropertyRepository;
            _logger = logger;
        }

        public async Task<List<GroupPropertyListItem>> GetGroupByParent(Guid projectId,Guid? parentId,List<GroupPropertyListItem> result)
        {
            if (!parentId.HasValue)
            {
                var top = await _solutionProjectPropertyRepository.GetGroupByParentId(projectId, null);
                foreach (var item in top)
                {
                    result.Add(new GroupPropertyListItem()
                    {
                        Id = item.Id.ToString(),
                        Key = item.Key.PadLeft(item.Level,'-')
                    });
                    result = await GetGroupByParent(projectId, item.Id, result);
                }

                return result;
            }
            else
            {
                var group = await _solutionProjectPropertyRepository.GetGroupByParentId(projectId, parentId);
                if (group.Count > 0)
                {
                    foreach (var item in group)
                    {
                        var preKey = "╏";
                        for (int i = 0; i < item.Level; i++)
                        {
                            preKey += "➡";
                        }
                        result.Add(new GroupPropertyListItem()
                        {
                            Id = item.Id.ToString(),
                            Key = preKey+item.Key
                        });
                        result = await GetGroupByParent(projectId, item.Id, result);
                    }

                    return result;
                }
                else
                {
                    return result;
                }
            }
        }

        public async Task<List<GroupPropertyListItem>> Handle(PropertyGroupQuery request, CancellationToken cancellationToken)
        {
            var result = new List<GroupPropertyListItem>();
            result = await GetGroupByParent(request.ProjectId, null, result);
            return result;
        }
    }
}
