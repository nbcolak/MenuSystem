using System.Text.Json;
using MongoDB.Bson.Serialization.Attributes;

namespace MenuSystem.Composite;
public class MenuItem : IComponent//leaf
{
    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("price")]
    public double Price { get; set; }

    public MenuItem(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public void Display()
    {
        Console.WriteLine($"Menu Item: {Name}, Price: {Price}");
    }

    
}