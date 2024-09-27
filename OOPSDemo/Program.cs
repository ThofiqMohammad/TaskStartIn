// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Top-level statement
Car car = new Volvo("Volvo");
Console.WriteLine(car.GetCarName()); // Output: Volvo

// Abstraction
public abstract class Car
{
    // Encapsulation
    private string name { get; set; }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    protected Car(string name)
    {
        this.name = name;
    }

    public abstract string GetCarName();
}

// Inheritance
public class Volvo : Car
{
    public Volvo(string name) : base(name)
    {
    }

    public override string GetCarName()
    {
        return "Volvo overrided";
    }
}


