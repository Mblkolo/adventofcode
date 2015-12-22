using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22
{
    class Program
    {
        enum Spell {
            MagicMissile,
            Drain,
            Shield,
            Poison,
            Recharge
        }

        enum SimulateResult
        {
            None,
            Win,
            Lose,
        }

        static void Main(string[] args)
        {
            var allSpell = new[]{Spell.Drain, Spell.MagicMissile, Spell.Poison, Spell.Recharge, Spell.Shield};

            Stack<Spell[]> front = new Stack<Spell[]>();
            foreach (var spell in allSpell)
                front.Push(new[] { spell });

            int min = int.MaxValue;
            while(front.Count > 0)
            {
                var candidat = front.Pop();
                var result = Sumulate(candidat);

                if(result == SimulateResult.Win)
                {
                    var cost = GetCost(candidat);
                    if (min < cost)
                        min = cost;
                }

                if(result == SimulateResult.Lose)
                {
                    foreach(var spell in allSpell)
                        front.Push(candidat.Concat(new[] { spell }).ToArray());
                }

            }

        }

        private static int GetCost(Spell[] candidat)
        {
            throw new NotImplementedException();
        }


        private static SimulateResult Sumulate(Spell[] spell)
        {
            throw new NotImplementedException();
        }



        const int mDamage = 8;
        //static void MagicMissile(int pHeals, int pShield, int pMana, int mHeals)
        //{
        //    if (pMana <= 53)
        //        return false;

        //    mHeals -= 4;
        //    if (mHeals <= 0)
        //        return true;


        //    int damage = mDamage - pShield;
        //    if(damage >= 0)
        //        damage = 1;

        //    pHeals -= damage;
        //    if (pHeals <= 0)
        //        return false;

        //}
    }
}
