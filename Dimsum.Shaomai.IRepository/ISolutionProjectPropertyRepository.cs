using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;

namespace Dimsum.Shaomai.IRepository
{
    public interface ISolutionProjectPropertyRepository: IBaseRepository<SolutionProjectProperty, Guid>
    {
        /// <summary>
        /// 获得项目中最顶层的配置项
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<List<SolutionProjectProperty>> GetTopLevelByProjectId(Guid projectId);

        /// <summary>
        /// 获得指定父节点的一级子节点配置
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<List<SolutionProjectProperty>> GetByParentId(Guid parentId);

        /// <summary>
        /// 同个父级节点下是否有同样的键
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="parentId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> ExistKeyByParent(Guid projectId,Guid? parentId, string key);

        /// <summary>
        /// 根据父节点Id查询配置组
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<List<SolutionProjectProperty>> GetGroupByParentId(Guid projectId,Guid? parentId);
    }
}
