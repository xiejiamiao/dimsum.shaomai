using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Commands.Project
{
    public class AddProjectCommand:IRequest<BaseDto>
    {
        public Guid SolutionId { get; set; }

        public Guid EnvId { get; set; }

        public string Name { get; set; }

        public string CName { get; set; }

        public string AppId { get; set; }
    }
}
