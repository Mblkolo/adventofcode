using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new[] {
                Tuple.Create("Al", "ThF"),
                Tuple.Create("Al", "ThRnFAr"),
                Tuple.Create("B", "BCa"),
                Tuple.Create("B", "TiB"),
                Tuple.Create("B", "TiRnFAr"),
                Tuple.Create("Ca", "CaCa"),
                Tuple.Create("Ca", "PB"),
                Tuple.Create("Ca", "PRnFAr"),
                Tuple.Create("Ca", "SiRnFYFAr"),
                Tuple.Create("Ca", "SiRnMgAr"),
                Tuple.Create("Ca", "SiTh"),
                Tuple.Create("F", "CaF"),
                Tuple.Create("F", "PMg"),
                Tuple.Create("F", "SiAl"),
                Tuple.Create("H", "CRnAlAr"),
                Tuple.Create("H", "CRnFYFYFAr"),
                Tuple.Create("H", "CRnFYMgAr"),
                Tuple.Create("H", "CRnMgYFAr"),
                Tuple.Create("H", "HCa"),
                Tuple.Create("H", "NRnFYFAr"),
                Tuple.Create("H", "NRnMgAr"),
                Tuple.Create("H", "NTh"),
                Tuple.Create("H", "OB"),
                Tuple.Create("H", "ORnFAr"),
                Tuple.Create("Mg", "BF"),
                Tuple.Create("Mg", "TiMg"),
                Tuple.Create("N", "CRnFAr"),
                Tuple.Create("N", "HSi"),
                Tuple.Create("O", "CRnFYFAr"),
                Tuple.Create("O", "CRnMgAr"),
                Tuple.Create("O", "HP"),
                Tuple.Create("O", "NRnFAr"),
                Tuple.Create("O", "OTi"),
                Tuple.Create("P", "CaP"),
                Tuple.Create("P", "PTi"),
                Tuple.Create("P", "SiRnFAr"),
                Tuple.Create("Si", "CaSi"),
                Tuple.Create("Th", "ThCa"),
                Tuple.Create("Ti", "BP"),
                Tuple.Create("Ti", "TiTi")
            };

            string bel = "ZZZCRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaFZZZ";

            var res = new List<string>();
            foreach(var d in data)
            {
                res.AddRange(Replase(bel, d.Item1, d.Item2));
            }

            Console.WriteLine(res.Distinct().Count());
        }

        static string[] Replase(string bel, string templ, string repl)
        {
            if (templ.Length != 1 && templ.Length != 2)
                throw new Exception();

            var res = new List<string>();
            for(int i=0; i<bel.Length; ++i)
            {
                bool isRight = false;
                if (templ.Length == 2 && bel[i] == templ[0] && bel[i + 1] == templ[1] && Char.IsUpper(bel[i + 2]))
                    isRight = true;

                if (templ.Length == 1 && bel[i] == templ[0] && Char.IsUpper(bel[i + 1]))
                    isRight = true;

                if (!isRight)
                    continue;

                res.Add(bel.Substring(0, i) + repl + bel.Substring(i + templ.Length));
            }

            return res.ToArray();
        }
    }
}
