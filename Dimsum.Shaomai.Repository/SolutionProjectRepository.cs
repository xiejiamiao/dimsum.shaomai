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
    public class SolutionProjectRepository: BaseRepository<SolutionProject, Guid>, ISolutionProjectRepository
    {
        private readonly DomainContext _domainContext;

        public SolutionProjectRepository(DomainContext domainContext) : base(domainContext)
        {
            _domainContext = domainContext;
        }

        public async Task<bool> ExistProjectName(Guid solutionId, Guid envId,string name)
        {
            return await _domainContext.SolutionProjects.AnyAsync(x =>
                x.SolutionId == solutionId && x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                x.SolutionEnvId == envId);
        }

        public async Task<bool> ExistAppId(Guid solutionId, Guid envId,string appId)
        {
            return await _domainContext.SolutionProjects.AnyAsync(x =>
                x.SolutionId == solutionId && x.AppId.Equals(appId, StringComparison.OrdinalIgnoreCase) &&
                x.SolutionEnvId == envId);
        }

        public async Task<List<SolutionProject>> GetProjectBySolutionId(Guid solutionId)
        {
            return await _domainContext.SolutionProjects.Where(x => x.SolutionId == solutionId)
                .OrderBy(x => x.CreatedOn).ToListAsync();
        }
    }
}
