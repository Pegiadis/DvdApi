namespace DvdApi.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; } 
        public short RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length { get; set; } 
        public decimal ReplacementCost { get; set; }
        public string Rating { get; set; } 
        public DateTime LastUpdate { get; set; }
        public string[] SpecialFeatures { get; set; }
        
    }

}
