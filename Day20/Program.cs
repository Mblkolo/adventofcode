using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 3400000;

            int[] g = new int[10000000];


            for(int i=1; i< 10000000; ++i)
            {
                for (int t = i; t < 10000000; t += i)
                    g[t] += i;
            }


            int max = 0;
            for (int i = 0; i < 10000000; ++i)
            {
                int count = g[i];
                if (count > max)
                {
                    Console.WriteLine("" + i + " " + count);
                    max = count;
                }

                if(count >= total)
                {
                    Console.WriteLine("" + i + " " + count);
                    break;
                }
            }



            Console.Read();
        }
    }
}
