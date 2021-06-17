using converter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZorePazaryeriConverter.Entity;
using Excel = Microsoft.Office.Interop.Excel;
namespace ZorePazaryeriConverter
{
    public partial class GittigidiyorConvert : Form
    {
        Excel.Application xlApp = new Excel.Application();
        private void GittigidiyorConvert_Load(object sender, EventArgs e)
        {
            gonderiyapilacakzamantextbox.Text = "tomorrow";
            SayfaDuzeniNoTextbox.Text = "5";
            GTINTextbox.Text = "190198072078";
            YeniKatalogiNoTextbox.Text = "";
            kargosirketiTextbox.Text = "aras";
            UrunFormatiTextbox.Text = "S";
            kategoritexbox.Text = "taf";
            SureTextbox.Text = "360";
            Context context = new Entity.Context();
            string[] degerler = Tag.ToString().Split(',');
            if (degerler[1] != "")
            {
                string acayip = degerler[1];
                Toplu seciliUrun = context.Toplu.FirstOrDefault(x => x.Kod2 == acayip);
                aciklamaTextbox.Text= seciliUrun.Detail;

            }
        }
        public GittigidiyorConvert()
        {
            InitializeComponent();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            Context context = new Context();
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
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Kategori No";
                xlWorkSheet.Cells[1, 2] = "Dükkan No";
                xlWorkSheet.Cells[1, 3] = "Stok No";
                xlWorkSheet.Cells[1, 4] = "Başlık";
                xlWorkSheet.Cells[1, 5] = "Açıklama";
                xlWorkSheet.Cells[1, 6] = "1. Fotoğraf";
                xlWorkSheet.Cells[1, 7] = "2. Fotoğraf";
                xlWorkSheet.Cells[1, 8] = "3. Fotoğraf";
                xlWorkSheet.Cells[1, 9] = "4. Fotoğraf";
                xlWorkSheet.Cells[1, 10] = "5. Fotoğraf";
                xlWorkSheet.Cells[1, 11] = "6. Fotoğraf";
                xlWorkSheet.Cells[1, 12] = "7. Fotoğraf";
                xlWorkSheet.Cells[1, 13] = "8. Fotoğraf";
                xlWorkSheet.Cells[1, 14] = "Sayfa Düzeni No";
                xlWorkSheet.Cells[1, 15] = "Katalog No";
                xlWorkSheet.Cells[1, 16] = "Katalog Detay";
                xlWorkSheet.Cells[1, 17] = "Ürün Formatı";
                xlWorkSheet.Cells[1, 18] = "Hemen Al Fiyatı";
                xlWorkSheet.Cells[1, 19] = "Piyasa Satış Fiyatı";
                xlWorkSheet.Cells[1, 20] = "Süre (Gün)";
                xlWorkSheet.Cells[1, 21] = "Ürün Adeti";
                xlWorkSheet.Cells[1, 22] = "Şehir No";
                xlWorkSheet.Cells[1, 23] = "Kargo Ölçüleri";
                xlWorkSheet.Cells[1, 24] = "Kargo Desi";
                xlWorkSheet.Cells[1, 25] = "Kargo Şirketleri";
                xlWorkSheet.Cells[1, 26] = "Kargo Ücreti";
                xlWorkSheet.Cells[1, 27] = "Gönderi Yapacağınız Zaman";
                xlWorkSheet.Cells[1, 28] = "Gönderi Yapılacak Alanlar";
                xlWorkSheet.Cells[1, 29] = "Ürün Seçeneği";
                xlWorkSheet.Cells[1, 30] = "Ürün Özelliği";
                xlWorkSheet.Cells[1, 31] = "Üretici Parça Numarası (MPN)";
                xlWorkSheet.Cells[1, 32] = "Global Ticari Öğe Numarası (GTIN)";
                xlWorkSheet.Cells[1, 33] = "Yeni Katalog No";
                int satir = 2;
                int sutun = 1;
                List<Toplu> kontrol = new List<Toplu>();
                int don = 0;
                foreach (Toplu toplu in seciliUrunler.ToArray())
                {
                    string stokkodu = "TKN" + context.Toplu.FirstOrDefault(x => x.Kod12 == toplu.Kod12).Barcode.ToString();
                    if (toplu.Stok.Split(',')[0] == "0" || toplu.Renk == null || toplu.Barcode == null || toplu.Stok == null || toplu.Stok == "" || toplu.Kod12 == "")
                        continue;
                    if (kontrol.FirstOrDefault(x => x.Name == toplu.Name) != null)
                        continue;
                    kontrol.Add(toplu);
                    string barcode = "TKN" + toplu.Barcode.Substring(3, 10);
                    xlWorkSheet.Cells[satir, sutun++] = kategoritexbox.Text;
                    xlWorkSheet.Cells[satir, sutun++] = "0";//dükkan no
                    xlWorkSheet.Cells[satir, sutun++] = stokkodu;//stok no
                    xlWorkSheet.Cells[satir, sutun++] = toplu.Kod12+" "+basliktextbox.Text;
                    xlWorkSheet.Cells[satir, sutun++] = aciklamaTextbox.Text;
                    int sayac = 0;
                    //ürün fotografları
                    foreach (Toplu resim in context.Toplu.Where(x => x.Name==toplu.Name&x.Renk==null))
                    {
                        
                        if (sayac++ < 9&resim.Renk==null)
                            xlWorkSheet.Cells[satir, sutun++] = resim.Resim;
                    }
                    if (sutun != 13)
                    {
                        int don2 = 13-sutun;
                        for (int i = 0; i < don2; i++)
                        {
                            xlWorkSheet.Cells[satir, sutun++] = "";
                        }
                        sutun++;
                    }
                    decimal hemenAlFiyati=0;
                    decimal piyasaSatisFiyati=0;
                    try
                    {
                        hemenAlFiyati = decimal.Parse(HemenAlTexbox.Text);
                        piyasaSatisFiyati = decimal.Parse(PiyasaSatisFiyatiTextbox.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Fiyat Bilgisi yanlıştır.");
                        return;
                    }
                    xlWorkSheet.Cells[satir, sutun++] = SayfaDuzeniNoTextbox.Text;
                    xlWorkSheet.Cells[satir, sutun++] = "";//katalog no
                    xlWorkSheet.Cells[satir, sutun++] = "";//katalog detay
                    xlWorkSheet.Cells[satir, sutun++] = UrunFormatiTextbox.Text;//Ürün Formatı
                    xlWorkSheet.Cells[satir, sutun++] = hemenAlFiyati;
                    xlWorkSheet.Cells[satir, sutun++] = piyasaSatisFiyati;
                    xlWorkSheet.Cells[satir, sutun++] = SureTextbox.Text;
                    xlWorkSheet.Cells[satir, sutun++] = toplu.Stok.Split(',')[0];
                    xlWorkSheet.Cells[satir, sutun++] = "06";//şehir no
                    xlWorkSheet.Cells[satir, sutun++] = "";//Kargo ölçüleri
                    xlWorkSheet.Cells[satir, sutun++] = "";//Kargo Desi
                    xlWorkSheet.Cells[satir, sutun++] = kargosirketiTextbox.Text;
                    xlWorkSheet.Cells[satir, sutun++] = "S";//Kargo Ücreti
                    xlWorkSheet.Cells[satir, sutun++] = gonderiyapilacakzamantextbox.Text;
                    xlWorkSheet.Cells[satir, sutun++] = "country";//gönderi yapılacak alan
                    //Ürün Seçeneği
                    string yaz = "";
                    try
                    {
                        int tut = don;
                        while (true)
                        {
                            Toplu renk = seciliUrunler.ToArray()[tut++];
                            if (renk.Renk == null)
                                continue;
                            int stok = int.Parse(renk.Stok.Split(',')[0]);
                            if (stok > 999)
                                stok = 998;
                            if (stok < 15)
                                stok = 0;
                            stokkodu= "TKN" + toplu.Barcode.Substring(3, 10);
                            int cikar = renk.Renk.IndexOf("Koyu");
                            if (cikar >= 0)
                                renk.Renk = renk.Renk.Replace("Koyu", "").Trim();
                            yaz += "Renk:"+renk.Renk+","+stok.ToString()+","+stokkodu+"," + renk.Resim+";";
                            Toplu kontrol2 = seciliUrunler.ToArray()[tut++];
                            if (kontrol2.Kod12 != renk.Kod12)
                                break;
                            tut--;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    xlWorkSheet.Cells[satir, sutun++] = yaz;//Seçenekler
                    xlWorkSheet.Cells[satir, sutun++] = "Marka::Zore|Durum::Sıfır";
                    xlWorkSheet.Cells[satir, sutun++] = "";//Üretici Parça Numarası (MPN)
                    xlWorkSheet.Cells[satir, sutun++] = "";//Global Ticari Öğe Numarası (GTIN)
                    xlWorkSheet.Cells[satir, sutun++] = "";//Yeni Katalog No
                    don++;
                    satir++;
                    sutun = 1;
                }
                xlWorkBook.SaveAs("E:\\csharp-Excel.xls");
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }

            customMessageBox.Close();
            this.Close();
            MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xls");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
