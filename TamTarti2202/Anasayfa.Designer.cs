using System.Windows.Forms;

namespace TamTarti2202
{
    partial class Anasayfa
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
            this.components = new System.ComponentModel.Container();
            this.TartimveKayitBtn = new FontAwesome.Sharp.IconButton();
            this.UstMenuPnl = new System.Windows.Forms.Panel();
            this.MinimizeBtn = new FontAwesome.Sharp.IconButton();
            this.KilogramPnl = new System.Windows.Forms.Panel();
            this.KgLabel = new System.Windows.Forms.Label();
            this.ResizeBtn = new FontAwesome.Sharp.IconButton();
            this.AyarlarBtn = new FontAwesome.Sharp.IconButton();
            this.ExitBtn = new FontAwesome.Sharp.IconButton();
            this.YazdirmaBtn = new FontAwesome.Sharp.IconButton();
            this.RaporlamaBtn = new FontAwesome.Sharp.IconButton();
            this.KayitlarVeDuzenlemeBtn = new FontAwesome.Sharp.IconButton();
            this.AltMenuPanel = new System.Windows.Forms.Panel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.UstMenuPnl.SuspendLayout();
            this.KilogramPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TartimveKayitBtn
            // 
            this.TartimveKayitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TartimveKayitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TartimveKayitBtn.FlatAppearance.BorderSize = 0;
            this.TartimveKayitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TartimveKayitBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.TartimveKayitBtn.ForeColor = System.Drawing.Color.White;
            this.TartimveKayitBtn.IconChar = FontAwesome.Sharp.IconChar.ScaleBalanced;
            this.TartimveKayitBtn.IconColor = System.Drawing.Color.White;
            this.TartimveKayitBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.TartimveKayitBtn.IconSize = 36;
            this.TartimveKayitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TartimveKayitBtn.Location = new System.Drawing.Point(5, 35);
            this.TartimveKayitBtn.Margin = new System.Windows.Forms.Padding(5);
            this.TartimveKayitBtn.Name = "TartimveKayitBtn";
            this.TartimveKayitBtn.Size = new System.Drawing.Size(180, 60);
            this.TartimveKayitBtn.TabIndex = 1;
            this.TartimveKayitBtn.Text = "Tartım ve Kayıt";
            this.TartimveKayitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TartimveKayitBtn.UseVisualStyleBackColor = true;
            this.TartimveKayitBtn.Click += new System.EventHandler(this.TartimveKayitBtn_Click);
            // 
            // UstMenuPnl
            // 
            this.UstMenuPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(100)))));
            this.UstMenuPnl.Controls.Add(this.MinimizeBtn);
            this.UstMenuPnl.Controls.Add(this.KilogramPnl);
            this.UstMenuPnl.Controls.Add(this.ResizeBtn);
            this.UstMenuPnl.Controls.Add(this.AyarlarBtn);
            this.UstMenuPnl.Controls.Add(this.ExitBtn);
            this.UstMenuPnl.Controls.Add(this.YazdirmaBtn);
            this.UstMenuPnl.Controls.Add(this.RaporlamaBtn);
            this.UstMenuPnl.Controls.Add(this.KayitlarVeDuzenlemeBtn);
            this.UstMenuPnl.Controls.Add(this.TartimveKayitBtn);
            this.UstMenuPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.UstMenuPnl.Location = new System.Drawing.Point(0, 0);
            this.UstMenuPnl.Margin = new System.Windows.Forms.Padding(0);
            this.UstMenuPnl.Name = "UstMenuPnl";
            this.UstMenuPnl.Size = new System.Drawing.Size(1360, 100);
            this.UstMenuPnl.TabIndex = 0;
            this.UstMenuPnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UstMenuPnl_MouseDown);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.MinimizeBtn.ForeColor = System.Drawing.Color.White;
            this.MinimizeBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.MinimizeBtn.IconColor = System.Drawing.Color.White;
            this.MinimizeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MinimizeBtn.IconSize = 20;
            this.MinimizeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinimizeBtn.Location = new System.Drawing.Point(1273, 5);
            this.MinimizeBtn.Margin = new System.Windows.Forms.Padding(5);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(28, 24);
            this.MinimizeBtn.TabIndex = 6;
            this.MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MinimizeBtn.UseVisualStyleBackColor = true;
            this.MinimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            // 
            // KilogramPnl
            // 
            this.KilogramPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KilogramPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.KilogramPnl.Controls.Add(this.KgLabel);
            this.KilogramPnl.Location = new System.Drawing.Point(980, 35);
            this.KilogramPnl.Margin = new System.Windows.Forms.Padding(0);
            this.KilogramPnl.MaximumSize = new System.Drawing.Size(260, 60);
            this.KilogramPnl.MinimumSize = new System.Drawing.Size(260, 60);
            this.KilogramPnl.Name = "KilogramPnl";
            this.KilogramPnl.Size = new System.Drawing.Size(260, 60);
            this.KilogramPnl.TabIndex = 0;
            // 
            // KgLabel
            // 
            this.KgLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.KgLabel.AutoSize = true;
            this.KgLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KgLabel.Location = new System.Drawing.Point(66, 8);
            this.KgLabel.Name = "KgLabel";
            this.KgLabel.Size = new System.Drawing.Size(128, 45);
            this.KgLabel.TabIndex = 0;
            this.KgLabel.Text = "000000";
            this.KgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResizeBtn
            // 
            this.ResizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResizeBtn.FlatAppearance.BorderSize = 0;
            this.ResizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResizeBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.ResizeBtn.ForeColor = System.Drawing.Color.White;
            this.ResizeBtn.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.ResizeBtn.IconColor = System.Drawing.Color.White;
            this.ResizeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ResizeBtn.IconSize = 20;
            this.ResizeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ResizeBtn.Location = new System.Drawing.Point(1304, 5);
            this.ResizeBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ResizeBtn.Name = "ResizeBtn";
            this.ResizeBtn.Size = new System.Drawing.Size(28, 24);
            this.ResizeBtn.TabIndex = 7;
            this.ResizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ResizeBtn.UseVisualStyleBackColor = true;
            this.ResizeBtn.Click += new System.EventHandler(this.ResizeBtn_Click);
            // 
            // AyarlarBtn
            // 
            this.AyarlarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AyarlarBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AyarlarBtn.FlatAppearance.BorderSize = 0;
            this.AyarlarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AyarlarBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.AyarlarBtn.ForeColor = System.Drawing.Color.White;
            this.AyarlarBtn.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            this.AyarlarBtn.IconColor = System.Drawing.Color.White;
            this.AyarlarBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.AyarlarBtn.IconSize = 36;
            this.AyarlarBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AyarlarBtn.Location = new System.Drawing.Point(730, 35);
            this.AyarlarBtn.Margin = new System.Windows.Forms.Padding(5);
            this.AyarlarBtn.Name = "AyarlarBtn";
            this.AyarlarBtn.Size = new System.Drawing.Size(120, 60);
            this.AyarlarBtn.TabIndex = 5;
            this.AyarlarBtn.Text = "Ayarlar";
            this.AyarlarBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AyarlarBtn.UseVisualStyleBackColor = true;
            this.AyarlarBtn.Click += new System.EventHandler(this.AyarlarBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.ExitBtn.ForeColor = System.Drawing.Color.White;
            this.ExitBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.ExitBtn.IconColor = System.Drawing.Color.White;
            this.ExitBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ExitBtn.IconSize = 20;
            this.ExitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitBtn.Location = new System.Drawing.Point(1332, 5);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(28, 24);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // YazdirmaBtn
            // 
            this.YazdirmaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.YazdirmaBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YazdirmaBtn.FlatAppearance.BorderSize = 0;
            this.YazdirmaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YazdirmaBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.YazdirmaBtn.ForeColor = System.Drawing.Color.White;
            this.YazdirmaBtn.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.YazdirmaBtn.IconColor = System.Drawing.Color.White;
            this.YazdirmaBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.YazdirmaBtn.IconSize = 36;
            this.YazdirmaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.YazdirmaBtn.Location = new System.Drawing.Point(590, 35);
            this.YazdirmaBtn.Margin = new System.Windows.Forms.Padding(5);
            this.YazdirmaBtn.Name = "YazdirmaBtn";
            this.YazdirmaBtn.Size = new System.Drawing.Size(135, 60);
            this.YazdirmaBtn.TabIndex = 4;
            this.YazdirmaBtn.Text = "Yazdırma";
            this.YazdirmaBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.YazdirmaBtn.UseVisualStyleBackColor = true;
            // 
            // RaporlamaBtn
            // 
            this.RaporlamaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RaporlamaBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RaporlamaBtn.FlatAppearance.BorderSize = 0;
            this.RaporlamaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RaporlamaBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.RaporlamaBtn.ForeColor = System.Drawing.Color.White;
            this.RaporlamaBtn.IconChar = FontAwesome.Sharp.IconChar.FileCircleCheck;
            this.RaporlamaBtn.IconColor = System.Drawing.Color.White;
            this.RaporlamaBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.RaporlamaBtn.IconSize = 36;
            this.RaporlamaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RaporlamaBtn.Location = new System.Drawing.Point(435, 35);
            this.RaporlamaBtn.Margin = new System.Windows.Forms.Padding(5);
            this.RaporlamaBtn.Name = "RaporlamaBtn";
            this.RaporlamaBtn.Size = new System.Drawing.Size(150, 60);
            this.RaporlamaBtn.TabIndex = 3;
            this.RaporlamaBtn.Text = "Raporlama";
            this.RaporlamaBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RaporlamaBtn.UseVisualStyleBackColor = true;
            this.RaporlamaBtn.Click += new System.EventHandler(this.RaporlamaBtn_Click);
            // 
            // KayitlarVeDuzenlemeBtn
            // 
            this.KayitlarVeDuzenlemeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.KayitlarVeDuzenlemeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.KayitlarVeDuzenlemeBtn.FlatAppearance.BorderSize = 0;
            this.KayitlarVeDuzenlemeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KayitlarVeDuzenlemeBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.KayitlarVeDuzenlemeBtn.ForeColor = System.Drawing.Color.White;
            this.KayitlarVeDuzenlemeBtn.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
            this.KayitlarVeDuzenlemeBtn.IconColor = System.Drawing.Color.White;
            this.KayitlarVeDuzenlemeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.KayitlarVeDuzenlemeBtn.IconSize = 36;
            this.KayitlarVeDuzenlemeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KayitlarVeDuzenlemeBtn.Location = new System.Drawing.Point(190, 35);
            this.KayitlarVeDuzenlemeBtn.Margin = new System.Windows.Forms.Padding(5);
            this.KayitlarVeDuzenlemeBtn.Name = "KayitlarVeDuzenlemeBtn";
            this.KayitlarVeDuzenlemeBtn.Size = new System.Drawing.Size(240, 60);
            this.KayitlarVeDuzenlemeBtn.TabIndex = 2;
            this.KayitlarVeDuzenlemeBtn.Text = "Kayıtlar ve Düzenleme";
            this.KayitlarVeDuzenlemeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.KayitlarVeDuzenlemeBtn.UseVisualStyleBackColor = true;
            this.KayitlarVeDuzenlemeBtn.Click += new System.EventHandler(this.KayitlarVeDuzenlemeBtn_Click);
            // 
            // AltMenuPanel
            // 
            this.AltMenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AltMenuPanel.Location = new System.Drawing.Point(0, 100);
            this.AltMenuPanel.Name = "AltMenuPanel";
            this.AltMenuPanel.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.AltMenuPanel.Size = new System.Drawing.Size(1360, 648);
            this.AltMenuPanel.TabIndex = 1;
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(1360, 768);
            this.Controls.Add(this.AltMenuPanel);
            this.Controls.Add(this.UstMenuPnl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1360, 768);
            this.Name = "Anasayfa";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.Load += new System.EventHandler(this.Anasayfa_Load);
            this.UstMenuPnl.ResumeLayout(false);
            this.KilogramPnl.ResumeLayout(false);
            this.KilogramPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton TartimveKayitBtn;
        private Panel UstMenuPnl;
        private FontAwesome.Sharp.IconButton YazdirmaBtn;
        private FontAwesome.Sharp.IconButton RaporlamaBtn;
        private FontAwesome.Sharp.IconButton KayitlarVeDuzenlemeBtn;
        private FontAwesome.Sharp.IconButton AyarlarBtn;
        private Panel KilogramPnl;
        private Label KgLabel;
        private FontAwesome.Sharp.IconButton ExitBtn;
        private FontAwesome.Sharp.IconButton ResizeBtn;
        private FontAwesome.Sharp.IconButton MinimizeBtn;
        private Panel AltMenuPanel;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

