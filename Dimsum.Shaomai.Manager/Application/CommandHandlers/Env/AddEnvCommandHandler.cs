using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Commands.Env;
using Dimsum.Shaomai.Manager.Application.Events;
using Dimsum.Shaomai.ManagerDto;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.CommandHandlers.Env
{
    public class AddEnvCommandHandler:IRequestHandler<AddEnvCommand,BaseDto>
    {
        private readonly ISolutionEnvRepository _solutionEnvRepository;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public AddEnvCommandHandler(ISolutionEnvRepository solutionEnvRepository,IMediator mediator,IUnitOfWork unitOfWork)
        {
            _solutionEnvRepository = solutionEnvRepository;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseDto> Handle(AddEnvCommand request, CancellationToken cancellationToken)
        {
            if (await _solutionEnvRepository.ExistEnvName(request.SolutionId, request.EnvName)) return new BaseDto() {IsSuccess = false, Msg = "环境变量名已存在"};

            var dbEntity = new SolutionEnv()
            {
                SolutionId = request.SolutionId,
                EnvName = request.EnvName,
            };
            await _solutionEnvRepository.AddAsync(dbEntity,cancellationToken);
            var changedRow = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (changedRow > 0)
            {
                await _mediator.Publish(new EnvCreatedEvent() {SolutionId = request.SolutionId, EnvId = dbEntity.Id}, cancellationToken);
                return new BaseDto(){IsSuccess = true,Msg="添加成功"};
            }
            else
            {
                return new BaseDto() { IsSuccess = true, Msg = "添加失败" };
            }
        }
    }
}
