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
    public partial class HepsiburadaConverter : Form
    {
        public HepsiburadaConverter()
        {
            InitializeComponent();
        }
        Context context = new Context();
        CustomMessageBox customMessageBox;
        Excel.Application xlApp = new Excel.Application();
        private void HepsiburadaConverter_Load(object sender, EventArgs e)
        {
            string[] degerler = Tag.ToString().Split(',');
            if (degerler[1] != "")
            {
                string acayip = degerler[1];
                Toplu seciliUrun = context.Toplu.FirstOrDefault(x => x.Kod2 == acayip);
                textBoxAciklama.Text = seciliUrun.Detail;
                textBoxMarka.Text = "Zore";
                textBoxGarantiSuresi.Text = "1";
                textBoxKdv.Text = "18";
                textBoxMalzemeTuru.Text = "Silikon";
                textBoxKilifTipi.Text = "Arka Kapak";
                textBoxDesi.Text = "1";
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            customMessageBox = new CustomMessageBox();
            customMessageBox.Show();
            Urunler N11Urun = new Urunler();
            string acayip = Tag.ToString().Split(',')[1];
            List<Toplu> seciliUrunler = context.Toplu.Where(x => x.Kod2 == acayip).ToList();
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "Ürün Adı";
            xlWorkSheet.Cells[1, 2] = "Satıcı Stok Kodu";
            xlWorkSheet.Cells[1, 3] = "Barkod";
            xlWorkSheet.Cells[1, 4] = "Varyant Grup Id";
            xlWorkSheet.Cells[1, 5] = "Ürün Açıklaması";
            xlWorkSheet.Cells[1, 6] = "Marka";
            xlWorkSheet.Cells[1, 7] = "Desi";
            xlWorkSheet.Cells[1, 8] = "KDV";
            xlWorkSheet.Cells[1, 9] = "Garanti Süresi (Ay)";
            xlWorkSheet.Cells[1, 10] = "Görsel1";
            xlWorkSheet.Cells[1, 11] = "Görsel2";
            xlWorkSheet.Cells[1, 12] = "Görsel3";
            xlWorkSheet.Cells[1, 13] = "Görsel4";
            xlWorkSheet.Cells[1, 14] = "Görsel5";
            xlWorkSheet.Cells[1, 15] = "Fiyat";
            xlWorkSheet.Cells[1, 16] = "Stok";
            xlWorkSheet.Cells[1, 17] = "Uyumlu Model";
            xlWorkSheet.Cells[1, 18] = "Renk";
            xlWorkSheet.Cells[1, 19] = "Garanti Tipi";
            xlWorkSheet.Cells[1, 20] = "Garanti Tipi";
            xlWorkSheet.Cells[1, 21] = "Telefon Modeli";
            xlWorkSheet.Cells[1, 22] = "Su Geçirmezlik";
            xlWorkSheet.Cells[1, 23] = "Ürün  Kodu";
            xlWorkSheet.Cells[1, 24] = "Kılıf Tipi";
            xlWorkSheet.Cells[1, 25] = "Malzeme Türü";
            xlWorkSheet.Cells[1, 26] = "Uyumlu Marka";
            int satir = 2;
            int sutun = 1;
            foreach (Toplu toplu in seciliUrunler)
            {
                string stokkodu = "TK" + context.Toplu.FirstOrDefault(x => x.Kod12 == toplu.Kod12 & x.Kod2 == toplu.Kod2).Barcode.ToString();
                if (toplu.Barcode==""||toplu.Stok.Split(',')[0] == "0" || toplu.Renk == null || toplu.Barcode == null || toplu.Stok == null || toplu.Stok == "" || toplu.Kod12 == null)
                    continue;
                else if (int.Parse(toplu.Stok.Split(',')[0]) < 15)
                    continue;
                string barcode = "TK" + toplu.Barcode.Substring(2, 10);
                toplu.Barcode = "TKN" + toplu.Barcode;
                xlWorkSheet.Cells[satir, sutun++] = toplu.Kod12 + " " + textBoxBaslik.Text;//ürün adı
                xlWorkSheet.Cells[satir, sutun++] = barcode;//satıcı stok kodu
                xlWorkSheet.Cells[satir, sutun++] = "'"+toplu.Barcode;//Barcode
                xlWorkSheet.Cells[satir, sutun++] = stokkodu;//Varyant gruop ıd
                string aciklama= textBoxAciklama.Text;
                aciklama = aciklama.Replace("youtube","");
                xlWorkSheet.Cells[satir, sutun++] = aciklama;
                xlWorkSheet.Cells[satir, sutun++] = textBoxMarka.Text;
                xlWorkSheet.Cells[satir, sutun++] = textBoxDesi.Text;
                xlWorkSheet.Cells[satir, sutun++] = textBoxKdv.Text;
                xlWorkSheet.Cells[satir, sutun++] = textBoxGarantiSuresi.Text;
                xlWorkSheet.Cells[satir, sutun++] = toplu.Resim;//göresel 1
                xlWorkSheet.Cells[satir, sutun++] = "";//göresel 2
                xlWorkSheet.Cells[satir, sutun++] = "";//göresel 3
                xlWorkSheet.Cells[satir, sutun++] = "";//göresel 4
                xlWorkSheet.Cells[satir, sutun++] = "";//göresel 5
                try
                {
                    xlWorkSheet.Cells[satir, sutun++] = decimal.Parse(textBoxFiyat.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen Fiyat Bilgisini kontrol edin");
                    customMessageBox.Close();
                    return;
                }
                xlWorkSheet.Cells[satir, sutun++] = toplu.Stok.Split(',')[0];
                xlWorkSheet.Cells[satir, sutun++] = "";//Uyumlu model
                xlWorkSheet.Cells[satir, sutun++] = toplu.Renk;
                xlWorkSheet.Cells[satir, sutun++] = "";//Garnti tipi
                xlWorkSheet.Cells[satir, sutun++] = "";//Garnti tipi
                xlWorkSheet.Cells[satir, sutun++] = toplu.Kod12;//Telefon Modeli
                xlWorkSheet.Cells[satir, sutun++] = "Var";//Su geçirmezlik
                xlWorkSheet.Cells[satir, sutun++] = "";//Ürün Kodu
                xlWorkSheet.Cells[satir, sutun++] = textBoxKilifTipi.Text;
                xlWorkSheet.Cells[satir, sutun++] = textBoxMalzemeTuru.Text;
                xlWorkSheet.Cells[satir, sutun++] = "";//Uymlu marka
                satir++;
                sutun = 1;
            }
            xlWorkBook.SaveAs("E:\\csharp-Excel.xlsx");
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            customMessageBox.Close();
            this.Close();
        }
    }
}
