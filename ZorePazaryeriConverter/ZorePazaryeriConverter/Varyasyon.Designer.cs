namespace ZorePazaryeriConverter
{
    partial class Varyasyon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TemperliCamFiyat = new System.Windows.Forms.TextBox();
            this.BlueNanoCamFiyat = new System.Windows.Forms.TextBox();
            this.NanoCamFiyat = new System.Windows.Forms.TextBox();
            this.TamKaplatanCamFiyat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Kaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TemperliCamFiyat
            // 
            this.TemperliCamFiyat.Location = new System.Drawing.Point(165, 28);
            this.TemperliCamFiyat.Name = "TemperliCamFiyat";
            this.TemperliCamFiyat.Size = new System.Drawing.Size(100, 22);
            this.TemperliCamFiyat.TabIndex = 0;
            // 
            // BlueNanoCamFiyat
            // 
            this.BlueNanoCamFiyat.Location = new System.Drawing.Point(165, 84);
            this.BlueNanoCamFiyat.Name = "BlueNanoCamFiyat";
            this.BlueNanoCamFiyat.Size = new System.Drawing.Size(100, 22);
            this.BlueNanoCamFiyat.TabIndex = 1;
            // 
            // NanoCamFiyat
            // 
            this.NanoCamFiyat.Location = new System.Drawing.Point(165, 137);
            this.NanoCamFiyat.Name = "NanoCamFiyat";
            this.NanoCamFiyat.Size = new System.Drawing.Size(100, 22);
            this.NanoCamFiyat.TabIndex = 2;
            // 
            // TamKaplatanCamFiyat
            // 
            this.TamKaplatanCamFiyat.Location = new System.Drawing.Point(165, 195);
            this.TamKaplatanCamFiyat.Name = "TamKaplatanCamFiyat";
            this.TamKaplatanCamFiyat.Size = new System.Drawing.Size(100, 22);
            this.TamKaplatanCamFiyat.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Temperli Cam Fiyatı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Blue Nano Fiyatı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nano Camlı Fiyatı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "5D Camlı Fiyatı:";
            // 
            // Kaydet
            // 
            this.Kaydet.Location = new System.Drawing.Point(165, 255);
            this.Kaydet.Name = "Kaydet";
            this.Kaydet.Size = new System.Drawing.Size(100, 34);
            this.Kaydet.TabIndex = 5;
            this.Kaydet.Text = "Kaydet";
            this.Kaydet.UseVisualStyleBackColor = true;
            this.Kaydet.Click += new System.EventHandler(this.Kaydet_Click);
            // 
            // Varyasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 304);
            this.Controls.Add(this.Kaydet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TamKaplatanCamFiyat);
            this.Controls.Add(this.NanoCamFiyat);
            this.Controls.Add(this.BlueNanoCamFiyat);
            this.Controls.Add(this.TemperliCamFiyat);
            this.Name = "Varyasyon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Varyasyon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TemperliCamFiyat;
        private System.Windows.Forms.TextBox BlueNanoCamFiyat;
        private System.Windows.Forms.TextBox NanoCamFiyat;
        private System.Windows.Forms.TextBox TamKaplatanCamFiyat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Kaydet;
    }
}