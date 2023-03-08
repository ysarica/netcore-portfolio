using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netcore_portfolio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using netcore_portfolio.Models;

namespace netcore_portfolio.Controllers
{
    [Authorize]
    
    public class ResumeSettings : Controller
    {
        private readonly Context _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ResumeSettings(Context context,SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetResume()
        {
            var resume = _context.Resume.FirstOrDefault(x => x.ResumeID == 1);
            return Json(resume);
        }
        public IActionResult GetEducation()
        {
       
            var edu1 = _context.Hobbies.Where(x => x.ResumeID == 2).ToList();
            return Json(edu1);
        }

    }
}
