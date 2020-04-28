using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Commands.User;
using Dimsum.Shaomai.Util;
using Dimsum.Shaomai.Util.Extensions;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.CommandHandlers.User
{
    public class AddManagerUserHandler : IRequestHandler<AddManagerUserCommand, ManagerUser>
    {
        private readonly IManagerUserRepository _managerUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddManagerUserHandler(IManagerUserRepository managerUserRepository,IUnitOfWork unitOfWork)
        {
            _managerUserRepository = managerUserRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ManagerUser> Handle(AddManagerUserCommand request, CancellationToken cancellationToken)
        {
            var salt = StringUtils.RandomStringWithCharacter(6);
            var managerUser = new ManagerUser()
            {
                AvatarUrl = "",
                Email = request.Email,
                UserName = request.Username,
                Salt = salt,
                Password = $"{request.Password}-shaomai-{salt}".ToMd5(),
                EmailIsValidate = false
            };
            await _managerUserRepository.AddAsync(entity: managerUser, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return managerUser;
        }
    }
}
