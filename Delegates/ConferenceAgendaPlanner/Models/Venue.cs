/// <summary>
/// ConferenceAgendaPlanner.Models.Venue: represents a venue with an identifier and 2D coordinates.
/// </summary>
namespace ConferenceAgendaPlanner.Models
{
    /// <summary>
    /// Represents a venue within the conference layout.
    /// </summary>
    public class Venue
    {
        /// <summary>
        /// Unique identifier for the venue.
        /// </summary>
        public string Id;

        /// <summary>
        /// X coordinate of the venue position.
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate of the venue position.
        /// </summary>
        public int Y;
    }
}
