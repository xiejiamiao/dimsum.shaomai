﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto.Solution;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Queries.Solution
{
    public class EnvQuery:IRequest<List<EnvListItem>>
    {
        public Guid SolutionId { get; set; }
    }
}
