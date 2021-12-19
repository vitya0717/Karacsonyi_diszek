using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karacsonyCLI
{
    class NapiMunka
    {
        public static int KeszultDb { get; private set; }
        public int Nap { get; private set; }
        public int HarangKesz { get; private set; }
        public int HarangEladott { get; private set; }
        public int AngyalkaKesz { get; private set; }
        public int AngyalkaEladott { get; private set; }
        public int FenyofaKesz { get; private set; }
        public int FenyofaEladott { get; private set; }

        public NapiMunka(string sor)
        {
            string[] s = sor.Split(';');
            Nap = Convert.ToInt32(s[0]);
            HarangKesz = Convert.ToInt32(s[1]);
            HarangEladott = Convert.ToInt32(s[2]);
            AngyalkaKesz = Convert.ToInt32(s[3]);
            AngyalkaEladott = Convert.ToInt32(s[4]);
            FenyofaKesz = Convert.ToInt32(s[5]);
            FenyofaEladott = Convert.ToInt32(s[6]);

            NapiMunka.KeszultDb += HarangKesz + AngyalkaKesz + FenyofaKesz;
        }

        public int NapiBevetel()
        {
            return -(HarangEladott * 1000 + AngyalkaEladott * 1350 + FenyofaEladott * 1500);
        }

        public int eladottHarang() {
            int osszeg = 0;
            for (int i = 0; i < 40; i++)
            {
                osszeg += HarangEladott;
            }
            return osszeg;
        }

        public int eladottAngyal()
        {
            int osszeg = 0;
            for (int i = 0; i < 40; i++)
            {
                osszeg += AngyalkaEladott;
            }
            return osszeg;
        }

        public int eladottFenyofa()
        {
            int osszeg = 0;
            for (int i = 0; i < 40; i++)
            {
                osszeg += FenyofaEladott;
            }
            return osszeg;
        }



    }
    class Program
    {
        static void Main(string[] args)
        {

            //3. feladat: beolvasás és tárolás
            string[] sorok = File.ReadAllLines("diszek.txt");
            List<NapiMunka> munkak = new List<NapiMunka>();

            foreach (var item in sorok)
            {
                munkak.Add(new NapiMunka(item));
            }

            /*foreach (var item in munkak)
            {
                Console.WriteLine();
            }*/

            /*4.feladat: Határozza meg és írja ki a képernyőre a minta szerint, hogy összesen hány karácsonyi díszt
            készített a hölgy!*/
            Console.WriteLine("4. feladat: Összesen {0} darab dísz készült", NapiMunka.KeszultDb);
            Console.WriteLine("\n");

            /*5. feladat: Állapítsa meg, hogy volt-e olyan nap, amikor a hölgy egyetlen díszt sem készített!
            A keresést ne folytassa, ha választ meg tudja adni! A megállapítását írja a képernyőre! */
            bool vane = false;
            foreach (var item in munkak)
            {
                if(item.FenyofaKesz == 0 && item.AngyalkaKesz == 0 && item.HarangKesz == 0)
                {
                    vane = true;
                    break;
                }
            }
            Console.WriteLine(vane ? "5. feladat: Volt olyan nap, amikor egyetlen dísz sem készült!" : "5. feladat: Nem volt ilyen nap!");


            /*6. feladat: Kérjen be a felhasználótól egy 1 és 40 közé eső számot (a határokat is beleértve)! Ismételje
            addig a nap számának bekérését, míg érvényes értéket nem ad meg a felhasználó! Ha nem
            tudta megoldani az adatbevitelt, akkor a feladat további részében dolgozzon a 15-ös
            számmal! Határozza meg, és írja a képernyőre, hogy az adott nap végén melyik díszből
            hány maradt készleten! */


            //15;0;0;3;0;5;-4

            Console.WriteLine("6. feladat: ");
            Console.Write("Adja meg a keresett napot: [1 ... 40]: ");
            int szam = int.Parse(Console.ReadLine());
            
            //harangos dolog
            int harang_kesz = 0;
            int harang_eladott = 0;

            int angyal_kesz = 0;
            int angyal_eladott = 0;


            int fenyofa_kesz = 0;
            int fenyofa_eladott = 0;

            while (szam > 40 && szam >= 1 || szam == 0)
            {
                Console.Write("Adja meg a keresett napot: [1 ... 40]: ");
                szam = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < szam; i++)
            {
                harang_kesz += munkak[i].HarangKesz;
                harang_eladott += munkak[i].HarangEladott;

                angyal_kesz += munkak[i].AngyalkaKesz;
                angyal_eladott += munkak[i].AngyalkaEladott;

                fenyofa_kesz += munkak[i].FenyofaKesz;
                fenyofa_eladott += munkak[i].FenyofaEladott;


            }
            
            Console.WriteLine("\tA(z) {0} nap végén {1} harang, {2} angyalka és {3} fenyőfa maradt készleten. ", szam,
                harang_kesz+harang_eladott,
                angyal_kesz+angyal_eladott,
                fenyofa_kesz+fenyofa_eladott);


            /*7.feladat. Határozza meg, és írja a képernyőre, hogy a 40 nap alatt melyik díszből sikerült eladni
            a legtöbbet! Az eladott mennyiséget is jelenítse meg! Ha több díszből is egyformán
            a legtöbb lett eladva, akkor mindegyiket jelenítse meg! */


            int harang = 0;
            int angyal = 0;
            int fenyofa = 0;

            int max = 0;

            foreach (var item in munkak)
            {
                harang -= item.HarangEladott;
                angyal -= item.AngyalkaEladott;
                fenyofa -= item.FenyofaEladott;

                if(harang > angyal && harang > fenyofa)
                {
                    max = harang;

                } else if(angyal > harang && angyal > fenyofa) 
                {
                    max = angyal;
                } else
                {
                    max = fenyofa;
                }

            }
            Console.WriteLine(max);
            

            Console.WriteLine("7. feladat: A legtöbb eladott dísz: {0}", max);
            if(harang == max)
            {
                Console.WriteLine("\tHarang");
            }
            if (angyal == max)
            {
                Console.WriteLine("\tAngyalka");

            }
            if (fenyofa == max)
            {
                Console.WriteLine("\tFenyőfa");
            }


            /*8.feladat: A NapiMunka osztály NapiBevetel() metódusának felhasználásával válogassa ki és írja
            ki a bevetel.txt fájlba azokat a napi bevételeket, melyek elérték a 10 000 forintot!
            Minden sorban jelenjen meg a nap száma és az aznapi bevétel egymástól kettősponttal
            elválasztva. A fájl utolsó sorában jelenítse meg, hogy hány olyan nap volt, amikor a bevétel
            elérte a 10 000 forintot! „X napon volt legalább 10000 Ft a bevétel.” */

            int napok = 0;
            foreach (var item in munkak)
            {
                if(item.NapiBevetel() >= 10000)
                {
                    File.AppendAllText("bevetel.txt", item.Nap+": "+item.NapiBevetel().ToString()+"\n");
                    napok++;
                }
            }
            File.AppendAllText("bevetel.txt", napok.ToString()+ " napon volt legalább 10000 Ft a bevétel.");


            Console.ReadKey();
        }
    }
}
