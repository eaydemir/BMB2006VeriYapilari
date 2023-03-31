// .Net 7 ile yazılmıştır.

//ekran çıktısı --->>> en altta bağlı liste ile kuyruk kodları vardır.

//rimedya
//polidrom değil

//7849487
//7849487
//polidrom

// öncelikli liste
//p(26) -> w(25)->E(23)->q(22)->R(21)->z(12)->m(11)->

namespace Kuyruk;

public class Program
{
    static void Main(string[] args)
    {
        #region kuyruk1

        pNode n1 = new pNode('a');
        pNode n2 = new pNode('y');
        pNode n3 = new pNode('d');
        pNode n4 = new pNode('e');
        pNode n5 = new pNode('m');
        pNode n6 = new pNode('i');
        pNode n7 = new pNode('r');

        var kuyruk1 = new pKuyruk();

        kuyruk1.enqueue(n1);
        kuyruk1.enqueue(n2);
        kuyruk1.enqueue(n3);
        kuyruk1.enqueue(n4);
        kuyruk1.enqueue(n5);
        kuyruk1.enqueue(n6);
        kuyruk1.enqueue(n7);

        kuyruk1.polidrommu();

        #endregion

        Console.WriteLine("");

        #region kuyruk2

        pNode n11 = new pNode('7');
        pNode n12 = new pNode('8');
        pNode n13 = new pNode('4');
        pNode n14 = new pNode('9');
        pNode n15 = new pNode('4');
        pNode n16 = new pNode('8');
        pNode n17 = new pNode('7');

        var kuyruk2 = new pKuyruk();

        kuyruk2.enqueue(n11);
        kuyruk2.enqueue(n12);
        kuyruk2.enqueue(n13);
        kuyruk2.enqueue(n14);
        kuyruk2.enqueue(n15);
        kuyruk2.enqueue(n16);
        kuyruk2.enqueue(n17);

        kuyruk2.polidrommu();
        #endregion

        Console.WriteLine("");

        #region Oncelikli Kuyruk

        oNode on1 = new oNode("q", 22);
        oNode on2 = new oNode("R", 21);
        oNode on3 = new oNode("m", 11);
        oNode on4 = new oNode("E", 23);
        oNode on5 = new oNode("z", 12);
        oNode on6 = new oNode("p", 26);
        oNode on7 = new oNode("w", 25);

        var olist = new oKuyruk();

        olist.enqueue(on1);
        olist.enqueue(on2);
        olist.enqueue(on3);
        olist.enqueue(on4);
        olist.enqueue(on5);
        olist.enqueue(on6);
        olist.enqueue(on7);

        olist.yaz();

        #endregion

        Console.ReadKey();

    }
}

#region Polidrom Kuyruk

//polidrom kuyruk
public class pNode
{
    public char veri;
    public pNode ileri;

    public pNode(char veri)
    {
        this.veri = veri;
        ileri = null;
    }
}


public class pKuyruk
{
    public pNode bas;
    public pNode son;

    public pKuyruk()
    {
        bas = null;
        son = null;
    }

    public void enqueue(pNode yeni)
    {
        if (bas == null)
            bas = yeni;
        else
            son.ileri = yeni;

        son = yeni;
    }

    public pNode dequeue()
    {
        var tmp = bas;

        bas = bas.ileri;

        if (bas == null)
            son = null;


        return tmp;
    }

    public int say()
    {
        pNode temp = bas;
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
        pNode temp = bas;
        while (temp != null)
        {
            Console.Write(temp.veri + " -> ");
            temp = temp.ileri;
        }
        Console.WriteLine("");
    }

    public void polidrommu()
    {
        var bs = bastansonaoku();
        var sb = sondanbasaoku();

        Console.WriteLine(bs);
        Console.WriteLine(sb);

        Console.WriteLine(bs == sb ? "polidrom" : "polidrom değil");
    }

    public string bastansonaoku()
    {
        int elemansayisi = say();
        int i = 0;

        char[] ret = new char[elemansayisi];

        pNode temp = bas;
        while (temp != null)
        {
            ret[i] += temp.veri;
            temp = temp.ileri;
            i++;
        }

        return new string(ret);
    }

    public string sondanbasaoku()
    {
        int elemansayisi = say();
        int i = elemansayisi - 1;

        char[] ret = new char[elemansayisi];


        pNode temp = bas;
        while (temp != null)
        {
            ret[i] += temp.veri;
            temp = temp.ileri;
            i--;
        }

        return new string(ret);
    }
}
#endregion

#region Oncelikli Kuyruk

public class oNode
{
    public string veri;
    public int oncelik;

    public oNode ileri;

    public oNode(string veri, int oncelik)
    {
        this.oncelik = oncelik;
        this.veri = veri;
        ileri = null;
    }
}

//oncelikli kuyruk
public class oKuyruk
{
    public oNode bas;

    public oKuyruk()
    {
        bas = null;
    }

    public void enqueue(oNode yeni)
    {
        if (bas == null)
        {
            bas = yeni;
        }
        else
        {
            if (bas.oncelik > yeni.oncelik)
            {
                sonunaEkle(bas, yeni);
            }
            else
            {
                yeni.ileri = bas;
                bas = yeni;
            }
        }
    }

    private void sonunaEkle(oNode referans, oNode yeni)
    {
        if (referans.ileri == null)
        {
            referans.ileri = yeni;
        }
        else if (referans.ileri.oncelik > yeni.oncelik)
        {
            sonunaEkle(referans.ileri, yeni);
        }
        else
        {
            var tmp = referans.ileri;
            yeni.ileri = tmp;
            referans.ileri = yeni;
        }
    }

    public oNode dequeue()
    {
        var tmp = bas;

        if (tmp.ileri != null)
            bas = bas.ileri;

        return tmp;
    }

    public int say()
    {
        oNode temp = bas;
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
        oNode temp = bas;
        while (temp != null)
        {
            Console.Write(temp.veri + $"({temp.oncelik}) -> ");
            temp = temp.ileri;
        }
        Console.WriteLine("");
    }



}
#endregion

#region BaseKuyruk
//public class Program
//{
//    static void Main(string[] args)
//    {
//        node n1 = new node(10);
//        node n2 = new node(20);
//        node n3 = new node(30);
//        node n4 = new node(40);
//        node n5 = new node(50);
//        node n6 = new node(60);

//        var kuyruk = new kListe();

//        kuyruk.enqueue(n1);
//        kuyruk.enqueue(n2);
//        kuyruk.enqueue(n3);
//        kuyruk.yaz();
//        kuyruk.dequeue();
//        kuyruk.yaz();
//        kuyruk.enqueue(n4);
//        kuyruk.enqueue(n5);
//        kuyruk.yaz();
//        kuyruk.dequeue();
//        kuyruk.dequeue();
//        kuyruk.yaz();

//        Console.ReadKey();

//    }
//}

//public class node
//{
//    public int veri;
//    public node ileri;

//    public node(int veri)
//    {
//        this.veri = veri;
//        ileri = null;
//    }
//}

//public class kListe
//{
//    public node bas;
//    public node son;

//    public kListe()
//    {
//        bas = null;
//        son = null;
//    }

//    public void enqueue(node yeni)
//    {
//        if (bas == null)
//            bas = yeni;
//        else
//            son.ileri = yeni;

//        son = yeni;
//    }


//    public node dequeue()
//    {
//        var tmp = bas;

//        bas = bas.ileri;

//        if (bas == null)
//            son = null;


//        return tmp;
//    }

//    public int say()
//    {
//        node temp = bas;
//        int sayac = 0;
//        while (temp != null)
//        {
//            sayac++;
//            temp = temp.ileri;
//        }
//        return sayac;
//    }

//    public void yaz()
//    {
//        node temp = bas;
//        while (temp != null)
//        {
//            Console.Write(temp.veri + " -> ");
//            temp = temp.ileri;
//        }
//        Console.WriteLine("");
//    }
//}
#endregion