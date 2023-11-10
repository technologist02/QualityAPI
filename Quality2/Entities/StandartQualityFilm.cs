using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Quality2.Database;

namespace Quality2.Entities
{
    public class StandartQualityFilm
    {
        public int StandartQualityFilmId { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
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
        public StandartQualityTitle StandartQualityTitle { get; set; }
    }
}
