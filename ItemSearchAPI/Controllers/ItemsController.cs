using Microsoft.AspNetCore.Mvc;
using ItemSearchAPI.Models;
using ItemSearchAPI.Services;

namespace ItemSearchAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    /// <summary>
    /// Get all items
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetAllItems()
    {
        var items = _itemService.GetAllItems();
        return Ok(items);
    }

    /// <summary>
    /// Search for an item by barcode
    /// </summary>
    /// <param name="barcode">The barcode to search for</param>
    [HttpGet("search/barcode/{barcode}")]
    public ActionResult<Item> GetItemByBarcode(string barcode)
    {
        if (string.IsNullOrWhiteSpace(barcode))
        {
            return BadRequest("Barcode cannot be empty");
        }

        var item = _itemService.GetItemByBarcode(barcode);
        
        if (item == null)
        {
            return NotFound($"Item with barcode '{barcode}' not found");
        }

        return Ok(item);
    }

    /// <summary>
    /// Search for items by name
    /// </summary>
    /// <param name="name">The name to search for</param>
    [HttpGet("search/name/{name}")]
    public ActionResult<IEnumerable<Item>> SearchItemsByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest("Name cannot be empty");
        }

        var items = _itemService.SearchItemsByName(name);
        
        if (!items.Any())
        {
            return NotFound($"No items found with name containing '{name}'");
        }

        return Ok(items);
    }
}
