// See https://aka.ms/new-console-template for more information

using System;

class Farma
{
    static void Main(string[] args)
    {
        Random rnd = new Random();  
        int brojZivotinja;
        Console.WriteLine("Napisite koliko zelite zivotinja na vasoj farmi");
        string val=Console.ReadLine();  
        brojZivotinja=Convert.ToInt32(val);
        List<Zivotinja> zivotinje = new List<Zivotinja>();

        for (int i = 0; i <= brojZivotinja; i++)
        {
          
            Console.WriteLine("Navedite ime zivotinje i njezinu pasminu");
            int razinaSrece;
            string ime, pasmina;
            ime= Console.ReadLine();
            pasmina=Console.ReadLine(); 
            Console.WriteLine("Za dodavanje krave upisite broj 1, za konja 2");

            string izbor = Console.ReadLine();
            if (izbor is "1")
            {
                Krava krava = new Krava(ime,pasmina,razinaSrece=Convert.ToInt32(rnd.Next(10)));
                zivotinje.Add(krava);
            }
            else
            {
                Konj konj = new Konj(ime,pasmina, razinaSrece = Convert.ToInt32(rnd.Next(10)));
                zivotinje.Add(konj);
            }
             
        }

        int sumaSrece = 0;
        foreach (Zivotinja zivotinja in zivotinje)
        {

            sumaSrece += zivotinja.stupanjSrece;
            Console.Write( zivotinja + " : " + zivotinja.ime + ", pasmina: " + zivotinja.pasmina + ", razina srece:" + zivotinja.stupanjSrece + ", glasanje: ");
            zivotinja.Glasanje();
    
        }
        float prosjekSrece = sumaSrece / zivotinje.Count;
        if (prosjekSrece < 5)
        {
            Console.WriteLine("Vas prosjek srece je: " + prosjekSrece + "\n. Vase zivotinje su nesretne i nezbrinute, morate se vise potruditi");
        }
        else if (prosjekSrece > 5 && prosjekSrece < 8)
        {
            Console.WriteLine("Vas prosjek srece je: " + prosjekSrece + "\n Vase zivotinje imaju zbrinute osnovne potrebe, no treba im zabave");
        }
        else
        {
            Console.WriteLine("Vas prosjek srece je: " + prosjekSrece + "\n.Bravo!Vase zivotinje su vrlo sretne te uzivaju :)");
            
        }

        

    }


}
