using Quality2.Entities;

namespace Quality2.ViewModels
{
    public class StandartQualityFilmCreateView
    {
        public int FilmId { get; set; }
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
    }
}
