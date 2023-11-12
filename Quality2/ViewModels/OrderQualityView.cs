namespace Quality2.ViewModels
{
    public class OrderQualityView
    {
        public int OrderNumber { get; set; }
        public string? Customer { get; set; }
        public DateOnly ProductionDate { get; set; }
        public int BrigadeNumber { get; set; }
        public int ExtruderId { get; set; }
        public int FilmId { get; set; }
        public int Width { get; set; }
        public int MinThickness { get; set; }
        public int MaxThickness { get; set; }
        public double TensileStrengthMD { get; set; }
        public double TensileStrengthTD { get; set; }
        public int ElongationAtBreakMD { get; set; }
        public int ElongationAtBreakTD { get; set; }
        public double CoefficientOfFrictionS { get; set; }
        public double CoefficientOfFrictionD { get; set; }
        public int LightTransmission { get; set; }
        public int CoronaTreatment { get; set; }
        public int StandartQualityTitleId { get; set; }
        public DateTime CreationDate { get; set; }
        public int InspectorId { get; set; }
    }
}
