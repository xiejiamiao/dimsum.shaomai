using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Application.Queries.User;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.User
{
    public class ExistUserNameHandler : IRequestHandler<ExistUserNameQuery, bool>
    {
        private readonly IManagerUserRepository _managerUserRepository;

        public ExistUserNameHandler(IManagerUserRepository managerUserRepository)
        {
            _managerUserRepository = managerUserRepository;
        }

        public async Task<bool> Handle(ExistUserNameQuery request, CancellationToken cancellationToken)
        {
            return await _managerUserRepository.ExistUserName(request.Username, cancellationToken);
        }
    }
}
