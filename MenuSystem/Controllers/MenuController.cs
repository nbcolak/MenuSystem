using MenuSystem.Composite;
using MenuSystem.Mongo;

namespace MenuSystem.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly MongoDbService _mongoDbService;

    public MenuController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    // API ile yeni bir menü (MenuCategory) ekleme işlemi
    [HttpPost("add-category")]
    public async Task<IActionResult> AddMenuCategory([FromBody] MenuCategory menuCategory)
    {
        if (menuCategory == null)
        {
            return BadRequest("Invalid menu category.");
        }

        await _mongoDbService.SaveMenuAsync(menuCategory);
        return Ok("Menu category added successfully.");
    }

    // API ile yeni bir menü öğesi (MenuItem) ekleme işlemi
    [HttpPost("add-item/{categoryName}")]
    public async Task<IActionResult> AddMenuItem(string categoryName, [FromBody] MenuItem menuItem)
    {
        if (menuItem == null)
        {
            return BadRequest("Invalid menu item.");
        }

        var category = await _mongoDbService.GetMenuAsync(categoryName);
        if (category == null)
        {
            return NotFound($"Menu category '{categoryName}' not found.");
        }

        category.AddItem(menuItem);
        await _mongoDbService.UpdateMenuAsync(categoryName, category);

        return Ok($"Menu item '{menuItem.Name}' added to category '{categoryName}'.");
    }

    // API ile menüyü (MenuCategory) getirme işlemi
    [HttpGet("get/{name}")]
    public async Task<IActionResult> GetMenuCategory(string name)
    {
        var category = await _mongoDbService.GetMenuAsync(name);
        if (category == null)
        {
            return NotFound($"Menu category '{name}' not found.");
        }

        return Ok(category);
    }
}