namespace ZorePazaryeriConverter
{
    partial class PazaryeriConverter3
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PazaryeriConverter3));
            this.TrendyolConvert = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AdetLabel = new System.Windows.Forms.Label();
            this.CAT1ComboBox = new System.Windows.Forms.ComboBox();
            this.CAT1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CAT2ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.N11Convert = new System.Windows.Forms.Button();
            this.CicekSepeti = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TrendyolConvert
            // 
            resources.ApplyResources(this.TrendyolConvert, "TrendyolConvert");
            this.TrendyolConvert.Name = "TrendyolConvert";
            this.TrendyolConvert.UseVisualStyleBackColor = true;
            this.TrendyolConvert.Click += new System.EventHandler(this.TrendyolConvert_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // AdetLabel
            // 
            resources.ApplyResources(this.AdetLabel, "AdetLabel");
            this.AdetLabel.Name = "AdetLabel";
            // 
            // CAT1ComboBox
            // 
            resources.ApplyResources(this.CAT1ComboBox, "CAT1ComboBox");
            this.CAT1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CAT1ComboBox.FormattingEnabled = true;
            this.CAT1ComboBox.Name = "CAT1ComboBox";
            this.CAT1ComboBox.SelectedIndexChanged += new System.EventHandler(this.CAT1ComboBox_SelectedIndexChanged);
            // 
            // CAT1
            // 
            resources.ApplyResources(this.CAT1, "CAT1");
            this.CAT1.Name = "CAT1";
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Name = "dataGridView1";
            // 
            // CAT2ComboBox
            // 
            resources.ApplyResources(this.CAT2ComboBox, "CAT2ComboBox");
            this.CAT2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CAT2ComboBox.FormattingEnabled = true;
            this.CAT2ComboBox.Name = "CAT2ComboBox";
            this.CAT2ComboBox.SelectedIndexChanged += new System.EventHandler(this.CAT2ComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // N11Convert
            // 
            resources.ApplyResources(this.N11Convert, "N11Convert");
            this.N11Convert.Name = "N11Convert";
            this.N11Convert.UseVisualStyleBackColor = true;
            this.N11Convert.Click += new System.EventHandler(this.N11Convert_Click);
            // 
            // CicekSepeti
            // 
            resources.ApplyResources(this.CicekSepeti, "CicekSepeti");
            this.CicekSepeti.Name = "CicekSepeti";
            this.CicekSepeti.UseVisualStyleBackColor = true;
            this.CicekSepeti.Click += new System.EventHandler(this.CicekSepeti_Click);
            // 
            // PazaryeriConverter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CicekSepeti);
            this.Controls.Add(this.TrendyolConvert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AdetLabel);
            this.Controls.Add(this.CAT1ComboBox);
            this.Controls.Add(this.CAT1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CAT2ComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.N11Convert);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PazaryeriConverter";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TrendyolConvert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label AdetLabel;
        private System.Windows.Forms.ComboBox CAT1ComboBox;
        private System.Windows.Forms.Label CAT1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CAT2ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button N11Convert;
        private System.Windows.Forms.Button CicekSepeti;
    }
}

