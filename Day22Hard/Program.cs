using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22Hard
{
    class Program
    {
        enum Spell
        {
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
            var allSpell = new[] { Spell.Drain, Spell.MagicMissile, Spell.Poison, Spell.Recharge, Spell.Shield };
            var allCost = new Dictionary<Spell, int>{
                {Spell.MagicMissile, 53},
                {Spell.Drain, 73},
                {Spell.Shield, 113},
                {Spell.Poison, 173},
                {Spell.Recharge, 229}
            };


            Stack<Spell[]> front = new Stack<Spell[]>();
            foreach (var spell in allSpell)
                front.Push(new[] { spell });

            int min = int.MaxValue;
            while (front.Count > 0)
            {
                var candidat = front.Pop();

                var cost = GetCost(candidat, allCost);
                if (cost >= min)
                    continue;

                var result = Sumulate(candidat, allCost);


                if (result == SimulateResult.Win)
                {
                    min = cost;
                }

                if (result == SimulateResult.None)
                {
                    foreach (var spell in allSpell)
                        front.Push(candidat.Concat(new[] { spell }).ToArray());
                }
            }

            Console.WriteLine(min);
            Console.Read();

        }

        private static int GetCost(Spell[] candidat, Dictionary<Spell, int> manaCost)
        {
            return candidat.Select(x => manaCost[x]).Sum();
        }


        private static SimulateResult Sumulate(Spell[] spells, Dictionary<Spell, int> manaCost)
        {
            int mHealts = 55;
            int pHealts = 50;
            int mDamage = 8;
            int hMana = 500;

            int shieldAffect = 0;
            int poisonAffect = 0;
            int rechargeAffect = 0;

            foreach (var spell in spells)
            {
                hMana -= manaCost[spell];
                if (hMana <= 0)
                    return SimulateResult.Lose;


                //Ход игрока
                //Эффекты
                pHealts -= 1;
                if (pHealts <= 0)
                    return SimulateResult.Lose;

                if (shieldAffect > 0)
                    shieldAffect--;
                if (poisonAffect > 0)
                {
                    poisonAffect--;
                    mHealts -= 3;
                }

                if (rechargeAffect > 0)
                {
                    rechargeAffect--;
                    hMana += 101;
                }

                //Заклинание
                if (spell == Spell.MagicMissile)
                {
                    mHealts -= 4;
                }

                if (spell == Spell.Drain)
                {
                    mHealts -= 2;
                    pHealts += 2;
                }

                if (spell == Spell.Shield)
                {
                    if (shieldAffect != 0)
                        return SimulateResult.Lose;

                    shieldAffect = 6;
                }

                if (spell == Spell.Poison)
                {
                    if (poisonAffect != 0)
                        return SimulateResult.Lose;

                    poisonAffect = 6;
                }

                if (spell == Spell.Recharge)
                {
                    if (rechargeAffect != 0)
                        return SimulateResult.Lose;

                    rechargeAffect = 5;
                }

                if (mHealts <= 0)
                    return SimulateResult.Win;


                //Ход монстра, эффекты
                if (shieldAffect > 0)
                    shieldAffect--;

                if (poisonAffect > 0)
                {
                    poisonAffect--;
                    mHealts -= 3;
                }
                if (rechargeAffect > 0)
                {
                    rechargeAffect--;
                    hMana += 101;
                }

                if (mHealts <= 0)
                    return SimulateResult.Win;


                //Удар монстра
                if (shieldAffect > 0)
                    pHealts -= (mDamage - 7);
                else
                    pHealts -= mDamage;


                if (pHealts <= 0)
                    return SimulateResult.Lose;

            }

            return SimulateResult.None;
        }
    }

}
