namespace ConferenceApi.Models;

public class WorkshopModel
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Duration { get; set; } = null;

    public string Year { get; set; } = null;
}
