using AutoMapper;
using MVC4TestBed.Models;

namespace MVC4TestBed
{
    public static class Bootstrapper
    {
        public static void AutoMapperConfigure()
        {
            Mapper.CreateMap<Movie, MovieSearchResult>();
        }
    }
}
