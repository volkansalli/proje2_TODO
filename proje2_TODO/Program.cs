using System;
using System.Collections.Generic;

namespace proje2_TODO
{
    class Program
    {
    static void Main(string [] args)
    {
    List<kart> TODO=new();
    List<kart> IN_PROGRESS=new();
    List<kart> DONE=new();
    List<kisi> calisanlistesi=new();
    kisi kisi1=new("volkan","şallı","1");
    kisi kisi2=new("doğan","hepoğlu","2");
    kisi kisi3=new("nejat","duman","3");
    calisanlistesi.Add(kisi1);
    calisanlistesi.Add(kisi2);
    calisanlistesi.Add(kisi3);
    metotlar fonksiyon=new();
    string secim;
    while(true)
    {
        fonksiyon.menu_goster();
        secim=Console.ReadLine();
        if(secim=="1")
        fonksiyon.boardlistele(TODO,IN_PROGRESS,DONE);
        if(secim=="2")
        fonksiyon.kartekle(calisanlistesi,TODO,IN_PROGRESS,DONE);
        if(secim=="3")
        fonksiyon.kartsil(TODO,IN_PROGRESS,DONE);
        if(secim=="4")
        fonksiyon.karttasi(TODO,IN_PROGRESS,DONE);
    }
    }
    }
    class kisi
    {
        public string ad;
        public string soyad;
        public string ID;
        public kisi(string ad,string soyad,string ID)
        {
            this.ad=ad;
            this.soyad=soyad;
            this.ID=ID;
        }
        public kisi()
        {

        }
    }
    class kart
    {
        public string baslik;
        public string icerik;
        
        public string line;
        public int buyukluk;
        public kart()
        {

        }
        public kisi eklenen;
        public kart(string baslik,string icerik,int buyukluk,string line)
        {
            this.baslik=baslik;
            this.icerik=icerik;
            this.line=line;
            this.buyukluk=buyukluk;
        }
    }
    class metotlar
    {
////////////////////////////////////////////////////////////////////////////MENUGOSTER
        public void menu_goster()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)\n*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
        }
////////////////////////////////////////////////////////////////////////////KISIBUL
        public kisi kisibul(string ID, List<kisi> takimlistesi)
        {
            
            for (int i = 0; i < takimlistesi.Count; i++)
            {
                if(ID==takimlistesi[i].ID)
                return takimlistesi[i];
            }
                kisi kisinull=new("0","0","0");
                return kisinull; 
        }
////////////////////////////////////////////////////////////////////////////KARTEKLE
        public void kartekle(List<kisi> takimlistesi,List<kart> TODO,List<kart> IN_PROGRESS,List<kart> DONE)
        {
            kart olusacakkart=new();
            string ID;
            string line;
            string buyukluk;
            Console.WriteLine("Başlık Giriniz                                  :");
            olusacakkart.baslik=Console.ReadLine();
            Console.WriteLine("İçerik Giriniz                                  :");
            olusacakkart.icerik=Console.ReadLine();
            Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
            buyukluk=Console.ReadLine();
            if( buyukluk=="1" || buyukluk=="2" || buyukluk=="3" || buyukluk=="4" || buyukluk=="5")
            {
                olusacakkart.buyukluk=Convert.ToInt32(buyukluk);
            }
            else
            {
            Console.WriteLine("Hatalı girişler yaptınız");
            return;
            }            
            Console.WriteLine("Kişi Seçiniz   (ID) sini giriniz! ID(1)-Volkan Şallı ID(2)-Doğan Hepoğlu ID(3)-Nejat Duman               :");
            ID=Console.ReadLine();
            olusacakkart.eklenen=kisibul(ID,takimlistesi);
            if(olusacakkart.eklenen.ad=="0")
            {
            Console.WriteLine("Hatalı girişler yaptınız");
            return;
            }
            Console.WriteLine("Eklenecek Line ı seçiniz TODO(1) IN_PROGRESS(2) DONE(3)");
            line=Console.ReadLine();
            if(line=="1")
            {
            olusacakkart.line="TODO";
            TODO.Add(olusacakkart);
            }
                                    if(line=="2")
                                    {
                                    olusacakkart.line="IN_PROGRESS";
                                    IN_PROGRESS.Add(olusacakkart);
                                    }
                                                            if(line=="3")
                                                            {
                                                            olusacakkart.line="DONE";
                                                            DONE.Add(olusacakkart);
                                                            }
        }
////////////////////////////////////////////////////////////////////////////BUYUKLUK GOSTER
        public void buyuklukgoster(int b)
        {
            if(b==1)
            Console.WriteLine(buyukluk.XS);
            if(b==2)
            Console.WriteLine(buyukluk.S);
            if(b==3)
            Console.WriteLine(buyukluk.M);
            if(b==4)
            Console.WriteLine(buyukluk.L);
            if(b==5)
            Console.WriteLine(buyukluk.XL);
        }
////////////////////////////////////////////////////////////////////////////BOARD LISTELE
    public void boardlistele(List<kart> TODO,List<kart> IN_PROGRESS,List<kart> DONE)
    {
        Console.WriteLine("\n\n");
        Console.WriteLine("TODO Line\n************************"); 
        boardgoster(TODO);       
        Console.WriteLine("\n\n");
        Console.WriteLine("IN_PROGRESS Line\n************************"); 
        boardgoster(IN_PROGRESS);       
        Console.WriteLine("\n\n");
        Console.WriteLine("DONE Line\n************************"); 
        boardgoster(DONE);       
    }
    ////////////////////////////////////////////////////////////////////////////BOARD GOSTER
    public void boardgoster(List<kart> BOARD)
    {
        if(BOARD.Count==0)
        {
            Console.WriteLine("~ Boş ~");
            return;
        }
        for (int i = 0; i < BOARD.Count; i++)
        {
            kartgoster(BOARD[i]);
            if(i!=(BOARD.Count-1))
            Console.WriteLine("-");
        }
    }
    ////////////////////////////////////////////////////////////////////////////KARTGOSTER
    public void kartgoster(kart kartg)
    {
            Console.WriteLine("Başlık          :{0}",kartg.baslik);
            Console.WriteLine("İçerik          :{0}",kartg.icerik);
            Console.WriteLine("AtananKişi      :{0}",kartg.eklenen.ad);
            Console.Write("Büyüklük        :");
            buyuklukgoster(kartg.buyukluk);
    }
    ////////////////////////////////////////////////////////////////////////////KARTBUL
    public List<int> kartbul(string kartbasligi,List<kart> TODO)
    {
        //string kartbasligi=Console.ReadLine();
        List<int> indexlistesi=new();
        for (int i = 0; i < TODO.Count; i++)
        {
            if(TODO[i].baslik==kartbasligi)
             indexlistesi.Add(i);
        }
        return indexlistesi;
    }
    ////////////////////////////////////////////////////////////////////////////KART SİLME
    public void kartsil(List<kart> TODO,List<kart> IN_PROGRESS,List<kart> DONE)
    {
        sticker:
        Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız:");
        int kontrol=0;
        string kartbasligi;
        kartbasligi=Console.ReadLine();
        string secim;
        kontrol=kontrol+kartyoket(kartbasligi,TODO);
        kontrol=kontrol+kartyoket(kartbasligi,IN_PROGRESS);
        kontrol=kontrol+kartyoket(kartbasligi,DONE);
        if(kontrol<=0)
        {
            Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
            secim=Console.ReadLine();
            if(secim=="1")
            return;
            if(secim=="2")
            goto sticker;
        }
    }
    ////////////////////////////////////////////////////////////////////////////KART YOKET
    public int kartyoket(string kartbasligi,List<kart> TODO)
    {
        List<int> indexlistesi=new();
        indexlistesi=kartbul(kartbasligi,TODO);
        if(indexlistesi.Count!=0)
        {
            for (int i = 0; i < indexlistesi.Count; i++)
            {
            TODO.RemoveAt(indexlistesi[i]);                
            }
            return 3;
        }
        return -1;
    }
    ////////////////////////////////////////////////////////////////////////////KART TAŞI
    public void karttasi(List<kart> TODO,List<kart> IN_PROGRESS,List<kart> DONE)
    {
        List<int> indexlistesiTODO=new();
        List<int> indexlistesiIN_PROGRESS=new();
        List<int> indexlistesiDONE=new();
        string secim;
        string kartbasligi;
        kart kartg=new();
        etiket:
        Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız:");
        kartbasligi=Console.ReadLine();
        indexlistesiTODO=kartbul(kartbasligi,TODO);
        if(indexlistesiTODO.Count!=0)
        {
            kartg=TODO[indexlistesiTODO[0]];
            TODO.RemoveAt(indexlistesiTODO[0]);
            kartswap(kartg,TODO,IN_PROGRESS,DONE);
            return;
        }
        indexlistesiIN_PROGRESS=kartbul(kartbasligi,IN_PROGRESS);
        if(indexlistesiIN_PROGRESS.Count!=0)
        {
            kartg=IN_PROGRESS[indexlistesiIN_PROGRESS[0]];
            IN_PROGRESS.RemoveAt(indexlistesiIN_PROGRESS[0]);
            kartswap(kartg,TODO,IN_PROGRESS,DONE);
            return;
        }
        indexlistesiDONE=kartbul(kartbasligi,DONE);
        if(indexlistesiDONE.Count!=0)
        {
            kartg=DONE[indexlistesiDONE[0]];
            DONE.RemoveAt(indexlistesiDONE[0]);
            kartswap(kartg,TODO,IN_PROGRESS,DONE);
            return;
        }
        if((indexlistesiTODO.Count+indexlistesiIN_PROGRESS.Count+indexlistesiDONE.Count)==0)
        {
            Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* İşlemi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
            secim=Console.ReadLine();
            if(secim=="1")
            return;
            if(secim=="2")
            goto etiket;
        }
    }
    ////////////////////////////////////////////////////////////////////////////KART SWAP
    public void kartswap(kart kartg,List<kart> TODO,List<kart> IN_PROGRESS,List<kart> DONE)
    {
        string secim;
        Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:\n(1) TODO\n(2) IN PROGRESS\n(3) DONE");
        secim=Console.ReadLine();
        if(secim=="1")
        {
            TODO.Add(kartg);
        }
        if(secim=="2")
        {
            IN_PROGRESS.Add(kartg);
        }
        if(secim=="3")
        {
            DONE.Add(kartg);
        }
    }
    ////////////////////////////////////////////////////////////////////////////
}
}
public enum buyukluk
        {
            XS,
            S,
            M,
            L,
            XL
        }