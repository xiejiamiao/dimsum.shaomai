using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.Infrastructure;
using Dimsum.Shaomai.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Dimsum.Shaomai.Repository
{
    public class ManagerUserRepository : BaseRepository<ManagerUser, Guid>, IManagerUserRepository
    {
        private readonly DomainContext _domainContext;

        public ManagerUserRepository(DomainContext domainContext) : base(domainContext)
        {
            _domainContext = domainContext;
        }

        public async Task<bool> ExistUserName(string username,CancellationToken cancellationToken=default)
        {
            return await _domainContext.ManagerUsers.AnyAsync(x =>
                x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase), cancellationToken);
        }

        public async Task<ManagerUser> GetManagerUserByUserNameAsync(string username, CancellationToken cancellationToken = default)
        {
            return await _domainContext.ManagerUsers.Where(x => x.UserName == username).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
