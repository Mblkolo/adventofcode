using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Hard
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("input.txt");

            int niceCount = 0;
            foreach (var l in allLines)
            {
                bool isRight = false;
                for (int i = 0; i < l.Length - 3; ++i )
                {
                    for (int t = i + 2; t < l.Length - 1; ++t )
                        if (l[i] == l[t] && l[i + 1] == l[t + 1])
                            isRight = true;
                }

                if (!isRight)
                    continue;


                isRight = false;
                for (int i = 0; i < l.Length - 2; ++i)
                {
                    if (l[i] == l[i + 2])
                        isRight = true;
                }

                if (!isRight)
                    continue;

                niceCount++;
            }

            Console.WriteLine(niceCount);
            Console.Read();

        }
    }
}
