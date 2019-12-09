using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RockPaperScissorsSite.Controlers
{
    public class OptionController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }
    }
}