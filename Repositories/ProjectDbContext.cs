using Microsoft.EntityFrameworkCore;
/// <summary>
/// The thing that interfaces with the database or something.
/// </summary>
public class ProjectDbContext: DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<BaseCharacter> BaseCharacters { get; set; }
    // constructor.
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options): base(options) {}
}