using System.ComponentModel.Design;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic Tac Toe, have fun!");
        pauseClear();
        char[] row1 = { '-', '-', '-' };
        char[] row2 = { '-', '-', '-' };
        char[] row3 = { '-', '-', '-' };
        int lepesek = 9;
        string playerChoice = "";
        int botChoice = 0;
        bool jatszik = true;
        string opciok = "123456789";

        //list to avoid the bot to choose a number that has already been chosen by the player
        List<int> choices = new List<int>();
        while (jatszik)
        {
            //displaying the board
            Rows(row1, row2, row3);
            Console.WriteLine(" ");
            Console.Write("Enter a number between 1 and 9: ");

            //invalid input filtering
            playerChoice = Console.ReadLine();
            if (!opciok.Contains(playerChoice) || playerChoice == "")
            {
                Console.Clear();
                Console.Write("Invalid input, please try again");
                pauseClear();
            }
            else if (!PlayerStep(int.Parse(playerChoice), row1, row2, row3))
            {
                positionReserved();
            }
            else
            {
                //jatekos valasztasanak elmentese a listaba
                choices.Add(int.Parse(playerChoice));

                //store bot choice in a variable and add it to the list to avoid choosing the same number again
                botChoice = botNum(choices);
                choices.Add(botChoice);
                if (lepesek >= 0)
                {
                    if (PlayerStep(int.Parse(playerChoice), row1, row2, row3))
                    {
                        if (int.Parse(playerChoice) <= 3)
                        {
                            if (row1[int.Parse(playerChoice) - 1] != 'O' && row1[int.Parse(playerChoice) - 1] != 'X')
                            {
                                row1[int.Parse(playerChoice) - 1] = 'X';
                                botStep(botChoice, row1, row2, row3);
                                lepesek--;
                                Console.Clear();
                                
                            }
                        }
                        else if (int.Parse(playerChoice) > 3 && int.Parse(playerChoice) <= 6)
                        {
                            if (row2[int.Parse(playerChoice) - 3 - 1] != 'O' && row2[int.Parse(playerChoice) - 3 - 1] != 'X')
                            {
                                row2[int.Parse(playerChoice) - 3 - 1] = 'X';
                                botStep(botChoice, row1, row2, row3);
                                lepesek--;
                                Console.Clear();
                            }
                        }
                        else if (int.Parse(playerChoice) > 6 && int.Parse(playerChoice) <= 9)
                        {
                            if (row3[int.Parse(playerChoice) - 6 - 1] != 'O' && row3[int.Parse(playerChoice) - 6 - 1] != 'X')
                            {
                                row3[int.Parse(playerChoice) - 6 - 1] = 'X';
                                botStep(botChoice, row1, row2, row3);
                                lepesek--;
                                Console.Clear();
                            }
                        }
                    }
                    else
                    {
                        positionReserved();
                    }
                }
            }
            if(CheckWin(row1, row2, row3, 'X'))
            {
                Rows(row1, row2, row3);
                Console.WriteLine(" ");
                Console.WriteLine("Congratulations, you won! Press any key to exit.");
                jatszik = false;
            }
            else if (CheckWin(row1, row2, row3, 'O'))
            {
                Rows(row1, row2, row3);
                Console.WriteLine(" ");
                Console.WriteLine("Sorry, you lost! Press any key to exit.");
                jatszik = false;
            }
            else if(lepesek == 0)
            {
                Rows(row1, row2, row3);
                Console.WriteLine(" ");
                Console.WriteLine("It's a tie! Press any key to exit.");
                jatszik = false;
            }
            else
            {
                continue;

            }

            Console.ReadKey();
        }
    }
    private static void Rows(char[] a, char[] b, char[] c)
    {
        Console.WriteLine($" {a[0]} {a[1]} {a[2]} ");
        Console.WriteLine($" {b[0]} {b[1]} {b[2]} ");
        Console.WriteLine($" {c[0]} {c[1]} {c[2]} ");
    }
    private static void pauseClear()
    {
        Console.ReadKey();
        Console.Clear();
    }
    private static bool PlayerStep(int x, char[] a, char[] b, char[] c)
    {
        if (x <= 3)
        {
            if (a[x - 1] != 'O' && a[x - 1] != 'X')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (x > 3 && x <= 6)
        {
            if (b[x - 3 - 1] != 'O' && b[x - 3 - 1] != 'X')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (x > 6 && x <= 9)
        {
            if (c[x - 6 - 1] != 'O' && c[x - 6 - 1] != 'X')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private static int botNum(List<int> x)
    {
        Random rnd = new Random();
        int szam = rnd.Next(1, 10);
        if (x.Contains(szam))
        {
            while (x.Contains(szam))
            {
                szam = rnd.Next(1, 10);
            }
        }
        return szam;
    }
    private static void botStep(int x, char[] a, char[] b, char[] c)
    {
        if (x <= 3)
        {
            a[x - 1] = 'O';
        }
        else if (x > 3 && x <= 6)
        {
            b[x - 3 - 1] = 'O';
        }
        else if (x > 6 && x <= 9)
        {
            c[x - 6 - 1] = 'O';
        }
    }
    private static void positionReserved()
    {
        Console.Clear();
        Console.Write("pozicio foglalt, probald ujra!");
        pauseClear();
    }

    private static bool CheckWin(char[] a, char[] b, char[] c, char jel)
    {
        char[,] mezo = { { a[0], a[1], a[2] }, { b[0], b[1], b[2] }, { c[0], c[1], c[2] } };

        for (int i = 0; i < 3; i++)
        {
            if (mezo[i, 0] == jel && mezo[i, 1] == jel && mezo[i, 2] == jel) return true; // sor
            if (mezo[0, i] == jel && mezo[1, i] == jel && mezo[2, i] == jel) return true; // oszlop
        }
        if (mezo[0, 0] == jel && mezo[1, 1] == jel && mezo[2, 2] == jel) return true; // átló
        if (mezo[0, 2] == jel && mezo[1, 1] == jel && mezo[2, 0] == jel) return true; // átló
        return false;
    }
}

