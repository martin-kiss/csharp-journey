using System.ComponentModel.Design;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
internal class Program
{
    private static void Main(string[] args)
    {
        int disc = 0;
        Stack<int> A = new Stack<int>();
        bool isPlaying = false;
        Console.WriteLine("Welcome to the Tower of Hanoi game! Hope you enjoy!");
        Console.ReadKey();
        Console.Clear();
        while (disc < 3)
        {
            Console.WriteLine("How many disks would you like to play with? (3 is the minimum) ");
            disc = int.Parse(Console.ReadLine());
            if (disc < 3)
            {
                Console.Clear();
                Console.Write("You must select at least 3 disks.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                for (int i = disc; i >= 1; i--) A.Push(i);
                isPlaying = true;
            }
        }
        Stack<int> B = new Stack<int>();
        Stack<int> C = new Stack<int>();
        bool hasMoved = false;
        Stack<int> fromStack = new Stack<int>();
        Stack<int> toStack = new Stack<int>();
        while (isPlaying)
        {

            ShowTowers(A, B, C);

            Console.WriteLine(" ");
            Console.Write("Enter the tower you want to move from and to (e.g., ab, cb): ");
            string step = Console.ReadLine();

            if (Contains(step))
            {
                if (step[0] == 'a') fromStack = A;
                else if (step[0] == 'b') fromStack = B;
                else if (step[0] == 'c') fromStack = C;
                if (step[1] == 'a') toStack = A;
                else if (step[1] == 'b') toStack = B;
                else if (step[1] == 'c') toStack = C;
                if (replaceTest(fromStack, toStack))
                {
                    if (step[0] == step[1])
                    {
                        noReplace();
                    }
                    else
                    {
                        replace(fromStack, toStack);
                        hasMoved = true;
                    }
                }
                else
                {
                    largerNumError();
                }
                if (hasMoved)
                {
                    Win(disc, A, ref isPlaying);
                    Win(disc, B, ref isPlaying);
                    Win(disc, C, ref isPlaying);
                }
            }
            else if (step == "k")
            {
                Console.Clear();
                System.Console.Write("Press enter to exit...");
                Console.ReadLine();
                isPlaying = false;
            }
            else
            {
                incorrectInput();
            }
        }
    }
    private static void ShowTowers(Stack<int> A, Stack<int> B, Stack<int> C)
    {
        Console.Write("A: [ ");
        foreach (int i in A) System.Console.Write(i + " ");
        Console.Write("] \n");
        Console.Write("B: [ ");
        foreach (int i in B) System.Console.Write(i + " ");
        Console.Write("] \n");
        Console.Write("C: [ ");
        foreach (int i in C) System.Console.Write(i + " ");
        Console.Write("] \n");
    }
    private static void largerNumError()
    {
        Console.Clear();
        Console.WriteLine(" ");
        Console.Write("You cannot place a larger disk on a smaller one!");
        Console.ReadKey();
        Console.Clear();
    }
    private static void incorrectInput()
    {
        Console.Clear();
        Console.Write("Invalid input!");
        Console.ReadKey();
        Console.Clear();
    }
    private static void noReplace()
    {
        Console.Clear();
        Console.Write("You cannot place a disk on a full tower.");
        Console.ReadKey();
        Console.Clear();
    }
    private static void Win(int a, Stack<int> x, ref bool jatek)
    {
        if (x.Count == a && x.Peek() == 1)
        {
            Console.Clear();
            Console.Write("Congratulations, you won! \nPress enter to exit...");
            Console.ReadKey();
            jatek = false;
        }
    }
    private static bool replaceTest(Stack<int> from, Stack<int> to)
    {
        if (from.Count == 0)
        {
            return false;
        }
        if (to.Count == 0 || to.Peek() > from.Peek())
        {
            return true;
        }
        return false;
    }
    private static bool Contains(string s)
    {
        if (s.Length == 2 && "abc".Contains(s[0]) && "abc".Contains(s[1]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private static void replace(Stack<int> from, Stack<int> to)
    {
        to.Push(from.Pop());
        Console.Clear();
    }
}

