namespace Conference.Domain.Entities;

public class Workshop
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Duration { get; set; } = null;

    public string Year { get; set; } = null;

    public int? SpeakerId { get; set; }

    public virtual Speaker? Speaker { get; set; }
}