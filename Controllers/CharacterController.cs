using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for Character HTTP requests.
/// </summary>
[ApiController]
[Route("characters")]
public class CharacterController: ControllerBase
{
    // Use the service layer to deal with logic and data stuff.
    private IsaacService isaacService;

    public CharacterController(IsaacService service)
    {
        isaacService = service;
    }

    [HttpGet("{id}", Name = "GetCharacterById")]
    public Character? GetCharacterById(int id)
    {
        return isaacService.GetCharacterById(id);
    }

    [HttpPost("", Name = "CreateCharacter")]
    public Character CreateCharacter(CharacterCreateRequest request)
    {
        if(!ModelState.IsValid)
        {
            throw new InvalidInputException("Character create request is invalid: ", ModelState);
        }
        else
        {
            return isaacService.CreateCharacter(request);
        }
        
    }

    [HttpPut("{charId}/items/{itemId}", Name = "AddItemToCharacter")]
    public Character AddItemToCharacter([Range(0, int.MaxValue)]int charId, [Range(0, int.MaxValue)] int itemId)
    {
        if(!ModelState.IsValid)
        {
            throw new InvalidInputException("Character update request is invalid: ", ModelState);
        }
        else
        {
            return isaacService.AddItemToCharacter(charId, itemId);
        }
    }

    [HttpDelete("", Name = "DeleteCharacterById")]
    public void DeleteCharacterById(int id)
    {
        isaacService.DeleteCharacterById(id);
    }
}