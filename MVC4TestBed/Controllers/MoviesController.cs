using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MVC4TestBed.Models;
using System.Linq.Dynamic;

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

        public ViewResult Index(MovieSearchCriteria movieSearchCriteria, PagingInfo pagingInfo, SortInfo sortInfo)
        {
            // Filter Drop Down Lists
            var genres = _genreRepository.All.OrderBy(i => i.GenreName);
            ViewBag.PossibleGenres = genres;

            IQueryable<Movie> items;

            // Filter
            if (movieSearchCriteria != null)
            {
                items =
                    _movieRepository.All.Where(
                        i => (i.GenreId == movieSearchCriteria.GenreId || movieSearchCriteria.GenreId == 0));
                if (!string.IsNullOrEmpty(movieSearchCriteria.MovieTitle))
                {
                    items = items.Where(i => i.MovieTitle.Contains(movieSearchCriteria.MovieTitle));
                }
            }
            else
            {
                items = _movieRepository.All;
            }

            // Paging & Sorting
            if (string.IsNullOrEmpty(sortInfo.SortBy))
            {
                sortInfo.SortBy = "MovieTitle";
            }

            pagingInfo.TotalItems = items.Count();
            pagingInfo.IndexStart = (pagingInfo.CurrentPage - 1) * pagingInfo.MaxPerPage;

            var pagedResults = items
                .OrderBy(sortInfo.SortExpression)
                .Skip(pagingInfo.IndexStart)
                .Take(pagingInfo.MaxPerPage);

            pagingInfo.ItemsOnPage = pagedResults.Count();

            // Map DTO to ViewModel
            var movieSearchResults = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieSearchResult>>(pagedResults);
            var movieSearchVO = new MovieSearchVO
            {
                MovieSearchCriteria = movieSearchCriteria,
                PagingInfo = pagingInfo,
                SortInfo = sortInfo,
                MovieSearchResults = movieSearchResults
            };

            return View(movieSearchVO);
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

