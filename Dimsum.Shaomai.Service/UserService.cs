using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.IService;
using Dimsum.Shaomai.ManagerDto.User;

namespace Dimsum.Shaomai.Service
{
    public class UserService: IUserService
    {
        private readonly IManagerUserRepository _managerUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IManagerUserRepository managerUserRepository,IUnitOfWork unitOfWork)
        {
            _managerUserRepository = managerUserRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ExistUserNameAsync(string username, CancellationToken cancellationToken = default)
        {
            return await _managerUserRepository.ExistUserName(username, cancellationToken);
        }

        public async Task<(bool isSuccess, Guid managerUserId)> AddUserAsync(RegisterUser dto, CancellationToken cancellationToken = default)
        {
            var salt
            throw new NotImplementedException();
        }
    }
}
