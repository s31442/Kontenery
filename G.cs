namespace Kontenery;

public class G : Kontener, IHazardNotifier
{
    public override double cargoWeight { get; set; }
    public override double height { get; set; }
    public override double contenerWeight { get; set; }
    public override double depth { get; set; }
    public override double maxCapacity { get; set; }
    public override string type { get; set; }
    private double cisnienie;
    
    public G(double height, double contenerWeight, double depth, double maxCapacity, double cisnienie)
        : base("G", height, contenerWeight, depth, maxCapacity)
    {
        this.cisnienie = cisnienie;
    }
    
    public void SendHazardMessage()
    {
        Console.WriteLine($"Niebezpieczna sytuacja - {SerialNumber}");
    }
    
    public override void load(double masa, string cargoType)
    {
        if (masa > maxCapacity)
            throw new OverfillException("Przekroczono ładowność kontenera");
        
        cargoWeight = masa;
        Console.WriteLine($"Załadowano {SerialNumber} {masa}kg");
    }
    
    public override void unload()
    {
        cargoWeight *= 0.05;
    }
    
    public override void PrintInfo()
    {
        Console.WriteLine(
            $"{SerialNumber}: Typ - {type}, Masa ładunku - {cargoWeight}kg, Cisnienie - {cisnienie}");
    }
}