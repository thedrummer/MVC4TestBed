using System.Data.Entity.Migrations;
using MVC4TestBed.Models;

namespace MVC4TestBed.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MVC4TestBedContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVC4TestBedContext context)
        {
            var action = new Genre
                {
                    GenreId = 1,
                    GenreName = "Action"
                };
            var animation = new Genre
                {
                    GenreId = 2,
                    GenreName = "Animation"
                };
            var comedy = new Genre
                {
                    GenreId = 3,
                    GenreName = "Comedy"
                };
            var documentary = new Genre
                {
                    GenreId = 4,
                    GenreName = "Documentary"
                };
            var drama = new Genre
                {
                    GenreId = 5,
                    GenreName = "Drama"
                };
            var horror = new Genre
                {
                    GenreId = 6,
                    GenreName = "Horror"
                };
            var romantic = new Genre
                {
                    GenreId = 7,
                    GenreName = "Romantic"
                };
            var scifi = new Genre
                {
                    GenreId = 8,
                    GenreName = "Sci-Fi"
                };
            var thriller = new Genre
                {
                    GenreId = 9,
                    GenreName = "Thriller"
                };

            context.Genres.AddOrUpdate(
                i => i.GenreId,
                action,
                animation,
                comedy,
                documentary,
                drama,
                horror,
                romantic,
                scifi,
                thriller
                );

            context.Movies.AddOrUpdate(
                i => i.MovieId,
                new Movie
                    {
                        MovieTitle = "Braveheart",
                        Genre = action,
                        Year = 1995,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Children of Men",
                        Genre = action,
                        Year = 2006,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "The Dark Knight",
                        Genre = action,
                        Year = 2008,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Face Off",
                        Genre = action,
                        Year = 1997,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "The Fugitive",
                        Genre = action,
                        Year = 1993,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Batman",
                        Genre = action,
                        Year = 1989,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Die Hard",
                        Genre = action,
                        Year = 1988,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Aladdin",
                        Genre = animation,
                        Year = 1992,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "WALL-E",
                        Genre = animation,
                        Year = 2008,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "101 Dalmations",
                        Genre = animation,
                        Year = 1997,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Antz",
                        Genre = animation,
                        Year = 1998,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Chicken Run",
                        Genre = animation,
                        Year = 2000,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "The Incredibles",
                        Genre = animation,
                        Year = 2004,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Shrek",
                        Genre = animation,
                        Year = 2001,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "American Beauty",
                        Genre = comedy,
                        Year = 1999,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "The Intouchables",
                        Genre = comedy,
                        Year = 2012,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Nine Months",
                        Genre = comedy,
                        Year = 1995,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Notting Hill",
                        Genre = comedy,
                        Year = 1999,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "The Wood",
                        Genre = comedy,
                        Year = 1999,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "10 Things I Hate About You",
                        Genre = comedy,
                        Year = 1999,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "50/50",
                        Genre = comedy,
                        Year = 2011,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Apollo 13",
                        Genre = drama,
                        Year = 1995,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Atonement",
                        Genre = drama,
                        Year = 2007,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "The Aviator",
                        Genre = drama,
                        Year = 2004,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Better Luck Tomorrow",
                        Genre = drama,
                        Year = 2003,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Finding Forrester",
                        Genre = drama,
                        Year = 2000,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Memento",
                        Genre = drama,
                        Year = 2001,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Silence of the Lambs",
                        Genre = horror,
                        Year = 1991,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "28 Weeks Later",
                        Genre = horror,
                        Year = 2007,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "The Cabin in the Woods",
                        Genre = horror,
                        Year = 2012,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Adam",
                        Genre = romantic,
                        Year = 2009,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Amelie",
                        Genre = romantic,
                        Year = 2001,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "The Artist",
                        Genre = romantic,
                        Year = 2011,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "As Good As It Gets",
                        Genre = romantic,
                        Year = 1997,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Bridget Jone's Diary",
                        Genre = romantic,
                        Year = 2001,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Can't Hardly Wait",
                        Genre = romantic,
                        Year = 1998,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Aliens",
                        Genre = scifi,
                        Year = 1986,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "The Lord of the Rings: The Fellowship of the Ring",
                        Genre = scifi,
                        Year = 2001,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "The Lord of the Rings: The Return of the King",
                        Genre = scifi,
                        Year = 2003,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Star Wars: Episode VI: Return of the Jedi",
                        Genre = scifi,
                        Year = 1983,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Terminator 2: Judgement Day",
                        Genre = scifi,
                        Year = 1991,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Alien: The Director's Cut",
                        Genre = scifi,
                        Year = 1979,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Another Earth",
                        Genre = scifi,
                        Year = 2011,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "The Departed",
                        Genre = thriller,
                        Year = 2006,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "A Time to Kill",
                        Genre = thriller,
                        Year = 1996,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Zodiac",
                        Genre = thriller,
                        Year = 2007,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Arlington Road",
                        Genre = thriller,
                        Year = 1999,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Black Swan",
                        Genre = thriller,
                        Year = 2010,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Brick",
                        Genre = thriller,
                        Year = 2006,
                        IsArchived = false
                    },
                new Movie
                    {
                        MovieTitle = "Copycat",
                        Genre = thriller,
                        Year = 1995,
                        IsArchived = false
                    }
                )
                ;
        }
    }
}