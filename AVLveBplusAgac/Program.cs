using System;

namespace AVLveBplusAgac;

class Program
{
    static void Main(string[] args)
    {
        #region AVL Ağacı

        Console.WriteLine("---AVL AĞACI---");

        AVLTree avl = new AVLTree();

        avl.Ekle(59);
        avl.Ekle(24);
        avl.Ekle(36);
        avl.Ekle(30);
        avl.Ekle(36);
        avl.Ekle(56);
        avl.Ekle(58);
        avl.Ekle(62);

        avl.AraGezinti();
        Console.WriteLine();

        #region avl Silme işlemi

        //1.Silinecek düğüm bulunur.
        //2.Silinecek düğümün bir veya iki çocuğu varsa, onların yerine geçecek düğüm bulunur. Eğer silinecek düğümün iki çocuğu varsa,
        //onun hemen sağındaki en küçük düğüm veya hemen solundaki en büyük düğüm seçilir.
        //3.Seçilen düğüm, silinecek düğümün yerine geçirilir.
        //4.Ağaçta bir düğüm silindiği için, ağacın dengesi bozulabilir, dengeyi bulmak için aşağıdaki maddelerden biri yapılır.  
        //    1.Sol - Sol Dönüşü(LL Dönüşü): Bu durumda, ağacın sol alt ağacı daha yüksektir ve sol alt ağacın sol alt ağacı da sağ alt ağacından daha yüksektir. Bu durumda, ağaç sola döndürülür.
        //    2.Sağ - Sağ Dönüşü(RR Dönüşü): Bu durumda, ağacın sağ alt ağacı daha yüksektir ve sağ alt ağacın sağ alt ağacı da sol alt ağacından daha yüksektir. Bu durumda, ağaç sağa döndürülür.
        //    3.Sol - Sağ Dönüşü(LR Dönüşü): Bu durumda, ağacın sol alt ağacı daha yüksektir ve sol alt ağacın sağ alt ağacı da sol alt ağacından daha yüksektir. Bu durumda, ağaç önce sol alt ağaçta sağa döndürülür, ardından ağaç sağa döndürülür.
        //    4.Sağ - Sol Dönüşü(RL Dönüşü): Bu durumda, ağacın sağ alt ağacı daha yüksektir ve sağ alt ağacın sol alt ağacı da sağ alt ağacından daha yüksektir. Bu durumda, ağaç önce sağ alt ağaçta sola döndürülür, ardından ağaç sola döndürülür.

        #endregion

        avl.Sil(30);

        avl.AraGezinti();
        Console.WriteLine();
        #endregion

        #region B PLUS AĞACI

        Console.WriteLine("---B PLUS AĞACI---");

        //- Anahtarın ağaçta olup olmadığını kontrol etmek için Search metodu kullanılır.
        //- Anahtarın bulunduğu yaprak düğümüne ulaşılır ve anahtarın silinmesi yaprağı kapasite altına düşürürse, ödünç alınması gereken anahtarlar belirlenir. Bu anahtarlar, yaprak düğümünden hemen sonra gelen kardeş düğümlerden alınabilir.
        //- Eğer ödünç alınacak anahtar kardeş düğümlerde yoksa, anahtarın üst düğümlerden birinden alınması gerekebilir. Bu anahtarın belirlenmesi için, anahtarın hangi düğümde ödünç alındığına dikkat edilmelidir.
        //- Anahtar, ödünç alınarak silindiğinde, yaprak düğümündeki anahtar sayısı kapasitenin altında mı kalıyor diye kontrol edilir.Kapasitenin altında kalırsa, yaprak düğümünün ebeveyn düğümüne haber verilir ve yaprak düğümü dengeleme işlemi için ebeveyn düğümünün referansını döndürür.
        //- Ebeveyn düğümü de aynı şekilde kapasitenin altına düşerse, ödünç alınması veya anahtarların yeniden düzenlenmesi için kardeş düğümlere ve üst düğümlere haber verilir.
        //- Eğer ödünç alınan bir anahtar varsa, ödünç alınan anahtarın kardeş düğümlerde yeterli anahtar varsa doğrudan alınabilir.Ancak yeterli anahtar yoksa, anahtar üst düğümlerden birinden alınmalıdır.
        //- Silinen anahtarın ebeveyn düğümüne geri döndüğünde, ağaç dengelenmelidir.Ağacın yeniden dengelenmesi, AVL ağaçlarındaki gibi, sağa veya sola dönerek yapılabilir.
        //- Ağacın yeniden dengelenmesiyle birlikte, ödünç alınan anahtarlar geri yerleştirilir ve ağacın yapısı güncellenir.

        // silme metodu aşağıdaki gibidir.

        //public void Delete(int key)
        //{
        //    int index = FindIndex(key); // silinecek index bulunur

        //    if (index < size && keys[index] == key)
        //    {
        //        for (int i = index + 1; i < size; i++)
        //        {
        //            keys[i - 1] = keys[i];
        //            values[i - 1] = values[i];
        //        }

        //        size--;

        //        if (AltSiniraDustuMu() && parent != null)  // silindikten sonra alt sınırın altına düşerse, ağaç elemanlarının bölünüp birbirine bağlanması sağlanır.
        //        {
        //            parent.YenidenUyarla(this, index);  
        //        }
        //    }
        //}

        #endregion
    }
}

public class avlNode
{
    public int veri;
    public int height;
    public avlNode left;
    public avlNode right;

    public avlNode(int veri)
    {
        this.veri = veri;
        left = null;
        right = null;
        this.height = 1;
    }
}

public class AVLTree
{

    private avlNode root;

    private int Yukseklik(avlNode node)
    {
        if (node == null)
            return 0;

        return node.height;
    }

    private int Denge(avlNode node)
    {
        if (node == null)
            return 0;

        return Yukseklik(node.left) - Yukseklik(node.right);
    }

    private avlNode SagaDondur(avlNode y)
    {
        avlNode x = y.left;
        avlNode T2 = x.right;

        x.right = y;
        y.left = T2;

        y.height = Math.Max(Yukseklik(y.left), Yukseklik(y.right)) + 1;
        x.height = Math.Max(Yukseklik(x.left), Yukseklik(x.right)) + 1;

        return x;
    }

    private avlNode SolaDondur(avlNode x)
    {
        avlNode y = x.right;
        avlNode T2 = y.left;

        y.left = x;
        x.right = T2;

        x.height = Math.Max(Yukseklik(x.left), Yukseklik(x.right)) + 1;
        y.height = Math.Max(Yukseklik(y.left), Yukseklik(y.right)) + 1;

        return y;
    }

    private avlNode KucukNode(avlNode node)
    {
        avlNode current = node;

        while (current.left != null)
            current = current.left;

        return current;
    }

    public void Ekle(int veri)
    {
        this.root = Ekle(this.root, veri);
    }

    private avlNode Ekle(avlNode node, int veri)
    {
        if (node == null)
            return new avlNode(veri);

        if (veri < node.veri)
            node.left = Ekle(node.left, veri);
        else if (veri > node.veri)
            node.right = Ekle(node.right, veri);
        else
            return node;

        node.height = 1 + Math.Max(Yukseklik(node.left), Yukseklik(node.right));

        int deng = Denge(node);

        if (deng > 1 && veri < node.left.veri)
            return SagaDondur(node);

        if (deng < -1 && veri > node.right.veri)
            return SolaDondur(node);

        if (deng > 1 && veri > node.left.veri)
        {
            node.left = SolaDondur(node.left);
            return SagaDondur(node);
        }

        if (deng < -1 && veri < node.right.veri)
        {
            node.right = SagaDondur(node.right);
            return SolaDondur(node);
        }

        return node;
    }

    public void Sil(int veri)
    {
        this.root = Sil(this.root, veri);
    }

    private avlNode Sil(avlNode node, int veri)
    {
        if (node == null)
            return node;

        if (veri < node.veri)
        {
            node.left = Sil(node.left, veri);
        }
        else if (veri > node.veri)
        {
            node.right = Sil(node.right, veri);
        }
        else
        {
            if ((node.left == null) || (node.right == null))
            {
                avlNode temp = null;
                if (temp == node.left)
                    temp = node.right;
                else
                    temp = node.left;

                if (temp == null)
                {
                    temp = node;
                    node = null;
                }
                else
                {
                    node = temp;
                }
            }
            else
            {
                avlNode temp = KucukNode(node.right);
                node.veri = temp.veri;
                node.right = Sil(node.right, temp.veri);
            }
        }

        if (node == null)
            return node;

        node.height = 1 + Math.Max(Yukseklik(node.left), Yukseklik(node.right));

        int balance = Denge(node);

        if (balance > 1 && Denge(node.left) >= 0)
            return SagaDondur(node);


        if (balance > 1 && Denge(node.left) < 0)
        {
            node.left = SolaDondur(node.left);
            return SagaDondur(node);
        }

        if (balance < -1 && Denge(node.right) <= 0)
        {
            return SolaDondur(node);
        }

        if (balance < -1 && Denge(node.right) > 0)
        {
            node.right = SagaDondur(node.right);
            return SolaDondur(node);
        }

        return node;
    }

    public void AraGezinti()
    {
        Console.Write("*" + root.veri + "* ");
        AraGezinti(this.root);
    }

    private void AraGezinti(avlNode node)
    {
        if (node != null)
        {
            AraGezinti(node.left);
            Console.Write(node.veri + " - ");
            AraGezinti(node.right);
        }
    }
     
}
