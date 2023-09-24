using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Database
{
    [Index(nameof(Mark), nameof(Thickness), nameof(Color), IsUnique = true)]
    [Table("Film")]
    public class Film
    {
        public int ID { get; set; }
        public string Mark { get; set; }
        public int Thickness { get; set; }
        public string Color { get; set; }
        public double Density { get; set; }
    }
}
