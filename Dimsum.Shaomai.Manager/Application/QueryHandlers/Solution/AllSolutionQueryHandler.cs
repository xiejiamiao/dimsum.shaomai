using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.Solution;
using Dimsum.Shaomai.Manager.Infrastructure.Authorize;
using Dimsum.Shaomai.ManagerDto.Solution;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.Solution
{
    public class AllSolutionQueryHandler:IRequestHandler<AllSolutionQuery,List<SolutionListItem>>
    {
        private readonly ISolutionRepository _solutionRepository;
        private readonly HttpAuthorizeHandler _httpAuthorizeHandler;

        public AllSolutionQueryHandler(ISolutionRepository solutionRepository,HttpAuthorizeHandler httpAuthorizeHandler)
        {
            _solutionRepository = solutionRepository;
            _httpAuthorizeHandler = httpAuthorizeHandler;
        }

        public async Task<List<SolutionListItem>> Handle(AllSolutionQuery request, CancellationToken cancellationToken)
        {
            var solutions = await _solutionRepository.GetSolutionByOwner(_httpAuthorizeHandler.GetUseIdFromCookie());
            return solutions.Select(x => new SolutionListItem()
            {
                Id = x.Id,
                Name = x.Name,
                CName = x.CName
            }).ToList();
        }
    }
}
