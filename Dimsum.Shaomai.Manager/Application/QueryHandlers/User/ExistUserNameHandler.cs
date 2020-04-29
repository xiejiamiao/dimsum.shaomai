using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.User;
using Dimsum.Shaomai.ManagerDto;
using Dimsum.Shaomai.ManagerDto.User;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.User
{
    public class ExistUserNameHandler : IRequestHandler<ExistUserNameQuery, BaseDto>
    {
        private readonly IManagerUserRepository _managerUserRepository;

        public ExistUserNameHandler(IManagerUserRepository managerUserRepository)
        {
            _managerUserRepository = managerUserRepository;
        }

        public async Task<BaseDto> Handle(ExistUserNameQuery request, CancellationToken cancellationToken)
        {
            if(request.Username.Contains(":"))
                return new BaseDto(){IsSuccess = false,Msg = "用户名不允许包含[:]"};
            var exist = await _managerUserRepository.ExistUserName(request.Username, cancellationToken);
            return exist
                ? new BaseDto() {IsSuccess = false, Msg = "用户名已存在"}
                : new BaseDto() {IsSuccess = true, Msg = "校验通过"};
        }
    }
}
