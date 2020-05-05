using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;

namespace Dimsum.Shaomai.IRepository
{
    public interface ISolutionProcessRepository : IBaseRepository<SolutionProcess, Guid>
    {
        /// <summary>
        /// 查询解决方案操作日志
        /// </summary>
        /// <param name="solutionId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<SolutionProcess>> GetSolutionProcess(Guid solutionId, int pageIndex, int pageSize);
    }
}
