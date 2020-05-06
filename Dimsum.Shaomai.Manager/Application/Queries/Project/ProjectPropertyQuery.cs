﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.ManagerDto.Project;
using MediatR;

namespace Dimsum.Shaomai.Manager.Application.Queries.Project
{
    public class ProjectPropertyQuery:IRequest<List<PropertyListItem>>
    {
        public Guid ProjectId { get; set; }

        public string ParentId { get; set; }
    }
}