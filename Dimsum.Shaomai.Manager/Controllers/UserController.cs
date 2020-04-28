using System;
using System.Threading.Tasks;
using Dimsum.Shaomai.Manager.Application.Commands.User;
using Dimsum.Shaomai.Manager.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dimsum.Shaomai.Manager.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator,ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            await Task.CompletedTask;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            await Task.CompletedTask;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<bool> CheckUsername(string username)
        {
            if (username.Contains(":")) return false;
            var exist = await _mediator.Send(new ExistUserNameQuery(username));
            return exist;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<Guid> AddManagerUser()
        {
            var cmdResponse = await _mediator.Send(new AddManagerUserCommand(username: "jiamiao.x", password: "m-6685265", email: "xiejiamiao0326@hotmail.com"));
            return cmdResponse.Id;
        }
    }
}