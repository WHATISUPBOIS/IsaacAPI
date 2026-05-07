using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for Item HTTP requests.
/// </summary>
[ApiController]
[Route("items")]
public class ItemController: ControllerBase
{
    private IIsaacRepository isaacRepository;

    public ItemController(IIsaacRepository repository)
    {
        isaacRepository = repository;
    }

    [HttpGet("{id}", Name = "GetItemById")]
    public Item? GetItemById(int id)
    {
        return isaacRepository.GetItemById(id);
    }

    [HttpGet("", Name = "GetAllItems")]
    public List<Item> GetAllItems()
    {
        return isaacRepository.GetAllItems();
    }

    [HttpPost("", Name = "CreateItem")]
    public Item CreateItem(ItemCreateRequest request)
    {
        // Map request to item we are creating.
        Item item = new Item
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            SpeedUp = request.SpeedUp,
            DamageUp = request.DamageUp,
            DamageMult = request.DamageMult,
            TearsUp = request.TearsUp,
            FireRateUp = request.FireRateUp,
            RangeUp = request.RangeUp,
            ShotSpeedUp = request.ShotSpeedUp,
            LuckUp = request.LuckUp
        };
        
        return isaacRepository.CreateItem(item);
    }

    [HttpDelete("", Name = "DeleteItemById")]
    public void DeleteItemById(int id)
    {
        Item item = isaacRepository.GetItemById(id);
        isaacRepository.DeleteItem(item);
    }
}