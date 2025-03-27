namespace Kontenery;

public abstract class Kontener
{
    public abstract double cargoWeight { get; set; }
    public abstract double height { get; set; }
    public abstract double contenerWeight { get; set; }
    public abstract double depth { get; set; }
    public abstract double maxCapacity { get; set; }
    public abstract string type { get; set; }
    public string SerialNumber { get; protected set; }
    private static int counter = 0;
    
    public Kontener(string type, double height, double contenerWeight, double depth, double maxCapacity)
    {
        if (type != "L" && type != "G" && type != "C")
            throw new Exception("Unknown type");
        
        this.type = type;
        this.height = height;
        this.contenerWeight = contenerWeight;
        this.depth = depth;
        this.maxCapacity = maxCapacity;
        SerialNumber = $"KON-{type}-{++counter}";
    }
    
    public virtual void unload()
    {
        cargoWeight = 0;
        Console.WriteLine($"Rozladowano kontener {SerialNumber}");
    }
    
    public virtual void load(double masa, string cargoType)
    {
        if (masa > this.maxCapacity)
            throw new OverfillException("Maximum capacity exceeded");
        
        cargoWeight = masa;
    }
    
    public virtual void PrintInfo()
    {
        Console.WriteLine(
            $"{SerialNumber}: Typ - {type}, Masa ładunku - {cargoWeight}kg");
    }
    
}