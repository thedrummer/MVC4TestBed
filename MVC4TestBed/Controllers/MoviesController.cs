using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MVC4TestBed.Models;

namespace MVC4TestBed.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMovieRepository _movieRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public MoviesController()
            : this(new GenreRepository(), new MovieRepository())
        {
        }

        public MoviesController(IGenreRepository genreRepository, IMovieRepository movieRepository)
        {
            _genreRepository = genreRepository;
            _movieRepository = movieRepository;
        }

        //
        // GET: /Movies/

        public ViewResult Index(MovieSearchCriteria movieSearchCriteria)
        {
            var genres = _genreRepository.All.OrderBy(i => i.GenreName);
            ViewBag.PossibleGenres = genres;

            IQueryable<Movie> movies;

            if (movieSearchCriteria != null)
            {
                movies =
                    _movieRepository.All.Where(
                        i => (i.GenreId == movieSearchCriteria.GenreId || movieSearchCriteria.GenreId == 0))
                                    .OrderBy(i => i.MovieTitle);
                if (!string.IsNullOrEmpty(movieSearchCriteria.MovieTitle))
                {
                    movies = movies.Where(i => i.MovieTitle.Contains(movieSearchCriteria.MovieTitle));
                }
            }
            else
            {
                movies = _movieRepository.All.OrderBy(i => i.MovieTitle);
            }

            // Map DTO to ViewModel
            var movieSearchResults = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieSearchResult>>(movies);
            var movieSearch = new MovieSearch
            {
                MovieSearchCriteria = movieSearchCriteria,
                MovieSearchResults = movieSearchResults
            };

            return View(movieSearch);
        }

        //
        // GET: /Movies/Details/5

        public ViewResult Details(int id)
        {
            return View(_movieRepository.Find(id));
        }

        //
        // GET: /Movies/Create

        public ActionResult Create()
        {
            ViewBag.PossibleGenres = _genreRepository.All;
            return View();
        }

        //
        // POST: /Movies/Create

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.InsertOrUpdate(movie);
                _movieRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleGenres = _genreRepository.All;
            return View();
        }

        //
        // GET: /Movies/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.PossibleGenres = _genreRepository.All;
            return View(_movieRepository.Find(id));
        }

        //
        // POST: /Movies/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.InsertOrUpdate(movie);
                _movieRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleGenres = _genreRepository.All;
            return View();
        }

        //
        // POST: /Movies/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _movieRepository.Delete(id);
            _movieRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _genreRepository.Dispose();
                _movieRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

