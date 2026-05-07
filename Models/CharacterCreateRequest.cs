using System.ComponentModel.DataAnnotations;

/// <summary>
/// Used to create a Character.
/// </summary>
public class CharacterCreateRequest
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public int BaseCharacterId { get; set; }
}