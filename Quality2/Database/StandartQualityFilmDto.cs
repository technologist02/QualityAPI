using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Database
{
    [Index(nameof(FilmId), nameof(StandartQualityTitleId), IsUnique = true)]
    [Table("StandartQualityFilms")]
    [PrimaryKey(nameof(StandartQualityFilmId))]
    public class StandartQualityFilmDto
    {
        public int StandartQualityFilmId { get; set; }
        public int FilmId { get; set; }

        [ForeignKey("FilmId")]
        public FilmDto Film { get; set; }
        public double ThicknessVariation { get; set; }
        public double TensileStrengthMD { get; set; }
        public double TensileStrengthTD { get; set; }
        public int ElongationAtBreakMD { get; set; }
        public int ElongationAtBreakTD { get; set; }
        public double CoefficientOfFrictionS { get; set; }
        public double CoefficientOfFrictionD { get; set; }
        public int? LightTransmission { get; set; }
        public int CoronaTreatment { get; set; }
        public int StandartQualityTitleId { get; set; }

        [ForeignKey("StandartQualityTitleId")]
        public StandartQualityTitleDto StandartQualityTitle { get; set; }
    }
}
