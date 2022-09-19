﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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
        List<adatok> adatokList=new List<adatok>();

        public feladat()
        {
            f1();
            f2();
            f3();
            f4();
            f5();
            f6();
        }
        public void f6()
        {
            int index = 0;
            for (int i = 0; i < adatokList.Count; i++)
            {
                if (!adatokList[i].ferfi)
                {
                    if (adatokList[index].osszIdo() > adatokList[i].osszIdo())
                    {
                        index = i;
                    }
                }

            }

            Console.WriteLine("6.feladat: A legjobb időt {0} érte el", adatokList[index].nev);
        }

        void f5()
        {
            Console.Write("5. feladat: Kérek egy kategóriát: ");
            string kat = Console.ReadLine();
            string rajtszamok = "";
            for (int i = 0; i < adatokList.Count; i++)
            {
                if(adatokList[i].kategoria == kat)
                {
                    rajtszamok += adatokList[i].rajtszam + " ";
                }
            }
        }
        void f4()
        {
            double ossz = 0;
            foreach (var item in adatokList)
            {
                ossz += 2014-item.szuldatum;
            }
            Console.WriteLine("4. feladat: Átlagéletkor: {0:0.0} év.",ossz/adatokList.Count);
        }
        void f3()
        {
            int db = 0;
            foreach(adatok item in adatokList)
            {
                if(item.kategoria=="elit junior")
                {
                    db++;
                }
            }

            Console.WriteLine("3. feladat: Versenyők száma az \"elit junior\" kategóriában: {0} fő",db);
        }
        void f1()
        {
            string[] sorok=File.ReadAllLines("Eredmenyek.txt", Encoding.Default);
            for (int i = 0; i < sorok.Length; i++)
            {
                adatokList.Add(new adatok(sorok[i]));
            }
        }
        void f2()
        {
            Console.WriteLine("2.feladat: A versenyt {0} versenyző fejezte be.",adatokList.Count);
        }
    }

    class adatok
    {
        public string nev;
        public int szuldatum;
        public int rajtszam;
        public bool ferfi;
        public string kategoria;
        public string uszas, depo1, kerekpar, depo2, futas;
        public adatok(string sor)
        {
            //Ábrahám Richárd;1998;159;f;16-17;00:24:03;00:01:54;00:45:15;00:01:15;00:25:15
            string[] vag = sor.Split(';');
            nev = vag[0];
            szuldatum = Convert.ToInt32(vag[1]);
            rajtszam = Convert.ToInt32(vag[2]);
            ferfi = vag[3] == "f";
            kategoria = vag[4];
            
            uszas = vag[5];
            depo1 = vag[6];
            kerekpar = vag[7];
            depo2 = vag[8];
            futas = vag[9];
        }

        public int osszIdo()
        {
            return mp(uszas) + mp(depo1) + mp(kerekpar) + mp(depo2) + mp(futas);
        }

        int mp(string ido)
        {

            string[] vag = ido.Split(':');
        
            return Convert.ToInt32(vag[0])*60*60 + Convert.ToInt32(vag[1]) * 60+ Convert.ToInt32(vag[2]);
        }
    }

}
