namespace Kontenery;

public class C : Kontener
{
    public override double cargoWeight { get; set; }
    public override double height { get; set; }
    public override double contenerWeight { get; set; }
    public override double depth { get; set; }
    public override double maxCapacity { get; set; }
    public override string type { get; set; }
    public string RodzajProduktu { get; set; }
    public double KontenerTemp { get; set; }
    
    public C(double height, double contenerWeight, double depth, double maxCapacity, string rodzajProduktu, double Temp)
        : base("C", height, contenerWeight, depth, maxCapacity)
    {
        RodzajProduktu = rodzajProduktu;
        KontenerTemp = Temp;
    }
    
    public override void load(double masa, string cargoType)
    {
        if (masa > maxCapacity)
            throw new OverfillException("Przekroczono ładowność kontenera");
        
        cargoWeight = masa;
        Console.WriteLine($"Załadowano {SerialNumber} {masa}kg");
    }
    
    public override void PrintInfo()
    {
        Console.WriteLine(
            $"{SerialNumber}: Typ - {type}, Masa ładunku - {cargoWeight}kg, Temperatura - {KontenerTemp}");
    }
}