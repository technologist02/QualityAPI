using Quality2.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Entities
{
    public class StandartQualityTitle
    {
        public int StandartQualityTitleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
