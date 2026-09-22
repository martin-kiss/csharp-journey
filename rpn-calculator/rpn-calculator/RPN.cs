using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN_calculator
{
    public class RPN
    {
        List<string> tags = new List<string>();
        List<string> output = new List<string>();

        public string rpnString
        {
            get
            {
                return string.Join("", output);
            }
        }

        public double value
        {
            get => SolvePostfix(output);

        }
        public RPN(string infix)
        {
            string digit = "";
            string operators = "+-/*()^";

            foreach (var item in infix)
            {
                if (operators.Contains(item))
                {
                    if (digit.Length > 0) tags.Add(digit);
                    digit = string.Empty;
                    tags.Add(item.ToString());
                }
                else
                {
                    digit += item;
                }
            }
            if (digit.Length > 0) tags.Add(digit);

            CreateRpn();
        }

        private void CreateRpn()
        {
            Stack<string> stack = new Stack<string>();

            foreach (var item in tags)
            {
                if (item == "(")
                {
                    stack.Push(item);
                    continue;
                }

                if (item == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        output.Add(stack.Pop());
                    }
                    stack.Pop();
                    continue;
                }

                if ("+-*/^".Contains(item))
                {
                    while (stack.Count > 0 && GetPrecedence(stack.Peek()) >= GetPrecedence(item))
                    {
                        output.Add(stack.Pop());
                    }
                    stack.Push(item);
                }
                else
                {
                    output.Add(item);
                }
            }

            while (stack.Count != 0)
            {
                output.Add(stack.Pop());
            }
        }
        private int GetPrecedence(string op)
        {
            switch (op)
            {
                case "+": return 1;
                case "-": return 1;
                case "*": return 2;
                case "/": return 2;
                case "^": return 3;
                default: return 0;
            }
        }

        private double SolvePostfix(List<string> output)
        {
            Stack<double> stack = new Stack<double>();
            double num1 = 0;
            double num2 = 0;

            foreach (var item in output)
            {
                if (!"+-*/^".Contains(item))
                {
                    stack.Push(double.Parse(item));
                }

                else
                {
                    num1 = stack.Pop();
                    num2 = stack.Pop();

                    switch (item)
                    {
                        case "+":
                            stack.Push(num2 + num1);
                            break;
                        case "-":
                            stack.Push(num2 - num1);
                            break;
                        case "*":
                            stack.Push(num2 * num1);
                            break;
                        case "/":
                            stack.Push(num2 / num1);
                            break;
                        case "^":
                            stack.Push(Math.Pow(num2, num1));
                            break;
                    }
                }
            }
            return stack.Pop();
        }
    }
}