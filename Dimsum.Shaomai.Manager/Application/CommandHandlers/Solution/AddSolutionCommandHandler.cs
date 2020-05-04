using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Commands.Solution;
using Dimsum.Shaomai.Manager.Application.Events;
using Dimsum.Shaomai.Manager.Infrastructure.Authorize;
using Dimsum.Shaomai.ManagerDto.Solution;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.CommandHandlers.Solution
{
    public class AddSolutionCommandHandler:IRequestHandler<AddSolutionCommand, AddSolution>
    {
        private readonly ISolutionRepository _solutionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly HttpAuthorizeHandler _httpAuthorizeHandler;

        public AddSolutionCommandHandler(ISolutionRepository solutionRepository,IUnitOfWork unitOfWork,IMediator mediator, HttpAuthorizeHandler httpAuthorizeHandler)
        {
            _solutionRepository = solutionRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _httpAuthorizeHandler = httpAuthorizeHandler;
        }

        public async Task<AddSolution> Handle(AddSolutionCommand request, CancellationToken cancellationToken)
        {
            var dbEntity = new DomainEntity.Solution()
            {
                Name = request.Name,
                CName = request.CName,
                ContactEmail = request.ContactEmail,
                ManagerUserId = _httpAuthorizeHandler.GetUseIdFromCookie(),
                SolutionProcesses = new List<SolutionProcess>()
                {
                    new SolutionProcess()
                    {
                        Level = SolutionProcessLevel.Solution,
                        Content = $"创建解决方案【{request.Name}】"
                    }
                }
            };
            await _solutionRepository.AddAsync(dbEntity, cancellationToken);
            var changedRow = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (changedRow > 0)
            {
                await _mediator.Publish(new SolutionCreatedEvent() {SolutionId = dbEntity.Id}, cancellationToken);
                return new AddSolution()
                {
                    IsSuccess = true,
                    Msg = "添加解决方案成功",
                    Id = dbEntity.Id
                };
            }
            else
            {
                return new AddSolution()
                {
                    IsSuccess = false,
                    Msg = "添加解决方案失败"
                };
            }
        }
    }
}
