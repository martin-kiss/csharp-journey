namespace Állatmenhely_nyilvántartás
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnimalSection dogYard = new AnimalSection("Kutyaudvar A", 18);
            AnimalSection catRoom = new AnimalSection("Macskaszoba", 12, true);
            AnimalSection rabbitHouse = new AnimalSection("Nyúlház", 10, true);
            AnimalSection isolation = new AnimalSection("Elkülönítő", 5, true);


            List<ShelterAnimal> animals = new List<ShelterAnimal>
            {
                new ShelterAnimal ("Bodri" , "Kutya" , dogYard, 6, 18.5, DateTime .Today.AddDays (-220) ,
            true ) ,
                new ShelterAnimal ("Morzsi" , "Kutya" , dogYard, 3, 12.2, DateTime .Today.AddDays (-75) ,
            false ) ,
                new ShelterAnimal ("Zara" , "Kutya" , dogYard, 9, 28.7, DateTime .Today.AddDays (-365) ,
            true ) ,
                new ShelterAnimal ("Pötty" , "Kutya" , dogYard, 1, 7.4, DateTime .Today.AddDays (-20) ,
            false ) ,
                new ShelterAnimal ("Cirmi" , "Macska" , catRoom, 4, 4.3, DateTime .Today.AddDays (-190) ,
            true ) ,
                new ShelterAnimal ("Málna" , "Macska" , catRoom, 2, 3.8, DateTime .Today.AddDays (-40) ,
            false ) ,
                new ShelterAnimal ("Fekete" , "Macska" , catRoom, 7, 5.1, DateTime .Today.AddDays (-250) ,
            true ) ,
                new ShelterAnimal ("Hópihe" , "Nyúl" , rabbitHouse, 2, 2.4, DateTime .Today.AddDays (-185) ,
            false ) ,
                new ShelterAnimal ("Dió", "Nyúl" , rabbitHouse, 5, 3.1, DateTime .Today.AddDays (-95) , true ),
                new ShelterAnimal ("Lili" , "Macska" , isolation, 1, 2.9, DateTime .Today.AddDays (-8) ,
            false )
            };

            //d.
            Console.WriteLine("Menhelyi részlegek:\n");
            Console.WriteLine(dogYard);
            Console.WriteLine(catRoom);
            Console.WriteLine(rabbitHouse);
            Console.WriteLine(isolation);
            Console.WriteLine();

            //e.
            Console.WriteLine();
            Console.WriteLine("Állatok faj, majd név szerinti sorrendben:");
            foreach (var item in animals.OrderBy(x => x.Species).ThenBy(x => x.Name))
            {
                Console.WriteLine(item);
            }

            //f.
            Console.WriteLine();
            Random rnd = new Random();
            animals[rnd.Next(animals.Count)].ChangeWeight(30.0);

            //g.
            Console.WriteLine();
            animals[rnd.Next(animals.Count)].MoveToSection(isolation);

            //h.
            Console.WriteLine();
            Console.WriteLine($"Állatok átlagos testtömege: \n {animals.Average(a => a.WeightKg):N2}Kg.");

            //i.
            Console.WriteLine();
            int pick = rnd.Next(animals.Count);
            Console.WriteLine("Menhelyi ajánló:");
            Console.WriteLine($"\tNév: {animals[pick].Name}");
            Console.WriteLine($"\tFaj: {animals[pick].Species}");
            Console.WriteLine($"\tKor: {animals[pick].AgeInYears}");
            Console.WriteLine($"\tSúly: {animals[pick].WeightKg:N2} kg");
            Console.WriteLine($"\tÉrkezés dátuma: {animals[pick].ArrivalDate}");
            Console.WriteLine($"\tRészleg: {animals[pick].Section.SectionName}");
            Console.WriteLine($"\tIvartalan: {(animals[pick].IsNeutered ? "igen" : "nem")}");
            Console.WriteLine($"\tAzonosító: {animals[pick].Id}");

            //j.
            Console.WriteLine();
            Console.WriteLine($"A legidosebb allat:\n{animals.MaxBy(x => x.AgeInYears)}");

            //k.
            Console.WriteLine();
            Console.WriteLine($"10kg-nál nehezebb állatok:");
            List<ShelterAnimal> heavyAnimals = animals.Where(x => x.WeightKg > 10).ToList();

            foreach (var item in heavyAnimals)
            {
                Console.WriteLine(item);
            }

            //l.
            Console.WriteLine();
            Console.Write("Adjon meg egy nevet/név részletet: ");
            string searchName = Console.ReadLine().ToLower();

            foreach (var item in animals)
            {
                if (item.Name.ToLower().Contains(searchName) || item.Name.ToLower() == searchName)
                {
                    Console.WriteLine(item);
                    break;
                }
                else if(animals.Where(x => !x.Name.ToLower().Contains(searchName) && x.Name.ToLower() != searchName).Count() == 0)
                {
                    Console.WriteLine($"Nincs találat a(z) '{searchName}' névre/név részletre.");
                    break;
                }
            }

            //m.
            Console.WriteLine();
            Console.WriteLine("Fajonkénti állatok száma:");
            foreach (var item in animals.GroupBy(x => x.Species))
            {
                Console.WriteLine($"Faj: {item.Key}, Szám: {item.Count()}");
  
            }

            //n.
            Console.WriteLine();
            Console.WriteLine("Állatok, akik több, mint 180 napja tartózkodnak a menhelyen:");
            foreach(var item in animals)
            {
                if(animals.Where(x => !x.IsLongTermResident).Count() == 0)
                {
                    Console.WriteLine($"Nincs olyan állat, aki több, mint 180 napja tartózkodik a menhelyen.");
                    break;
                }
                else if (item.IsLongTermResident)
                {
                    Console.WriteLine($" {item} | {(DateTime.Today - item.ArrivalDate).Days} nap");
                }
                
            }

            Console.ReadKey();


        }
    }
}
