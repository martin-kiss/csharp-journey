using System.Net.Http.Headers;
internal class Program
{
    private static void Main(string[] args)
    {
        //rendszam - ora - perc - sebesseg
        string path = @"C:\temp\jeladas.txt";
        string ora = "";
        string perc = "";
        int counter = 0;
        int maxSeb = 0;
        string path2 = @"c:\temp\ido.txt";
        if (File.Exists(path))
        {
            string[] adatok = File.ReadAllLines(path);
            List<Meres> auto = new List<Meres>();
            foreach (string item in adatok)
            {
                auto.Add(new Meres(item));
            }
            Console.WriteLine($"2. feladat: \nAz utolso meres idopontja: {auto[auto.Count - 1].ora}:{auto[auto.Count - 1].perc}, a jarmu rendszama: {auto[auto.Count - 1].rendszam}");
            Console.WriteLine();
            Console.WriteLine("3. feladat:");
            Console.WriteLine($"Az elso jarmu: {auto[0].rendszam}");
            Console.Write("Jarmu jeladasainak idopontja: ");
            for (int i = 0; i < auto.Count; i++)
            {
                if (auto[i].rendszam == auto[0].rendszam)
                {
                    Console.Write($"{auto[i].ora}:{auto[i].perc} ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("\n4. feladat:");
            Console.Write("Kerem adja meg az orat: ");
            ora = Console.ReadLine();
            Console.Write("Kerem adja meg a percet: ");
            perc = Console.ReadLine();
            for (int i = 0; i < auto.Count; i++)
            {
                if (ora == auto[i].ora && perc == auto[i].perc)
                {
                    counter++;
                }
            }
            Console.WriteLine($"A jeladasok szama: {counter}");
            Console.WriteLine();
            Console.WriteLine("5. feladat:");
            for (int i = 0; i < auto.Count; i++)
            {
                if (auto[i].sebesseg > maxSeb)
                {
                    maxSeb = auto[i].sebesseg;
                }
            }
            Console.WriteLine($"Legnagyobb mert sebesseg km/h: {maxSeb}");
            Console.Write($"A jarmuvek:");
            foreach (Meres item in auto)
            {
                if (item.sebesseg == maxSeb)
                {
                    Console.Write(item.rendszam);
                }
            }
            Console.WriteLine();
            Console.WriteLine("\n6. feladat:");
            Console.Write("adja meg a rendszamot: ");
            string rendszam = Console.ReadLine();
            double tav = 0;
            int elozoOra = 0;
            int elozoPerc = 0;
            int elozoSeb = 0;
            bool elso = true;
            for (int i = 0; i < auto.Count; i++)
            {
                if (auto[i].rendszam == rendszam)
                {
                    int oraMost = int.Parse(auto[i].ora);
                    int percMost = int.Parse(auto[i].perc);
                    int seb = auto[i].sebesseg;
                    if (elso)
                    {
                        Console.WriteLine($"{oraMost}:{percMost} 0.0 km");
                        elso = false;
                        elozoOra = oraMost;
                        elozoPerc = percMost;
                        elozoSeb = seb;
                    }
                    else
                    {
                        int diff = (oraMost * 60 + percMost) - (elozoOra * 60 + elozoPerc);
                        tav += elozoSeb * (diff / 60.0);
                        Console.WriteLine($"{oraMost}:{percMost} {tav:F1} km");
                        elozoOra = oraMost;
                        elozoPerc = percMost;
                        elozoSeb = seb;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("7. feladat:");
            var rendszamok = auto.Select(x => x.rendszam).Distinct();
            using (StreamWriter sw = new StreamWriter(path2))
            {
                foreach (var r in rendszamok)
                {
                    var elsoMeres = auto.First(x => x.rendszam == r);
                    var utolsoMeres = auto.Last(x => x.rendszam == r);
                    sw.WriteLine($"{r} {elsoMeres.ora} {elsoMeres.perc} {utolsoMeres.ora} {utolsoMeres.perc}");
                }
            }
            Console.WriteLine("\nAz ido.txt fajl sikeresen elkészült.");
        }
        else
        {
            Console.WriteLine("nem letezik ilyen forras.");
        }
        Console.ReadKey();
    }
}
class Meres
{
    public string rendszam;
    public string ora;
    public string perc;
    public int sebesseg;
    public Meres(string adat)
    {
        string[] data = adat.Split("\t");
        rendszam = data[0];
        ora = data[1];
        perc = data[2];
        sebesseg = int.Parse(data[3]);
    }
}

