using System;
using System.Collections.Generic;
using System.Text;
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
        /// <returns></returns>
        Task<bool> ExistUserName(string username);
    }
}
