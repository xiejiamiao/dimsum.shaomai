using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.Infrastructure;
using Dimsum.Shaomai.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Dimsum.Shaomai.Repository
{
    public class SolutionProjectPropertyRepository: BaseRepository<SolutionProjectProperty, Guid>, ISolutionProjectPropertyRepository
    {
        private readonly DomainContext _domainContext;

        public SolutionProjectPropertyRepository(DomainContext domainContext) : base(domainContext)
        {
            _domainContext = domainContext;
        }

        public async Task<List<SolutionProjectProperty>> GetTopLevelByProjectId(Guid projectId)
        {
            return await _domainContext.SolutionProjectProperties
                .Where(x => x.SolutionProjectId == projectId && x.Level == 0).OrderBy(x=>x.CreatedOn).ToListAsync();
        }

        public async Task<List<SolutionProjectProperty>> GetByParentId(Guid parentId)
        {
            return await _domainContext.SolutionProjectProperties
                .Where(x => x.ParentId.HasValue && x.ParentId == parentId).OrderBy(x=>x.CreatedOn).ToListAsync();
        }

        public async Task<bool> ExistKeyByParent(Guid projectId, Guid? parentId, string key)
        {
            if (parentId.HasValue)
            {
                return await _domainContext.SolutionProjectProperties
                    .AnyAsync(x => x.SolutionProjectId == projectId &&
                                   x.ParentId.HasValue &&
                                   x.ParentId.Value ==
                                   parentId.Value && x.Key == key);
            }
            else
            {
                return await _domainContext.SolutionProjectProperties.AnyAsync(x =>
                    x.SolutionProjectId == projectId && x.Key == key && x.Level == 0);
            }
        }

        public async Task<List<SolutionProjectProperty>> GetGroupByParentId(Guid projectId, Guid? parentId)
        {
            if (parentId.HasValue)
            {
                return await _domainContext.SolutionProjectProperties
                    .Where(x => x.SolutionProjectId == projectId
                                && x.Type == PropertyType.Group
                                && x.ParentId == parentId
                                && !x.IsObsolete)
                    .OrderBy(x => x.CreatedOn).ToListAsync();
            }
            else
            {
                return await _domainContext.SolutionProjectProperties.Where(x =>
                        x.SolutionProjectId == projectId && x.Type == PropertyType.Group && x.Level == 0 &&
                        !x.IsObsolete)
                    .OrderBy(x=>x.CreatedOn)
                    .ToListAsync();
            }
            
        }
    }
}
