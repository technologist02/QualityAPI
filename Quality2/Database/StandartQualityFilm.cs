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
        public double ThicknessVariation { get; set; }
        public double TensileStrengthMD { get; set; }
        public double TensileStrengthTD { get; set; }
        public int ElongationAtBreakMD { get; set; }
        public int ElongationAtBreakTD { get; set; }
        public double CoefficientOfFrictionS { get; set; }
        public double CoefficientOfFrictionD { get; set; }
        public int? LightTransmission { get; set; }
        public int CoronaTreatment { get; set; }
        [ForeignKey("StandartQualityName")]
        public int StandartQualityNameID { get; set; }
    }
}
