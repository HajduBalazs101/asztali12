using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpfdomino
{
    public class Domino
    {
        public int bal { get; set; }
        public int jobb { get; set; }

        public Domino(string sor)
        {
            string[] darabok = sor.Split(' ');
            this.bal = Convert.ToInt32(darabok[0]);
            this.jobb = Convert.ToInt32(darabok[1]);
        }

        public Domino(int bal, int jobb)
        {
            this.bal = bal;
            this.jobb = jobb;
        }

        public override string ToString()
        {
            return this.bal + " " + this.jobb;
        }

    }
}
