using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Commands.Rsa;
using Dimsum.Shaomai.ManagerDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Dimsum.Shaomai.Manager.Application.CommandHandlers.Rsa
{
    public class AddRsaCommandHandler:IRequestHandler<AddRsaCommand,BaseDto>
    {
        private readonly ISolutionRsaRepository _solutionRsaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddRsaCommandHandler(ISolutionRsaRepository solutionRsaRepository,IUnitOfWork unitOfWork)
        {
            _solutionRsaRepository = solutionRsaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseDto> Handle(AddRsaCommand request, CancellationToken cancellationToken)
        {
            var dbEntity = new SolutionRsa()
            {
                Title = request.Name,
                PublicKey = request.PublicKey,
                PrivateKey = request.PrivateKey,
                SolutionId = Guid.Parse(request.SolutionId)
            };
            if (request.RsaType == "all")
            {
                dbEntity.RsaType = RsaType.AllProject;
            }
            else
            {
                dbEntity.RsaType = RsaType.SomeProject;
                dbEntity.SolutionRsaProjects = request.ProjectIds.Select(x => new SolutionRsaProject()
                {
                    SolutionProjectId = Guid.Parse(x)
                }).ToList();
            }

            await _solutionRsaRepository.AddAsync(dbEntity,cancellationToken);
            var changedRow = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (changedRow > 0)
            {
                return new BaseDto()
                {
                    IsSuccess = true,
                    Msg = "Handle Success"
                };
            }
            else
            {
                return new BaseDto(){IsSuccess = false,Msg="添加失败"};
            }
        }
    }
}
