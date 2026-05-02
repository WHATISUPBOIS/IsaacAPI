/// <summary>
/// Represents a character, which is based off of a BaseCharacter. Has an Id, Name, and list of Items.
/// </summary>
public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }

    // relational data
    public BaseCharacter BaseCharacter { get; set; }
    public int BaseCharacterId { get; set; }
    public List<Item> Items { get; set; }
}