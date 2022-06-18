using System;

namespace HataliCarpmaveToplamaIslemi
{
    class Program
    {
        //Sevgili öğrencilerimiz bu alıştırmada sizden istenen yanlış çarpma ve toplama işlemi yapan programı tasarlamanız.
        //Bu senaryo üzerinde şekillenen alıştırmanız belirli kriterlerden oluşmaktadır;
        // Çarpma işleminin hatası sayıları bir basamak sola kaydırmıyor oluşudur,
        // Toplama işleminin hatası ise bir basamaktaki toplam sayı 10’nu geçerse diğer basamağa herhangi bir sayı aktarmıyor oluşudur,
        // Çarpan1 ve Çarpan2nın boş geçilememesi gerekiyor ve İkinci sayının basamak sayısı 3’ten büyük olamaz.
        // Konunun daha iyi anlaşılması için aşağıdaki örneği inceleyiniz.

        // 211  // Kullanıcı tarafından girilen ilk sayı
        //  33 // Kullanıcı tarafından girilen ikinci sayı
        //X_____
        //  633// Bir basamak sola kaydırılmıyor

        //  633

        //+ _____

        //  266 // Örneğin 6+6=12. Sonuç 10’u geçti. Elde var 1 kısmı diğer basamağa aktarılmadı.
        //Sonuç: 266 olmalıdır.


        //Dikkat edilmesi gereken konular:
        //Yazılıma başlamadan algoritmayı çıkarın.
        //Güzel kod yazma kurallarını uygulayın.
        //Yapmış olduğunuz programı etkili olarak test etmenizi sağlayacak en az 3 farklı örnek veri hazırlayın ve test sonuçlarını paylaşın
        //Kullanıcı deneyimini yükseltecek kod yazmaya dikkat edin.

        // 1) Verilen iki sayıdan ilkini olduğu gibi al
        // 2) Verilen ikinci sayının rakamları 4'ü geçmeyecek ve her basamağını al ve carp
        // 3) Her basamağı çarpılan sayı diziye at
        // 4) Her oluşacak dizinin aynı sütunlarını toplayacağız. Eğer onu geçerse birler bamağını al ve yazdır.
        static void Main(string[] args)
        {
            Login();
            int sayiBir = SayiBirAl();
            int sayiIki = SayiIkiAl();
            int sonuc = YanlisCarpma(sayiBir, sayiIki);
            Console.WriteLine($"Çarpma işleminin sonucu : {sonuc}");
            Logout();
        }
        private static void Login()
        {
            Console.WriteLine("Bu program hatalı çarpma işlemi ve toplama işlemi yapmaktadır.");
        }
        private static int SayiBirAl()
        {
            Console.WriteLine("Lütfen birinci çarpanı giriniz");
            bool sayiMi = int.TryParse(Console.ReadLine(), out int sayi);
            if (sayiMi == false)
            {
                Console.WriteLine("Sayıyı tekrardan giriniz");
                return SayiBirAl();
            }
            int sayac = 0;
            int sayi1Yedek = sayi;
            while (sayi > 0)
            {
                sayi /= 10;
                sayac++;
            }
            if (sayac >= 6)
            {
                Console.WriteLine("Lütfen sayıyı 5 basamaklıdan fazla girmeyiniz");
                return SayiBirAl();
            }
            return sayi1Yedek;
        }
        private static int SayiIkiAl()
        {
            Console.WriteLine("Lütfen ikinci çarpanı giriniz");
            bool sayiMi = int.TryParse(Console.ReadLine(), out int sayi);
            if (sayiMi == false)
            {
                Console.WriteLine("Sayıyı tekrardan giriniz");
                return SayiIkiAl();
            }
            int sayac = 0;
            int sayi2Yedek = sayi;
            while (sayi > 0)
            {
                sayi /= 10;
                sayac++;
            }
            if (sayac >= 4)
            {
                Console.WriteLine("Lütfen sayıyı 3 basamaklıdan fazla girmeyiniz");
                return SayiIkiAl();
            }
            return sayi2Yedek;
        }

        private static int YanlisCarpma(int gelenSayi1, int gelenSayi2)
        {
            int birler = 0, onlar = 0, yuzler = 0;
            int gelenSayi2Yedek = gelenSayi2;
            int sayac = 4;
            while (sayac > 0)
            {
                gelenSayi2 /= 10;
                sayac--;
                switch (sayac)
                {
                    case 3:
                        yuzler = gelenSayi2Yedek / 100;
                        gelenSayi2Yedek = gelenSayi2Yedek - (yuzler * 100);
                        break;
                    case 2:
                        onlar = gelenSayi2Yedek / 10;
                        gelenSayi2Yedek = gelenSayi2Yedek - (onlar * 10);
                        break;
                    case 1:
                        birler = gelenSayi2Yedek;
                        break;

                    default:
                        break;
                }
            }
            int birlerCarpim = birler * gelenSayi1;
            int onlarCarpim = onlar * gelenSayi1;
            int yuzlerCarpim = yuzler * gelenSayi1;

            int toplam = YanlisToplamaYap(birlerCarpim, onlarCarpim);
            int sonCarpimSonucu = YanlisToplamaYap(toplam, yuzlerCarpim);
            return sonCarpimSonucu;

        }
        private static int YanlisToplamaYap(int gelenSayi, int gelenSayi2)
        {
            int birlerBirinci = 0, onlarBirinci = 0, yuzlerBirinci = 0, binlerBirinci = 0, onBinlerBirinci = 0, birlerIkinci = 0, onlarIkinci = 0, yuzlerIkinci = 0, binlerIkinci = 0, onBinlerIkinci = 0;

            int gelenSayiYedek = gelenSayi;
            int gelenSayi2Yedek = gelenSayi2;
            int sayac = 6;
            while (sayac > 0)
            {
                gelenSayi /= 10;
                sayac--;
                switch (sayac)
                {
                    case 5:
                        onBinlerBirinci = gelenSayiYedek / 10000;
                        gelenSayiYedek = gelenSayiYedek - (onBinlerBirinci * 10000);
                        break;
                    case 4:
                        binlerBirinci = gelenSayiYedek / 1000;
                        gelenSayiYedek = gelenSayiYedek - (binlerBirinci * 1000);
                        break;
                    case 3:
                        yuzlerBirinci = gelenSayiYedek / 100;
                        gelenSayiYedek = gelenSayiYedek - (yuzlerBirinci * 100);
                        break;
                    case 2:
                        onlarBirinci = gelenSayiYedek / 10;
                        gelenSayiYedek = gelenSayiYedek - (onlarBirinci * 10);
                        break;
                    case 1:
                        birlerBirinci = gelenSayiYedek;
                        break;
                    default:
                        break;
                }
            }
            int sayac2 = 6;
            while (sayac2 > 0)
            {
                gelenSayi2 /= 10;
                sayac2--;
                switch (sayac2)
                {
                    case 5:
                        onBinlerIkinci = gelenSayi2Yedek / 10000;
                        gelenSayi2Yedek = gelenSayi2Yedek - (onBinlerIkinci * 10000);
                        break;
                    case 4:
                        binlerIkinci = gelenSayi2Yedek / 1000;
                        gelenSayi2Yedek = gelenSayi2Yedek - (binlerIkinci * 1000);
                        break;
                    case 3:
                        yuzlerIkinci = gelenSayi2Yedek / 100;
                        gelenSayi2Yedek = gelenSayi2Yedek - (yuzlerIkinci * 100);
                        break;
                    case 2:
                        onlarIkinci = gelenSayi2Yedek / 10;
                        gelenSayi2Yedek = gelenSayi2Yedek - (onlarIkinci * 10);
                        break;
                    case 1:
                        birlerIkinci = gelenSayi2Yedek;
                        break;

                }
            }
            int birlerToplam = (birlerBirinci + birlerIkinci) % 10;
            int onlarToplam = (onlarBirinci + onlarIkinci) % 10;
            int yuzlerToplam = (yuzlerBirinci + yuzlerIkinci) % 10;
            int binlerToplam = (binlerBirinci + binlerIkinci) % 10;
            int onBinlerToplam = (onBinlerBirinci + onBinlerIkinci) % 10;

            onlarToplam *= 10;
            yuzlerToplam *= 100;
            binlerToplam *= 1000;
            onBinlerToplam *= 10000;

            int yanlisToplam = birlerToplam + onlarToplam + yuzlerToplam + binlerToplam + onBinlerToplam;
            return yanlisToplam;
        }
        private static void Logout()
        {
            Console.WriteLine("Programı kullandığınız için teşekkür ederiz.");
        }
    }
}
