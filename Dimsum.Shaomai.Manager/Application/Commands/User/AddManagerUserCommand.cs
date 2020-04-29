using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.ManagerDto.User;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Commands.User
{
    public class AddManagerUserCommand:IRequest<RegisterUser>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
