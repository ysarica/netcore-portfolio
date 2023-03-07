using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netcore_portfolio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace netcore_portfolio.Controllers
{
    [Authorize]

    public class ResumeSettings : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
