using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
[ApiController]
public class ItemController: ControllerBase
{
    private readonly ProjectDbContext projectDbContext;

    public ItemController(ProjectDbContext context)
    {
        this.projectDbContext = context;
    }
    /*
    private static List<Item> ITEMS = new List<Item>
    {
        new Item{Id = 1, Name = "The Sad Onion"},
        new Item{Id = 2, Name = "The Inner Eye"},
        new Item{Id = 3, Name = "Spoon Bender"},
        new Item{Id = 4, Name = "Cricket's Head"},
        new Item{Id = 5, Name = "My Reflection"}
    };
    */

    /// <summary>
    /// Get information about an item using an ID as input.
    /// </summary>
    /// <param name="id">The ID of the item.</param>
    /// <returns>The item with the specified ID.</returns>
    [HttpGet("items/{id}", Name = "GetItemByID")]
    public Item? GetItemByID(int id)
    {
        return projectDbContext.Items.Find(id);
    }
    
    [HttpPost("items", Name = "PostItem")]
    public Item PostItem(ItemCreateRequest request)
    {
        Item ItemToCreate = new Item
        {
            Id = request.Id,
            Name = request.Name
        };
        projectDbContext.Items.Add(ItemToCreate);

        projectDbContext.SaveChanges();

        return ItemToCreate;
    }
}