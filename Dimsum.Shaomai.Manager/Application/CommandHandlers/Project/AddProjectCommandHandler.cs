using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Commands.Project;
using Dimsum.Shaomai.Manager.Application.Events;
using Dimsum.Shaomai.ManagerDto;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.CommandHandlers.Project
{
    public class AddProjectCommandHandler:IRequestHandler<AddProjectCommand,BaseDto>
    {
        private readonly ISolutionProjectRepository _solutionProjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public AddProjectCommandHandler(ISolutionProjectRepository solutionProjectRepository,IUnitOfWork unitOfWork,IMediator mediator)
        {
            _solutionProjectRepository = solutionProjectRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<BaseDto> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var projectEntity = new SolutionProject()
            {
                SolutionId = request.SolutionId,
                SolutionEnvId = request.EnvId,
                Name = request.Name,
                CName = request.CName,
                AppId = request.AppId
            };
            await _solutionProjectRepository.AddAsync(projectEntity, cancellationToken);
            var changedRow = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (changedRow > 0)
            {
                await _mediator.Publish(new ProjectCreatedEvent() {ProjectId = projectEntity.Id}, cancellationToken);
                return new BaseDto(){IsSuccess = true,Msg = "Handler Success"};
            }
            else
            {
                return new BaseDto(){IsSuccess = false,Msg = "添加项目失败"};
            }
        }
    }
}
