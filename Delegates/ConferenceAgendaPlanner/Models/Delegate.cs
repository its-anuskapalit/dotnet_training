namespace ConferenceAgendaPlanner.Models;

/// <summary>
/// Represents a conference delegate (an attendee or participant).
/// </summary>
/// <remarks>
/// This model currently contains only an identifier. Extend with additional properties
/// such as Name, Email, Company, and RegistrationStatus as needed.
/// </remarks>

/// <summary>
/// The unique identifier for the delegate.
/// </summary>
/// <remarks>
/// Stored as a string to allow GUIDs or other alphanumeric identifiers.
/// </remarks>
public class Delegate
{
    public string Id;
}
