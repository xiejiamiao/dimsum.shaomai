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
    public class ProjectCreatedEventHandler_AddProcess: INotificationHandler<ProjectCreatedEvent>
    {
        private readonly ILogger<ProjectCreatedEventHandler_AddProcess> _logger;
        private readonly ISolutionProcessRepository _solutionProcessRepository;

        private readonly ISolutionProjectRepository _solutionProjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectCreatedEventHandler_AddProcess(ILogger<ProjectCreatedEventHandler_AddProcess> logger,
            ISolutionProcessRepository solutionProcessRepository,
            ISolutionProjectRepository solutionProjectRepository,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _solutionProcessRepository = solutionProcessRepository;
            _solutionProjectRepository = solutionProjectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ProjectCreatedEvent notification, CancellationToken cancellationToken)
        {
            var projectInfo = await _solutionProjectRepository.GetAsync(notification.ProjectId);
            var processEntity = new SolutionProcess()
            {
                SolutionId = projectInfo.SolutionId,
                Level = SolutionProcessLevel.Property,
                Content = $"创建项目【{projectInfo.Name}({projectInfo.CName})】",
                CreatedOn = DateTime.Now
            };
            await _solutionProcessRepository.AddAsync(processEntity,cancellationToken);
            var changedRow = await _unitOfWork.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"触发ProjectCreatedEvent事件处理器 -> ProjectCreatedEventHandler_AddProcess -> ProjectId={notification.ProjectId} -> changedRow={changedRow}");
        }
    }
}
