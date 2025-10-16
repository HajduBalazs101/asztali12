using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesztelesdolgozat
{
    public class Program
    {
        public static int Osszegzes(int[] tomb)
        {
            int osszeg = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                osszeg += tomb[i];
            }
            return osszeg;
        }
        public static double Atlagx2(int[] tomb)
        {
            return ((double)Osszegzes(tomb) / tomb.Length)*2;
        }
        public static int NegativSzamlalas(int[] tomb)
        {
            int db = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] < 0)
                {
                    db++;
                }
            }
            return db;
        }
        public static bool vane4gyeloszthato(int[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 4 == 0)
                {
                    return true;
                }
            }
            return false;


        }
        public static List<int> hetes(int[] tomb)
        {
            List<int> hetesek = new List<int>();
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 7 == 0)
                {
                    hetesek.Add(tomb[i]);
                }
            }
            return hetesek;
        }

        public static int Maxertek(int[] tomb)
        {
            int max = tomb[0];
            for (int i = 1; i < tomb.Length; i++)
            {
                if (tomb[i] > max)
                {
                    max = tomb[i];
                }
            }
            return max;
        }


        public static void Main(string[] args)
        {
            int[] tomb = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rnd.Next(-10, 90);
            }

            //Átlag szorozva 2-vel
            Console.WriteLine("Átlag*2: " + Atlagx2(tomb));
            //Negatív számok száma
            Console.WriteLine("Negatív számok száma: " + NegativSzamlalas(tomb));
            //4-gyel osztható számok száma
            Console.WriteLine("Van-e 4-gyel osztható szám? " + vane4gyeloszthato(tomb));
            //7-tel osztható számok más adatstruktúrában
            Console.WriteLine($"7-tel osztható számok: " + String.Join(",", hetes(tomb)));
        }
    }
}
