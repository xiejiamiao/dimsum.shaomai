using System;
using System.Collections.Generic;
using System.Text;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.Infrastructure;
using Dimsum.Shaomai.IRepository;

namespace Dimsum.Shaomai.Repository
{
    public class SolutionEnvRepository : BaseRepository<SolutionEnv, Guid>, ISolutionEnvRepository
    {
        public SolutionEnvRepository(DomainContext domainContext) : base(domainContext)
        {
        }
    }
}
