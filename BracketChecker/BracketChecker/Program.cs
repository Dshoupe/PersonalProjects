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
    }
}