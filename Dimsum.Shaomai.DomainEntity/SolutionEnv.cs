using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.DomainEntity
{
    public class SolutionEnv:IBaseEntity
    {
        public Guid Id { get; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// 解决方案Id
        /// </summary>
        public Guid SolutionId { get; set; }

        /// <summary>
        /// 【导航属性】解决方案
        /// </summary>
        public Solution Solution { get; set; }

        /// <summary>
        /// 环境变量名称
        /// </summary>
        public string EnvName { get; set; }

        /// <summary>
        /// 项目集合
        /// </summary>
        public List<SolutionProject> SolutionProjects { get; set; }
    }
}
