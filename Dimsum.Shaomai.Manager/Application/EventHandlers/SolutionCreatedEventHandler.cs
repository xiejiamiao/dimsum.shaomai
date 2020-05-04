using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dimsum.Shaomai.Manager.Application.EventHandlers
{
    public class SolutionCreatedEventHandler_AddDefaultEnv:INotificationHandler<SolutionCreatedEvent>
    {
        private readonly ILogger<SolutionCreatedEventHandler_AddDefaultEnv> _logger;
        private readonly ISolutionRepository _solutionRepository;
        private readonly ISolutionEnvRepository _solutionEnvRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SolutionCreatedEventHandler_AddDefaultEnv(ILogger<SolutionCreatedEventHandler_AddDefaultEnv> logger,ISolutionRepository solutionRepository,ISolutionEnvRepository solutionEnvRepository,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _solutionRepository = solutionRepository;
            _solutionEnvRepository = solutionEnvRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(SolutionCreatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var dbSolution = await _solutionRepository.GetAsync(notification.SolutionId);
            dbSolution.SolutionEnvs.Add(new SolutionEnv()
            {
                SolutionId = notification.SolutionId,
                EnvName = "Development"
            });
            dbSolution.SolutionProcesses.Add(new SolutionProcess()
            {
                Level = SolutionProcessLevel.Env,
                Content = "添加默认环境变量【Development】"
            });
            await _solutionRepository.UpdateAsync(dbSolution);
            var changedRow = await _unitOfWork.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(
                $"触发SolutionCreatedEvent事件处理器-> AddDefaultEnv -> {notification.SolutionId} -> changedRow={changedRow}");
        }
    }

    public class SolutionCreatedEventHandlerV2:INotificationHandler<SolutionCreatedEvent>
    {
        private readonly ILogger<SolutionCreatedEventHandlerV2> _logger;

        public SolutionCreatedEventHandlerV2(ILogger<SolutionCreatedEventHandlerV2> logger)
        {
            _logger = logger;
        }

        public async Task Handle(SolutionCreatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            _logger.LogInformation($"触发解决方案创建成功事件通知Step2 -> {notification.SolutionId}");
        }
    }
}
