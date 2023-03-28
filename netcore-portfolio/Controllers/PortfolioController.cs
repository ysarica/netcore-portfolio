using Microsoft.AspNetCore.Mvc;
using netcore_portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly Context _context;

        public PortfolioController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PCategory()
        {
            return View();
        }
    }
}
