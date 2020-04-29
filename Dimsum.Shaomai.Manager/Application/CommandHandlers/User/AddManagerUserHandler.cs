using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.DomainEntity;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Commands.User;
using Dimsum.Shaomai.Manager.Infrastructure.Authorize;
using Dimsum.Shaomai.ManagerDto.User;
using Dimsum.Shaomai.Util;
using Dimsum.Shaomai.Util.Extensions;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.CommandHandlers.User
{
    public class AddManagerUserHandler : IRequestHandler<AddManagerUserCommand, RegisterUser>
    {
        private readonly IManagerUserRepository _managerUserRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpAuthorizeHandler _httpAuthorizeHandler;

        public AddManagerUserHandler(IManagerUserRepository managerUserRepository,IUnitOfWork unitOfWork,HttpAuthorizeHandler httpAuthorizeHandler)
        {
            _managerUserRepository = managerUserRepository;
            _unitOfWork = unitOfWork;
            _httpAuthorizeHandler = httpAuthorizeHandler;
        }

        public async Task<RegisterUser> Handle(AddManagerUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Username.Contains(":"))
            {

            }
            var existUserName = await _managerUserRepository.ExistUserName(request.Username, cancellationToken);
            if (existUserName)
            {
                return new RegisterUser() {IsSuccess = false, Msg = "用户名已存在", Id = null};
            }

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
            var changedRow = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (changedRow > 0)
            {
                await _httpAuthorizeHandler.SignInAsync(managerUser.Id, cancellationToken);
                return new RegisterUser() {IsSuccess = true, Msg = "注册成功",Id = managerUser.Id};
            }
            else
            {
                return new RegisterUser() {IsSuccess = false, Msg = "写入数据库失败", Id = null};
            }
        }
    }
}
