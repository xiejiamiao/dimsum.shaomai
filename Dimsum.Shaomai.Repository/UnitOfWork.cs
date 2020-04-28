using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.Infrastructure;
using Dimsum.Shaomai.IRepository;

namespace Dimsum.Shaomai.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DomainContext _ctx;

        public UnitOfWork(DomainContext ctx)
        {
            _ctx = ctx;
        }

        public int SaveChanged()
        {
            return _ctx.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _ctx.SaveChangesAsync(cancellationToken);
        }

        public bool SaveEntities()
        {
            return SaveChanged() > 0;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return (await SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
