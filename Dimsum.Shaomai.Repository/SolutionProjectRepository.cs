using System;
using System.Collections.Generic;
using System.Text;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.Infrastructure;
using Dimsum.Shaomai.IRepository;

namespace Dimsum.Shaomai.Repository
{
    public class SolutionProjectRepository: BaseRepository<SolutionProject, Guid>, ISolutionProjectRepository
    {
        public SolutionProjectRepository(DomainContext domainContext) : base(domainContext)
        {
        }
    }
}
