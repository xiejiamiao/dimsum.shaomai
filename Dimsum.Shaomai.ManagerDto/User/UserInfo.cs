using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.ManagerDto.User
{
    public class UserInfo:IBaseDto
    {
        public bool IsSuccess { get; set; }

        public string Msg { get; set; }

        public string UserName { get; set; }

        public string Avatar { get; set; }
    }
}
