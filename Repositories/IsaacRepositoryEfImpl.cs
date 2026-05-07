using Microsoft.EntityFrameworkCore;
/// <summary>
/// IIsaacRepository implementation for Entity Framework.
/// </summary>
public class IsaacRepositoryEfImpl : IIsaacRepository
{
    // inject our ProjectDbContext.
    private readonly ProjectDbContext projectDbContext;
    public IsaacRepositoryEfImpl(ProjectDbContext context)
    {
        projectDbContext = context;
    }

    // -----Base Character-----

    public List<BaseCharacter> GetAllBaseCharacters()
    {
        return projectDbContext.BaseCharacters.ToList();
    }

    public BaseCharacter? GetBaseCharacterById(int id)
    {
        return projectDbContext.BaseCharacters.Find(id);
    }
    public BaseCharacter CreateBaseCharacter(BaseCharacter baseCharacter)
    {
        projectDbContext.BaseCharacters.Add(baseCharacter);
        projectDbContext.SaveChanges();
        return baseCharacter;
    }

    public void DeleteBaseCharacter(BaseCharacter baseCharacter)
    {
        projectDbContext.BaseCharacters.Remove(baseCharacter);
        projectDbContext.SaveChanges();
    }

    // -----Character-----

    public Character? GetCharacterById(int id)
    {
        // Make sure to include the character's list of items please and thank you.
        return projectDbContext.Characters.Include(character => character.Items).FirstOrDefault(character => character.Id == id);
    }

    public Character CreateCharacter(Character character)
    {
        projectDbContext.Characters.Add(character);
        projectDbContext.SaveChanges();
        return character;
    }

    public Character AddItemToCharacter(Character character, Item item)
    {
        character.Items.Add(item);
        projectDbContext.SaveChanges();
        return character;
    }

    public void DeleteCharacter(Character character)
    {
        projectDbContext.Characters.Remove(character);
        projectDbContext.SaveChanges();
    }

    // -----Item-----

    public Item? GetItemById(int id)
    {
        return projectDbContext.Items.Find(id);
    }
    public List<Item> GetAllItems()
    {
        return projectDbContext.Items.ToList();
    }
    public Item CreateItem(Item item)
    {
        projectDbContext.Items.Add(item);
        projectDbContext.SaveChanges();
        return item;
    }

    public void DeleteItem(Item item)
    {
        projectDbContext.Items.Remove(item);
        projectDbContext.SaveChanges();
    }
}