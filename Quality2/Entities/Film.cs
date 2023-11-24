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

        
        public Film(string mark, int thickness, string color)
        {
            Mark = mark;
            Thickness = thickness;
            Color = color;
        }
        public override string ToString()
        {
            return $"{FilmId} {Mark} {Thickness} {Density}";
            
        }
    }
}
