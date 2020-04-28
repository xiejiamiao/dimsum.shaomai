using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.DomainEntity
{
    public class ManagerUser:IBaseEntity
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码盐
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// MD5密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        public bool EmailIsValidate { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string AvatarUrl { get; set; }
    }
}
