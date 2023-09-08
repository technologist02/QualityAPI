namespace Quality2.ViewModels
{
    public class ViewOrderQuality
    {
        public int ID { get; set; }
        public int OrderNumber { get; set; }
        public string? Customer { get; set; }
        public DateOnly ProductionDate { get; set; }
        public int BrigadeNumber { get; set; }
        public int RollNumber { get; set; }
        public string ExtruderName { get; set; }
        public int FilmID { get; set; }
        public int Width { get; set; }
        //public FilmProperties? FilmProperty { get; set; }
    }
}
