internal class Program
{
    static Random rnd = new Random();
    private static void Main(string[] args)
    {
        string path = @"C:\temp\words.txt";
        if (!File.Exists(path))
        {
            Console.WriteLine("The file does not exist.");
            return;
        }
        bool playing = true;
        string[,] field = new string[15, 15];
        List<string> list = File.ReadAllLines(path).ToList();
        List<string> szavak = new List<string>();

        for (int i = 0; i < field.GetLength(0); i++)
            for (int j = 0; j < field.GetLength(1); j++)
                field[i, j] = ".";
        while (list.Count != 10)
        {
            int corX = rnd.Next(field.GetLength(0));
            int corY = rnd.Next(field.GetLength(1));
            switch (rnd.Next(1, 4))
            {
                case 1:
                    string vizszint = pickWord(field, list, corX, corY);
                    if (vizszint != null)
                    {
                        for (int i = 0; i < vizszint.Length; i++)
                        {
                            int y = corY + i;
                            if (y >= field.GetLength(1) || field[corX, y] != ".") break;
                            field[corX, y] = vizszint[i].ToString();
                        }
                        szavak.Add(vizszint);
                        list.Remove(vizszint);
                    }
                    break;
                case 2:
                    string fuggo = pickWord(field, list, corX, corY);
                    if (fuggo != null)
                    {
                        for (int i = 0; i < fuggo.Length; i++)
                        {
                            int x = corX + i;
                            if (x >= field.GetLength(0) || field[x, corY] != ".") break;
                            field[x, corY] = fuggo[i].ToString();
                        }
                        szavak.Add(fuggo);
                        list.Remove(fuggo);
                    }
                    break;
                case 3:
                    string atlo = pickWord(field, list, corX, corY);
                    if (atlo != null)
                    {
                        for (int i = 0; i < atlo.Length; i++)
                        {
                            int x = corX + i;
                            int y = corY + i;
                            if (x >= field.GetLength(0) || y >= field.GetLength(1) || field[x, y] != ".") break;
                            field[x, y] = atlo[i].ToString();
                        }
                        szavak.Add(atlo);
                        list.Remove(atlo);
                    }
                    break;
            }
        }
        string letters = "qwertzuiopőúöüóasdfghjkléáűíyxcvbnm";
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == ".")
                {
                    field[i, j] = letters[rnd.Next(letters.Length)].ToString();
                }
                else
                {
                    continue;
                }
            }
        }
        Console.WriteLine("Welcome to the word guessing game! Type 'kilep' at any time to exit.");
        Console.ReadKey();
        Console.Clear();
        while (playing)
        {

            writeMatrix(field);
            Console.Write("- ");
            string valasz = Console.ReadLine();
            if (szavak.Contains(valasz))
            {
                Console.Clear();
                Console.WriteLine("You guessed it!");
                Console.ReadKey();
                Console.Clear();
            }
            else if (valasz == "kilep")
            {
                playing = false;
                Console.Clear();
                Console.WriteLine("Thank you for playing!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong guess!");
                Console.ReadKey();
                Console.Clear();
            }
        }
        Console.ReadKey();
    }
    public static string pickWord(string[,] matrix, List<string> words, int X, int Y)
    {
        int atloCount = Math.Min(matrix.GetLength(0) - X, matrix.GetLength(1) - Y);
        List<string> list = words
            .Where(x => x.Length <= matrix.GetLength(0) - X &&
                        x.Length <= matrix.GetLength(1) - Y &&
                        x.Length <= atloCount)
            .ToList();
        if (list.Count == 0)
            return null;
        return list[rnd.Next(list.Count)];
    }
    public static void writeMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j]);
            Console.WriteLine();
        }
    }
}