using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC4TestBed.Models
{
    public class MovieSearchCriteria
    {
        public virtual int UserId { get; set; }

        [Display(Name = "Genre")]
        public virtual int GenreId { get; set; }

        [Display(Name = "Title")]
        public virtual string MovieTitle { get; set; }
    }

    public class MovieSearchResult
    {
        [Key]
        [Display(Name = "#")]
        public virtual int MovieId { get; set; }

        [Display(Name = "Title")]
        public virtual string MovieTitle { get; set; }

        [Display(Name = "Year")]
        public virtual int Year { get; set; }

        [Display(Name = "Genre")]
        public virtual Genre Genre { get; set; }
    }

    public class MovieSearch
    {
        public MovieSearchCriteria MovieSearchCriteria { get; set; }
        public IEnumerable<MovieSearchResult> MovieSearchResults { get; set; }
    }
}
