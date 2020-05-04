using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Queries.Solution
{
    public class ExistNameQuery:IRequest<BaseDto>
    {
        public string Name { get; set; }
    }
}
