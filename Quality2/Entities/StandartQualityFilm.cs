using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Entities
{
    [Index(nameof(FilmID), nameof(StandartName))]
    [Table("StandartQuality")]
    public class StandartQualityFilm
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Film")]
        public int FilmID { get; set; }
        [Required]
        public FilmProperties FilmProperty { get; set; }
        [Required]
        public string StandartName { get; set; }
    }
}
