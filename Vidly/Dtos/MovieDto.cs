using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
	public class MovieDto
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public DateTime ReleaseDate { get; set; }

		public DateTime DateAdded { get; set; }

		public int NumberInStock { get; set; }

		[Required]
		public int GenreId { get; set; }
	}
}