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
    public class SolutionEnvRepository : BaseRepository<SolutionEnv, Guid>, ISolutionEnvRepository
    {
        private readonly DomainContext _domainContext;

        public SolutionEnvRepository(DomainContext domainContext) : base(domainContext)
        {
            _domainContext = domainContext;
        }

        public async Task<List<SolutionEnv>> GetBySolutionId(Guid solutionId)
        {
            return await _domainContext.SolutionEnvs.Where(x => x.SolutionId == solutionId)
                .OrderByDescending(x => x.CreatedOn).ToListAsync();
        }

        public async Task<bool> ExistEnvName(Guid solutionId, string envName)
        {
            return await _domainContext.SolutionEnvs.AnyAsync(x =>
                x.SolutionId == solutionId && x.EnvName.Equals(envName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
