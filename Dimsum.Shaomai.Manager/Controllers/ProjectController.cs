using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.Manager.Application.Commands.Project;
using Dimsum.Shaomai.Manager.Application.Queries.Solution;
using Dimsum.Shaomai.ManagerDto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimsum.Shaomai.Manager.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            var solution = await _mediator.Send(new SolutionDetailQuery() { Id = id });
            return View(solution);
        }

        [HttpPost]
        public async Task<BaseDto> AddHandle([FromBody] AddProjectCommand cmd)
        {
            var cmdResponse = await _mediator.Send(cmd);
            return cmdResponse;
        }
    }
}