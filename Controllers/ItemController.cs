using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for Item HTTP requests.
/// </summary>
[ApiController]
public class ItemController: ControllerBase
{
    private ProjectDbContext projectDbContext;

    public ItemController(ProjectDbContext context)
    {
        this.projectDbContext = context;
    }

    /// <summary>
    /// Return info about the item under the specified ID.
    /// </summary>
    /// <param name="id">Yeah.</param>
    /// <returns>An item, if one is found.</returns>
    [HttpGet("items/{id}", Name = "GetItemByID")]
    public Item? GetItemByID(int id)
    {
        return projectDbContext.Items.Find(id);
    }

    /// <summary>
    /// Returns a list of all items.
    /// </summary>
    /// <returns>Did I stutter?</returns>
    [HttpGet("items", Name = "GetAllItems")]
    public List<Item> GetAllItems()
    {
        return projectDbContext.Items.ToList();
    }

    /// <summary>
    /// Create an item.
    /// </summary>
    /// <param name="request">Contains data used to create the item.</param>
    /// <returns>The item that was created.</returns>
    [HttpPost("items", Name = "PostItem")]
    public Item PostItem(ItemCreateRequest request)
    {
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
        projectDbContext.Items.Add(item);
        projectDbContext.SaveChanges();
        return item;
    }
}