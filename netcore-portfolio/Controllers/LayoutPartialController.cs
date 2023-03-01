using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_portfolio.Controllers
{
    public class LayoutPartialController : Controller
    {
        public PartialViewResult _LayoutMenu()
        {
            return PartialView();
        }
        public PartialViewResult _LayoutBg()
        {
            return PartialView();
        }
        public PartialViewResult _LayoutHead()
        {
            return PartialView();
        }
        public PartialViewResult _LayoutScripts()
        {
            return PartialView();
        }
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult _LayoutSocial()
        {
            return PartialView();
        }
        public PartialViewResult _LayoutFooter()
        {
            return PartialView();
        }
        public PartialViewResult _LayoutMusic()
        {
            return PartialView();
        }
    }
}
