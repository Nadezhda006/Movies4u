using System.ComponentModel.DataAnnotations.Schema;

namespace Movies4u.Data
{
    public class MoviesandGenres
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Movies))]
        public int MoviesId { get; set; }
        public virtual Movies? Movies { get; set; }
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
    }
}
