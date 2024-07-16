using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Movie
	{
		public int Id { get; set; }

		public string Name { get; set; }

		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }

		public DateTime DateAdded { get; set; }

		[Display(Name = "Number in Stock")]
		public int NumberInStock { get; set; }

		public Genre Genre { get; set; }

		[Display(Name = "Genre")]
		[Required]
		public int GenreId { get; set; }
	}
}