using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Entities
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
        public string ExtruderName { get; set; }
        [ForeignKey("Film")]
        public int FilmID { get; set; }
        public int Width { get; set; }
        public FilmProperties? FilmProperty { get; set; }
    }
}
