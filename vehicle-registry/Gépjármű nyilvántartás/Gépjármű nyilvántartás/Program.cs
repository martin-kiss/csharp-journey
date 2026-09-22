using System.Security.Cryptography.X509Certificates;

namespace Gépjármű_nyilvántartás
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Company autoparkkft = new Company("Autópark KFT.", "12345678-1-12","Budapest Váci út 6.");

            Car bmw = new Car("Opel", "ABC-123", "Insignia", 2022, 196150, 12000, autoparkkft);
            Car audi = new Car("Toyota", "DEF-456", "Corola", 2021, 85720, 10500, autoparkkft);
            Car opel = new Car("Skoda", "GHI-654", "Octavia", 2020, 122300, 11000, autoparkkft);
            Car kia = new Car("Ford", "JKL-321", "Focus", 2018, 176500, 8500, autoparkkft);
            Car porsche = new Car("Volkswagen", "MNO-654", "Passat", 2023, 42880, 15000, autoparkkft);

            List<Car> autok = new List<Car>()
            {
                bmw, audi, opel, kia, porsche
            }; 

            User peti = new User("Peti","peti@example.com","ertekesites");
            User feri = new User("Feri", "feri@example.com","penzugy");
            User kati = new User("Kati", "kati@example.com","informatika");
            User zoli = new User("Zoli", "zoli@example.com","ertekesites");

            List<User> felhasznalok = new List<User>()
            {
                peti,feri,kati,zoli
            };
            
            bmw.AddUser(peti);
            audi.AddUser(peti);
            kia.AddUser(peti);
            porsche.AddUser(zoli);
            bmw.AddUser(feri);
            opel.AddUser(kati);
            porsche.AddUser(kati);

            audi.AddMileage(1000);
            kia.AddMileage(500);
            porsche.AddMileage(5500);

            Console.WriteLine("CÉG ADATAI");
            Console.WriteLine(autoparkkft.ToString());
            Console.WriteLine();

            Console.WriteLine("AUTÓK");
            foreach(var item in autok)
            {
                Console.WriteLine($"{item.ToString()}");
            }
            Console.WriteLine();

            Console.WriteLine("FELHASZNÁLÓK");
            foreach(var item in felhasznalok)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("1. Autó(k), ami(ke)t több, mint 1 felhasználó használ");
            foreach(var item in autok.Where(x => x.Users.Count > 1))
            {
                Console.WriteLine($"{item.Brand} - {item.Model} - {item.LicensePlate}");
            }
            Console.WriteLine();

            Console.WriteLine("2. Autók, ahol a napi bérlési ár 10.000 Ft felett van:");
            foreach(var item in autok.Where(x => x.DailyRentalPrice > 10000).ToList())
            {
                Console.WriteLine($"{item.Brand} - {item.Model} - {item.LicensePlate}");
            }
            Console.WriteLine();

            Console.WriteLine("3. Gyártási év szerint növekvő sorrend");
            foreach(var item in autok.OrderBy(x => x.ManufactureYear).ToList())
            {
                Console.WriteLine($"{item.Brand} - {item.Model} - {item.LicensePlate} - {item.ManufactureYear}");
            }
            Console.WriteLine();
            Console.WriteLine("4. 100 000km feletti autók");
            foreach(var item in autok.Where(x => x.Mileage > 100000))
            {
                Console.WriteLine($"{item.Brand} - {item.Model} - {item.LicensePlate}");
            }
            Console.WriteLine();

            Console.WriteLine("5. Meghatározott szervezeti egységhez tartozó felhasználók:");
            foreach(var item in felhasznalok.Where(x => x.Department == "ertekesites"))
            {
                Console.WriteLine($"{item.Name} - {item.Email} - {item.Department}");
            }
            Console.WriteLine();

            Console.WriteLine("6. A ceghez tartozo autok szama:");
            Console.WriteLine(autoparkkft.Cars.Count);
            Console.WriteLine();

            Console.WriteLine("7. Autok atlagos futasteljesitmenye");

            double averageMileage = autok.Average(x => x.Mileage);
            Console.WriteLine($"Az autók átlagos futásteljesítménye: {averageMileage} km");
            Console.WriteLine();

            Console.WriteLine("8. Legnagyobb napi bérlési árú autó:");
            foreach(var item in autok.Where(x => x.DailyRentalPrice == autok.Max(y => y.DailyRentalPrice)))
            {
                Console.WriteLine($"{item.Brand} - {item.Model} - {item.LicensePlate} - {item.DailyRentalPrice}");
            }
            Console.WriteLine();

            Console.WriteLine("9. Felhasznalok, akik legalabb ket autot vezetnek");
            foreach(var item in felhasznalok.Where(x=> x.Cars.Count >= 2))
            {
                Console.WriteLine($"{item.Name} - {item.Email} - {item.Department}");
            }
            Console.WriteLine();

            Console.WriteLine("10.Felhasználók szervezeti egységek szerint");
            foreach(var item in felhasznalok.GroupBy(x => x.Department))
            {
                Console.WriteLine($"Szervezeti egység: {item.Key} - Felhasználók száma: {item.Count()}");
            }
            Console.WriteLine();

            Console.WriteLine("11. Azok az autok, amik hasznalatara az informatika legalabb egy munkatarsa jogosult");
            foreach(var item in autok.Where(x => x.Users.Any(y => y.Department == "informatika")))
            {
                Console.WriteLine($"{item.Brand} - {item.Model} - {item.LicensePlate}");
            }
            Console.WriteLine();

            Console.WriteLine("12. Brutto napi berlési árak osszesen");

            decimal total = autok.Sum(x => x.VatIncludedDailyRentalPrice);
            Console.WriteLine($"Az autók bruttonapi bérlési árak összege: {total:C0}");

            Console.WriteLine();

            Console.WriteLine("13. Van-e olyan auto, amihez nincs felhasznalo rendelve: ");

            bool hasNoUser = autok.Any(x => x.Users.Count == 0);
            if (hasNoUser)
            {
                Console.WriteLine("van");
            }
            else
            {
                Console.WriteLine("nincs");
            }

            Console.WriteLine();

            Console.WriteLine("14. Harom legnagyobb futasteljesitmenyu auto:");

            foreach(var item in autok.OrderByDescending(x => x.Mileage).Take(3))
            {
                Console.WriteLine($"{item.Brand} - {item.Model} - {item.LicensePlate} - {item.Mileage}");
            }
            Console.ReadKey();
        }
    }
}
