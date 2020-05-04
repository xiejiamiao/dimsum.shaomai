using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimsum.Shaomai.Manager.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            return View();
        }
    }
}