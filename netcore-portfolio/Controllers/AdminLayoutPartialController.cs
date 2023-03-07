using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using netcore_portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netcore_portfolio.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace netcore_portfolio.Controllers
{
    public class AdminLayoutPartialController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Context _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AdminLayoutPartialController(UserManager<ApplicationUser> userManager, Context context, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult _LayoutHead()
        {
            return PartialView();
        }
        public PartialViewResult _LayoutScripts()
        {
            return PartialView();
        }
        public PartialViewResult _LayoutNavbar()
        {
            return PartialView();
        }
        public PartialViewResult _LayoutSidebarMenu()
        {
            return PartialView();
        }
        public PartialViewResult _LayoutFooter()
        {
            return PartialView();
        }
        public PartialViewResult _LayoutUser()
        {            
            return PartialView();
        }
    }
}
