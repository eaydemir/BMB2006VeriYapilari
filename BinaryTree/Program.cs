
namespace BinaryTreeNS;

public class Program
{
    static void Main(string[] args)
    {

        Random rand = new Random();
        // 5. seviye bir ikili arama ağacında 31 eleman bulunur, rastgele ürettiğimiz sayıların bir 
        // tarafa yığılırsa seviye artabilir, o yüzden root elemanı ortalardan seçtim

        var rootValue = rand.Next(450, 500);
        System.Console.WriteLine(rootValue);

        İkiliAramaAgaci agac = new İkiliAramaAgaci(rootValue);

        for (int i = 0; i < 30; i++)
        {
            int value = rand.Next(100, 901); // 100-900 arası rastgele sayı üretir
            agac.Insert(value);
        }

        agac.AraGezinti();
        System.Console.WriteLine();

        var ikiliagacmi1 = agac.ikiliAramaAgaciMi();
        System.Console.WriteLine(ikiliagacmi1);

        agac.Root.left.veri = 999;

        var ikiliagacmi2 = agac.ikiliAramaAgaciMi();
        System.Console.WriteLine(ikiliagacmi2);

        Console.ReadKey();

    }
}

public class btNode
{
    public int veri;

    public btNode left;

    public btNode right;

    public btNode(int veri)
    {
        this.veri = veri;
        left = null;
        right = null;
    }
}

public class İkiliAramaAgaci
{
    public btNode Root { get; set; }

    public İkiliAramaAgaci(int veri)
    {
        this.Root = new btNode(veri);
    }

    public btNode Max(btNode node)
    {
        if (node.right != null)
            return Max(node.right);
        else
            return node.right;
    }

    public btNode Min(btNode node)
    {
        if (node.left != null)
            return Min(node.left);
        else
            return node.left;
    }

    public void Insert(int value)
    {
        Insert(Root, value);
    }

    public btNode Insert(btNode node, int value)
    {
        if (node == null)
        {
            return new btNode(value);
        }

        if (value < node.veri)
        {
            node.left = Insert(node.left, value);
        }
        else if (value > node.veri)
        {
            node.right = Insert(node.right, value);
        }

        return node;
    }

    public void Delete(int value)
    {
        DeleteNode(Root, value);
    }

    public btNode DeleteNode(btNode node, int value)
    {
        if (node == null)
            return null;

        if (value < node.veri)
        {
            node.left = DeleteNode(node.left, value);
        }
        else if (value > node.veri)
        {
            node.right = DeleteNode(node.right, value);
        }
        else
        {
            if (node.left == null && node.right == null)
            {
                node = null;
            }
            else if (node.left == null)
            {
                node = node.right;
            }
            else if (node.right == null)
            {
                node = node.left;
            }
            else
            {
                btNode temp = Min(node.right);
                node.veri = temp.veri;
                node.right = DeleteNode(node.right, temp.veri);
            }
        }

        return node;
    }

    public void AraGezinti()
    {
        AraGezinti(Root);
    }

    private void AraGezinti(btNode node)
    {
        if (node != null)
        {
            AraGezinti(node.left);
            Console.Write(node.veri + " ");
            AraGezinti(node.right);
        }
    }

    public bool ikiliAramaAgaciMi()
    {
        return ikiliAramaAgaciMi(Root);
    }

    private bool ikiliAramaAgaciMi(btNode node)
    {
        if (node == null)
            return true;

        return AltAgaclarKucukMu(node.left, node.veri) &&
            AltAgaclarBuyukMu(node.right, node.veri) &&
            ikiliAramaAgaciMi(node.left) &&
            ikiliAramaAgaciMi(node.right);
    }

    private bool AltAgaclarKucukMu(btNode node, int value)
    {
        if (node == null)
            return true;

        return node.veri <= value && AltAgaclarKucukMu(node.left, value) && AltAgaclarKucukMu(node.right, value);
    }

    private bool AltAgaclarBuyukMu(btNode node, int value)
    {
        if (node == null)
            return true;

        return node.veri >= value && AltAgaclarBuyukMu(node.left, value) && AltAgaclarBuyukMu(node.right, value);

    }

    public void OnceGezinti()
    {
        OnceGezinti(Root);
    }

    private void OnceGezinti(btNode node)
    {
        if (node != null)
        {
            Console.Write(node.veri + " ");
            OnceGezinti(node.left);
            OnceGezinti(node.right);
        }
    }

    public void SonraGezinti()
    {
        SonraGezinti(Root);
    }

    private void SonraGezinti(btNode node)
    {
        if (node != null)
        {
            SonraGezinti(node.left);
            SonraGezinti(node.right);
            Console.Write(node.veri + " ");
        }
    }



}