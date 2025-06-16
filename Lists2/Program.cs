using System;
abstract class BaseMakine
{
    public DateTime UretimTarihi { get; private set; }
    public string SeriNumarasi { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public string IsletimSistemi { get; set; }

    public BaseMakine()
    {
        UretimTarihi = DateTime.Now;
    }

    public virtual void BilgileriYazdir()
    {
        Console.WriteLine("Üretim Tarihi: " + UretimTarihi);
        Console.WriteLine("Seri Numarası: " + SeriNumarasi);
        Console.WriteLine("Ad: " + Ad);
        Console.WriteLine("Açıklama: " + Aciklama);
        Console.WriteLine("İşletim Sistemi: " + IsletimSistemi);
    }

    public abstract void UrunAdiGetir();
}
class Telefon : BaseMakine
{
    public bool TrLisansli { get; set; }
    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir();
        Console.WriteLine("Türk Lisanslı mı?: " + (TrLisansli ? "Evet" : "Hayır"));
    }

    public override void UrunAdiGetir()
    {
        Console.WriteLine("Telefonunuzun adı ---> " + Ad);
    }
}
class Bilgisayar : BaseMakine
{
    private int usbGirisSayisi;

    public int UsbGirisSayisi
    {
        get { return usbGirisSayisi; }
        set
        {
            if (value == 2 || value == 4)
            {
                usbGirisSayisi = value;
            }
            else
            {
                Console.WriteLine("Hatalı USB giriş sayısı girdiniz. 2 veya 4 olmalıdır.");
                usbGirisSayisi = -1;
            }
        }
    }
    public bool BluetoothVarMi { get; set; }
    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir();
        Console.WriteLine("USB Giriş Sayısı: " + (UsbGirisSayisi == -1 ? "Geçersiz" : UsbGirisSayisi.ToString()));
        Console.WriteLine("Bluetooth Var mı?: " + (BluetoothVarMi ? "Evet" : "Hayır"));
    }
    public override void UrunAdiGetir()
    {
        Console.WriteLine("Bilgisayarınızın adı ---> " + Ad);
    }
}
class Program
{
    static void Main()
    {
        bool devam = true;
        while (devam)
        {
            Console.WriteLine("Üretmek istediğiniz ürün için sayı giriniz: Telefon -> 1, Bilgisayar -> 2");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Telefon tel = new Telefon();

                Console.Write("Seri Numarası: ");
                tel.SeriNumarasi = Console.ReadLine();

                Console.Write("Ad: ");
                tel.Ad = Console.ReadLine();

                Console.Write("Açıklama: ");
                tel.Aciklama = Console.ReadLine();

                Console.Write("İşletim Sistemi: ");
                tel.IsletimSistemi = Console.ReadLine();

                Console.Write("Türk Lisanslı mı? (Evet/Hayır): ");
                string lisans = Console.ReadLine().ToLower();
                tel.TrLisansli = (lisans == "evet");

                Console.WriteLine("\nÜrün başarıyla üretildi!\n");

                tel.BilgileriYazdir();
                tel.UrunAdiGetir();
            }
            else if (secim == "2")
            {
                Bilgisayar pc = new Bilgisayar();

                Console.Write("Seri Numarası: ");
                pc.SeriNumarasi = Console.ReadLine();

                Console.Write("Ad: ");
                pc.Ad = Console.ReadLine();

                Console.Write("Açıklama: ");
                pc.Aciklama = Console.ReadLine();

                Console.Write("İşletim Sistemi: ");
                pc.IsletimSistemi = Console.ReadLine();

                Console.Write("USB Giriş Sayısı (2 veya 4): ");
                if (int.TryParse(Console.ReadLine(), out int usbSayisi))
                {
                    pc.UsbGirisSayisi = usbSayisi;
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş, USB giriş sayısı -1 olarak atanacak.");
                    pc.UsbGirisSayisi = -1;
                }

                Console.Write("Bluetooth var mı? (Evet/Hayır): ");
                string bt = Console.ReadLine().ToLower();
                pc.BluetoothVarMi = (bt == "evet");

                Console.WriteLine("\nÜrün başarıyla üretildi!\n");

                pc.BilgileriYazdir();
                pc.UrunAdiGetir();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
                continue;
            }

            Console.WriteLine("\nBaşka ürün üretmek ister misiniz? (Evet/Hayır): ");
            string devamCevap = Console.ReadLine().ToLower();

            if (devamCevap != "evet")
            {
                devam = false;
                Console.WriteLine("İyi günler!");
            }
        }
    }
}
