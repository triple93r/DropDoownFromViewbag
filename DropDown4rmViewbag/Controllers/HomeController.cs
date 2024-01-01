using DropDown4rmViewbag.Data;
using DropDown4rmViewbag.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Drawing;

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
            ViewBag.Subject = Subjects;
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
            ViewBag.Subject = Subjects;
            return View();
        }

        [HttpGet]
        public IActionResult GetClass()
        {
            return View(_context.AllClass.ToList());
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return View(_context.tblStudent.ToList());
        }

        [HttpGet]
        public IActionResult GetStudentClass()
        {
            var x = _context.StudentClass.ToList();

            var query =     (from stdclass in _context.StudentClass  
                            join cl in _context.AllClass on stdclass.ClassId equals cl.Id
                            select new StudentClass
                            {
                                Id = stdclass.Id,
                                StudId = stdclass.Id,
                                ClassId = stdclass.Id,
                                ClassName = cl.ClName
                            });
            return View(query);
        }

        [HttpGet]
        public IActionResult EditGetStudentClass(int Id)
        {
            var s = _context.StudentClass.Where(x => x.Id == Id).FirstOrDefault();
            var Classes = (from classes in _context.AllClass
                            select new SelectListItem()
                            {
                                Text = classes.ClName,
                                Value = classes.Id.ToString()
                            }).ToList();
            Classes.Insert(0, new SelectListItem()
            {
                Text = "-- Select --",
                Value = string.Empty
            });
            ViewBag.Classes = Classes;

            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> EditGetStudentClass(StudentClass sd)
        {
            var s = _context.StudentClass.Where(x => x.Id == sd.Id).FirstOrDefault();

            s.ClassId = sd.ClassId;
            await _context.SaveChangesAsync();

            return RedirectToAction("GetStudentClass");
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentClass2()
        {
            var x = _context.StudentClass.ToList();

            var query = (from stdclass in _context.StudentClass
                         join cl in _context.AllClass on stdclass.ClassId equals cl.Id
                         select new StudentClass
                         {
                             Id = stdclass.Id,
                             StudId = stdclass.Id,
                             ClassId = stdclass.Id,
                             ClassName = cl.ClName
                         }).ToList();
            return View(query);
        }


        [HttpPost]
        public IActionResult GetStudentClass2(List<StudentClass> tableData)
        {

            if (tableData != null && tableData.Any())
            {
                foreach (var data in tableData)
                {
                    // Create a new entity to store in the database
                    var entity = new StudentClass // Replace YourEntity with your actual entity type
                    {
                        StudId = data.StudId,
                        ClassId = data.ClassId
                        // Map other properties accordingly
                    };

                    // Assuming you are using Entity Framework Core
                    _context.StudentClass.Add(entity);
                }
            }

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction("Index"); // Redirect to another action or view
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
