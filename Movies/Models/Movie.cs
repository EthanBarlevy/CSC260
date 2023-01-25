using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
	public class Movie
	{
		private static int nextID = 0;
		// ? means that its nullable
		public int? Id { get; set; } = nextID++;

		[Required]
		[MaxLength(40)]
		public string Title { get; set; }
		[Required]
		[Range(1888, 2023)]
		public int? Year { get; set; }
		[Required]
		public float? Rating { get; set; }
		public DateTime? ReleaseDate { get; set; }
		public string? Image { get; set; }
		public string? Genre { get; set; }

		public Movie() { }
		public Movie(string title, int year, float rating)
		{
			Title = title;
			Year = year;
			Rating = rating;
		}

		public override string ToString()
		{
			return $"{Title} - {Year} - {Rating} stars";
		}
	}
}
