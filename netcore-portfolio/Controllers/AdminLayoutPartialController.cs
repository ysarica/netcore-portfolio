using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using netcore_portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netcore_portfolio.ViewModels;

namespace netcore_portfolio.Controllers
{
    public class AdminLayoutPartialController : Controller
    {
  
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
