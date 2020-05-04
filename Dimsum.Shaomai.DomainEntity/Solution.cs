using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.DomainEntity
{
    public class Solution:IBaseEntity
    {
        public Guid Id { get; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// 解决方案英文名(作为命名空间一部分)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 解决方案中文名(展示用)
        /// </summary>
        public string CName { get; set; }

        /// <summary>
        /// 解决方案联系邮箱
        /// </summary>
        public string ContactEmail { get; set; }

        /// <summary>
        /// 解决方案所属用户Id
        /// </summary>
        public Guid ManagerUserId { get; set; }

        /// <summary>
        /// 【导航属性】解决方案所属用户
        /// </summary>
        public ManagerUser ManagerUser { get; set; }

    }
}
