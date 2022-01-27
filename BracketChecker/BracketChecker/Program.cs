using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonChecker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Read();
        }

        public static bool BracketChecker(string bracketInput)
        {
            if (string.IsNullOrWhiteSpace(bracketInput)) return true;

            var bracketStack = new Stack<char>();
            foreach (var character in bracketInput)
            {
                switch (character)
                {
                    case '{':
                        bracketStack.Push('{');
                        break;
                    case '}':
                        if (bracketStack.Count == 0) return false;
                        bracketStack.Pop();
                        break;
                }
            }

            return !bracketStack.Any();
        }

        public static long FibonacciSequence(int n)
        {
            if (n < 0) throw new ArgumentException("Parameter n cannot be lower than 0");
            if (n >= 93) throw new OverflowException("Function cannot go past 92 with long data type limitations");
            if (n == 0) return 0;
            if (n == 1) return 1;

            long first = 0;
            long second = 1;
            long sum = 1;
            var pointer = n;
            do
            {
                sum = first + second;
                first = second;
                second = sum;
                pointer--;
            } while (pointer >= 2);

            return sum;
        }
    }
}