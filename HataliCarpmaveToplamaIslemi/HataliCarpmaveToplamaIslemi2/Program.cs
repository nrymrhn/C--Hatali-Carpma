using System;
using System.Collections.Generic;

namespace HataliCarpmaveToplamaIslemi2
{
    class Program
    {
        static int carpan1;
        static string carpan2;
        static void Main(string[] args)
        {

            HosgeldinMesajVer();
            SayilariAl();
            List<string> carpanlar = VeriKontrol(carpan2);
            List<int> toplamlar = SayilarCarp(carpanlar, carpan1);
            string[] basamaklar = SayilariTopla(toplamlar);
            Goster(basamaklar);
        }
        private static void HosgeldinMesajVer()
        {
            Console.WriteLine("Hoşgeldiniz.!");
        }

        private static void SayilariAl()
        {
            //Global alanda tanımlandılar.
            Console.Write("1. Sayıyı Giriniz : ");
            carpan1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("2. Sayıyı Giriniz : ");
            carpan2 = Console.ReadLine();
        }

        private static List<string> VeriKontrol(string carpan2)
        {
            List<string> carpanlar = new List<string>();

            for (int i = 0; i < carpan2.Length; i++)
            {
                if (Convert.ToInt32(carpan2.Length.ToString()) < 4)
                    carpanlar.Add(carpan2[i].ToString());
                else
                {
                    Console.WriteLine("Lütfen ikinci çarpanın basamak sayısı 4'ten küçük giriniz");
                    break;
                }
            }

            return carpanlar;
        }

        private static List<int> SayilarCarp(List<string> carpanlar, int carpan1)
        {
            List<int> toplamlar = new List<int>();

            for (int i = 0; i < carpanlar.Count; i++)
                toplamlar.Add(Convert.ToInt32(carpanlar[i]) * carpan1);

            return toplamlar;
        }

        private static string[] SayilariTopla(List<int> toplamlar)
        {
            string[] basamaklar = new string[1000];

            for (int i = 0; i < toplamlar.Count; i++)
            {
                for (int j = 0; j < toplamlar[i].ToString().Length; j++)
                {
                    if (basamaklar[j] == null)
                        basamaklar[j] = toplamlar[i].ToString()[j].ToString();
                    else
                    {
                        int toplam = Convert.ToInt32(basamaklar[j].ToString()) + Convert.ToInt32(toplamlar[i].ToString()[j].ToString());

                        if (toplam > 9)
                            basamaklar[j] = (toplam % 10).ToString();
                        else
                            basamaklar[j] = toplam.ToString();
                    }
                }
            }
            return basamaklar;
        }

        private static void Goster(string[] basamaklar)
        {
            Console.WriteLine("---------------------");
            Console.Write("Sonuc : ");
            for (int i = 0; i < basamaklar.Length; i++)
            {
                Console.Write(basamaklar[i]);
            }
            Console.WriteLine("\n---------------------");

            Console.ReadKey();
        }
    }
}
