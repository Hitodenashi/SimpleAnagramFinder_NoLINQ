using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "listen";
            var answers = new List<string> { "enlists", "google", "inlets", "banana", "stieln", "listens" };

            var letterDict = new Dictionary<char, int>();
            foreach(var letter in input.ToCharArray())
            {
                if (letterDict.ContainsKey(letter))
                    letterDict[letter]++;
                else
                    letterDict.Add(letter, 1);
            }

            var possibleAnswers = new List<string>();
            foreach(var answer in answers)
            {
                if (answer.Length != input.Length)
                    continue;

                var isValid = false;
                foreach (var letter in letterDict)
                {
                    isValid = false;
                    if (!answer.Contains(letter.Key) || answer.GetCount(letter.Key) != letter.Value)
                        break;

                    isValid = true;
                }

                if(isValid)
                    possibleAnswers.Add(answer);
            }

            if (possibleAnswers.Count == 0)
                Console.WriteLine("No valid anagrams");
            else
            {
                foreach (var answer in possibleAnswers)
                    Console.WriteLine(answer);
            }
        }

    }
    
    static class StringExtension
    {
        public static int GetCount(this string str, char value)
        {
            var letterCount = 0;
            foreach (var letter in str.ToCharArray())
                letterCount += (letter.Equals(value)) ? 1 : 0;

            return letterCount;
        }
    }
}
