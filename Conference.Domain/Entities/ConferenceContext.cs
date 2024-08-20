using Microsoft.EntityFrameworkCore;

namespace Conference.Domain.Entities;

public class ConferenceContext : DbContext
{
    public ConferenceContext(DbContextOptions<ConferenceContext> options) : base(options) { }

    public DbSet<Speaker> Speakers { get; set; }

    public DbSet<Workshop> Workshops { get; set; }
}
