using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto.User;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Queries.User
{
    public class UserInfoQuery:IRequest<UserInfo>
    {
    }
}
