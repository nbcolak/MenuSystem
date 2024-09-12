using MenuSystem.Composite;
using MongoDB.Driver;

namespace MenuSystem.Mongo;
using MongoDB.Driver;
using System.Threading.Tasks;

public class MongoDbService
{
    private readonly IMongoCollection<MenuCategory> _menuCollection;

    public MongoDbService()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("MenuDb");
        _menuCollection = database.GetCollection<MenuCategory>("Menus");
    }

    public async Task SaveMenuAsync(MenuCategory menu)
    {
        await _menuCollection.InsertOneAsync(menu);
    }

    public async Task UpdateMenuAsync(string categoryName, MenuCategory updatedCategory)
    {
        await _menuCollection.ReplaceOneAsync(menu => menu.Name == categoryName, updatedCategory);
    }

    public async Task<MenuCategory> GetMenuAsync(string name)
    {
        return await _menuCollection.Find(menu => menu.Name == name).FirstOrDefaultAsync();
    }
}