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
            string[] allLines = File.ReadAllLines("inputTest.txt");
            Console.WriteLine(allLines);
        }
    }
}
