using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Commands.Rsa
{
    public class AddRsaCommand:IRequest<BaseDto>
    {
        public string SolutionId { get; set; }

        public string Name { get; set; }

        public string RsaType { get; set; }

        public List<string> ProjectIds { get; set; }

        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }
    }
}
