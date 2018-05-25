using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartPager.AspNetCore.Test.Models;

namespace SmartPager.AspNetCore.Test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int p=1)
        {
            var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            var pagedList = list.ToPagedList(p, 10, 1000);
            return View(pagedList);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
