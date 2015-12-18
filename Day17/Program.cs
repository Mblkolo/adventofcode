using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] bottles = new[] {
                33,
                14,
                18,
                20,
                45,
                35,
                16,
                35,
                1 ,
                13,
                18,
                13,
                50,
                44,
                48,
                6 ,
                24,
                41,
                30,
                42
            };
            var limit = 150;

            Stopwatch wath1 = new Stopwatch();
            wath1.Start();
            var o1 = Search(bottles, 0, 0, limit, 0);
            wath1.Stop();


            Stopwatch wath2 = new Stopwatch();
            wath2.Start();

            int o2 = 0;
            int combination = (1 << bottles.Length);
            for(int i=0; i < combination; ++i)
            {
                int total = 0;
                for(int t=0; t < bottles.Length; t++)
                {
                    if ((i & (1 << t)) != 0)
                        total += bottles[t];
                }

                if (total == limit)
                    ++o2;
            }
            wath2.Stop();


        }

        static int[] otv = new int[200];

        static int Search(int[] bottles, int index, int total, int limit, int steps)
        {
            if (index == bottles.Length)
                return 0;


            int count = 0;
            if(total + bottles[index] >= limit)
            {
                if (total + bottles[index] == limit)
                {
                    count++;
                    otv[steps]++;
                }
            }
            else
                count += Search(bottles, index + 1, total + bottles[index], limit, steps+1);

            count += Search(bottles, index + 1, total, limit, steps);

            return count;
        }
    }


}
