namespace RecommendationAPI.Models;

public class Rating
{
    public int RatingId { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public float Rating { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
}