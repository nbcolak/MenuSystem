using MenuSystem.Composite;

public class Program
{
    public static void Main(string[] args)
    {
        // Ana kategori
        MenuCategory mainMenu = new MenuCategory("Main Menu");

        // Menü öğeleri (items)
        MenuItem pizza = new MenuItem("Pizza", 12.99);
        MenuItem burger = new MenuItem("Burger", 8.99);

        // Alt kategori - Drinks
        MenuCategory drinks = new MenuCategory("Drinks");
        MenuItem coke = new MenuItem("Coke", 2.50);
        MenuItem water = new MenuItem("Water", 1.00);
        drinks.AddItem(coke);
        drinks.AddItem(water);

        // Alt kategori - Desserts
        MenuCategory desserts = new MenuCategory("Desserts");
        MenuItem iceCream = new MenuItem("Ice Cream", 4.50);
        MenuItem cake = new MenuItem("Cake", 5.00);
        desserts.AddItem(iceCream);
        desserts.AddItem(cake);

        // Ana kategoriye öğeler ve alt kategoriler ekleme
        mainMenu.AddItem(pizza);
        mainMenu.AddItem(burger);
        mainMenu.AddSubCategory(drinks);
        mainMenu.AddSubCategory(desserts);

        // Menü yapısını ekrana yazdır
        mainMenu.Display();
    }
}