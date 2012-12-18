using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MVC4TestBed.Models
{ 
    public class MovieRepository : IMovieRepository
    {
        MVC4TestBedContext context = new MVC4TestBedContext();

        public IQueryable<Movie> All
        {
            get { return context.Movies.Where(i => i.IsArchived == false); }
        }

        public IQueryable<Movie> AllIncluding(params Expression<Func<Movie, object>>[] includeProperties)
        {
            var query = context.Movies.Where(i => i.IsArchived == false);
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public Movie Find(int id)
        {
            var match = context.Movies.Find(id);
            return !match.IsArchived ? match : null;
        }

        public void InsertOrUpdate(Movie movie)
        {
            if (movie.MovieId == default(int)) {
                // New entity
                context.Movies.Add(movie);
            } else {
                // Existing entity
                context.Entry(movie).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var movie = context.Movies.Find(id);
            movie.IsArchived = true;
            movie.ArchivedDate = DateTime.Now;
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

    public interface IMovieRepository : IDisposable
    {
        IQueryable<Movie> All { get; }
        IQueryable<Movie> AllIncluding(params Expression<Func<Movie, object>>[] includeProperties);
        Movie Find(int id);
        void InsertOrUpdate(Movie movie);
        void Delete(int id);
        void Save();
    }
}