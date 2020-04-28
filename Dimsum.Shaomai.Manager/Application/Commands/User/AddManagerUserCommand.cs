using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Commands.User
{
    public class AddManagerUserCommand:IRequest<ManagerUser>
    {
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }

        public AddManagerUserCommand(string username,string password,string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
