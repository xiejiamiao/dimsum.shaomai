using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;

namespace Dimsum.Shaomai.IRepository
{
    public interface ISolutionEnvRepository: IBaseRepository<SolutionEnv, Guid>
    {
        /// <summary>
        /// 查询指定解决方案的环境变量
        /// </summary>
        /// <param name="solutionId"></param>
        /// <returns></returns>
        Task<List<SolutionEnv>> GetBySolutionId(Guid solutionId);

        /// <summary>
        /// 判断环境变量名是否存在
        /// </summary>
        /// <param name="solutionId"></param>
        /// <param name="envName"></param>
        /// <returns></returns>
        Task<bool> ExistEnvName(Guid solutionId, string envName);
    }
}
