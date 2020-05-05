using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Events
{
    public class ProjectCreatedEvent: INotification
    {
        public Guid ProjectId { get; set; }
    }
}
