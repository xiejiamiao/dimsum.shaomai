using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimsum.Shaomai.Manager.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class SolutionController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddSolution()
        {
            return View();
        }

        [HttpPost]
        public async Task AddSolutionHandler(string solutionName)
        {
            
        }

        public async Task<IActionResult> Worker()
        {
            return View();
        }
    }
}