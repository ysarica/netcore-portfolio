﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_portfolio.Controllers
{
    public class ResumeSettings : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
