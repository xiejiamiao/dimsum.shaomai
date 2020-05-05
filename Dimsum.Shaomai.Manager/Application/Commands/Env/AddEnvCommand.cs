using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Commands.Env
{
    public class AddEnvCommand:IRequest<BaseDto>
    {
        public Guid SolutionId { get; set; }

        public string EnvName { get; set; }
    }
}
