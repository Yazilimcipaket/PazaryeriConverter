
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZorePazaryeriConverter;
using ZorePazaryeriConverter.Entity;
using ZorePazaryeriConverter.Static;

namespace converter
{
    public partial class N11ConvertForm : Form
    {
        public N11ConvertForm()
        {
            InitializeComponent();
        }
        Context context = new Context();
        private void N11ConvertForm_Load(object sender, EventArgs e)
        {
            string[] degerler = Tag.ToString().Split(',');
            if (degerler[0] != "KAPAK")
            {
                EkranKoruyucu.Hide();
            }
            if (degerler[1] != "")
            {
                string acayip = degerler[1];
                Toplu seciliUrun = context.Toplu.FirstOrDefault(x => x.Kod2 == acayip);
                textBoxAciklama.Text = seciliUrun.Detail;
                textBoxSatisBaslangicTarihi.Text = "22/12/2020";
                textBoxFiyat.Text = "35.90";
                textBoxKategori.Text = "Telefon & amp; Aksesuarları & gt; Cep Telefonu Aksesuarları & gt; Kapak";
                textBoxKategoriNo.Text = "1000489";
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            CustomMessageBox customMessageBox = new CustomMessageBox();
            customMessageBox.Show();

            List<Urunler> n11Urunler = new List<Urunler>();
            if (this.Tag.ToString() == "")
            {
                MessageBox.Show("Boş");
            }
            else
            {
                Urunler N11Urun = new Urunler();
                string acayip = Tag.ToString().Split(',')[1];
                List<Toplu> seciliUrunler = context.Toplu.Where(x => x.Kod2 == acayip).ToList();
                List<Toplu> convert = new List<Toplu>();
                Resimler resimler = new Resimler();
               
                foreach (Toplu secili in seciliUrunler)
                {

                    if (secili.Renk == null || secili.Stok == "")
                    {
                        continue;
                    }
                    
                    else if (convert.FirstOrDefault(x => x.Name == secili.Name) == null & convert.Count != 0)
                    {
                        Toplu[] nullResim = seciliUrunler.Where(x => x.Name == convert.FirstOrDefault().Name).ToArray();
                        try
                        {
                            resimler.Resim.Add(nullResim[1].Resim);
                            resimler.Resim.Add(nullResim[2].Resim);
                        }
                        catch (Exception)
                        {
                            resimler.Resim.Add(nullResim[0].Resim);
                        }

                        string baslik = convert.FirstOrDefault().Kod12;
                        if (baslik == null)
                            baslik = convert.FirstOrDefault().Marka + " " + convert.FirstOrDefault().Model;
                        if (baslik == null)
                            continue;
                        Urun n11Urun = new Urun()
                        {
                            UrunKodu = N11ConvertEkAyarlar.UrunKodu,
                            Kod = convert.FirstOrDefault().Supplier_code,
                            Baslik = baslik + " " + textBoxBaslik.Text,
                            AltBaslik = textBoxAltBaslik.Text,
                            Aciklama = textBoxAciklama.Text,
                            UrunOnayi = "1",
                            HazirlamaSuresi = textBoxHazirlanmaSuresi.Text,
                            Kategori = new Kategori
                            {
                                Isim = textBoxKategori.Text,
                                No = textBoxKategoriNo.Text,
                                Ozellikler = new Ozellikler
                                {
                                    Ozellik = ""
                                }
                            },
                            Fiyat = textBoxFiyat.Text,
                            SatisBaslangicTarihi = textBoxSatisBaslangicTarihi.Text,
                            TeslimatSablonu = textBoxTeslimatSablonu.Text,
                            IndirimTutari = N11ConvertEkAyarlar.IndirimliFiyat,
                            YerliUretim = "0",
                            ParaBirimi = "TL",
                            GroupAttribute = "",
                            GroupItemCode = "",
                            ItemName = "",
                        };
                        Stoklar n11Stoklar = new Stoklar();
                        if (!EkranKoruyucu.Checked)
                        {
                            foreach (Toplu item in convert)
                            {
                                resimler.Resim.Add(item.Resim);
                                Stok stok = new Stok
                                {
                                    Miktar = item.Stok.Split(',')[0],
                                    StokFiyati = textBoxFiyat.Text,
                                    Bundle = "true"
                                };
                                stok.Ozellik.Add(new Ozellik
                                {
                                    Isim = "Renk",
                                    Text = item.Renk
                                });
                                if (stok.Miktar == "0")
                                    continue;
                                n11Stoklar.Stok.Add(stok);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                foreach (Toplu item in convert)
                                {
                                    if (i == 0)
                                    {

                                        resimler.Resim.Add(item.Resim);
                                        Stok stok = new Stok
                                        {
                                            Miktar = item.Stok.Split(',')[0],
                                            StokFiyati = textBoxFiyat.Text,
                                            Bundle = "true"
                                        };
                                        stok.Ozellik.Add(new Ozellik
                                        {
                                            Isim = "Kampanya",
                                            Text = "Sadece Kılıf"
                                        });
                                        stok.Ozellik.Add(new Ozellik
                                        {
                                            Isim = "Renk",
                                            Text = item.Renk
                                        });
                                        if (stok.Miktar == "0")
                                            continue;
                                        n11Stoklar.Stok.Add(stok);
                                    }
                                    else if (i == 1)
                                    {
                                        if (context.Toplu.FirstOrDefault(x => x.Model == item.Model & x.Kod2 == "ZORE MAXİ GLASS") == null)
                                            if(context.Toplu.FirstOrDefault(x => x.Kod12 == item.Kod12 & x.Kod2 == "ZORE MAXİ GLASS") == null)
                                                continue;
                                        Stok stok = new Stok
                                        {
                                            Miktar = item.Stok.Split(',')[0],
                                            StokFiyati = Varsayılan.TemperliCamFiyat,
                                            Bundle = "true"
                                        };
                                        stok.Ozellik.Add(new Ozellik
                                        {
                                            Isim = "Kampanya",
                                            Text = "Kılıf + Temperli cam"
                                        });

                                        stok.Ozellik.Add(new Ozellik
                                        {
                                            Isim = "Renk",
                                            Text = item.Renk
                                        });
                                        if (stok.Miktar == "0")
                                            continue;
                                        n11Stoklar.Stok.Add(stok);
                                    }
                                    else if (i == 2)
                                    {
                                        if (context.Toplu.FirstOrDefault(x => x.Model == item.Model & x.Kod2 == "ZORE BLUE NANO") == null)
                                             if (context.Toplu.FirstOrDefault(x => x.Kod12 == item.Kod12 & x.Kod2 == "ZORE BLUE NANO") == null)
                                                     continue;
                                        Stok stok = new Stok
                                        {
                                            Miktar = item.Stok.Split(',')[0],
                                            StokFiyati = Varsayılan.BlueNanoCamFiyat,
                                            Bundle = "true"
                                        };
                                        stok.Ozellik.Add(new Ozellik
                                        {
                                            Isim = "Kampanya",
                                            Text = "Kılıf + Blue Nano"
                                        });
                                        stok.Ozellik.Add(new Ozellik
                                        {
                                            Isim = "Renk",
                                            Text = item.Renk
                                        });
                                        if (stok.Miktar == "0")
                                            continue;
                                        n11Stoklar.Stok.Add(stok);

                                    }
                                    else if (i == 3)
                                    {
                                        if (context.Toplu.FirstOrDefault(x => x.Model == item.Model & x.Kod2 == "ZORE MİCRO NANO") == null)
                                                if (context.Toplu.FirstOrDefault(x =>x.Kod12==item.Kod12 & x.Kod2 == "ZORE MİCRO NANO") == null)
                                                      continue;
                                        Stok stok = new Stok
                                        {
                                            Miktar = item.Stok.Split(',')[0],
                                            StokFiyati = Varsayılan.NanoCamFiyat,
                                            Bundle = "true"
                                        };
                                        stok.Ozellik.Add(new Ozellik
                                        {
                                            Isim = "Kampanya",
                                            Text = "Kılıf + Nano"
                                        });

                                        stok.Ozellik.Add(new Ozellik
                                        {
                                            Isim = "Renk",
                                            Text = item.Renk
                                        });
                                        if (stok.Miktar == "0")
                                            continue;
                                        n11Stoklar.Stok.Add(stok);

                                    }
                                    else if (i == 4)
                                    {
                                        if (context.Toplu.FirstOrDefault(x => x.Model == item.Model & x.Kod2 == "ZORE KENARLARI KIRILMAYA DAYANIKLI 5D GLASS") == null)
                                                if (context.Toplu.FirstOrDefault(x => x.Kod12 == item.Kod12 & x.Kod2 == "ZORE KENARLARI KIRILMAYA DAYANIKLI 5D GLASS") == null)
                                                       continue;
                                        Stok stok = new Stok
                                        {
                                            Miktar = item.Stok.Split(',')[0],
                                            StokFiyati = Varsayılan.TamKaplayanCamFiyat,
                                            Bundle = "true"
                                        };
                                        stok.Ozellik.Add(new Ozellik
                                        {
                                            Isim = "Kampanya",
                                            Text = "Kılıf + 5D cam"
                                        });

                                        stok.Ozellik.Add(new Ozellik
                                        {
                                            Isim = "Renk",
                                            Text = item.Renk
                                        });
                                        if (stok.Miktar == "0")
                                            continue;
                                        n11Stoklar.Stok.Add(stok);
                                    }
                                }
                            }
                        }
                        resimler.Resim.Add(context.Toplu.FirstOrDefault(x => x.Kod2 == "ZORE MAXİ GLASS").Resim);
                        resimler.Resim.Add(context.Toplu.FirstOrDefault(x => x.Kod2 == "ZORE BLUE NANO").Resim);
                        resimler.Resim.Add(context.Toplu.FirstOrDefault(x => x.Kod2 == "ZORE MİCRO NANO").Resim);
                        resimler.Resim.Add(context.Toplu.FirstOrDefault(x => x.Kod2 == "ZORE KENARLARI KIRILMAYA DAYANIKLI 5D GLASS").Resim);
                        n11Urun.Stoklar = n11Stoklar;
                        n11Urun.Resimler = resimler;
                        N11Urun.Urun.Add(n11Urun);
                        if (N11Urun.Urun.Count == 100)
                        {
                            n11Urunler.Add(N11Urun);
                            N11Urun = new Urunler();
                        }

                        resimler = new Resimler();
                        convert = new List<Toplu>();
                        convert.Add(secili);
                        resimler.Resim.Add(secili.Resim);
                    }
                    else
                    {
                        convert.Add(secili);
                    }
                        
                   
                }
                if (N11Urun.Urun.Count != 0)
                    n11Urunler.Add(N11Urun);
            }
           
            int sayac1 = 1;
            foreach (Urunler item in n11Urunler)
            {
                item.CreateXml(N11ConvertEkAyarlar.DosyaYolu, N11ConvertEkAyarlar.DosyaIsmi + sayac1++);
            }
            MessageBox.Show("Xml Dönüştürüldü");
            customMessageBox.Close();
            this.Close();

        }

        private void EkranKoruyucu_CheckedChanged(object sender, EventArgs e)
        {
            if (EkranKoruyucu.Checked)
            {
                Varyasyon varyasyon = new Varyasyon();
                varyasyon.ShowDialog();
            }

        }

        private void EkAyarlar_Click(object sender, EventArgs e)
        {
            N11ConvertEkAyarlarForm n11ConvertEkAyarlarForm = new N11ConvertEkAyarlarForm();
            n11ConvertEkAyarlarForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Context context = new Context();
            string acayip = Tag.ToString().Split(',')[1];
            List<JsonProduct> jsonProducts = new List<JsonProduct>();
            Urunler n11Urunler = new Urunler();
            jsonProducts = context.JsonProduct.Where(x => x.KOD2 == acayip).ToList();
            foreach (JsonProduct jsonProduct in jsonProducts)
            {
                Resimler resimler = new Resimler();
                resimler.Resim = new List<string>();
                XmlProduct xmlProduct = context.XmlProduct.FirstOrDefault(x => x.Code == jsonProduct.KOD19);
                if (xmlProduct == null)
                    continue;
                foreach (var item in xmlProduct.XmlImage)
                {
                    if (resimler.Resim.Count < 7)
                        resimler.Resim.Add(item.Img_item);
                }
                string baslik = "";
                if (jsonProduct.KOD4 != null || jsonProduct.KOD7 != null)
                    baslik = jsonProduct.KOD4 + " " + jsonProduct.KOD7;
                else
                    baslik = jsonProduct.KOD12;
                Urun n11Urun = new Urun()
                {
                    UrunKodu = N11ConvertEkAyarlar.UrunKodu,
                    Kod = xmlProduct.Supplier_code,
                    Baslik = baslik + " " + textBoxBaslik.Text,
                    AltBaslik = textBoxAltBaslik.Text,
                    Aciklama = textBoxAciklama.Text,
                    UrunOnayi = "1",
                    HazirlamaSuresi = textBoxHazirlanmaSuresi.Text,
                    Kategori = new Kategori
                    {
                        Isim = textBoxKategori.Text,
                        No = textBoxKategoriNo.Text,
                        Ozellikler = new Ozellikler
                        {
                            Ozellik = ""
                        }
                    },
                    Fiyat = textBoxFiyat.Text,
                    SatisBaslangicTarihi = textBoxSatisBaslangicTarihi.Text,
                    TeslimatSablonu = textBoxTeslimatSablonu.Text,
                    IndirimTutari = N11ConvertEkAyarlar.IndirimliFiyat,
                    YerliUretim = "0",
                    ParaBirimi = "TL",
                    GroupAttribute = "",
                    GroupItemCode = "",
                    ItemName = "",
                };
                Stoklar n11Stoklar = new Stoklar();
                n11Stoklar.Stok = new List<Stok>();
                if (xmlProduct.XmlSubProduct.Count != 0)
                {
                    int sayac = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        foreach (XmlSubProduct subProduct in xmlProduct.XmlSubProduct)
                        {
                            foreach (XmlImage item in context.XmlImage.Where(x => x.ProductID == subProduct.ProductID))
                            {
                                resimler.Resim.Add(item.Img_item);
                            }
                            if (sayac == 0)
                            {
                                Stok stok = new Stok
                                {
                                    Miktar = jsonProduct.ENVANTER.ToString().Split(',')[0],
                                    StokFiyati = textBoxFiyat.Text,
                                    Bundle = "true"
                                };
                                stok.Ozellik.Add(new Ozellik
                                {
                                    Isim = "Kampanya",
                                    Text = "Sadece Kılıf"
                                });
                                stok.Ozellik.Add(new Ozellik
                                {
                                    Isim = "Renk",
                                    Text = subProduct.Type1
                                });
                                if (stok.Miktar == "0")
                                    continue;
                                n11Stoklar.Stok.Add(stok);
                            }
                            if (sayac == 1 & context.JsonProduct.FirstOrDefault(x => x.KOD2 == "ZORE MAXİ GLASS" && x.KOD12 == jsonProduct.KOD12) != null)
                            {
                                Stok stok = new Stok
                                {
                                    Miktar = jsonProduct.ENVANTER.ToString().Split(',')[0],
                                    StokFiyati = textBoxFiyat.Text,
                                    Bundle = "true"
                                };
                                stok.Ozellik.Add(new Ozellik
                                {
                                    Isim = "Kampanya",
                                    Text = "Temperli Cam"
                                });
                                stok.Ozellik.Add(new Ozellik
                                {
                                    Isim = "Renk",
                                    Text = subProduct.Type1
                                });
                                if (stok.Miktar == "0")
                                    continue;
                                n11Stoklar.Stok.Add(stok);

                            }
                            else if (sayac == 2 & context.JsonProduct.FirstOrDefault(x => x.KOD2 == "ZORE BLUE NANO" && x.KOD12 == jsonProduct.KOD12) != null)
                            {
                                Stok stok = new Stok
                                {
                                    Miktar = jsonProduct.ENVANTER.ToString().Split(',')[0],
                                    StokFiyati = textBoxFiyat.Text,
                                    Bundle = "true"
                                };
                                stok.Ozellik.Add(new Ozellik
                                {
                                    Isim = "Kampanya",
                                    Text = "Blue Nano"
                                });
                                stok.Ozellik.Add(new Ozellik
                                {
                                    Isim = "Renk",
                                    Text = subProduct.Type1
                                });
                                if (stok.Miktar == "0")
                                    continue;
                                n11Stoklar.Stok.Add(stok);
                            }
                            else if (sayac == 3 & context.JsonProduct.FirstOrDefault(x => x.KOD2 == "ZORE MİCRO NANO" && x.KOD12 == jsonProduct.KOD12) != null)
                            {
                                Stok stok = new Stok
                                {
                                    Miktar = jsonProduct.ENVANTER.ToString().Split(',')[0],
                                    StokFiyati = textBoxFiyat.Text,
                                    Bundle = "true"
                                };
                                stok.Ozellik.Add(new Ozellik
                                {
                                    Isim = "Kampanya",
                                    Text = "Nano"
                                });
                                stok.Ozellik.Add(new Ozellik
                                {
                                    Isim = "Renk",
                                    Text = subProduct.Type1
                                });
                                if (stok.Miktar == "0")
                                    continue;
                                n11Stoklar.Stok.Add(stok);
                            }
                            else if (sayac == 4 & context.JsonProduct.FirstOrDefault(x => x.KOD2 == "ZORE KENARLARI KIRILMAYA DAYANIKLI 5D GLASS" && x.KOD12 == jsonProduct.KOD12) != null)
                            {
                                Stok stok = new Stok
                                {
                                    Miktar = jsonProduct.ENVANTER.ToString().Split(',')[0],
                                    StokFiyati = textBoxFiyat.Text,
                                    Bundle = "true"
                                };
                                stok.Ozellik.Add(new Ozellik
                                {
                                    Isim = "Kampanya",
                                    Text = "5D Cam"
                                });
                                stok.Ozellik.Add(new Ozellik
                                {
                                    Isim = "Renk",
                                    Text = subProduct.Type1
                                });
                                if (stok.Miktar == "0")
                                    continue;
                                n11Stoklar.Stok.Add(stok);
                            }

                        }
                        sayac++;
                    }

                }
                else
                {
                    Stok stok = new Stok
                    {
                        Miktar = jsonProduct.ENVANTER.ToString().Split(',')[0],
                        StokFiyati = textBoxFiyat.Text,
                        Bundle = "true"
                    };
                    n11Stoklar.Stok.Add(stok);
                }
                n11Urun.Stoklar = n11Stoklar;
                n11Urun.Resimler = resimler;
                if (n11Urunler.Urun.FirstOrDefault(x => x.Baslik == n11Urun.Baslik) == null)
                    n11Urunler.Urun.Add(n11Urun);

            }
            n11Urunler.CreateXml();
        }
    }
}
