using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto.Solution;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Queries.Solution
{
    public class ProcessQuery:IRequest<List<ProcessListItem>>
    {
        public Guid SolutionId { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
