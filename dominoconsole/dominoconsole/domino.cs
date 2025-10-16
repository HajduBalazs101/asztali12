using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominoconsole
{
    public class domino
    {
        public int left { get; set; }
        public int right { get; set; }

        public domino(string sor)
        {
            string[] darabok = sor.Split(' ');
            this.left = Convert.ToInt32(darabok[0]);
            this.right = Convert.ToInt32(darabok[1]);
        }

        public domino(int left, int right)
        {
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return this.left + " " + this.right;
        }
    }
}
