using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.DomainEntity
{
    public class SolutionProjectProperty:IBaseEntity
    {
        public Guid Id { get; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        public Guid SolutionProjectId { get; set; }

        /// <summary>
        /// 【导航属性】项目
        /// </summary>
        public SolutionProject SolutionProject { get; set; }

        /// <summary>
        /// 配置项等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 配置项类型
        /// </summary>
        public PropertyType Type { get; set; }
        
        /// <summary>
        /// 是否已经过时
        /// </summary>
        public bool IsObsolete { get; set; }

        /// <summary>
        /// 配置项键
        /// </summary>
        public string Key { get; set; }
        
        /// <summary>
        /// 配置项的值(已发布)
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 配置项说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否已经发布
        /// </summary>
        public bool IsPublish { get; set; }

        /// <summary>
        /// 未发布的值
        /// </summary>
        public string ValueBeforePublish { get; set; }
    }

    public enum PropertyType
    {
        KeyValue,
        Group
    }
}
