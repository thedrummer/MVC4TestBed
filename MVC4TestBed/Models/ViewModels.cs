using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace MVC4TestBed.Models
{
    public class PagingInfo
    {
        public PagingInfo()
        {
            MaxPerPage = 20;
            CurrentPage = 1;
        }

        public int MaxPerPage { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get { return (int) Math.Ceiling((decimal) TotalItems/MaxPerPage); }
        }

        public int IndexStart { get; set; }
        public int ItemsOnPage { get; set; }

        public string IndexLegend
        {
            get { return string.Format("{0} - {1} of {2}",
                (IndexStart + 1).ToString("N0"),
                (CurrentPage == 1) ? ItemsOnPage.ToString("N0") : ((MaxPerPage * (CurrentPage - 1)) + ItemsOnPage).ToString("N0"),
                TotalItems.ToString("N0")); }
        }
    }

    public class SortInfo
    {
        public SortInfo()
        {
            SortAscending = true;
        }

        public string SortBy { get; set; }
        public bool SortAscending { get; set; }

        public string SortExpression
        {
            get { return SortAscending ? SortBy + " asc" : SortBy + " desc"; }
        }
    }

    public class MovieSearchCriteria
    {
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Title")]
        public string MovieTitle { get; set; }
    }

    public class MovieSearchResult
    {
        [Key]
        [Display(Name = "#")]
        public int MovieId { get; set; }

        [Display(Name = "Title")]
        public string MovieTitle { get; set; }

        [Display(Name = "Year")]
        public int Year { get; set; }

        [Display(Name = "Genre")]
        public Genre Genre { get; set; }
    }

    public class MovieSearchVO
    {
        public PagingInfo PagingInfo { get; set; }
        public SortInfo SortInfo { get; set; }
        public MovieSearchCriteria MovieSearchCriteria { get; set; }
        public IEnumerable<MovieSearchResult> MovieSearchResults { get; set; }
    }
}