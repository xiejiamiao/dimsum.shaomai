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
    public class SolutionRepository : BaseRepository<Solution, Guid>, ISolutionRepository
    {
        private readonly DomainContext _domainContext;

        public SolutionRepository(DomainContext domainContext) : base(domainContext)
        {
            _domainContext = domainContext;
        }


        public async Task<bool> ExistName(string name)
        {
            return await _domainContext.Solutions.AnyAsync(x => x.Name == name);
        }

        public async Task<List<Solution>> GetSolutionByOwner(Guid managerUserId)
        {
            return await _domainContext.Solutions.Where(x => x.ManagerUserId == managerUserId)
                .OrderByDescending(x => x.CreatedOn).ToListAsync();
        }

        public override async Task<Solution> GetAsync(Guid id)
        {
            return await _domainContext.Solutions.Include(x => x.SolutionEnvs).Include(x => x.SolutionProjects)
                .Where(x => x.Id == id).FirstAsync();
        }
    }
}
