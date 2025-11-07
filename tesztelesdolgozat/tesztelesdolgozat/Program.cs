using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesztelesdolgozat
{
    public class Program
    {
        public static int Osszegzes(int[] tomb) //egyszerűbb legyen az átlag számítás
        {
            int osszeg = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                osszeg += tomb[i];
            }
            return osszeg;
        }
        public static double Atlagx3(int[] tomb)
        {
            return ((double)Osszegzes(tomb) / tomb.Length)*3;
        }
        public static int NagyobbmintszazSzamlalas(int[] tomb)
        {
            int db = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] < 100)
                {
                    db++;
                }
            }
            return db;
        }
        public static bool vane5teloszthatopoz(int[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 5 == 0 || tomb[i] > 0)
                {
                    return true;
                }
            }
            return false;


        }
        public static List<int> tizes(int[] tomb)
        {
            List<int> tizesek = new List<int>();
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 10 == 0)
                {
                    tizesek.Add(tomb[i]);
                }
            }
            return tizesek;
        }

        public static int Maxertek(int[] tomb)
        {
            int min = tomb[0];
            for (int i = 1; i < tomb.Length; i++)
            {
                if (tomb[i] < min)
                {
                    min = tomb[i];
                }
            }
            return min;
        }


        public static void Main(string[] args)
        {
            int[] tomb = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rnd.Next(-50, 150);
            }

            //Random számok kiíratása
            Console.WriteLine("Tömb elemei: " + String.Join(",", tomb));
            //Átlag szorozva 3-al
            Console.WriteLine("Átlag*3: " + Atlagx3(tomb));
            //Száznál nagyobb számok száma
            Console.WriteLine("100-nál nagyobb számok száma: " + NagyobbmintszazSzamlalas(tomb));
            //5-tel osztható pozitív számok száma
            Console.WriteLine("Van-e 5-tel osztható pozitív szám? " + vane5teloszthatopoz(tomb));
            //10-tel osztható számok más adatstruktúrában
            Console.WriteLine($"10-el osztható számok: " + String.Join(",", tizes(tomb)));
        }
    }
}
