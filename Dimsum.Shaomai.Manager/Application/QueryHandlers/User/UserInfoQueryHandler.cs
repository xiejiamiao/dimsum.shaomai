using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.User;
using Dimsum.Shaomai.Manager.Infrastructure.Authorize;
using Dimsum.Shaomai.ManagerDto.User;
using Dimsum.Shaomai.Util.Extensions;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.User
{
    public class UserInfoQueryHandler:IRequestHandler<UserInfoQuery, UserInfo>
    {
        private readonly HttpAuthorizeHandler _httpAuthorizeHandler;
        private readonly IManagerUserRepository _managerUserRepository;

        public UserInfoQueryHandler(HttpAuthorizeHandler httpAuthorizeHandler,IManagerUserRepository managerUserRepository)
        {
            _httpAuthorizeHandler = httpAuthorizeHandler;
            _managerUserRepository = managerUserRepository;
        }

        public async Task<UserInfo> Handle(UserInfoQuery request, CancellationToken cancellationToken)
        {
            var managerUserId = _httpAuthorizeHandler.GetUseIdFromCookie();
            var managerUser = await _managerUserRepository.GetAsync(managerUserId);
            return new UserInfo()
            {
                IsSuccess = true,
                Msg = "Handler Success",
                Avatar = managerUser.AvatarUrl.IsNullOrEmpty() ? "/dist/purple/images/faces/face10.jpg" : managerUser.AvatarUrl,
                UserName = managerUser.UserName
            };
            throw new NotImplementedException();
        }
    }
}
