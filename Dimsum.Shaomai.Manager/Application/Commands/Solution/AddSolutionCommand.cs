using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto.Solution;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Commands.Solution
{
    public class AddSolutionCommand:IRequest<AddSolution>
    {
        public string Name { get; set; }

        public string CName { get; set; }

        public string ContactEmail { get; set; }
    }
}
