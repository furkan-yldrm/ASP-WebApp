using ASP_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace ASP_WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var values = c.Departments.ToList();
            return View(values);
        }
    }
}
