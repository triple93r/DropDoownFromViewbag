using DropDown4rmViewbag.Data;
using DropDown4rmViewbag.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DropDown4rmViewbag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var Subjects = (from subjcts in _context.tbl_Subject
                            select new SelectListItem()
                            {
                                Text = subjcts.sName,
                                Value = subjcts.Id.ToString()
                            }).ToList();
            Subjects.Insert(0, new SelectListItem()
            {
                Text = "-- Select --",
                Value = string.Empty
            });
            ViewBag.Scheme = Subjects;
            return View();
        }

        [HttpGet]
        public IActionResult TestDropdown()
        {
            var Subjects = (from subjcts in _context.tbl_Subject
                            select new SelectListItem()
                            {
                                Text = subjcts.sName, 
                                Value = subjcts.Id.ToString()
                            }).ToList();
            Subjects.Insert(0, new SelectListItem()
            {
                Text = "-- Select --",
                Value = string.Empty
            });
            ViewBag.Scheme = Subjects;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
