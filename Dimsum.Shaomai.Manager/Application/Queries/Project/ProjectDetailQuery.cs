using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Queries.Project
{
    public class ProjectDetailQuery:IRequest<SolutionProject>
    {
        public Guid ProjectId { get; set; }
    }
}
