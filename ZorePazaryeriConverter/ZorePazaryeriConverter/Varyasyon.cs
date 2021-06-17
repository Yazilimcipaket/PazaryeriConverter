using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZorePazaryeriConverter
{
    public partial class Varyasyon : Form
    {
        public Varyasyon()
        {
            InitializeComponent();
        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            Varsayılan.TemperliCamFiyat = TemperliCamFiyat.Text;
            Varsayılan.BlueNanoCamFiyat = BlueNanoCamFiyat.Text;
            Varsayılan.NanoCamFiyat = NanoCamFiyat.Text;
            Varsayılan.TamKaplayanCamFiyat = TamKaplatanCamFiyat.Text;
            this.Close();
        }
    }
}
