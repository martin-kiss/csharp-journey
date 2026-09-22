internal class Program
{
    private static void Main(string[] args)
    {
        //section speed control csapo 2
        string input = @"C:\temp\measurements.txt";
        string output = @"C:\temp\fines.txt";
        List<Gate> list = new List<Gate>();

        if (File.Exists(input))
        {
            //Exercise 1.
            string[] data = File.ReadAllLines(input);
            for (int i = 0; i < data.Length; i++)
            {
                list.Add(new Gate(data[i]));
            }

            Console.WriteLine("Exercise 2.");
            Console.WriteLine($"The data of {list.Count} vehicles were recorded in the measurement.");

            Console.WriteLine();
            Console.WriteLine("Exercise 3.");

            int counter = 0;

            foreach (var item in list)
            {
                if (item.exitHour == 8) counter++;
            }

            Console.WriteLine($"Before 9 o' clock {counter} vehicles were passed the exit point recorder.");

            Console.WriteLine();
            Console.WriteLine("Exercise 4.");

            Console.Write("Enter an hour and minute value divided by a single space: ");

            string s = Console.ReadLine();

            int reqHour = int.Parse(s.Split(' ')[0]);
            int reqMin = int.Parse(s.Split(' ')[1]);

            Console.WriteLine($"\ta. The number of vehicle that passed the entry point recorder: {list.Where(x => x.entryMinute == reqMin && x.entryHour == reqHour).Count()}");

            double cars = list.Where(x => x.entryHour == reqHour && x.entryMinute == reqMin).Count();

            double intensity = cars / 10;

            Console.WriteLine($"\tb. The traffic intensity: {intensity}");

            Console.WriteLine();
            Console.WriteLine("Exercise 5.");
            Console.WriteLine("The data of the vehicle with the highest speed are");

            foreach (var item in list.OrderByDescending(x => x.avgSpeed).Take(1))
            {
                Console.WriteLine($"\tlicense plate number: {item.licensePlate}");
                Console.WriteLine($"\taverage speed: {Math.Floor(item.avgSpeed)} km/h");
                Console.WriteLine($"\tnumber of overtaken vehicles: {list.Where(x => x.entrymSec < item.entrymSec && x.exitmSec > item.exitmSec).Count()} ");
            }

            Console.WriteLine();
            Console.WriteLine("Exercise 6.");

            Console.WriteLine($"{percent(list):F2}% of the vehicles were speeding.");

            //Exercise 7.
            List<string> fines = new List<string>();

            foreach (var item in list)
            {
                if (item.avgSpeed > 104 && item.avgSpeed <= 121)
                {
                    fines.Add($"{item.licensePlate}\t{Math.Floor(item.avgSpeed)} km/h\t30 000 Ft");
                }
                else if (item.avgSpeed > 121 && item.avgSpeed <= 136)
                {
                    fines.Add($"{item.licensePlate}\t{Math.Floor(item.avgSpeed)} km/h\t45 000 Ft");
                }
                else if (item.avgSpeed > 136 && item.avgSpeed <= 151)
                {
                    fines.Add($"{item.licensePlate}\t{Math.Floor(item.avgSpeed)} km/h\t60 000 Ft");
                }
                else if (item.avgSpeed > 151)
                {
                    fines.Add($"{item.licensePlate}\t{Math.Floor(item.avgSpeed)} km /h\t200 000 Ft");
                }
            }

            Console.WriteLine();
            File.WriteAllLines(output, fines);
            Console.WriteLine("The file is ready.");
        }
        else
        {
            Console.WriteLine("The file does not exist.");
        }

        Console.ReadKey();
    }
    public static double percent(List<Gate> list)
    {
        double total = list.Count();
        double speedersCount = list.Where(x => x.avgSpeed > 90).Count();

        return (speedersCount / total) * 100;
    }
}

class Gate
{
    public string licensePlate;
    public int entryHour;
    public int entryMinute;
    public int entrySecond;
    public int entryMs;

    public int exitHour;
    public int exitMinute;
    public int exitSecond;
    public int exitMs;

    public double elapsedTime;
    public double avgSpeed;

    public int entrymSec;
    public int exitmSec;
    public Gate(string data)
    {
        string[] _data = data.Split(' ');
        licensePlate = _data[0];
        entryHour = int.Parse(_data[1]);
        entryMinute = int.Parse(_data[2]);
        entrySecond = int.Parse(_data[3]);
        entryMs = int.Parse(_data[4]);
        exitHour = int.Parse(_data[5]);
        exitMinute = int.Parse(_data[6]);
        exitSecond = int.Parse(_data[7]);
        exitMs = int.Parse(_data[8]);

        elapsedTime = ((exitHour * 3600000.0 + exitMinute * 60000.0 + exitSecond * 1000.0 + exitMs) - (entryHour * 3600000.0 + entryMinute * 60000.0 + entrySecond * 1000.0 + entryMs)) / 3600000;

        avgSpeed = 10 / elapsedTime;

        entrymSec = entryHour * 3600000 + entryMinute * 60000 + entrySecond * 1000 + entryMs;

        exitmSec = exitHour * 3600000 + exitMinute * 60000 + exitSecond * 1000 + exitMs;
    }
}