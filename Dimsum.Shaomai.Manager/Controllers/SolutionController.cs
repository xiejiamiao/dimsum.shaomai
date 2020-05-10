using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.Manager.Application.Commands.Solution;
using Dimsum.Shaomai.Manager.Application.Queries.Solution;
using Dimsum.Shaomai.ManagerDto;
using Dimsum.Shaomai.ManagerDto.Solution;
using Dimsum.Shaomai.ManagerDto.User;
using Dimsum.Shaomai.Util.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dimsum.Shaomai.Manager.Controllers
{
    [Authorize]
    public class SolutionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SolutionController> _logger;

        public SolutionController(IMediator mediator,ILogger<SolutionController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allSolution = await _mediator.Send(new AllSolutionQuery());
            return View(allSolution);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            await Task.CompletedTask;
            return View();
        }

        [HttpGet]
        public async Task<BaseDto> CheckName(string name)
        {
            var exist = await _mediator.Send(new ExistNameQuery() {Name = name});
            return exist;
        }

        [HttpPost]
        public async Task<AddSolution> AddSolutionHandler([FromBody]AddSolutionCommand cmd)
        {
            if (!cmd.ContactEmail.IsEmail()) return new AddSolution() { Id = null, IsSuccess = false, Msg = "请输入正确的邮箱" };

            var checkResult = await _mediator.Send(new ExistNameQuery() {Name = cmd.Name});
            if (!checkResult.IsSuccess) return new AddSolution() { Id = null, IsSuccess = false, Msg = checkResult.Msg };
            
            var cmdResponse = await _mediator.Send(cmd);
            return cmdResponse;
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            ViewBag.SolutionId = id;
            var solution = await _mediator.Send(new SolutionDetailQuery() {Id = id});
            return View(solution);
        }

        [HttpGet]
        public async Task<List<ProcessListItem>> Process(Guid id)
        {
            return await _mediator.Send(new ProcessQuery() {SolutionId = id, PageIndex = 1, PageSize = 10});
        }

        [HttpGet]
        public async Task<List<EnvListItem>> Env(Guid id)
        {
            return await _mediator.Send(new EnvQuery() {SolutionId = id});
        }

        [HttpGet]
        public async Task<List<ProjectListItem>> Project(Guid id)
        {
            return await _mediator.Send(new ProjectQuery() {SolutionId = id});
        }
    }
}