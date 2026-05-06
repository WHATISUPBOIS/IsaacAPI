using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Controller for Character HTTP requests.
/// </summary>
[ApiController]
public class CharacterController: ControllerBase
{
    private ProjectDbContext projectDbContext;

    public CharacterController(ProjectDbContext context)
    {
        this.projectDbContext = context;
    }

    /// <summary>
    /// Return info about the character under the specified ID.
    /// </summary>
    /// <param name="id">You know.</param>
    /// <returns>A character, if one is found.</returns>
    [HttpGet("characters/{id}", Name = "GetCharacterByID")]
    public Character? GetCharacterByID(int id)
    {
        // Make sure to include the character's list of items please and thank you.
        return projectDbContext.Characters.Include(character => character.Items).FirstOrDefault(character => character.Id == id);
    }

    /// <summary>
    /// Create a character.
    /// </summary>
    /// <param name="request">Contains data used to create the character.</param>
    /// <returns>The character that was created.</returns>
    [HttpPost("characters", Name = "CreateCharacter")]
    public Character CreateCharacter(CharacterCreateRequest request)
    {
        Character character = new Character
        {
            Name = request.Name,
            BaseCharacterId = request.BaseCharacterId
        };
        projectDbContext.Characters.Add(character);
        projectDbContext.SaveChanges();
        return character;
    }
    /// <summary>
    /// Add an existing item to a character's list of items.
    /// </summary>
    /// <param name="charId">ID of the character to be modified.</param>
    /// <param name="itemId">ID of the item to be added.</param>
    /// <returns></returns>
    [HttpPut("characters/{charId}/items/{itemId}", Name = "AddItem")]
    public Character AddItem(int charId, int itemId)
    {
        Character updatedCharacter = projectDbContext.Characters.Find(charId);
        Item itemToAdd = projectDbContext.Items.Find(itemId);
        updatedCharacter.Items.Add(itemToAdd);
        projectDbContext.SaveChanges();
        return updatedCharacter;
    }
    
}