namespace DvdApi.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; } // assuming "year" type can be represented as an integer
        public short LanguageId { get; set; }
        public short RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length { get; set; } // nullable: it appears this can be null in your table
        public decimal ReplacementCost { get; set; }
        public string Rating { get; set; } // assuming "mpaa_rating" can be represented as a string
        public DateTime LastUpdate { get; set; }
        public string[] SpecialFeatures { get; set; } // array of strings
        // Depending on how you use "fulltext", you might want to include it here or handle it separately
    }

}
