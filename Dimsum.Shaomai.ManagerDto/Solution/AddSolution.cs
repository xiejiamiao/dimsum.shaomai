using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.ManagerDto.Solution
{
    public class AddSolution:IBaseDto
    {
        public bool IsSuccess { get; set; }
        
        public string Msg { get; set; }

        public Guid? Id { get; set; }
    }
}
