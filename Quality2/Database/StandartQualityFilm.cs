using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Database
{
    [Index(nameof(FilmID), nameof(StandartQualityNameID), IsUnique = true)]
    [Table("StandartQuality")]
    public class StandartQualityFilm
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Film")]
        public int FilmID { get; set; }
        public int MinThickness { get; set; }
        public int MaxThickness { get; set; }
        public int TensileStrengthMD { get; set; }
        public int TensileStrengthTD { get; set; }
        public int ElongationAtBreakMD { get; set; }
        public int ElongationAtBreakTD { get; set; }
        public double CoefficientOfFrictionS { get; set; }
        public decimal CoefficientOfFrictionD { get; set; }
        public int? LightTransmission { get; set; }
        public int CoronaTreatment { get; set; }
        [ForeignKey("StandartQualityName")]
        public int StandartQualityNameID { get; set; }
    }
}
