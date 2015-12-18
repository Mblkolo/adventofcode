using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18Hard
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] lines = File.ReadAllLines("input.txt").Select(x => x.Select(y => y).ToArray()).ToArray();
            var copy = lines.Select(x => x.Select(y => y).ToArray()).ToArray();


            for (int i = 0; i < 100; ++i)
            {
                for (int y = 0; y < lines.Length; y++)
                {
                    var w = lines[y].Length;
                    var h = lines.Length;
                    for (int x = 0; x < lines[y].Length; ++x)
                    {
                        int turnOn = 0;
                        bool l = x > 0;
                        bool r = x < w - 1;
                        bool u = y > 0;
                        bool d = y < h - 1;

                        if (u && l && lines[y - 1][x - 1] == '#')
                            turnOn++;

                        if (u && r && lines[y - 1][x + 1] == '#')
                            turnOn++;

                        if (d && l && lines[y + 1][x - 1] == '#')
                            turnOn++;

                        if (d && r && lines[y + 1][x + 1] == '#')
                            turnOn++;


                        if (u && lines[y - 1][x] == '#')
                            turnOn++;

                        if (d && lines[y + 1][x] == '#')
                            turnOn++;

                        if (l && lines[y][x - 1] == '#')
                            turnOn++;

                        if (r && lines[y][x + 1] == '#')
                            turnOn++;

                        if (lines[y][x] == '#')
                            copy[y][x] = (turnOn == 2 || turnOn == 3) ? '#' : '.';
                        else
                            copy[y][x] = turnOn == 3 ? '#' : '.';

                        if ((!l && !u) || (!l && !d) || (!r && !u) || (!r && !d))
                            copy[y][x] = '#';
                    }
                }

                var t = lines;
                lines = copy;
                copy = t;
            }

            Console.WriteLine(lines.Sum(x => x.Count(y => y == '#')));
            Console.Read();
        }
    }
}
