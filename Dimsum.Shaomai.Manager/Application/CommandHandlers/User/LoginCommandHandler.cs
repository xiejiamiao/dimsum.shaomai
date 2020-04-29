using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Commands.User;
using Dimsum.Shaomai.Manager.Infrastructure.Authorize;
using Dimsum.Shaomai.ManagerDto;
using Dimsum.Shaomai.Util.Extensions;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.CommandHandlers.User
{
    public class LoginCommandHandler:IRequestHandler<LoginCommand, BaseDto>
    {
        private readonly IManagerUserRepository _managerUserRepository;
        private readonly HttpAuthorizeHandler _httpAuthorizeHandler;

        public LoginCommandHandler(IManagerUserRepository managerUserRepository,HttpAuthorizeHandler httpAuthorizeHandler)
        {
            _managerUserRepository = managerUserRepository;
            _httpAuthorizeHandler = httpAuthorizeHandler;
        }

        public async Task<BaseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var dbManagerUser = await _managerUserRepository.GetManagerUserByUserNameAsync(request.UserName, cancellationToken);
            if (dbManagerUser == null) return new BaseDto(){IsSuccess = false,Msg = "用户名不存在"};

            var inputPasswordMd5 = $"{request.Password}-shaomai-{dbManagerUser.Salt}".ToMd5();
            if (!dbManagerUser.Password.Equals(inputPasswordMd5, StringComparison.OrdinalIgnoreCase)) return new BaseDto(){IsSuccess = false,Msg = "密码错误"};

            await _httpAuthorizeHandler.SignInAsync(dbManagerUser.Id, cancellationToken);
            return new BaseDto(){IsSuccess = true,Msg = "登录成功"};
        }
    }
}
