namespace MenuSystem.Composite;

public interface IComponent
{
    string Name { get; set; }
    void Display();
}