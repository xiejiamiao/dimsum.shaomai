using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimsum.Shaomai.Manager.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IManagerUserRepository _managerUserRepository;

        public UserController(IManagerUserRepository managerUserRepository)
        {
            _managerUserRepository = managerUserRepository;
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
        public async Task<bool> CheckUsername(string username)
        {
            var exist =await _managerUserRepository.ExistUserName(username);
            return exist;
        }
    }
}