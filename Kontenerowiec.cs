namespace Kontenery;

public class Kontenerowiec
{
    public string Name { get; set; }
    public int MaxContainers { get; set; }
    public double MaxWeight { get; set; }
    public double Speed { get; set; }
    public List<Kontener> Kontenery;
    
    public Kontenerowiec(string name, int maxContainers, double maxWeight, double speed)
    {
        Name = name;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        Speed = speed;
        Kontenery = new List<Kontener>();
    }
    
    public void LoadContainer(Kontener kontener)
    {
        if (Kontenery.Count >= MaxContainers || TotalWeight() + kontener.cargoWeight > MaxWeight * 1000)
            throw new Exception("Przekroczono limit kontenerów lub wagi statku");
        Kontenery.Add(kontener);
        Console.WriteLine($"Załadowano kontener {kontener.SerialNumber} na statek {Name}");
    }
    
    public void LoadContainers(List<Kontener> noweKontenery)
    {
        foreach (var kontener in noweKontenery)
        {
            try
            {
                LoadContainer(kontener);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
    public void UnloadContainer(Kontener kontener)
    {
        if (Kontenery.Remove(kontener))
            Console.WriteLine($"Usunięto kontener {kontener.SerialNumber} ze statku {Name}");
    }
    
    public void SwapContainer(Kontener onShip, Kontener offShip)
    {
        if (!Kontenery.Contains(onShip))
        {
            Console.WriteLine($"Kontener {onShip.SerialNumber} nie znajduje się na statku {Name}");
            return;
        }

        UnloadContainer(onShip);
        LoadContainer(offShip);
        Console.WriteLine($"Zamieniono kontener {onShip.SerialNumber} na {offShip.SerialNumber} na statku {Name}");
    }
    
    public void TransferContainer(Kontener kontener, Kontenerowiec other)
    {
        UnloadContainer(kontener);
        other.LoadContainer(kontener);
        Console.WriteLine($"Przeniesiono kontener {kontener.SerialNumber} ze statku {Name} na {other.Name}");
    }
    
    public double TotalWeight()
    {
        return Kontenery.Sum(k => k.cargoWeight + k.contenerWeight);
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"Statek: {Name}, Prędkość: {Speed} węzłów, Maks kontenery: {MaxContainers}, Maks waga: {MaxWeight} ton");
        Console.WriteLine("Kontenery na pokładzie:");
        foreach (var k in Kontenery)
        {
            Console.WriteLine($"- {k.SerialNumber} ({k.type}) - {k.cargoWeight}kg");
        }
    }
}