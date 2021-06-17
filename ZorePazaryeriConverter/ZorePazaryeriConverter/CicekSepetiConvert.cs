using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZorePazaryeriConverter.Entity;
using System.Runtime.InteropServices;
using converter;

namespace ZorePazaryeriConverter
{
    public partial class CicekSepetiConvert : Form
    {
        public CicekSepetiConvert()
        {
            InitializeComponent();
        }
        Context context = new Context();
        
        Excel.Application xlApp = new Excel.Application();
        CustomMessageBox customMessageBox;
       
        private void CicekSepetiConvert_Load(object sender, EventArgs e)
        {
            customMessageBox = new CustomMessageBox();
          
            string[] degerler = Tag.ToString().Split(',');
            if (degerler[1] != "")
            {
                string acayip = degerler[1];
                Toplu seciliUrun = context.Toplu.FirstOrDefault(x => x.Kod2 == acayip);
                textBoxAciklama.Text = seciliUrun.Detail;
            }
            textBoxTeslimattipi.Text = "2";
            textBoxTeslimatturu.Text = "4";
            customMessageBox.Close();
        }
        private void Convert_Click(object sender, EventArgs e)
        {
            CicekSepetiRenk cicekSepetiRenk = new CicekSepetiRenk();
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
            xlWorkSheet.Cells[1, 1] = "Tedarikçi Ürün Stok Kodu";
            xlWorkSheet.Cells[1, 2] = "Ürün Adı";
            xlWorkSheet.Cells[1, 3] = "Tedarikçi Varyant Stok Kodu";
            xlWorkSheet.Cells[1, 4] = "Barkod";
            xlWorkSheet.Cells[1, 5] = "Varyant Yapan Özellikler";
            xlWorkSheet.Cells[1, 6] = "Kişiselleştirilebilir Özellikler";
            xlWorkSheet.Cells[1, 7] = "Ürün Özellikleri";
            xlWorkSheet.Cells[1, 8] = "Stok Miktarı";
            xlWorkSheet.Cells[1, 9] = "KDV Dahil Satış Fiyatı";
            xlWorkSheet.Cells[1, 10] = "KDV Dahil Üstü Çizili Fiyat";
            xlWorkSheet.Cells[1, 11] = "Ürün Görseli";
            xlWorkSheet.Cells[1, 12] = "Teslimat Tipi";
            xlWorkSheet.Cells[1, 13] = "Teslimat Türü";
            xlWorkSheet.Cells[1, 14] = "Açıklama";
            xlWorkSheet.Cells[1, 14] = "Youtube Linki";
            int satir = 2;
            int sutun = 1;
            List<Toplu> gidipgelme = context.Toplu.ToList();
            
            foreach (Toplu toplu in seciliUrunler)
            {
               
                string stokkodu = "TK" + gidipgelme.FirstOrDefault(x => x.Kod12 == toplu.Kod12 & x.Kod2 == toplu.Kod2).Barcode.ToString().Substring(2, 10);
                if (toplu.Stok.Split(',')[0] == "0" || toplu.Renk == null || toplu.Barcode == null || toplu.Stok == null || toplu.Stok == "" || toplu.Kod12 == null||toplu.Resim==null||toplu.Resim=="")
                    continue;
                else if (int.Parse(toplu.Stok.Split(',')[0]) < 15)
                    continue;
                string barcode = "TK" + toplu.Barcode;
                if (toplu.Barcode == null||toplu.Barcode=="")
                    continue;
                int ciceksepetirenkkodu = cicekSepetiRenk.RenkOzellikKoduVer(toplu.Renk);
                if (ciceksepetirenkkodu == 0)
                    continue;
                xlWorkSheet.Cells[satir, sutun++] = stokkodu;
                xlWorkSheet.Cells[satir, sutun++] = toplu.Kod12 + " " + textBoxBaslik.Text;
                xlWorkSheet.Cells[satir, sutun++] = barcode;//"Varyant Stok Kodu
                xlWorkSheet.Cells[satir, sutun++] ="" ;
                xlWorkSheet.Cells[satir, sutun++] = ciceksepetirenkkodu;
                xlWorkSheet.Cells[satir, sutun++] = "";//Kişiselleştirilebilir Özellikler
                xlWorkSheet.Cells[satir, sutun++] = "";//Ürün özellikleri
                xlWorkSheet.Cells[satir, sutun++] = toplu.Stok.Split(',')[0];
                try
                {
                    xlWorkSheet.Cells[satir, sutun++] = decimal.Parse(textBoxSatisFiyati.Text);
                    xlWorkSheet.Cells[satir, sutun++] = decimal.Parse(textBoxUstuCiziliSatisFiyati.Text);
                }
                catch (Exception)
                {
                   
                    MessageBox.Show("Lütfen Fiyat Bilgisini kontrol edin");
                    customMessageBox.Close();
                    return;
                }
                xlWorkSheet.Cells[satir, sutun++] = toplu.Resim;
                xlWorkSheet.Cells[satir, sutun++] = textBoxTeslimattipi.Text;
                xlWorkSheet.Cells[satir, sutun++] = textBoxTeslimatturu.Text;
                xlWorkSheet.Cells[satir, sutun++] = textBoxAciklama.Text;
                xlWorkSheet.Cells[satir, sutun++] = "";
                satir++;
                sutun = 1;
            }
            xlWorkBook.SaveAs("E:\\csharp-Excel.xls");
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            customMessageBox.Close();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}

