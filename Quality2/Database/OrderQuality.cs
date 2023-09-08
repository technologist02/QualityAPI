using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Database
{
    [Table("OrderQuality")]
    public class OrderQuality
    {
        public int ID { get; set; }
        public int OrderNumber { get; set; }
        public string? Customer { get; set; }
        public DateOnly ProductionDate { get; set; }
        public int BrigadeNumber { get; set; }
        public int RollNumber { get; set; }

        [ForeignKey("Extruder")]
        public int ExtruderID { get; set; }

        [ForeignKey("Film")]
        public int FilmID { get; set; }
        public int Width { get; set; }
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

        [ForeignKey("StandartQualityName")]
        public int StandartQualityNameID { get; set; }
    }
}
