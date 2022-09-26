﻿
feladat f = new feladat();

class feladat
{
    List<adatok> arvaltozas = new List<adatok>();
    public feladat()
    {
        f2();
        f3();
        f4();
    }
    void f4()
    {
        int minK = arvaltozas[0].kulonbseg();
        for (int i = 0; i < arvaltozas.Count; i++)
        {
            if (minK > arvaltozas[i].kulonbseg())
            {
                minK=arvaltozas[i].kulonbseg();
            }
        }

        Console.WriteLine("4. feladat: A legkisebb különbség: {0}",minK);
    }
    void f3()
    {
        Console.WriteLine("3. feladat: Változások száma {0}",arvaltozas.Count);
    }

    void f2()
    {
        string[] sorok = File.ReadAllLines("uzemanyag.txt");
        for (int i = 0; i < sorok.Length; i++)
        {
            arvaltozas.Add(new adatok(sorok[i]));
        }
    }
}



class adatok
{
    public string datum;
    public int benzin, gazolaj;

    public adatok(string sor)
    {
        string[] vag=sor.Split(';');
        datum=vag[0];
        benzin= Convert.ToInt32(vag[1]);
        gazolaj= Convert.ToInt32(vag[2]);
    }


    public int kulonbseg()
    {
        return Math.Abs(benzin - gazolaj);
    }

}