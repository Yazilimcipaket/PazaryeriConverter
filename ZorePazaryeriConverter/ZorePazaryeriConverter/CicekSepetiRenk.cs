using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace ZorePazaryeriConverter
{
    public class CicekSepetiRenk
    {
        Excel.Application excelApp = new Excel.Application();
        private Don ExelOku()
        {
            //Excel Dosyası Açılıyor.
            Excel.Workbook excelBook = excelApp.Workbooks.Open("C:\\Users\\Asus\\OneDrive\\Masaüstü\\Tekin-Exe\\ZorePazaryeriConverter\\ZorePazaryeriConverter\\CicekSepetiRenkVaryasyon.xlsx");
            //Excel Dosyasının Sayfası Seçilir.
            Excel._Worksheet excelSheet = excelBook.Sheets[1];
            //Excel Dosyasının ne kadar satır ve sütun kaplıyorsa tüm alanları alır.
            Excel.Range excelRange = excelSheet.UsedRange;
            return new Don
            {
                ExcelRange = excelRange,
                SatirSayisi = excelRange.Rows.Count,
                SutunSayisi = excelRange.Columns.Count
            };
        }
        public int RenkOzellikKoduVer(string renk)
        {
           
            Don don = ExelOku();
            string deger = "";
            for (int i = 1; i <= don.SatirSayisi; i++)
            {
                if (i != 1)
                { 
                    for (int j = 1; j <= 2; j++)
                    {
                        deger = don.ExcelRange.Cells[i, j].Value2;
                        if (don.ExcelRange.Cells[i, j].Value2 == renk)
                        {
                            int degerdon = int.Parse(don.ExcelRange.Cells[i, 1].Value2.ToString());
                            return degerdon;
                        }
                    }
                    continue;
                }
            }
            
            return 0;
        }
        class Don
        {
            public Excel.Range ExcelRange { get; set; }
            public int SatirSayisi { get; set; }
            public int SutunSayisi { get; set; }
        }
    }
}