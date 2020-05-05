using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Events
{
    public class EnvCreatedEvent:INotification
    {
        public Guid SolutionId { get; set; }

        public Guid EnvId { get; set; }
    }
}
