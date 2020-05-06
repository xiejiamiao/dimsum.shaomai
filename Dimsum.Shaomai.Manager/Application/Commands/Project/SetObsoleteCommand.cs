using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Commands.Project
{
    public class SetObsoleteCommand:IRequest<BaseDto>
    {
        public Guid PropertyId { get; set; }
    }
}
