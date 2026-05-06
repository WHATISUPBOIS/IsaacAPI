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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Character and Item is a many-to-many relationship.
        // many-to-many AND unidirectional. This should make adding an item to a character work OK.
        modelBuilder.Entity<Character>()
            .HasMany(character => character.Items)
            .WithMany();
    }
}