using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.DomainEntity
{
    public class SolutionProject:IBaseEntity
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
        /// 环境变量Id
        /// </summary>
        public Guid SolutionEnvId { get; set; }

        /// <summary>
        /// 【导航属性】环境变量
        /// </summary>
        public SolutionEnv SolutionEnv { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 项目中文名
        /// </summary>
        public string CName { get; set; }

        /// <summary>
        /// 项目AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 是否开启webhook
        /// </summary>
        public bool IsEnableWebHook { get; set; }

        /// <summary>
        /// webhook地址
        /// </summary>
        public string WebHookUrl { get; set; }

        /// <summary>
        /// 公共缓存生命周期(秒)
        /// </summary>
        public int CommonCacheLife { get; set; }

        /// <summary>
        /// 【导航属性】配置项集合
        /// </summary>
        public List<SolutionProjectProperty> SolutionProjectProperties { get; set; }

        /// <summary>
        /// 【导航属性】授权Key与项目映射关系
        /// </summary>
        public List<SolutionRsaProject> SolutionRsaProjects { get; set; }


    }
}
