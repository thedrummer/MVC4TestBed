using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MVC4TestBed.Models
{ 
    public class GenreRepository : IGenreRepository
    {
        MVC4TestBedContext context = new MVC4TestBedContext();

        public IQueryable<Genre> All
        {
            get { return context.Genres.Where(i => i.IsArchived == false); }
        }

        public IQueryable<Genre> AllIncluding(params Expression<Func<Genre, object>>[] includeProperties)
        {
            var query = context.Genres.Where(i => i.IsArchived == false);
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public Genre Find(int id)
        {
            var match = context.Genres.Find(id);
            return !match.IsArchived ? match : null;
        }

        public void InsertOrUpdate(Genre genre)
        {
            if (genre.GenreId == default(int)) {
                // New entity
                context.Genres.Add(genre);
            } else {
                // Existing entity
                context.Entry(genre).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var genre = context.Genres.Find(id);
            genre.IsArchived = true;
            genre.ArchivedDate = DateTime.Now;

            // Soft Delete all child Equipment Models (not already deleted)
            var movieRepository = new MovieRepository();
            var movies =
                context.Movies.Where(
                    i => i.GenreId == genre.GenreId && i.IsArchived == false);
            foreach (var movie in movies)
            {
                movieRepository.Delete(movie.MovieId);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IGenreRepository : IDisposable
    {
        IQueryable<Genre> All { get; }
        IQueryable<Genre> AllIncluding(params Expression<Func<Genre, object>>[] includeProperties);
        Genre Find(int id);
        void InsertOrUpdate(Genre genre);
        void Delete(int id);
        void Save();
    }
}