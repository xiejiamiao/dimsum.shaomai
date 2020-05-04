using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;

namespace Dimsum.Shaomai.IRepository
{
    public interface ISolutionRepository: IBaseRepository<Solution, Guid>
    {
        /// <summary>
        /// 英文名是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> ExistName(string name);

        /// <summary>
        /// 查询个人所有的解决方案
        /// </summary>
        /// <param name="managerUserId"></param>
        /// <returns></returns>
        Task<List<Solution>> GetSolutionByOwner(Guid managerUserId);
    }
}
