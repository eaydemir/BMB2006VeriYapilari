using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    static void Main(string[] args)
    {

        node n01 = new node(10);

        daireListe dliste1 = new daireListe();

        for (int i = 0; i < 41; i++)
        {
            node tmp = new node(i + 1);
            dliste1.ekle(tmp);
        }

        dliste1.yaz();


        int ind = 1;
        int listesayac = dliste1.say();

        while (listesayac > 1)
        {
            var silinecekEleman = (2 * ind) + 1;

            if (silinecekEleman > listesayac)
            {
                silinecekEleman = silinecekEleman % listesayac;
                ind = silinecekEleman - 1;
            }

            dliste1.sil(silinecekEleman);

            dliste1.yaz(); //Console.Write(" " + ind + " " + silinecekEleman);

            listesayac = dliste1.say();

            Console.ReadKey();

            ind++;
        }

        dliste1.yaz();


        Console.ReadKey();
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

public class daireListe
{
    node bas;

    public daireListe()
    {
        bas = null;
    }

    public void ekle(node yeni)
    {
        if (bas != null)
        {
            //yeni.ileri = bas;
            //yeni.geri = bas.geri;
            //bas.geri.ileri = yeni;
            //bas.geri = yeni;
            //bas = yeni;

            var sonnode = bas.geri;

            sonnode.ileri = yeni;
            yeni.geri = sonnode;
            yeni.ileri = bas;
            bas.geri = yeni;

        }
        else
        {
            bas = yeni;
            yeni.ileri = yeni;
            yeni.geri = yeni;
        }

    }

    public void sil()
    {
        if (bas.ileri == bas) //1 eleman varsa
        {
            bas = null;
        }
        else
        {
            bas.geri.ileri = bas.ileri;
            bas.ileri.geri = bas.geri;
            bas = bas.ileri;
        }
    }

    public void sil(int index)
    {
        node tmp = bas;

        for (int i = 1; i < index; i++)
        {
            tmp = tmp.ileri;
        }

        //Console.WriteLine(tmp.veri);

        if (bas.ileri != bas)
        {
            var onceki = tmp.geri;
            var sonraki = tmp.ileri;

            onceki.ileri = sonraki;
            sonraki.geri = onceki;

            if (tmp == bas)
                bas = sonraki;
        }

    }

    public void yaz()
    {
        Console.WriteLine("");

        node temp = bas;

        while (temp != null)
        {
            Console.Write(temp.veri + " ");
            temp = temp.ileri;
            if (temp == bas)
                break;
        }
    }
    public int say()
    {
        node temp = bas;
        int sayac = 1;
        while (temp.ileri != bas)
        {
            sayac++;
            temp = temp.ileri;
        }

        // Console.WriteLine(sayac);

        return sayac;
    }
}
