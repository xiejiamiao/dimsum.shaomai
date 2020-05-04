using System;
using System.Threading;
using System.Threading.Tasks;
using Dimsum.Shaomai.Manager.Application.Commands.User;
using Dimsum.Shaomai.Manager.Application.Queries.User;
using Dimsum.Shaomai.Manager.Infrastructure.Authorize;
using Dimsum.Shaomai.ManagerDto;
using Dimsum.Shaomai.ManagerDto.User;
using Dimsum.Shaomai.Util.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Dimsum.Shaomai.Manager.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Login(string returnUrl = "/")
        {
            await Task.CompletedTask;
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<BaseDto> LoginHandler([FromBody]LoginCommand cmd)
        {
            var cmdResponse = await _mediator.Send(cmd);
            return cmdResponse;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string returnUrl = "/")
        {
            await Task.CompletedTask;
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<RegisterUser> RegisterHandler([FromBody] AddManagerUserCommand cmd)
        {
            if (!cmd.Email.IsEmail()) return new RegisterUser() {Id = null, IsSuccess = false, Msg = "请输入正确的邮箱"};

            var checkResult = await _mediator.Send(new ExistUserNameQuery(cmd.Username));
            if (!checkResult.IsSuccess) return new RegisterUser() {Id = null, IsSuccess = false, Msg = checkResult.Msg};

            var cmdResponse = await _mediator.Send(cmd);
            return cmdResponse;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<BaseDto> CheckUsername(string username)
        {
            var checkResult = await _mediator.Send(new ExistUserNameQuery(username));
            return checkResult;
        }

        [HttpPost]
        public async Task<BaseDto> Logout([FromServices]HttpAuthorizeHandler httpAuthorizeHandler)
        {
            await httpAuthorizeHandler.SignOutAsync();
            return new BaseDto() {IsSuccess = true, Msg = "操作成功"};
        }

        [HttpGet]
        public async Task<UserInfo> Info()
        {
            var userInfoResponse =await _mediator.Send(new UserInfoQuery());
            return userInfoResponse;
        }

    }
}