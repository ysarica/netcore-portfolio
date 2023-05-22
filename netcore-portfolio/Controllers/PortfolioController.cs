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
        public IActionResult PCategory()
        {
            return View();
        }
        public IActionResult GetPortfolioCategory()
        {
            var pCategory = _context.PortfolioCategory.ToList();

            return Json(pCategory);
        }
        [HttpPost]
        public IActionResult AddPortfolioCategory([FromForm] PortfolioCategory portfolioCategory)
        {
                _context.PortfolioCategory.Add(portfolioCategory);
                _context.SaveChanges();
                return Json(new { success = true });  
        }
        [HttpPost]
        public IActionResult DeletePortfolioCategory(int id)
        {
            var portfolioCategory = _context.PortfolioCategory.FirstOrDefault(s => s.PCategoryID == id);
            if (portfolioCategory != null)
            {
                _context.PortfolioCategory.Remove(portfolioCategory);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpGet]
        public IActionResult GetPortfolioCategoryById(int id)
        {
            var portfolioCategory = _context.PortfolioCategory.FirstOrDefault(s => s.PCategoryID == id);
            return Json(portfolioCategory);
        }
        [HttpPost]
        public IActionResult UpdatePortfolioCategory([FromForm] PortfolioCategory portfolioCategory)
        {
            var oldPortfolioCategory = _context.PortfolioCategory.FirstOrDefault(x => x.PCategoryID == portfolioCategory.PCategoryID);

            oldPortfolioCategory.PCategoryName = portfolioCategory.PCategoryName;
            _context.SaveChanges();
            return Json(new { success = true });

        }
        //PortfolioCategory Finish
        //Portfolio Start
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetPortfolio()
        {
            var portfolio = _context.Portfolio.ToList();

            return Json(portfolio);
        }

        //Portfolio Finish

    }
}
