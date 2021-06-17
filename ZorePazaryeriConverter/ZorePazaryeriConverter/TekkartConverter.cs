using converter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZorePazaryeriConverter.Entity;
using ZorePazaryeriConverter.XmlClasses;

namespace ZorePazaryeriConverter
{
    public partial class TekkartConverter : Form
    {
        public TekkartConverter()
        {
            InitializeComponent();
        }
        Context context;
        private void TekkartConverter_Load(object sender, EventArgs e)
        {
            context = new Context();
            string[] degerler = Tag.ToString().Split(',');
            if (degerler[1] != "")
            {
                string acayip = degerler[1];
                Toplu seciliUrun = context.Toplu.FirstOrDefault(x => x.Kod2 == acayip);
                textBoxAciklama.Text = seciliUrun.Detail;
            }
            textBoxkategori.Text = "3216";
            textBoxKargolamaTipi.Text = "1";
            textBoxDesi.Text = "1";
            
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            CustomMessageBox customMessageBox = new CustomMessageBox();
            customMessageBox.Show();
            string acayip = Tag.ToString().Split(',')[1];
            List<Toplu> seciliUrunler = context.Toplu.Where(x => x.Kod2 == acayip).ToList();
            TekkartXmlClassList tekkartXmlClassList = new TekkartXmlClassList();
            
            List<string> tekUrun = new List<string>();
            foreach (Toplu urun in seciliUrunler)
            {
                if (urun.Stok.Split(',')[0] == "0" || urun.Renk == null || urun.Barcode == null || urun.Stok == null || urun.Stok == "" || urun.Kod12 == null || urun.Resim == null || urun.Resim == "")
                    continue;
                else if (int.Parse(urun.Stok.Split(',')[0]) < 15)
                    continue;
                string stokkodu = "TK" + context.Toplu.FirstOrDefault(x => x.Kod12 == urun.Kod12 & x.Kod2 == urun.Kod2).Barcode.ToString();
                if (tekUrun.FirstOrDefault() != urun.Kod12)
                {
                    TekkartXmlClass tekkartXmlClass = new TekkartXmlClass
                    {
                        Urunkod = stokkodu,
                        Aciklama = textBoxAciklama.Text,
                        AnaResim = urun.Resim,
                        Fiyat=decimal.Parse(textBoxSatisFiyati.Text),
                        Stok=int.Parse(urun.Stok.Split(',')[0]),
                        IndirimliFiyat=decimal.Parse(textBoxIndirimliFiyat.Text),
                        DovizTip=1,
                        Kargolamasuresi=int.Parse(textBoxKargolamaSuresi.Text),
                        UrunAd=urun.Kod12+" "+textBoxBaslik.Text,
                        KargolamaTipi=int.Parse(textBoxKargolamaTipi.Text),
                        Kategori= int.Parse(textBoxkategori.Text),
                        Marka ="Zore",
                        SonYayinTarihi="",
                        Desi=textBoxDesi.Text
                        

                    };
                    tekkartXmlClass.Varyantlar = TekkartVaryasyonEkle(urun, tekkartXmlClass).Varyantlar;

                    tekkartXmlClassList.Urunler.Add(tekkartXmlClass);
                    tekUrun = new List<string>();
                }

                tekUrun.Add(urun.Kod12);
            }
            tekkartXmlClassList.CreateXml("E", "Demo.xml");
            customMessageBox.Close();
            this.Close();
        }
        private TekkartXmlClass TekkartVaryasyonEkle(Toplu toplu,TekkartXmlClass tekkartXmlClass)
        {
            List<Toplu> ayniUrun = new List<Toplu>();
            List<string> resimler = new List<string>();
            List<Toplu> hata = context.Toplu.Where(x => x.Name == toplu.Name).ToList();
            foreach (Toplu urun in hata)
            {
                if (urun.Stok.Split(',')[0] == "0" || urun.Renk == null || urun.Barcode == null || urun.Stok == null || urun.Stok == "" || urun.Kod12 == null || urun.Resim == null || urun.Resim == "")
                    continue;
                tekkartXmlClass.Varyantlar.Varyantlar.Add(new TekkartXmlClassVaryant
                {
                    Grup = "Renk",
                    Fiyat = decimal.Parse(textBoxSatisFiyati.Text),
                    Ad = urun.Renk,
                    Stok =int.Parse(urun.Stok.Split(',')[0])
                });
                tekkartXmlClass.AnaResim = toplu.Resim;
                resimler.Add(urun.Resim);
            }
            int sayac = 1;
            for (int i = 1; i < 7; i++)
            {
                if (i == 6)
                    tekkartXmlClass.Resim6 = "";
                else if (i == 5)
                    tekkartXmlClass.Resim5 = "";
                else if (i == 4)
                    tekkartXmlClass.Resim4 = "";
                else if (i == 3)
                    tekkartXmlClass.Resim3 = "";
                else if (i == 2)
                    tekkartXmlClass.Resim2 = "";
                else if (i == 1)
                    tekkartXmlClass.Resim1 = "";
            }
            foreach (string resim in resimler)
            {
                if (sayac == 1)
                    tekkartXmlClass.Resim1 = resim;
                else if (sayac == 2)
                    tekkartXmlClass.Resim2 = resim;
                else if (sayac == 3)
                    tekkartXmlClass.Resim3 = resim;
                else if (sayac == 4)
                    tekkartXmlClass.Resim4 = resim;
                else if (sayac == 5)
                    tekkartXmlClass.Resim5 = resim;
                else if (sayac == 6)
                    tekkartXmlClass.Resim6 = resim;
                else
                    break;
                sayac++;
               
            }
            return tekkartXmlClass;
        }
    }
}
