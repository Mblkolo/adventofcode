using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19Hard
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new[] {
                Tuple.Create("1", "2F"),
                Tuple.Create("1", "23F7"),
                Tuple.Create("B", "B5"),
                Tuple.Create("B", "4B"),
                Tuple.Create("B", "43F7"),
                Tuple.Create("5", "55"),
                Tuple.Create("5", "PB"),
                Tuple.Create("5", "P3F7"),
                Tuple.Create("5", "83FYF7"),
                Tuple.Create("5", "8367"),
                Tuple.Create("5", "82"),
                Tuple.Create("F", "5F"),
                Tuple.Create("F", "P6"),
                Tuple.Create("F", "81"),
                Tuple.Create("H", "C317"),
                Tuple.Create("H", "C3FYFYF7"),
                Tuple.Create("H", "C3FY67"),
                Tuple.Create("H", "C36YF7"),
                Tuple.Create("H", "H5"),
                Tuple.Create("H", "N3FYF7"),
                Tuple.Create("H", "N367"),
                Tuple.Create("H", "N2"),
                Tuple.Create("H", "OB"),
                Tuple.Create("H", "O3F7"),
                Tuple.Create("6", "BF"),
                Tuple.Create("6", "46"),
                Tuple.Create("N", "C3F7"),
                Tuple.Create("N", "H8"),
                Tuple.Create("O", "C3FYF7"),
                Tuple.Create("O", "C367"),
                Tuple.Create("O", "HP"),
                Tuple.Create("O", "N3F7"),
                Tuple.Create("O", "O4"),
                Tuple.Create("P", "5P"),
                Tuple.Create("P", "P4"),
                Tuple.Create("P", "83F7"),
                Tuple.Create("8", "58"),
                Tuple.Create("2", "25"),
                Tuple.Create("4", "BP"),
                Tuple.Create("4", "44"),
                Tuple.Create("e", "HF"),
                Tuple.Create("e", "N1"),
                Tuple.Create("e", "O6"),
            };

            string seed = "C355583BP467838367835F744B82FY5F755825PB828255P43PB823F77558258283675P4BP3F782583F7B5835P3F7P6Y5F75P444BPB825P4BPB83F7BPB835F7BP383F7383BF75F7555828255PBP443F75P4B817PB555558367582F725825835FY583FYF7F7583FYF7583BP6782P3F7583F74383FYF7583BF7583467825825F7P3F783F74444B558355FYF7825P4BP4B58283675F";
            string bel = "e";


            var front = new Stack<string>();
            front.Push(seed);

            HashSet<string> processed = new HashSet<string>();

            for(int i=0; front.Count > 0; ++i)
            {
                //var newFront = new List<string>();

                var candidat = front.Pop();
                var res = new List<string>();
                foreach (var d in data)
                {
                    //res.AddRange(Replase(candidat, d.Item2, d.Item1));
                    var r = candidat.Replace(d.Item2, d.Item1);

                    if (r != candidat && processed.Add(r))
                        res.Add(r);
                }

                if(res.Contains(bel))
                {
                    Console.WriteLine(i);
                    Console.Read();
                    return;
                }


                foreach( var f in res)
                    front.Push(f);

                if(i%10000 == 0)
                    Console.WriteLine("step " + i + " front " + front.Count);
            }

            Console.Read();
        }

        static string[] Replase(string bel, string templ, string repl)
        {
            var res = new List<string>();
            for(int i=0; i<bel.Length; ++i)
            {
                if (bel[i] != templ[0])
                    continue;

                bool isRight = true;
                for (int t = 0; t < templ.Length; t++ )
                    if (bel[i + t] != templ[t])
                    {
                        isRight = false;
                        break;
                    }

                if (!isRight)
                    continue;
                
                res.Add(bel.Substring(0, i) + repl + bel.Substring(i + templ.Length));
            }

            return res.ToArray();
        }
    }
}
