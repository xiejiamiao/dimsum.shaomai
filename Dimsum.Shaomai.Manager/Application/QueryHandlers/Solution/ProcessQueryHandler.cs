using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.Solution;
using Dimsum.Shaomai.ManagerDto.Solution;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.Solution
{
    public class ProcessQueryHandler:IRequestHandler<ProcessQuery,List<ProcessListItem>>
    {
        private readonly ISolutionProcessRepository _solutionProcessRepository;


        public ProcessQueryHandler(ISolutionProcessRepository solutionProcessRepository)
        {
            _solutionProcessRepository = solutionProcessRepository;
        }

        public async Task<List<ProcessListItem>> Handle(ProcessQuery request, CancellationToken cancellationToken)
        {
            var dbProcess = await _solutionProcessRepository.GetSolutionProcess(request.SolutionId, request.PageIndex,
                request.PageSize);
            return dbProcess.Select(x => new ProcessListItem()
            {
                Level = x.Level.ToString(),
                Content = x.Content,
                ProcessedOn = x.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToList();
        }
    }
}
