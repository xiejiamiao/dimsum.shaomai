﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dimsum.Shaomai.DomainEntity
{
    public class SolutionRsaProject:IBaseEntity
    {
        public Guid Id { get; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public byte[] RowVersion { get; set; }

        public Guid SolutionRsaId { get; set; }

        public SolutionRsa SolutionRsa { get; set; }

        public Guid SolutionProjectId { get; set; }

        public SolutionProject SolutionProject { get; set; }
    }
}
