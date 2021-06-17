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
    public partial class TrendyolConvert : Form
    {
        Excel.Application xlApp = new Excel.Application();
        private void TrendyolConvert_Load(object sender, EventArgs e)
        {
            Context context = new Context();
            string[] degerler = Tag.ToString().Split(',');
            if (degerler[1] != "")
            {
                string acayip = degerler[1];
                Toplu seciliUrun = context.Toplu.FirstOrDefault(x => x.Kod2 == acayip);
                Aciklama.Text = seciliUrun.Detail;
                Kategori.Text = "766";
                KdvOrani.Text = "18";
                Metaryel.Text = "Silikon";
                Model.Text = "Arka Kapak";
                GarantiTipi.Text = "İthalatçı Garantili";

            }

        }
        public TrendyolConvert()
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
                xlWorkSheet.Cells[1, 1] = "Barkod";
                xlWorkSheet.Cells[1, 2] = "Model Kodu";
                xlWorkSheet.Cells[1, 3] = "Marka";
                xlWorkSheet.Cells[1, 4] = "Kategori";
                xlWorkSheet.Cells[1, 5] = "Para Birimi";
                xlWorkSheet.Cells[1, 6] = "Ürün Adı";
                xlWorkSheet.Cells[1, 7] = "Ürün Açıklaması";
                xlWorkSheet.Cells[1, 8] = "Piyasa Satış Fiyatı (KDV Dahil)";
                xlWorkSheet.Cells[1, 9] = "Trendyol'da Satılacak Fiyat (KDV Dahil)";
                xlWorkSheet.Cells[1, 10] = "Ürün Stok Adedi";
                xlWorkSheet.Cells[1, 11] = "Stok Kodu";
                xlWorkSheet.Cells[1, 12] = "KDV Oranı";
                xlWorkSheet.Cells[1, 13] = "Desi";
                xlWorkSheet.Cells[1, 14] = "Görsel Linki";
                xlWorkSheet.Cells[1, 15] = "Sevkiyat Süresi";
                xlWorkSheet.Cells[1, 16] = "Beden";
                xlWorkSheet.Cells[1, 17] = "Renk";
                xlWorkSheet.Cells[1, 18] = "Cep Telefonu Modeli";
                xlWorkSheet.Cells[1, 19] = "Yaş Grubu";
                xlWorkSheet.Cells[1, 20] = "Cinsiyet";
                xlWorkSheet.Cells[1, 21] = "Materyal";
                xlWorkSheet.Cells[1, 22] = "Model";
                xlWorkSheet.Cells[1, 23] = "Garanti Tipi";
                int satir = 2;
                int sutun = 1;
                foreach (Toplu toplu in seciliUrunler)
                {

                    string stokkodu = "TK" + context.Toplu.FirstOrDefault(x => x.Kod12 == toplu.Kod12 & x.Kod2 == toplu.Kod2).Barcode.ToString();
                    if (toplu.Stok.Split(',')[0] == "0" || toplu.Renk == null || toplu.Barcode == null || toplu.Stok == null || toplu.Stok == "" || toplu.Kod12 == null)
                        continue;
                    else if (int.Parse(toplu.Stok.Split(',')[0]) < 15)
                        continue;
                    string barcode = "TK" + toplu.Barcode.Substring(2, 10);
                    xlWorkSheet.Cells[satir, sutun++] = barcode;
                    xlWorkSheet.Cells[satir, sutun++] = stokkodu;
                    xlWorkSheet.Cells[satir, sutun++] = "Zore";
                    xlWorkSheet.Cells[satir, sutun++] = Kategori.Text;
                    xlWorkSheet.Cells[satir, sutun++] = "TL";
                    xlWorkSheet.Cells[satir, sutun++] = toplu.Kod12 + " " + UrunAdi.Text;
                    xlWorkSheet.Cells[satir, sutun++] = Aciklama.Text;
                    try
                    {
                        xlWorkSheet.Cells[satir, sutun++] = decimal.Parse(PiyasaSatisFiyati.Text);
                        xlWorkSheet.Cells[satir, sutun++] = decimal.Parse(TrendyolSatisFiyati.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lütfen Fiyat Bilgisini kontrol edin");
                        customMessageBox.Close();
                        return;
                    }
                    if (int.Parse(toplu.Stok.Split(',')[0]) < 15)
                        xlWorkSheet.Cells[satir, sutun++] = 0;
                    else
                        xlWorkSheet.Cells[satir, sutun++] = toplu.Stok.Split(',')[0];
                    xlWorkSheet.Cells[satir, sutun++] = "0";
                    xlWorkSheet.Cells[satir, sutun++] = KdvOrani.Text;
                    xlWorkSheet.Cells[satir, sutun++] = "1";
                    xlWorkSheet.Cells[satir, sutun++] = toplu.Resim;
                    xlWorkSheet.Cells[satir, sutun++] = SevkiyatSüresi.Text;
                    xlWorkSheet.Cells[satir, sutun++] = Beden.Text;
                    xlWorkSheet.Cells[satir, sutun++] = toplu.Renk;
                    xlWorkSheet.Cells[satir, sutun++] = "";
                    xlWorkSheet.Cells[satir, sutun++] = "";
                    xlWorkSheet.Cells[satir, sutun++] = Cinsiyet.Text;
                    xlWorkSheet.Cells[satir, sutun++] = Metaryel.Text;
                    xlWorkSheet.Cells[satir, sutun++] = Model.Text;
                    xlWorkSheet.Cells[satir, sutun++] = GarantiTipi.Text;
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

        private void label7_Click(object sender, EventArgs e)
        {

        }


    }
}
