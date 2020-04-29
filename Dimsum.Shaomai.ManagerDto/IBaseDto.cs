using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.ManagerDto
{
    public interface IBaseDto
    {
        bool IsSuccess { get; set; }

        string Msg { get; set; }
    }
}
