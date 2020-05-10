using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.Manager.Application.Commands.Rsa;
using Dimsum.Shaomai.Manager.Application.Queries.Rsa;
using Dimsum.Shaomai.ManagerDto;
using Dimsum.Shaomai.ManagerDto.Rsa;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimsum.Shaomai.Manager.Controllers
{
    [Authorize]
    public class RsaController : Controller
    {
        private readonly IMediator _mediator;

        public RsaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            await Task.CompletedTask;
            ViewBag.SolutionId = id;
            return View();
        }

        [HttpGet]
        public async Task<RsaInfo> NewRsa()
        {
            return await _mediator.Send(new CreateRsaQuery());
        }

        [HttpPost]
        public async Task<BaseDto> AddHandle([FromBody]AddRsaCommand cmd)
        {
            return await _mediator.Send(cmd);
        }
    }
}