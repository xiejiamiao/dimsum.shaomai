using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Commands.Project;
using Dimsum.Shaomai.ManagerDto;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.CommandHandlers.Project
{
    public class AddPropertyCommandHandler:IRequestHandler<AddPropertyCommand,BaseDto>
    {
        private readonly ISolutionProjectPropertyRepository _solutionProjectPropertyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public AddPropertyCommandHandler(ISolutionProjectPropertyRepository solutionProjectPropertyRepository,IUnitOfWork unitOfWork,IMediator mediator)
        {
            _solutionProjectPropertyRepository = solutionProjectPropertyRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<BaseDto> Handle(AddPropertyCommand request, CancellationToken cancellationToken)
        {
            var existKey = string.IsNullOrEmpty(request.Parent)
                ? await _solutionProjectPropertyRepository.ExistKeyByParent(request.ProjectId, null, request.Key)
                : await _solutionProjectPropertyRepository.ExistKeyByParent(request.ProjectId, Guid.Parse(request.Parent), request.Key);
            if (existKey) return new BaseDto() {IsSuccess = false, Msg = "键已存在"};

            var level = 0;
            Guid? parentId = null;
            if (!string.IsNullOrEmpty(request.Parent))
            {
                var parentItem = await _solutionProjectPropertyRepository.GetAsync(Guid.Parse(request.Parent));
                level = parentItem.Level + 1;
                parentId = parentItem.Id;
            }

            var dbEntity = new SolutionProjectProperty()
            {
                SolutionProjectId = request.ProjectId,
                Level = level,
                ParentId = parentId,
                Type = request.Type.Equals("keyValue", StringComparison.OrdinalIgnoreCase)
                    ? PropertyType.KeyValue
                    : PropertyType.Group,
                IsObsolete = false,
                Key = request.Key,
                Value = request.Value
            }; 
            await _solutionProjectPropertyRepository.AddAsync(dbEntity, cancellationToken);
            var changedRow = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (changedRow > 0)
            {
                return new BaseDto()
                {
                    IsSuccess = true,Msg="添加成功"
                };
            }
            else
            {
                return new BaseDto()
                {
                    IsSuccess = false,
                    Msg="操作失败"
                };
            }
        }
    }
}
