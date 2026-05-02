using Microsoft.AspNetCore.Mvc;

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
    [HttpGet("character/{id}", Name = "GetCharacterByID")]
    public Character? GetCharacterByID(int id)
    {
        return projectDbContext.Characters.Find(id);
    }

    /// <summary>
    /// Create a character.
    /// </summary>
    /// <param name="request">Contains data used to create the character.</param>
    /// <returns>The character that was created.</returns>
    [HttpPost("character", Name = "CreateCharacter")]
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
}