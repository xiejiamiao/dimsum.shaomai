using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto;
using Dimsum.Shaomai.ManagerDto.User;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Queries.User
{
    public class ExistUserNameQuery:IRequest<BaseDto>
    {
        public string Username { get; }

        public ExistUserNameQuery(string username)
        {
            Username = username;
        }
    }
}
