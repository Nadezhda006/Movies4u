using Moq;
using Movies4u.Data;
namespace Movies4uTests

{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestingMoviesData_ShoulNotBeNull()
        {
            //var humanUser = new List<string>();
            //var registration = new List<string>(humanUser);
            //var result = registration.Register();

            Movie movie = new Movie();
            movie.Id = 1;
            movie.Name = "Barbie";
            movie.Rate = 6.9;
            movie.Description = "Tup film";
            movie.Duration = "1÷30ì";
            movie.Year = "2023";
            movie.ImageURL = "https://upload.wikimedia.org/wikipedia/en/0/0b/Barbie_2023_poster.jpg";
            Assert.NotNull(movie);
        }
        [Test]
        public void TestingMoviesAndGenresData_ShoulNotBeNull()
        {
            MoviesandGenres moviesandGenres = new MoviesandGenres();
            moviesandGenres.Id = 1;
            moviesandGenres.MoviesId = 1;
            moviesandGenres.GenreId = 1;
            Assert.NotNull(moviesandGenres);
        }

        [Test]
        public void TestingGenreData_ShouldNotBeNull()
        {
            var genre = new Genre();
            genre.Id = 1;
            genre.Name = "Comedy";
            Assert.NotNull(genre);

        }

    }
}