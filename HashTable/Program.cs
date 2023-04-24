using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ConstrainedExecution;


namespace HashTable;

public class Program
{
    static void Main(string[] args)
    {
        HashTablosu tablo = new HashTablosu(7);
        tablo.EkleDoubleHashing(23);
        tablo.EkleDoubleHashing(12);
        tablo.EkleDoubleHashing(88);
        tablo.EkleDoubleHashing(45);
        tablo.EkleDoubleHashing(62);
        tablo.EkleDoubleHashing(17);
        tablo.EkleDoubleHashing(36);
        tablo.Yazdir();

        Console.WriteLine();

        HashTablosu tablo2 = new HashTablosu(7);
        tablo2.EkleQuadraticHashing(23);
        tablo2.EkleQuadraticHashing(12);
        tablo2.EkleQuadraticHashing(88);
        tablo2.EkleQuadraticHashing(45);
        tablo2.EkleQuadraticHashing(62);
        tablo2.EkleQuadraticHashing(17);
        tablo2.EkleQuadraticHashing(36);

        //çıktılar:
        // eleman eklemede her döngüde ekrana nokta yazdırıyorum.

        //. 12 eklendi
        //. 88 eklendi
        //. 45 eklendi
        //. 62 eklendi
        //. 17 eklendi
        //. 36 eklendi 
        //0: 17 | 1: 36 | 2: 23 | 3: 45 | 4: 88 | 5: 12 | 6: 62 |


        //. 23 eklendi
        //. 12 eklendi
        //. 88 eklendi
        //. 45 eklendi
        //. 62 eklendi
        //.  . 17 eklendi
        //.  .  .  .  . 36 eklendi 
        //0: 36 | 1: 17 | 2: 23 | 3: 45 | 4: 88 | 5: 12 | 6: 62 |

        //yukarıdaki örnekdeki sayılar ile double  hashing, quadratic hashing e göre çok daha az döngüye giriyor.
        // farklı sayılar ile deneyelim.
        Console.WriteLine();
        Console.WriteLine();

        HashTablosu tablo3 = new HashTablosu(7);
        tablo3.EkleDoubleHashing(15);
        tablo3.EkleDoubleHashing(22);
        tablo3.EkleDoubleHashing(33);
        tablo3.EkleDoubleHashing(44);
        tablo3.EkleDoubleHashing(35);
        tablo3.EkleDoubleHashing(51);
        tablo3.EkleDoubleHashing(58);
        tablo3.Yazdir();

        Console.WriteLine();

        HashTablosu tablo4 = new HashTablosu(7);
        tablo4.EkleQuadraticHashing(15);
        tablo4.EkleQuadraticHashing(22);
        tablo4.EkleQuadraticHashing(33);
        tablo4.EkleQuadraticHashing(44);
        tablo4.EkleQuadraticHashing(35);
        tablo4.EkleQuadraticHashing(51);
        tablo4.EkleQuadraticHashing(58);
        tablo4.Yazdir();

        //. 15 eklendi
        //. 22 eklendi
        //. 33 eklendi
        //. 44 eklendi
        //. 35 eklendi
        //. 51 eklendi
        //.  . 58 eklendi

        //0: 35 | 1: 15 | 2: 44 | 3: 22 | 4: 58 | 5: 33 | 6: 51 |


        //. 15 eklendi
        //. 22 eklendi
        //. 33 eklendi
        //. 44 eklendi
        //. 35 eklendi
        //.  .  .  . 51 eklendi
        //.  .  .  .  .  .  . 58 eklenmedi

        //0: 35 | 1: 15 | 2: 22 | 3: 44 | 4: 51 | 5: 33 | 6: -1 |

        // double  hashing, quadratic hashing e göre çok daha az döngüye giriyor.
        // derste anlatılandan farklı olarak hiç eleman eklenmeyen durumla karşılaşmadım.


    }
}

public class HashTablosu
{
    private int BOYUT;
    private int[] tablo;

    public HashTablosu(int boyut)
    {
        BOYUT = boyut;
        tablo = new int[BOYUT];

        for (int i = 0; i < BOYUT; i++)
            tablo[i] = -1;
    }

    private int Hash(int deger)
    {
        return deger % BOYUT;
    }

    private int Hash2(int deger)
    {
        int hash = Hash(deger);
        var yenimod = EnBuyukAsal(BOYUT);
        return (hash + (deger % yenimod)) % yenimod;
    }

    private int EnBuyukAsal(int number)
    {
        if (number < 2)
            return 2;

        for (int i = number - 1; i > 1; i--)
        {
            if (AsalMi(i))
                return i;
        }

        return -1;
    }

    private bool AsalMi(int number)
    {
        if (number < 2)
            return false;

        int squareRoot = (int)Math.Sqrt(number);

        for (int i = 2; i <= squareRoot; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    public void EkleDoubleHashing(int deger)
    {
        int pozisyon = Hash(deger);

        if (tablo[pozisyon] == -1)
        {
            tablo[pozisyon] = deger;
            Console.Write(" . ");
            Console.WriteLine($"{deger} eklendi");
        }
        else
        {
            var pozisyon2 = Hash2(deger);

            if (tablo[pozisyon2] == -1)
            {
                tablo[pozisyon2] = deger;
                Console.Write(" . ");
                Console.WriteLine($"{deger} eklendi");
            }
            else
            {
                pozisyon2 *= 2;
                if (pozisyon2 == 0) pozisyon2 = 2;

                while (pozisyon2 < BOYUT)
                {
                    Console.Write(" . ");

                    if (tablo[pozisyon2] == -1)
                    {
                        tablo[pozisyon2] = deger;
                        Console.WriteLine($"{deger} eklendi");
                        return;
                    }
                    pozisyon2 *= 2;
                }
                Console.WriteLine($"{deger} eklenmedi");
            }
        }
    }

    public void EkleQuadraticHashing(int deger)
    {
        int pozisyon = Hash(deger);

        if (tablo[pozisyon] == -1)
        {
            tablo[pozisyon] = deger;
            Console.Write(" . ");
            Console.WriteLine($"{deger} eklendi");
        }
        else
        {
            int i = 1;
            while (tablo[pozisyon] != -1)
            {
                pozisyon = (pozisyon + i * i) % BOYUT;
                i++;
                Console.Write(" . ");

                if (i > BOYUT)
                {
                    Console.WriteLine($"{deger} eklenmedi");
                    return;
                }
            }
            tablo[pozisyon] = deger;
            Console.WriteLine($"{deger} eklendi");
        }
    }

    private int SiraNo(int value)
    {
        return Array.IndexOf(tablo, value);
    }

    public void Yazdir()
    {
        Console.WriteLine();
        for (int i = 0; i < BOYUT; i++)
        {
            Console.Write($" {i}: {tablo[i]} |");
        }
        Console.WriteLine("\r\n");
    }
}

