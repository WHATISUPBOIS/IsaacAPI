using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for Base Character HTTP requests.
/// </summary>
[ApiController]
[Route("base-characters")]
public class BaseCharacterController: ControllerBase
{
    // Use the service layer to deal with logic and data stuff.
    private IsaacService isaacService;

    public BaseCharacterController(IsaacService service)
    {
        isaacService = service;
    }

    [HttpGet("", Name = "GetAllBaseCharacters")]
    public List<BaseCharacter> GetAllBaseCharacters()
    {
        return isaacService.GetAllBaseCharacters();
    }

    [HttpGet("{id}", Name = "GetBaseCharacterById")]
    public BaseCharacter? GetBaseCharacterById(int id)
    {
        return isaacService.GetBaseCharacterById(id);
    }

    [HttpPost("", Name = "CreateBaseCharacter")]
    public BaseCharacter CreateBaseCharacter(BaseCharacterCreateRequest request)
    {
        if(!ModelState.IsValid)
        {
            throw new InvalidInputException("Base Character create request is invalid: ", ModelState);
        }
        else
        {
            return isaacService.CreateBaseCharacter(request);
        }
        
    }

    [HttpDelete("", Name = "DeleteBaseCharacterById")]
    public void DeleteBaseCharacterById(int id)
    {
        isaacService.DeleteBaseCharacterById(id);
    }
}