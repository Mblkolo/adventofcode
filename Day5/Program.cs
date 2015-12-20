using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("input.txt");


            string vowels = "aeiou";

            int niceCount = 0;
            foreach(var l in allLines)
            {
                var count = l.Where(x => vowels.Contains(x)).Count();
                if (count < 3)
                    continue;

                bool isDouble = false;
                for(int i=0; i<l.Length-1; ++i)
                    if(l[i] == l[i+1])
                    {
                        isDouble = true;
                        break;
                    }

                if (!isDouble)
                    continue;

                if (l.Contains("ab") || l.Contains("cd") || l.Contains("pq") || l.Contains("xy"))
                    continue;

                niceCount++;
            }

            Console.WriteLine(niceCount);
            Console.Read();
            
        }
    }
}
