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
    public class SetObsoleteCommandHandler:IRequestHandler<SetObsoleteCommand,BaseDto>
    {
        private readonly ISolutionProjectPropertyRepository _solutionProjectPropertyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetObsoleteCommandHandler(ISolutionProjectPropertyRepository solutionProjectPropertyRepository,IUnitOfWork unitOfWork)
        {
            _solutionProjectPropertyRepository = solutionProjectPropertyRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<BaseDto> Handle(SetObsoleteCommand request, CancellationToken cancellationToken)
        {
            var result = new List<SolutionProjectProperty>();
            result = await _solutionProjectPropertyRepository.GetPropertyRecursion(request.PropertyId, result);

            foreach (var item in result)
            {
                item.IsObsolete = true;
                await _solutionProjectPropertyRepository.UpdateAsync(item);
            }

            var changedRow = await _unitOfWork.SaveChangesAsync();
            if (changedRow > 0)
            {
                return new BaseDto(){IsSuccess = true,Msg = "操作成功"};
            }
            else
            {
                return new BaseDto(){IsSuccess = false,Msg = "操作失败"};
            }
        }
    }
}
