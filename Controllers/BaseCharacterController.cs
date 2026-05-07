using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for Base Character HTTP requests.
/// </summary>
[ApiController]
[Route("base-characters")]
public class BaseCharacterController: ControllerBase
{
    private IIsaacRepository isaacRepository;

    public BaseCharacterController(IIsaacRepository repository)
    {
        isaacRepository = repository;
    }

    [HttpGet("", Name = "GetAllBaseCharacters")]
    public List<BaseCharacter> GetAllBaseCharacters()
    {
        return isaacRepository.GetAllBaseCharacters();
    }

    [HttpGet("{id}", Name = "GetBaseCharacterById")]
    public BaseCharacter? GetBaseCharacterById(int id)
    {
        return isaacRepository.GetBaseCharacterById(id);
    }

    [HttpPost("", Name = "CreateBaseCharacter")]
    public BaseCharacter CreateBaseCharacter(BaseCharacterCreateRequest request)
    {
        // Map request to the base character we are creating.
        BaseCharacter baseCharacter = new BaseCharacter
        {
            Name = request.Name,
            Speed = request.Speed,
            TearsUp = request.TearsUp,
            BaseDamage = request.BaseDamage,
            DamageMult = request.DamageMult,
            Range = request.Range,
            ShotSpeed = request.ShotSpeed,
            Luck = request.Luck
        };

        return isaacRepository.CreateBaseCharacter(baseCharacter);
    }
}