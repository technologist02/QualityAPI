namespace Quality2.Entities
{
    public class FilmProperties
    {
        public int ID { get; set; }
        public int MinThickness { get; set; }
        public int MaxThickness { get; set; }
        public int TensileStrengthMD { get; set; }
        public int TensileStrengthTD { get; set; }
        public int ElongationAtBreakMD { get; set; }
        public int ElongationAtBreakTD { get; set; }
        public double CoefficientOfFrictionS { get; set; }
        public decimal CoefficientOfFrictionD { get; set; }
        public int LightTransmission { get; set; }
        public int CoronaTreatment { get; set; }
    }
}
