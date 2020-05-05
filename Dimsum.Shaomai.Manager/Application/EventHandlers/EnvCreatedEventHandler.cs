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
    public class EnvCreatedEventHandler_AddProcess:INotificationHandler<EnvCreatedEvent>
    {
        private readonly ISolutionProcessRepository _solutionProcessRepository;
        private readonly ISolutionEnvRepository _solutionEnvRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EnvCreatedEventHandler_AddProcess> _logger;

        public EnvCreatedEventHandler_AddProcess(ISolutionProcessRepository solutionProcessRepository,
            ISolutionEnvRepository solutionEnvRepository,
            IUnitOfWork unitOfWork,
            ILogger<EnvCreatedEventHandler_AddProcess> logger)
        {
            _solutionProcessRepository = solutionProcessRepository;
            _solutionEnvRepository = solutionEnvRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(EnvCreatedEvent notification, CancellationToken cancellationToken)
        {
            var envInfo = await _solutionEnvRepository.GetAsync(notification.EnvId);
            var process = new SolutionProcess()
            {
                SolutionId = notification.SolutionId,
                Level = SolutionProcessLevel.Env,
                Content = $"创建环境变量【{envInfo.EnvName}】",
                CreatedOn = DateTime.Now
            };
            await _solutionProcessRepository.AddAsync(process,cancellationToken);
            var changedRow = await _unitOfWork.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"触发EnvCreatedEvent事件处理器 -> EnvCreatedEventHandler_AddProcess -> EnvId={notification.EnvId} -> changedRow={changedRow}");
        }
    }
}
