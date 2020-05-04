using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Queries.Solution
{
    public class SolutionDetailQuery:IRequest<DomainEntity.Solution>
    {
        public Guid Id { get; set; }
    }
}
