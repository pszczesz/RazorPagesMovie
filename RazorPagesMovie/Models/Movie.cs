using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models {
    public class Movie {
        public int ID { get; set; }

        [StringLength(60,MinimumLength = 3,ErrorMessage = "Długość pola 3 - 60 znaków")]
        [Required(ErrorMessage = "Pole wymagane")]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date,ErrorMessage = "Podaj poprawną datę")]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Range(1,100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required]
        [StringLength(5)]
        public string Rating { get; set; }
    }
}