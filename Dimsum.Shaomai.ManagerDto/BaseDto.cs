using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.ManagerDto
{
    public class BaseDto:IBaseDto
    {
        public bool IsSuccess { get; set; }
        public string Msg { get; set; }
    }
}
