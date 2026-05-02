using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for Base Character HTTP requests.
/// </summary>
[ApiController]
public class BaseCharacterController: ControllerBase
{
    private ProjectDbContext projectDbContext;

    public BaseCharacterController(ProjectDbContext context)
    {
        this.projectDbContext = context;
    }

    /// <summary>
    /// Return a list of all base characters.
    /// </summary>
    /// <returns></returns>
    [HttpGet("base-characters", Name = "GetAllBaseCharacters")]
    public List<BaseCharacter> GetAllBaseCharacters()
    {
        return projectDbContext.BaseCharacters.ToList();
    }

    /// <summary>
    /// Create a base character
    /// </summary>
    /// <param name="request">Contains data used to create the base character.</param>
    /// <returns>The base character that is created.</returns>
    [HttpPost("base-characters", Name = "CreateBaseCharacter")]
    public BaseCharacter CreateBaseCharacter(BaseCharacterCreateRequest request)
    {
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

        projectDbContext.BaseCharacters.Add(baseCharacter);
        projectDbContext.SaveChanges();
        return baseCharacter;
    }
}