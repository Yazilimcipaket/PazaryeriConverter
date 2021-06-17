using AutoMapper;
using converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ZorePazaryeriConverter.Entity;

namespace ZorePazaryeriConverter
{
    public partial class PazaryeriConverter : Form
    {
        private IMapper _productMapper;
        private IMapper _ımageMapper;
        private IMapper _subPrdouct;
        public PazaryeriConverter()
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
        private void PazaryeriConverter_Load(object sender, EventArgs e)
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
                tablo.Rows.Add(item2.Name, item2.Supplier_code, item2.Marka, item2.Model, item2.Kod12, item2.Renk, item2.Resim, item2.Stok, item2.Barcode, item2.Detail);
            }
            AdetLabel.Text = seciliUrunler.Count.ToString();
            dataGridView1.DataSource = tablo;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
            bekle.Close();
        }
        private void CAT1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomMessageBox custom = new CustomMessageBox();
            custom.Show();
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
                    tablo.Rows.Add(item.Name, item.Supplier_code, item.Marka, item.Model, item.Kod12, item.Renk, item.Resim, item.Stok, item.Barcode, item.Detail);
                    kontrol.Add(item);
                }
                AdetLabel.Text = seciliUrunler.Count.ToString();
            }
            custom.Close();
        }

        private void CAT2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDataTable(CAT2ComboBox.Text);
        }

        private void N11Convert_Click(object sender, EventArgs e)
        {

            N11ConvertForm n11ConvertForm = new N11ConvertForm();
            n11ConvertForm.Tag = CAT1ComboBox.Text + "," + CAT2ComboBox.Text;
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
            CicekSepetiConvert cicekSepetiConvert = new CicekSepetiConvert();
            cicekSepetiConvert.Tag = CAT1ComboBox.Text + "," + CAT2ComboBox.Text;
            cicekSepetiConvert.ShowDialog();
        }

        private void Hepsiburada_Click(object sender, EventArgs e)
        {
            HepsiburadaConverter hepsiburadaConverter = new HepsiburadaConverter();
            hepsiburadaConverter.Tag = CAT1ComboBox.Text + "," + CAT2ComboBox.Text;
            hepsiburadaConverter.ShowDialog();
        }
        private HttpResponseMessage GetXml(int altlimit, int ustlimit)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://zoreaksesuar.com/xml/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Response = client.GetAsync(string.Format("?R=8686&K=0e27&Imgs=1&AltUrun=1&start={0}&limit={1}", altlimit, ustlimit)).Result;
                return Response;
            }
        }
        public HttpResponseMessage GetJson()
        {
            /*46.221.56.226:6060/api/values/0& &1&1&200000&2018-01-01&2021-05-31*/
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5);
                client.BaseAddress = new Uri("http://46.221.56.226:6060/api/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Response = client.GetAsync("values/0& &1&1&200000&2018-01-01&2021-05-31").Result;
                return Response;
            }
        }
        private void TopluVeriYenile()
        {
            context.Database.ExecuteSqlCommand("Delete Toplu");
            context.SaveChanges();
            HttpResponseMessage mesaj = GetJson();

            List<JsonProduct> jsonProducts = new List<JsonProduct>();
            string stringJson = mesaj.Content.ReadAsStringAsync().Result;
            jsonProducts = JsonConvert.DeserializeObject<List<JsonProduct>>(JsonConvert.DeserializeObject<string>(stringJson));

            int altlimit = 0;
            int ustlimit = 1000;
            while (true)
            {
                HttpResponseMessage message = GetXml(altlimit, ustlimit);
                altlimit += 1000;
                if (!message.IsSuccessStatusCode)
                    return;
                using (TextReader reader = new StringReader(message.Content.ReadAsStringAsync().Result))
                {
                    try
                    {
                        Products urunler = (Products)new XmlSerializer(typeof(Products)).Deserialize(reader);
                        if (urunler.Product.Count == 0)
                            return;
                        foreach (Product urun in urunler.Product)
                        {
                            int sayac = 0;
                            JsonProduct jsonProduct = jsonProducts.FirstOrDefault(x => x.KOD19 == urun.Code);
                            if (jsonProduct == null)
                                continue;
                            foreach (var item in urun.Images.Img_item)
                            {
                                Toplu toplu = new Toplu();
                                if (sayac < 6)
                                {
                                    toplu.Code = urun.Code;
                                    toplu.Detail = urun.Detail;
                                    toplu.Stok = urun.Stock;
                                    toplu.Name = urun.Name;
                                    toplu.Resim = item;
                                    toplu.Kod1 = jsonProduct.KOD1;
                                    toplu.Kod2 = jsonProduct.KOD2;
                                    toplu.Barcode = jsonProduct.BARCODE;
                                    toplu.Kod12 = jsonProduct.KOD12;
                                    toplu.Marka = jsonProduct.KOD4;
                                    toplu.Model = jsonProduct.KOD7;
                                    toplu.Stok = jsonProduct.ENVANTER.ToString();
                                    toplu.Supplier_code = urun.Supplier_code;
                                    context.Toplu.Add(toplu);
                                }
                            }
                            if (urun.Subproducts != null)
                            {
                                foreach (var item in urun.Subproducts.Subproduct)
                                {
                                    JsonProduct stok = jsonProducts.FirstOrDefault(x => x.BARCODE == item.Barcode);
                                    if (stok == null)
                                        continue;
                                    Toplu toplu = new Toplu();
                                    toplu.Code = urun.Code;
                                    toplu.Detail = urun.Detail;
                                    toplu.Name = urun.Name;
                                    toplu.Renk = item.Type1;
                                    toplu.Kod1 = jsonProduct.KOD1;
                                    toplu.Kod2 = jsonProduct.KOD2;
                                    toplu.Resim = item.Images.Img_item.FirstOrDefault();
                                    toplu.Stok = stok.ENVANTER.ToString();
                                    toplu.Kod12 = jsonProduct.KOD12;
                                    toplu.Marka = jsonProduct.KOD4;
                                    toplu.Model = jsonProduct.KOD7;
                                    toplu.Barcode = item.Barcode;
                                    toplu.Supplier_code = item.Supplier_code;
                                    context.Toplu.Add(toplu);
                                }
                            }
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        // String passed is not XML, simply return defaultXmlClass
                    }
                }
                context.SaveChanges();
            }

        }
        private void JsonVeriYenile()
        {
            context.Database.ExecuteSqlCommand("delete Jsonproduct");
            context.SaveChanges();
            HttpResponseMessage mesaj = GetJson();

            List<JsonProduct> jsonProducts = new List<JsonProduct>();
            string stringJson = mesaj.Content.ReadAsStringAsync().Result;
            jsonProducts = JsonConvert.DeserializeObject<List<JsonProduct>>(JsonConvert.DeserializeObject<string>(stringJson));

            context.JsonProduct.AddRange(jsonProducts);
            context.SaveChanges();
        }
        private void XmlVeriYenile()
        {
            context.Database.ExecuteSqlCommand("delete XmlSubProduct");
            context.Database.ExecuteSqlCommand("delete XmlImage");
            context.Database.ExecuteSqlCommand("delete XmlProduct");
            context.SaveChanges();
            int altlimit = 0;
            int ustlimit = 1000;
            while (true)
            {
                HttpResponseMessage message = GetXml(altlimit, ustlimit);
                altlimit += 1000;
                if (!message.IsSuccessStatusCode || altlimit == 14000)
                    return;
                using (TextReader reader = new StringReader(message.Content.ReadAsStringAsync().Result))
                {
                    try
                    {
                        Products urunler = (Products)new XmlSerializer(typeof(Products)).Deserialize(reader);
                        foreach (Product urun in urunler.Product)
                        {
                            XmlProduct xmlProduct = _productMapper.Map<XmlProduct>(urun);
                            context.XmlProduct.Add(xmlProduct);
                            context.SaveChanges();
                            int sayac = 0;
                            foreach (var item in urun.Images.Img_item)
                            {
                                if (sayac < 6)
                                {
                                    XmlImage xmlImages = new XmlImage();
                                    xmlImages.ProductID = xmlProduct.ID;
                                    xmlImages.Img_item = item;
                                    xmlImages.Code = urun.Code;
                                    context.XmlImage.Add(xmlImages);
                                }
                            }
                            if (urun.Subproducts != null)
                            {
                                foreach (var item in urun.Subproducts.Subproduct)
                                {
                                    XmlSubProduct xmlSubProduct = _subPrdouct.Map<XmlSubProduct>(item);
                                    xmlSubProduct.ProductID = xmlProduct.ID;
                                    context.XmlSubProduct.Add(xmlSubProduct);
                                    XmlImage xmlImages = new XmlImage();
                                    xmlImages.ProductID = xmlProduct.ID;
                                    xmlImages.Img_item = item.Images.Img_item.FirstOrDefault();
                                    xmlImages.Code = item.Code;
                                    context.XmlImage.Add(xmlImages);
                                }
                            }
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        // String passed is not XML, simply return defaultXmlClass
                    }
                }
                context.SaveChanges();
            }
        }
        private void VeriGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult secenek= MessageBox.Show("Veriler Yenilenecek,bu zaman alabilir", "Bilgilendirme", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (secenek == DialogResult.Yes)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox();
                customMessageBox.ShowDialog();
                TopluVeriYenile();
                JsonVeriYenile();
                customMessageBox.Close();
                //XmlVeriYenile();
            }
        }
        private void Tekkart_Converter_click(object sender, EventArgs e)
        {
            TekkartConverter tekkartConverter = new TekkartConverter();
            tekkartConverter.Tag = CAT1ComboBox.Text + "," + CAT2ComboBox.Text;
            tekkartConverter.ShowDialog();
        }









        //private void Gittigidiyor_Click(object sender, EventArgs e)
        //{
        //    GittigidiyorConvert gittigidiyor = new GittigidiyorConvert();
        //    gittigidiyor.Tag = CAT1ComboBox.Text + "," + CAT2ComboBox.Text;
        //    gittigidiyor.Show();
        //}


    }
}
