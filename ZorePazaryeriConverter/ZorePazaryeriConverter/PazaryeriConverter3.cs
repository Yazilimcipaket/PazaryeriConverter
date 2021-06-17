
using AutoMapper;
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

namespace ZorePazaryeriConverter
{
    public partial class PazaryeriConverter3 : Form
    {
        private IMapper _productMapper;
        private IMapper _ımageMapper;
        private IMapper _subPrdouct;
        public PazaryeriConverter3()
        {
            var config = new MapperConfiguration(x => x.CreateMap<Product, XmlProduct>());
            var config2 = new MapperConfiguration(x => x.CreateMap<Image, XmlImage>());
            var config3 = new MapperConfiguration(x => x.CreateMap<Subproduct, XmlSubProduct>());
            _productMapper = new Mapper(config);
            _ımageMapper = new Mapper(config2);
            _subPrdouct = new Mapper(config3);
            InitializeComponent();
        }
        Context context = new Context();
        DataTable tablo = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            var kod1s = context.Toplu.GroupBy(x => x.Kod1).ToList();
            foreach (var item in kod1s)
            {
                if (item.Key != null)
                    CAT1ComboBox.Items.Add(item.Key);
            }
            CAT1ComboBox.Items.RemoveAt(0);
            NewTable();
           
            //Hepsiburada.Text = "Hepsiburada Convert";
            //Hepsiburada.Height = 21;
            //Hepsiburada.Width = 119;
        }
        private void NewTable()
        {
            tablo = new DataTable();
            tablo.Columns.Add("Name", typeof(string));
            tablo.Columns.Add("Supplier_code", typeof(string));
            tablo.Columns.Add("Marka", typeof(string));
            tablo.Columns.Add("Model", typeof(string));
            tablo.Columns.Add("Kod12", typeof(string));
            tablo.Columns.Add("Renk", typeof(string));
            tablo.Columns.Add("Resim", typeof(string));
            tablo.Columns.Add("Stok", typeof(string));
            tablo.Columns.Add("Barcode", typeof(string));
            tablo.Columns.Add("Acıklama", typeof(string));
            dataGridView1.DataSource = tablo;
            dataGridView1.Columns[8].Width = 300;
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[0].Width = 150;
        }
        private void CreateDataTable(string veri)
        {
            CustomMessageBox bekle = new CustomMessageBox();
            bekle.Show();
            NewTable();
            List<Toplu> seciliUrunler = context.Toplu.Where(x => x.Kod2 == veri).ToList();
            foreach (Toplu item2 in seciliUrunler)
            {
                tablo.Rows.Add(item2.Name, item2.Supplier_code,item2.Marka, item2.Model, item2.Kod12, item2.Renk, item2.Resim, item2.Stok, item2.Barcode, item2.Detail);
            }
            AdetLabel.Text = seciliUrunler.Count.ToString();
            dataGridView1.DataSource = tablo;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
            bekle.Close();
        }
        private void CAT1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kod1s = context.Toplu.Where(x => x.Kod1 == CAT1ComboBox.Text).GroupBy(x => x.Kod2).ToList();
            CAT2ComboBox.Items.Clear();
            foreach (var item in kod1s)
            {
                if (item.Key != null)
                    CAT2ComboBox.Items.Add(item.Key);
            }
            if (kod1s.Count == 1)
            {
                NewTable();
                List<Toplu> seciliUrunler = context.Toplu.Where(x => x.Kod1 == CAT1ComboBox.Text).ToList();
                List<Toplu> kontrol = new List<Toplu>();
                foreach (Toplu item in seciliUrunler)
                {
                    tablo.Rows.Add(item.Name,item.Supplier_code, item.Marka, item.Model, item.Kod12, item.Renk, item.Resim, item.Stok, item.Barcode, item.Detail);
                    kontrol.Add(item);
                }
                AdetLabel.Text = seciliUrunler.Count.ToString();
            }
        }

        private void CAT2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDataTable(CAT2ComboBox.Text);
        }

        private void N11Convert_Click(object sender, EventArgs e)
        {

            N11ConvertForm n11ConvertForm = new N11ConvertForm();
            n11ConvertForm.Tag =CAT1ComboBox.Text+","+ CAT2ComboBox.Text;
            n11ConvertForm.ShowDialog();
        }

        private void TrendyolConvert_Click(object sender, EventArgs e)
        {
            TrendyolConvert trendyol = new TrendyolConvert();
            trendyol.Tag = CAT1ComboBox.Text + "," + CAT2ComboBox.Text;
            trendyol.ShowDialog();

        }

        private void CicekSepeti_Click(object sender, EventArgs e)
        {

        }

      

        //private void Gittigidiyor_Click(object sender, EventArgs e)
        //{
        //    GittigidiyorConvert gittigidiyor = new GittigidiyorConvert();
        //    gittigidiyor.Tag = CAT1ComboBox.Text + "," + CAT2ComboBox.Text;
        //    gittigidiyor.Show();
        //}


    }
}
