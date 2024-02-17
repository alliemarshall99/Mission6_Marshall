using Microsoft.AspNetCore.Mvc;
using Mission6_Marshall.Models;
using System.Diagnostics;

namespace Mission6_Marshall.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private FilmDbContext _context;
        public HomeController(FilmDbContext filmName)
        {
            _context = filmName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddFilm()
        {
            return View("AddFilm");
        }


        [HttpPost]
        public IActionResult AddFilm(Film response)

        {
            _context.Films.Add(response);
            _context.SaveChanges();

            return View("Index", response); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
