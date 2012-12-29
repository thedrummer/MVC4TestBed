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
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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

    public class TemplateTest
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateTimeField { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateField { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Text)]
        public string Text { get; set; }

        [DataType(DataType.Text)]
        public string NormalString { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string TelNo { get; set; }

        [DataType(DataType.MultilineText)]
        public string LongText { get; set; }

        public int Month { get; set; }

        public int Week { get; set; }

        [DataType(DataType.Currency)]
        public float Currency { get; set; }


    }
}
