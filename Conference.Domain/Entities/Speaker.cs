namespace Conference.Domain.Entities;

public class Speaker
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Workshop> Workshops { get; } = new List<Workshop>();
}
