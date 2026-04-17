using Microsoft.AspNetCore.Mvc;
[ApiController]
public class CharacterController: ControllerBase
{
    private readonly ProjectDbContext projectDbContext;

    public CharacterController(ProjectDbContext context)
    {
        this.projectDbContext = context;
    }
    [HttpGet("character/{id}", Name = "GetCharacterByID")]
    public Character? GetCharacterByID(int id)
    {
        return projectDbContext.Characters.Find(id);
    }
}