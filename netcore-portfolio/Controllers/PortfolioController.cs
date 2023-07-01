using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public JsonResult GetPortfolio()
        {
            var portfolioCategories = _context.PortfolioCategory.Include(pc => pc.Portfolio).ToList();

            var portfolio = _context.Portfolio.ToList();
            foreach (var port in portfolio)
            {
                _context.Entry(port).Reference(p => p.PortfolioCategory).Load();
            }
            var portData = _context.Portfolio.Select(p => new
            {
                PID = p.PID,
                PCategoryID = p.PCategoryID,
                PCategoryName = p.PortfolioCategory.PCategoryName,
                PType = p.PType,
                PLink = p.PLink,
                PImage = p.PImage,
                PFactoryName = p.PFactoryName,
                PDeliveryDate = p.PDeliveryDate,
                PUseService = p.PUseService,
                PDescription = p.PDescription,
                PTitle = p.PTitle

            });

            //var portData = _context.Portfolio.Include(x => x.PortfolioCategory).ToList();

            return Json(portData);
        }

        //Portfolio Finish

    }
}
