using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.ManagerDto.User
{
    public class RegisterUser: IBaseDto
    {
        public bool IsSuccess { get; set; }
        public string Msg { get; set; }

        public Guid? Id { get; set; }
    }
}
