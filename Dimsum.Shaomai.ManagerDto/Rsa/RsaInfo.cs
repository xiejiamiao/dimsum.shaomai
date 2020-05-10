using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.ManagerDto.Rsa
{
    public class RsaInfo:IBaseDto
    {
        public bool IsSuccess { get; set; }
        public string Msg { get; set; }

        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }
    }
}
