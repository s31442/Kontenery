namespace Kontenery;

class Program
{
    static void Main()
    {
        Kontenerowiec statek1 = new Kontenerowiec("Horizon", 5, 100, 20);
        Kontenerowiec statek2 = new Kontenerowiec("Explorer", 5, 100, 22);
        
        Kontener doZamiany = new G(300, 2000, 250, 6000, 10);
        Kontener g1 = new G(300, 2000, 250, 6000, 10);
        g1.load(g1.maxCapacity * 0.9, "standard");
        statek2.LoadContainer(g1);
        
        List<Kontener> kontenery = new List<Kontener>
        {
            new G(300, 2000, 250, 5000, 10),
            new L(300, 1800, 250, 4000),
            new C(300, 2200, 250, 4500, "banany", 5),
            new C(300, 2200, 250, 4500, "mleko", 2)
        };
        
        foreach (var kontener in kontenery)
        {
            try
            {
                kontener.load(kontener.maxCapacity * 0.9, "standard");
            }
            catch (OverfillException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        statek1.LoadContainers(kontenery);
        
        statek1.UnloadContainer(kontenery[1]);
        
        kontenery[2].unload();
        
        statek1.SwapContainer(kontenery[0], doZamiany);
        
        statek1.TransferContainer(kontenery[3], statek2);
        
        statek1.PrintInfo();
        statek2.PrintInfo();
        
        statek2.Kontenery[0].PrintInfo();
    }
}