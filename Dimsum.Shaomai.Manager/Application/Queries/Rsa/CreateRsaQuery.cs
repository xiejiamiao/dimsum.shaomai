using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto.Rsa;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Queries.Rsa
{
    public class CreateRsaQuery:IRequest<RsaInfo>
    {
    }
}
