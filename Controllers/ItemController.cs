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

    /// <summary>
    /// Return info about the item under the specified ID.
    /// </summary>
    /// <param name="id">Yeah.</param>
    /// <returns>An item, if one is found.</returns>
    [HttpGet("{id}", Name = "GetItemByID")]
    public Item? GetItemByID(int id)
    {
        return isaacRepository.GetItemByID(id);
    }

    /// <summary>
    /// Returns a list of all items.
    /// </summary>
    /// <returns></returns>
    [HttpGet("", Name = "GetAllItems")]
    public List<Item> GetAllItems()
    {
        return isaacRepository.GetAllItems();
    }

    /// <summary>
    /// Create an item.
    /// </summary>
    /// <param name="request">Contains data used to create the item.</param>
    /// <returns>The item that was created.</returns>
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
}