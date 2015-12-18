using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Hard
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("input.txt");
            string input = allLines[0];

            var bases = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == '(')
                    bases++;

                if (input[i] == ')')
                    bases--;

                if (bases == -1)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }

            Console.Read();
        }
    }
}
