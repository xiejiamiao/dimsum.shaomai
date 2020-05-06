using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Commands.Project
{
    public class AddPropertyCommand:IRequest<BaseDto>
    {
        public Guid ProjectId { get; set; }

        public string Type { get; set; }

        public string Parent { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
