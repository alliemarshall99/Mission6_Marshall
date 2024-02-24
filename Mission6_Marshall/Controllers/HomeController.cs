using Microsoft.AspNetCore.Mvc;
using Mission6_Marshall.Models;
using System.Diagnostics;
using System.Linq;

namespace Mission6_Marshall.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FilmDbContext _context;

        public HomeController(ILogger<HomeController> logger, FilmDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var movies = _context.Movies.ToList();

            foreach (var movie in movies)
            {

                if (movie.Rating == null)
                {
                    movie.Rating = "N/A";
                }

                if (movie.LentTo == null)
                {
                    movie.LentTo = "N/A";
                }
            }

            return View(movies);
        }



        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, Film updatedMovie)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Update movie properties
                movie.Title = updatedMovie.Title;
                movie.Director = updatedMovie.Director;
                movie.Year = updatedMovie.Year;
                movie.Rating = updatedMovie.Rating;
                movie.Edited = updatedMovie.Edited;
                movie.LentTo = updatedMovie.LentTo;
                movie.Notes = updatedMovie.Notes;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(updatedMovie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddFilm()
        {
            return View("AddFilm");
        }

        [HttpPost]
        public IActionResult AddFilm(Film response)
        {
            if (ModelState.IsValid && response.Year >= 1888)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Handle validation errors or invalid year
            return View("AddFilm", response);
        }




    }
}
