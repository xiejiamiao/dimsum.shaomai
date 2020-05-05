using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.DomainEntity
{
    public class SolutionProcess:IBaseEntity
    {
        public Guid Id { get; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// 解决方案Id
        /// </summary>
        public Guid SolutionId { get; set; }

        /// <summary>
        /// 【导航属性】解决方案
        /// </summary>
        public Solution Solution { get; set; }

        /// <summary>
        /// 操作等级
        /// </summary>
        public SolutionProcessLevel Level { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>
        public string Content { get; set; }
    }

    public enum SolutionProcessLevel
    {
        Solution,
        Env,
        Project,
        Property,
        WebHook
    }
}
