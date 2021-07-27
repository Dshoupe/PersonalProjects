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

        /// <summary>
        /// Indicates whether or not the incoming string is contained in brackets
        /// </summary>
        /// <param name="jsonInput">The attempted json you would like to confirm</param>
        /// <returns>Returns a boolean determining if the input string is a valid "Json" string</returns>
        public static bool JsonChecker(string jsonInput)
        {
            //Early bailouts if it detects any discrepancies
            if (string.IsNullOrWhiteSpace(jsonInput))
                return true;
            if (jsonInput.Count(x => x == '{') != jsonInput.Count(x => x == '}'))
                return false;

            //The stack holds chars and builds pairs as the foreach below goes through
            var bracketStack = new Stack<char>();
            var bracketCompleted = false;
            var bracketContinues = false;

            jsonInput
                .Where(character => character == '{' || character == '}')
                .Aggregate("", (current, character) => current + character)
                .ToList()
                .ForEach(x =>
                {
                    if (x == '{')
                    {
                        if (bracketCompleted)
                            bracketContinues = true;
                        else
                            bracketStack.Push('{');
                    }
                    else if (bracketStack.Count != 0)
                    {
                        bracketStack.Pop();
                        bracketCompleted = true;
                    }
                });

            //If the count is 0, then that means the stack was executed to completion and all pairs were identified
            return bracketStack.Count == 0 && !bracketContinues;
        }
    }
}