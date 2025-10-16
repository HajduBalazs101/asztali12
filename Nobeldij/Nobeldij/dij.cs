﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobeldij
{
    class dij
    {
        public int ev{ get; set; }
        public string tipus { get; set; }
        public string keresztnev { get; set; }
        public string vezeteknev { get; set; }


        public dij(string sor)
        {
            string[] darabok = sor.Split(';');
            this.ev = Convert.ToInt32(darabok[0]);
            this.tipus = darabok[1];
            this.keresztnev = darabok[2];
            this.vezeteknev = darabok[3];
        }

        public dij(int ev, string tipus, string keresztnev, string vezeteknev)
        {
            this.ev = ev;
            this.tipus = tipus;
            this.keresztnev = keresztnev;
            this.vezeteknev = vezeteknev;
        }

        public override string ToString()
        {
            return ev + ";" + tipus + ";" + vezeteknev + ";" + keresztnev;
        }
    }
}