using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.DomainEntity
{
    public class SolutionRsa:IBaseEntity
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
        /// 密钥标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// RSA类型
        /// </summary>
        public RsaType RsaType { get; set; }

        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string PrivateKey { get; set; }

        public List<SolutionRsaProject> SolutionRsaProjects { get; set; }
    }

    public enum RsaType
    {
        AllProject,
        SomeProject
    }
}
