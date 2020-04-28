using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Queries.User
{
    public class ExistUserNameQuery:IRequest<bool>
    {
        public string Username { get; }

        public ExistUserNameQuery(string username)
        {
            Username = username;
        }
    }
}
