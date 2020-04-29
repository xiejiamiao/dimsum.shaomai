using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto.User;

namespace Dimsum.Shaomai.IService
{
    public interface IUserService
    {
        Task<bool> ExistUserNameAsync(string username, CancellationToken cancellationToken = default);

        Task<(bool isSuccess, Guid managerUserId)> AddUserAsync(RegisterUser dto, CancellationToken cancellationToken = default);
    }
}
