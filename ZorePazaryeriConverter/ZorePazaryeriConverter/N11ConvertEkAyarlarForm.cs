using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZorePazaryeriConverter.Static;

namespace ZorePazaryeriConverter
{
    public partial class N11ConvertEkAyarlarForm : Form
    {
        public N11ConvertEkAyarlarForm()
        {
            InitializeComponent();
        }

        private void N11ConvertEkAyarlar_Load(object sender, EventArgs e)
        {

        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            N11ConvertEkAyarlar.UrunKodu = TextBoxUrunKodu.Text;
            N11ConvertEkAyarlar.IndirimliFiyat = textboxIndirimFiyati.Text;
            N11ConvertEkAyarlar.DosyaIsmi = textBoxDosyaIsmi.Text;
            N11ConvertEkAyarlar.DosyaYolu = textBoxDosyaAdresi.Text;

        }
    }
}
