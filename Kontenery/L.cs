namespace Kontenery;

public class L : Kontener, IHazardNotifier
{
    public override double cargoWeight { get; set; }
    public override double height { get; set; }
    public override double contenerWeight { get; set; }
    public override double depth { get; set; }
    public override double maxCapacity { get; set; }
    public override string type { get; set; }
    
    public L(double height, double contenerWeight, double depth, double maxCapacity)
        : base("L", height, contenerWeight, depth, maxCapacity)
    {
    }
    
    public void SendHazardMessage()
    {
        Console.WriteLine($"Niebezpieczna sytuacja - {SerialNumber}");
    }
    
    public override void load(double masa, string cargoType)
    {
        double limit = cargoType == "hazardous" ? maxCapacity * 0.5 : maxCapacity * 0.9;
        
        if (masa > limit)
        {
            SendHazardMessage();
            throw new OverfillException("Przekroczono dopuszczalny limit dla ładunku");
        }
        
        cargoWeight = masa;
        Console.WriteLine($"Załadowano {SerialNumber} {masa}kg");
    }
    
    public override void PrintInfo()
    {
        Console.WriteLine(
            $"{SerialNumber}: Typ - {type}, Masa ładunku - {cargoWeight}kg");
    }
}