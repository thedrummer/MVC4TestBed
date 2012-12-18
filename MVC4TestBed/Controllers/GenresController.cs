using System.Web.Mvc;
using MVC4TestBed.Models;

namespace MVC4TestBed.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public GenresController()
            : this(new GenreRepository())
        {
        }

        public GenresController(IGenreRepository genreRepository)
        {
            this._genreRepository = genreRepository;
        }

        //
        // GET: /Genres/

        public ViewResult Index()
        {
            return View(_genreRepository.All);
        }

        //
        // GET: /Genres/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Genres/Create

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreRepository.InsertOrUpdate(genre);
                _genreRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Genres/Edit/5

        public ActionResult Edit(int id)
        {
            return View(_genreRepository.Find(id));
        }

        //
        // POST: /Genres/Edit/5

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreRepository.InsertOrUpdate(genre);
                _genreRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // POST: /Genres/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _genreRepository.Delete(id);
            _genreRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _genreRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

