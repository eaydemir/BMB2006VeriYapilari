using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace BagliListe
{

    public class Program
    {
        public cbListe liste;

        static void Main(string[] args)
        {
            Program app = new Program();
            app.KomutIsle();
        }

        public Program()
        {
            liste = new cbListe();
        }

        public void KomutIsle()
        {
            bool exit = false;

            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\r\ncbliste>");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string komut = Console.ReadLine()?.ToLower();
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine();

                if (komut == "quit")
                {
                    exit = true;
                }
                else if (komut == "clear")
                {
                    Console.Clear();
                }
                else if (komut.StartsWith("sonaekle"))
                {
                    #region sonaekle

                    var cmds = komut.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (cmds != null && cmds.Length > 1)
                    {
                        var cmd = cmds[1];
                        var cmdint = 0;
                        if (int.TryParse(cmd, out cmdint))
                        {
                            liste.sonaEkle(new node(cmdint));
                            Console.WriteLine("listeye eleman eklendi");
                        }
                        else
                        {
                            Console.WriteLine("eksik parametre, kullanım: sonaekle 20 ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("eksik parametre, kullanım: sonaekle 20 ");
                    }
                    #endregion
                }
                else if (komut.StartsWith("basaekle"))
                {
                    #region sonaekle

                    var cmds = komut.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (cmds != null && cmds.Length > 1)
                    {
                        var cmd = cmds[1];
                        var cmdint = 0;
                        if (int.TryParse(cmd, out cmdint))
                        {
                            liste.basaEkle(new node(cmdint));
                            Console.WriteLine("listeye eleman eklendi");
                        }
                        else
                        {
                            Console.WriteLine("eksik parametre, kullanım: basaekle 20 ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("eksik parametre, kullanım: basaekle 20 ");
                    }
                    #endregion
                }
                else if (komut == "bastansil")
                {
                    liste.bastanSil();
                }
                else if (komut == "sondansil")
                {
                    liste.sondanSil();
                }
                else if (komut == "yaz")
                {
                    liste.yaz();
                }
                else
                {
                    Console.WriteLine("komutlar:");
                    Console.WriteLine("quit");
                    Console.WriteLine("clear");
                    Console.WriteLine("sonaekle <deger>");
                    Console.WriteLine("basaekle <deger>");
                    Console.WriteLine("bastansil");
                    Console.WriteLine("sondansil");
                    Console.WriteLine("yaz");
                }

                Console.Write("\r\n");
            }
        }
    }

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

}