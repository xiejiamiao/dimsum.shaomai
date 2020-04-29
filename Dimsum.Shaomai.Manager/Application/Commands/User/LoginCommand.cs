using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Commands.User
{
    public class LoginCommand:IRequest<BaseDto>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
