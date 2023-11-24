using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Database
{
    [Index(nameof(Name), IsUnique = true)]
    [PrimaryKey(nameof(ExtruderId))]
    [Table("Extruders")]
    public class ExtruderDto
    {
        public int ExtruderId { get; set; }
        public string Name { get; set; }

    }
}
