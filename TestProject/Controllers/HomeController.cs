using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string Index1(string name, int Numtime=1)
        {
            return $"Hello {name} Number: {Numtime}";
        }
    }
}
