/// <summary>
/// Used to update a Character.
/// </summary>
public class CharacterUpdateRequest
{
    public int Id {get; set;}
    public string Name { get; set; }
    public int BaseCharacterId { get; set; }
}