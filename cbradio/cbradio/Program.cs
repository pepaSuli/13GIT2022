using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbradio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            feladat f = new feladat();
        }
    }

    class feladat
    {
        List<adatok> adasok = new List<adatok>();
        public feladat()
        {
            f2();
            f3();
            f4();
        }
        void f4()
        {
            for (int i = 0; i < adasok.Count; i++)
            {
                if (adasok[i].adasDb==4)
                {
                    Console.WriteLine("4. feladat: Volt 4 adás");
                    break;
                }
            }

        }
        void f2()
        {
            string[] sorok = File.ReadAllLines("cb.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                adasok.Add(new adatok(sorok[i]));
            }

        }
        void f3()
        {
            Console.WriteLine("3. feladat: {0}",adasok.Count);
        }
    }


    class adatok
    {
        public int ora, perc, adasDb;
        public string nev;
        public adatok(string sor)
        {
            string[] vag = sor.Split(';');
            ora = int.Parse(vag[0]);
            perc = Convert.ToInt32(vag[1]);
            adasDb=Convert.ToInt32(vag[2]);
            nev= vag[3];
        }
    }
}
