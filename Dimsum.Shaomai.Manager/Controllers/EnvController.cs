using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.Manager.Application.Commands.Env;
using Dimsum.Shaomai.Manager.Application.Queries.Solution;
using Dimsum.Shaomai.ManagerDto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimsum.Shaomai.Manager.Controllers
{
    [Authorize]
    public class EnvController : Controller
    {
        private readonly IMediator _mediator;

        public EnvController(IMediator mediator)
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
        public async Task<BaseDto> AddHandle([FromBody] AddEnvCommand cmd)
        {
            
            return await _mediator.Send(cmd);
        }

    }
}