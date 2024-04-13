using Movies4u.Data;

namespace Movies4u_Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestingDataMovie_ShouldNotBeNull()
        {
            Movie movie = new Movie()
            {
                Id = 1,
                Name = "Barbie",
                Rate = 7.5,
                Description = "(Comedy) Barbie is a 2023 fantasy comedy film directed by Greta Gerwig from a screenplay she wrote with Noah Baumbach. Based on the eponymous fashion dolls by Mattel, it is the first live-action Barbie film after numerous animated films and specials.",
                Duration = "2h 50min",
                Year = "2023",
                ImageURL = "https://en.wikipedia.org/wiki/File:Barbie_2023_poster.jpg"
            };
            Assert.IsNotNull(movie);
        }
        [Test]
        public void TestingDataMoviesandGenres_ShouldNotBeNull()
        {
            MoviesandGenres moviesandGenres = new MoviesandGenres()
            {
                Id = 1,
                MoviesId = 1,
                GenreId = 1
            };
            Assert.NotNull(moviesandGenres);
        }
        [Test]
        public void TestingDataGenre_ShouldNotBeNull()
        {
            Genre genre = new Genre()
            {
                Id = 1,
                Name = "Comedy",
            };
            Assert.NotNull(genre);
        }
        
    }
}