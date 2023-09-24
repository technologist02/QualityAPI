using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Quality2.Entities
{
    public class StandartQualityFilm
    {
        public int ID { get; set; }
        public int FilmID { get; set; }
        public int ThicknessVariation { get; set; }
        public int TensileStrengthMD { get; set; }
        public int TensileStrengthTD { get; set; }
        public int ElongationAtBreakMD { get; set; }
        public int ElongationAtBreakTD { get; set; }
        public double CoefficientOfFrictionS { get; set; }
        public decimal CoefficientOfFrictionD { get; set; }
        public int? LightTransmission { get; set; }
        public int CoronaTreatment { get; set; }
        public int StandartQualityNameID { get; set; }
    }
}
