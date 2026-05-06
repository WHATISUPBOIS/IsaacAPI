using System.Text.Json.Serialization;
/// <summary>
/// Represents a character, which is based off of a BaseCharacter. Has an Id, Name, and list of Items.
/// </summary>
public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }

    // relational data
    // Each character belongs to a BaseCharacter.
    [JsonIgnore]
    public BaseCharacter BaseCharacter { get; set; }
    public int BaseCharacterId { get; set; }
    
    // Characters start with an empty list of items.
    public List<Item> Items {get; set;} = new List<Item>();
}