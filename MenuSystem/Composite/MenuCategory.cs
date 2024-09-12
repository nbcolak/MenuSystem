using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MenuSystem.Composite;


public class MenuCategory : IComponent
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("items")]
    public List<MenuItem> Items { get; set; } = new List<MenuItem>();

    [BsonElement("subCategories")]
    public List<MenuCategory> SubCategories { get; set; } = new List<MenuCategory>();

    public MenuCategory(string name)
    {
        Name = name;
    }

    public void AddItem(MenuItem item)
    {
        Items.Add(item);
    }

    public void AddSubCategory(MenuCategory subCategory)
    {
        SubCategories.Add(subCategory);
    }

    public void Display()
    {
        Console.WriteLine($"Menu Category: {Name}");

        foreach (var item in Items)
        {
            item.Display();
        }

        foreach (var subCategory in SubCategories)
        {
            subCategory.Display();
        }
    }
}