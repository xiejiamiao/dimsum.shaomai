using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.Project;
using Dimsum.Shaomai.ManagerDto.Project;
using Dimsum.Shaomai.Util;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.Project
{
    public class AllPropertyQueryHandler:IRequestHandler<AllPropertyQuery,List<PropertyListItem>>
    {
        private readonly ISolutionProjectPropertyRepository _solutionProjectPropertyRepository;

        public AllPropertyQueryHandler(ISolutionProjectPropertyRepository solutionProjectPropertyRepository)
        {
            _solutionProjectPropertyRepository = solutionProjectPropertyRepository;
        }

        public async Task<List<PropertyListItem>> AllPropertyRecursion(Guid projectId, Guid? parentId, List<PropertyListItem> result)
        {
            if (!parentId.HasValue)
            {
                var dbProperties = await _solutionProjectPropertyRepository.GetTopLevelByProjectId(projectId);
                foreach (var item in dbProperties)
                {
                    result.Add(new PropertyListItem()
                    {
                        Id = item.Id.ToString(),
                        Level = item.Level,
                        Type = item.Type.ToString(),
                        Key = item.Key,
                        Value = item.Value,
                        IsObsolete = item.IsObsolete,
                        CreatedOn = item.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss"),
                        LastUpdatedOn = item.LastUpdatedOn.ToString("yyyy-MM-dd HH:mm:ss"),
                        BackgroundColor = ConstValue.SafeColor[item.Level % ConstValue.SafeColor.Count]
                    });
                    if (item.Type == PropertyType.Group)
                    {
                        result = await AllPropertyRecursion(projectId, item.Id, result);
                    }
                }

                return result;
            }
            else
            {
                var dbProperties = await _solutionProjectPropertyRepository.GetByParentId(parentId.Value);
                foreach (var item in dbProperties)
                {
                    var preKey = new StringBuilder();
                    for (int i = 0; i < item.Level; i++)
                    {
                        preKey.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
                    }

                    result.Add(new PropertyListItem()
                    {
                        Id = item.Id.ToString(),
                        Level = item.Level,
                        Type = item.Type.ToString(),
                        Key = preKey.ToString() + item.Key,
                        Value = item.Value,
                        IsObsolete = item.IsObsolete,
                        CreatedOn = item.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss"),
                        LastUpdatedOn = item.LastUpdatedOn.ToString("yyyy-MM-dd HH:mm:ss"),
                        BackgroundColor = ConstValue.SafeColor[item.Level % ConstValue.SafeColor.Count]
                    });
                    if (item.Type == PropertyType.Group)
                    {
                        result = await AllPropertyRecursion(projectId, item.Id, result);
                    }
                }

                return result;
            }
        }

        public async Task<List<PropertyListItem>> Handle(AllPropertyQuery request, CancellationToken cancellationToken)
        {
            var result = new List<PropertyListItem>();
            result = await AllPropertyRecursion(request.ProjectId, null, result);
            return result;
        }
    }
}
