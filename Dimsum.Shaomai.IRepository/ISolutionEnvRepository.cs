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
    }
}
