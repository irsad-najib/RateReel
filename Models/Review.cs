// Models/Review.cs
namespace RateReel.Models
{
    public class Review
    {
        public string Username { get; set; }
        public string MovieTitle { get; set; }
        public double Rating { get; set; } // e.g., "5.0"
        public string ReviewText { get; set; }
        public string PosterUrl { get; set; }
        public DateTime ReviewDate { get; set; }  // Add this property

        
    }
}