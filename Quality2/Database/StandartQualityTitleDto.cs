using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Database
{
    [Index(nameof(Title), IsUnique = true)]
    [Table("StandartQualityTitles")]
    [PrimaryKey(nameof(StandartQualityTitleId))]

    public class StandartQualityTitleDto
    {
        public int StandartQualityTitleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public StandartQualityTitleDto(string title, string description) 
        {
            Title = title;
            Description = description;
        }
    }
}
