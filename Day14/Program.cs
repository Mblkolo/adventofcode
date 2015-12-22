using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = {
                new []{19, 7,  124 },
                new []{3,15,  28  }   ,
                new []{19, 9,  164}   ,
                new []{19, 9,  158}   ,
                new []{13, 7,  82 }   ,
                new []{25, 6,  145}   ,
                new []{14, 3,  38 }   ,
                new []{3, 16,  37 }   ,
                new []{25, 6,  143}   ,
            };


            int totalTime = 2503;

            int max = 0;
            foreach (var inp in input)
            {
                int state = 0;
                int timeout = 0;
                int total = 0;
                for(int i=0; i<totalTime; i++)
                {
                    if (state == 0)
                        total += inp[0];

                    timeout++;
                    if (state == 0 && inp[1] == timeout)
                    {
                        state = 1;
                        timeout = 0;
                    }

                    if (state == 1 && inp[2] == timeout)
                    {
                        state = 0;
                        timeout = 0;
                    }
                }

                if (total > max)
                    max = total;
            }

            Console.WriteLine(max);
            Console.Read();
        }
    }
}
