using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Database
{
    [Index(nameof(Mark), nameof(Thickness), nameof(Color), IsUnique = true)]
    [PrimaryKey(nameof(FilmId))]
    [Table("Films")]
    public class FilmDto
    {
        public int FilmId { get; set; }
        public string Mark { get; set; }
        public int Thickness { get; set; }
        public string Color { get; set; }
        public double Density { get; set; }

        public FilmDto(string mark, int thickness, string color) 
        {
            Mark = mark;
            Thickness = thickness;
            Color = color;
        }

        //public List<StandartQualityFilmDto> StandartQualityFilms { get; set; }
    }
}
