using System;
using System.Collections.Generic;
using System.Linq;

namespace Q2
{
    public class Movie
    {
        public string? Title;
        public string? Artist;
        public string? Genre;
        public int? Ratings;
    }

    public class Program
    {
        public static List<Movie> MovieList = new List<Movie>();
        public static void AddMovie(string movieDetails)
        {
            string[] data = movieDetails.Split(',');
            Movie movie = new Movie
            {
                Title = data[0],
                Artist = data[1],
                Genre = data[2],
                Ratings = int.Parse(data[3])
            };
            MovieList.Add(movie);
        }
        public static List<Movie> ViewMoviesByGenre(string genre)
        {
            return MovieList
                    .Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                    .ToList();
        }
        public static List<Movie> ViewMoviesByRating()
        {
            return MovieList
                    .OrderByDescending(m => m.Ratings)
                    .ToList();
        }

        public static void Main()
        {
            AddMovie("Inception,Leonardo,Thriller,5");
            AddMovie("Titanic,Leonardo,Romance,4");
            AddMovie("Interstellar,Matthew,Thriller,5");
            AddMovie("Jumanji,The Rock,Comedy,3");
            AddMovie("Jumanji,The Rock2,Comedy,2");

            Console.WriteLine("Enter genre to search:");
            string genre = Console.ReadLine();

            var genreMovies = ViewMoviesByGenre(genre);
            Console.WriteLine("\nMovies of given genre:");
            foreach (var m in genreMovies)
                Console.WriteLine(m.Title + " - " + m.Artist + " - " + m.Ratings);

            Console.WriteLine("\nMovies sorted by ratings:");
            var ratingMovies = ViewMoviesByRating();
            foreach (var m in ratingMovies)
                Console.WriteLine(m.Title + " - " + m.Genre + " - " + m.Ratings);
        }
    }
}
