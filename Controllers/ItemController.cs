using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for Item HTTP requests.
/// </summary>
[ApiController]
[Route("items")]
public class ItemController: ControllerBase
{
    // Use the service layer to deal with logic and data stuff.
    private IsaacService isaacService;

    public ItemController(IsaacService service)
    {
        isaacService = service;
    }

    [HttpGet("{id}", Name = "GetItemById")]
    public Item? GetItemById(int id)
    {
        return isaacService.GetItemById(id);
    }

    [HttpGet("", Name = "GetAllItems")]
    public List<Item> GetAllItems()
    {
        return isaacService.GetAllItems();
    }

    [HttpPost("", Name = "CreateItem")]
    public Item CreateItem(ItemCreateRequest request)
    {
        if(!ModelState.IsValid)
        {
            throw new InvalidInputException("Item Create request is invalid: ", ModelState);
        }
        else
        {
            return isaacService.CreateItem(request);
        }
    }

    [HttpDelete("", Name = "DeleteItemById")]
    public void DeleteItemById(int id)
    {
        isaacService.DeleteItemById(id);
    }
}