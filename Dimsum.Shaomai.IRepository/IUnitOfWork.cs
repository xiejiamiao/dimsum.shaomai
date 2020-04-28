using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dimsum.Shaomai.IRepository
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns></returns>
        int SaveChanged();

        /// <summary>
        /// 异步保存修改
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <returns></returns>
        bool SaveEntities();

        /// <summary>
        /// 异步保存实体
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
