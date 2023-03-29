using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class node
    {
        public int veri;
        public node ileri;
        public node geri;
        public node(int veri)
        {
            this.veri = veri;
            ileri = null;
            geri = null;
        }
    }
    public class cbListe
    {
        public node bas;
        public node son;

        public cbListe()
        {
            bas = null;
            son = null;
        }

        public void basaEkle(node yeni)
        {
            if (son == null)
                son = yeni;
            else
                bas.geri = yeni;
            yeni.ileri = bas;
            yeni.geri = null;
            bas = yeni;
        }
        public void sonaEkle(node yeni)
        {
            if (bas == null)
                bas = yeni;
            else
                son.ileri = yeni;
            yeni.geri = son;
            son = yeni;
        }
        public void ortayaEkle(node yeni)
        {
            int sayac = say() / 2;
            node temp = bas;
            for (int i = 0; i < sayac; i++)
                temp = temp.ileri;
            yeni.ileri = temp.ileri;
            temp.ileri.geri = yeni;
            yeni.geri = temp;
            temp.ileri = yeni;
        }
        public void ortayaEkle2(node yeni, node once)
        {
            yeni.ileri = once.ileri;
            once.ileri.geri = yeni;
            yeni.geri = once;
            once.ileri = yeni;
        }

        public int getir(int index)
        {
            node temp = bas;
            int sayac = 0;

            while (temp != null)
            {
                if (sayac == index)
                {
                    return temp.veri;
                }

                sayac++;
                temp = temp.ileri;
            }

            return 0;
        }

        public void bastanSil()
        {
            bas = bas.ileri;
            if (bas == null)
                son = null;
            else
                bas.geri = null;
        }
        public void sondanSil()
        {
            son = son.geri;
            if (son == null)
                bas = null;
            else
                son.ileri = null;
        }
        public void ortayaSil()
        {
            int sayac = say() / 2;
            node temp = bas;
            for (int i = 0; i < sayac; i++)
                temp = temp.ileri;
            temp.ileri.geri = temp.geri;
            temp.geri.ileri = temp.ileri;
        }

        public void ortadanSil2(node d)
        {
            d.ileri.geri = d.geri;
            d.geri.ileri = d.ileri;
        }

        public int say()
        {
            node temp = bas;
            int sayac = 0;
            while (temp != null)
            {
                sayac++;
                temp = temp.ileri;
            }
            return sayac;
        }
        public void yaz()
        {
            node temp = bas;
            while (temp != null)
            {
                Console.Write(temp.veri + " - ");
                temp = temp.ileri;
            }
        }
    }



    internal class Program
    {
        public static void Main(string[] args)
        {
            cbListe liste1 = new cbListe();

            for (int i = 0; i < 22; i++)
            {
                node tmp = new node(i * 3 + 1);
                liste1.sonaEkle(tmp);
            }

            liste1.yaz();

            var deger = BinarySearch(liste1, 37);

            Console.WriteLine("\n\n");

            Console.WriteLine(deger);

            Console.WriteLine("\n");

            Console.ReadKey();
        }

        public static int BinarySearch(cbListe liste, int key)
        {
            int minNum = 0;
            int maxNum = liste.say() - 1;

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (key == liste.getir(mid))
                {
                    return ++mid;
                }
                else if (key < liste.getir(mid))
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            return -1;
        }
    }
}