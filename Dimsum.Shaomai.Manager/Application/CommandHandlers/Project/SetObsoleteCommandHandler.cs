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

        public SetObsoleteCommandHandler(ISolutionProjectPropertyRepository solutionProjectPropertyRepository)
        {
            _solutionProjectPropertyRepository = solutionProjectPropertyRepository;
        }


        public async Task<BaseDto> Handle(SetObsoleteCommand request, CancellationToken cancellationToken)
        {
            var dbEntity = await _solutionProjectPropertyRepository.GetAsync(request.PropertyId);
            dbEntity.IsObsolete = true;
            await _solutionProjectPropertyRepository.UpdateAsync(dbEntity);

            if (dbEntity.Type == PropertyType.Group)
            {

            }

            throw new NotImplementedException();
        }
    }
}
