using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.DomainEntity
{
    public interface IBaseEntity
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// 是否已经删除
        /// </summary>
        bool IsDeleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        DateTime? DeletedOn { get; set; }
    }
}
