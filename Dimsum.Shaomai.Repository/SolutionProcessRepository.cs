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
    public class SolutionProcessRepository: BaseRepository<SolutionProcess, Guid>, ISolutionProcessRepository
    {
        private readonly DomainContext _domainContext;

        public SolutionProcessRepository(DomainContext domainContext) : base(domainContext)
        {
            _domainContext = domainContext;
        }


        public async Task<List<SolutionProcess>> GetSolutionProcess(Guid solutionId, int pageIndex, int pageSize)
        {
            return await _domainContext.SolutionProcesses.Where(x => x.SolutionId == solutionId)
                .OrderByDescending(x => x.CreatedOn).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
