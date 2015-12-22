using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    class Program
    {
        static void Main(string[] args)
        {
            var weapons = new[]{
                new[]{  8,     4,       0 },
                new[]{ 10,     5,       0 },
                new[]{ 25,     6,       0 },
                new[]{ 40,     7,       0 },
                new[]{ 74,     8,       0 },
            };
            var armor = new[]{
                new[]{ 13,     0,       1},
                new[]{ 31,     0,       2},
                new[]{ 53,     0,       3},
                new[]{ 75,     0,       4},
                new[]{102,     0,       5},
            };
            var rings = new[]{
                    new[]{ 25,     1,       0},
                    new[]{ 50,     2,       0},
                    new[]{100,     3,       0},
                    new[]{ 20,     0,       1},
                    new[]{ 40,     0,       2},
                    new[]{80,     0 ,      3},
                };

            int min = int.MaxValue;
            for(int w=0; w<weapons.Length; w++)
            {
                for (int a = 0; a < armor.Length; a++)
                {
                    for (int r = 0; r < rings.Length; r++)
                    {
                        if(Simulate(weapons[w][1] + armor[a][1] + rings[r][1], weapons[w][2] + armor[a][2] + rings[r][2]))
                        {
                            var cost =  weapons[w][0] + armor[a][0] + rings[r][0];
                            if(cost < min)
                                min = cost;
                        }

                        if (Simulate(weapons[w][1] + rings[r][1], weapons[w][2] + rings[r][2]))
                        {
                            var cost = weapons[w][0] + rings[r][0];
                            if (cost < min)
                                min = cost;
                        }

                        for (int r2 = 0; r2 < rings.Length; r2++)
                        {
                            if (r2 == r)
                                continue;

                            if (Simulate(weapons[w][1] + armor[a][1] + rings[r][1] + +rings[r2][1], weapons[w][2] + armor[a][2] + rings[r][2] + rings[r2][2]))
                            {
                                var cost = weapons[w][0] + armor[a][0] + rings[r][0] + rings[r2][0];
                                if (cost < min)
                                    min = cost;
                            }
                        }

                        for (int r2 = 0; r2 < rings.Length; r2++)
                        {
                            if (r2 == r)
                                continue;

                            if (Simulate(weapons[w][1] + rings[r][1] + +rings[r2][1], weapons[w][2] + rings[r][2] + rings[r2][2]))
                            {
                                var cost = weapons[w][0] + rings[r][0] + rings[r2][0];
                                if (cost < min)
                                    min = cost;
                            }
                        }
                    }

                    if (Simulate(weapons[w][1] + armor[a][1], weapons[w][2] + armor[a][2]))
                    {
                        var cost = weapons[w][0] + armor[a][0];
                        if (cost < min)
                            min = cost;
                    }
                }
            }

            Console.WriteLine(min);
            Console.Read();
        }

        static bool Simulate(int hDamage, int hArmor)
        {
            int hh = 100;
            int mh = 104;
            int mDamage = 8;
            int mArmor = 1;

            while (true)
            {
                var damage = hDamage - mArmor;
                if (damage <= 0)
                    damage = 1;

                mh -= damage;
                if (mh <= 0)
                    return true;

                damage = mDamage - hArmor;
                if (damage <= 0)
                    damage = 1;

                hh -= damage;
                if (hh <= 0)
                    return false;
            }
        }
    }
}
