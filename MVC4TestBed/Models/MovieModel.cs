using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.DynamicData;

namespace MVC4TestBed.Models
{
    [TableName("Genre")]
    public class Genre
    {
        [Key]
        [Display(Name = "#")]
        public virtual int GenreId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Genre")]
        public virtual string GenreName { get; set; }

        public virtual bool IsArchived { get; set; }

        public virtual DateTime? ArchivedDate { get; set; }
    }

    [TableName("Movie")]
    public class Movie
    {
        [Key]
        [Display(Name = "#")]
        public virtual int MovieId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Title")]
        public virtual string MovieTitle { get; set; }

        [Required]
        [Display(Name = "Year")]
        public virtual int Year { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public virtual int GenreId { get; set; }

        [ForeignKey("GenreId")]
        [Display(Name = "Genre")]
        public virtual Genre Genre { get; set; }

        public virtual bool IsArchived { get; set; }

        public virtual DateTime? ArchivedDate { get; set; }
    }
}
