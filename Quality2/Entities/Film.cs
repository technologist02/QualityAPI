using Quality2.Database;

namespace Quality2.Entities
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Mark { get; set; }
        public int Thickness { get; set; }
        public string Color { get; set; }
        public double Density { get; set; }

        public override string ToString()
        {
            return $"{FilmId} {Mark} {Thickness} {Density}";
            
        }
    }
}
