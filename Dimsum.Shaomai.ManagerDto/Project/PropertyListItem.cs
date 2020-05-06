using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.ManagerDto.Project
{
    public class PropertyListItem
    {
        public string Id { get; set; }

        public int Level { get; set; }

        public string Type { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public bool IsObsolete { get; set; }

        public string CreatedOn { get; set; }

        public string LastUpdatedOn { get; set; }
    }
}
