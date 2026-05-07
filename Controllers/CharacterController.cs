using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for Character HTTP requests.
/// </summary>
[ApiController]
[Route("characters")]
public class CharacterController: ControllerBase
{
    private IIsaacRepository isaacRepository;

    public CharacterController(IIsaacRepository repository)
    {
        isaacRepository = repository;
    }

    [HttpGet("{id}", Name = "GetCharacterByID")]
    public Character? GetCharacterByID(int id)
    {
        return isaacRepository.GetCharacterById(id);
    }

    [HttpPost("", Name = "CreateCharacter")]
    public Character CreateCharacter(CharacterCreateRequest request)
    {
        // Map request to character we are creating.
        Character character = new Character
        {
            Name = request.Name,
            BaseCharacterId = request.BaseCharacterId
        };

        return isaacRepository.CreateCharacter(character);
    }

    [HttpPut("{charId}/items/{itemId}", Name = "AddItemToCharacter")]
    public Character AddItemToCharacter(int charId, int itemId)
    {
        return isaacRepository.AddItemToCharacter(charId, itemId);
    }
}