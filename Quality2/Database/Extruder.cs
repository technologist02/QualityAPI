using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Database
{
    [Index(nameof(ExtruderName), IsUnique = true)]
    [Table("Extruder")]
    public class Extruder
    {
        [Key]
        public int ID { get; set; }
        public string ExtruderName { get; set; }
    }
}
