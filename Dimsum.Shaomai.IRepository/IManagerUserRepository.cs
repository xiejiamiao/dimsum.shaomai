using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;

namespace Dimsum.Shaomai.IRepository
{
    public interface IManagerUserRepository:IBaseRepository<ManagerUser,Guid>
    {
        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> ExistUserName(string username, CancellationToken cancellationToken = default);

        /// <summary>
        /// 根据用户名查询用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ManagerUser> GetManagerUserByUserNameAsync(string username, CancellationToken cancellationToken = default);
    }
}
