using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("input.txt");

            int result = 0;
            foreach (var line in allLines)
            {
                var sizes = line.Split('x').Select(x => int.Parse(x)).ToArray();
                var a = sizes[0] * sizes[1];
                var b = sizes[1] * sizes[2];
                var c = sizes[2] * sizes[0];

                var min = a < b ? a : b;
                min = min < c ? min : c;

                var size = min + 2 * a + 2 * b + 2 * c;
                result += size;
            }

            Console.WriteLine(result);

            Console.Read();
        }
    }
}
