namespace RPN_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Give me an infix expression: ");
            string input = Console.ReadLine();

            var rpn = new RPN(input);
            Console.WriteLine($"\nRPN form: {rpn.rpnString} \nValue: {rpn.value}");

            Console.ReadKey();
        }
    }
}
