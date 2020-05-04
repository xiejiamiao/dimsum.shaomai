using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.Solution;
using Dimsum.Shaomai.ManagerDto;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.Solution
{
    public class ExistNameQueryHandler : IRequestHandler<ExistNameQuery, BaseDto>
    {
        private readonly ISolutionRepository _solutionRepository;

        public ExistNameQueryHandler(ISolutionRepository solutionRepository)
        {
            _solutionRepository = solutionRepository;
        }

        public async Task<BaseDto> Handle(ExistNameQuery request, CancellationToken cancellationToken)
        {
            var exist = await _solutionRepository.ExistName(request.Name);
            return new BaseDto() {IsSuccess = !exist, Msg = exist ? "解决方案名称已存在" : "验证通过"};
        }
    }
}
