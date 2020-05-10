using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;

namespace Dimsum.Shaomai.IRepository
{
    public interface ISolutionProjectRepository: IBaseRepository<SolutionProject, Guid>
    {
        Task<bool> ExistProjectName(Guid solutionId, Guid envId, string name);

        Task<bool> ExistAppId(Guid solutionId, Guid envId, string appId);

        Task<List<SolutionProject>> GetProjectBySolutionId(Guid solutionId);
    }
}
