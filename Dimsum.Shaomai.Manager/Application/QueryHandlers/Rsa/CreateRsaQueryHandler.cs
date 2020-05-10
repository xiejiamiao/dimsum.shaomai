using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.Manager.Application.Queries.Rsa;
using Dimsum.Shaomai.ManagerDto.Rsa;
using Dimsum.Shaomai.Util;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.QueryHandlers.Rsa
{
    public class CreateRsaQueryHandler:IRequestHandler<CreateRsaQuery,RsaInfo>
    {
        public async Task<RsaInfo> Handle(CreateRsaQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var rsaInfo = StringUtils.RSAInfoByPKCS8();
            return new RsaInfo()
                {IsSuccess = true, Msg = "Success", PublicKey = rsaInfo.PublicKey, PrivateKey = rsaInfo.privateKey};
        }
    }
}
