namespace TamTarti2202
{
    partial class Ayarlar
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
            this.ExitBtn = new FontAwesome.Sharp.IconButton();
            this.FirmaAyarlariTab = new System.Windows.Forms.TabPage();
            this.FirmaTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbl10 = new System.Windows.Forms.Label();
            this.FirmaAyarlariKaydetButton = new System.Windows.Forms.Button();
            this.FirmaAyariComboBox = new System.Windows.Forms.ComboBox();
            this.lbl11 = new System.Windows.Forms.Label();
            this.IndikatorAyarlariTab = new System.Windows.Forms.TabPage();
            this.indikatorTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.SeriPortComboBox = new System.Windows.Forms.ComboBox();
            this.ParityComboBox = new System.Windows.Forms.ComboBox();
            this.BoudRateComboBox = new System.Windows.Forms.ComboBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.StopBitsComboBox = new System.Windows.Forms.ComboBox();
            this.DataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.IndikatorAyarlariKaydetButton = new System.Windows.Forms.Button();
            this.DataUzunluguTextBox = new System.Windows.Forms.TextBox();
            this.DataUzunluguXTextBox = new System.Windows.Forms.TextBox();
            this.DataUzunluguYTextBox = new System.Windows.Forms.TextBox();
            this.AyarlarTabControl = new System.Windows.Forms.TabControl();
            this.DatabaseAyarlariTabControl = new System.Windows.Forms.TabPage();
            this.BaglantiTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ServerTextBox = new System.Windows.Forms.TextBox();
            this.DatabaseTextBox = new System.Windows.Forms.TextBox();
            this.UserIdTextBox = new System.Windows.Forms.TextBox();
            this.UserPasswordTextBox = new System.Windows.Forms.TextBox();
            this.XampTextBox = new System.Windows.Forms.TextBox();
            this.BaglantiAyarlariKaydetBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.FirmaAyarlariTab.SuspendLayout();
            this.FirmaTableLayoutPanel.SuspendLayout();
            this.IndikatorAyarlariTab.SuspendLayout();
            this.indikatorTableLayoutPanel.SuspendLayout();
            this.AyarlarTabControl.SuspendLayout();
            this.DatabaseAyarlariTabControl.SuspendLayout();
            this.BaglantiTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.ExitBtn.Location = new System.Drawing.Point(652, 1);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(28, 24);
            this.ExitBtn.TabIndex = 9;
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // FirmaAyarlariTab
            // 
            this.FirmaAyarlariTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.FirmaAyarlariTab.Controls.Add(this.FirmaTableLayoutPanel);
            this.FirmaAyarlariTab.Location = new System.Drawing.Point(4, 33);
            this.FirmaAyarlariTab.Name = "FirmaAyarlariTab";
            this.FirmaAyarlariTab.Padding = new System.Windows.Forms.Padding(3);
            this.FirmaAyarlariTab.Size = new System.Drawing.Size(662, 603);
            this.FirmaAyarlariTab.TabIndex = 4;
            this.FirmaAyarlariTab.Text = "Firmanızı Seçin";
            // 
            // FirmaTableLayoutPanel
            // 
            this.FirmaTableLayoutPanel.ColumnCount = 2;
            this.FirmaTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.FirmaTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.FirmaTableLayoutPanel.Controls.Add(this.lbl10, 1, 0);
            this.FirmaTableLayoutPanel.Controls.Add(this.FirmaAyarlariKaydetButton, 1, 4);
            this.FirmaTableLayoutPanel.Controls.Add(this.FirmaAyariComboBox, 1, 2);
            this.FirmaTableLayoutPanel.Controls.Add(this.lbl11, 0, 2);
            this.FirmaTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirmaTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.FirmaTableLayoutPanel.Name = "FirmaTableLayoutPanel";
            this.FirmaTableLayoutPanel.RowCount = 20;
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.FirmaTableLayoutPanel.Size = new System.Drawing.Size(656, 597);
            this.FirmaTableLayoutPanel.TabIndex = 1;
            // 
            // lbl10
            // 
            this.lbl10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl10.Location = new System.Drawing.Point(199, 0);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(454, 29);
            this.lbl10.TabIndex = 4;
            this.lbl10.Text = "Firma Seçim Alanı";
            this.lbl10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FirmaAyarlariKaydetButton
            // 
            this.FirmaAyarlariKaydetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FirmaAyarlariKaydetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirmaAyarlariKaydetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FirmaAyarlariKaydetButton.Location = new System.Drawing.Point(199, 119);
            this.FirmaAyarlariKaydetButton.Name = "FirmaAyarlariKaydetButton";
            this.FirmaAyarlariKaydetButton.Size = new System.Drawing.Size(454, 47);
            this.FirmaAyarlariKaydetButton.TabIndex = 99;
            this.FirmaAyarlariKaydetButton.Text = "FİRMA AYARLARINI KAYDET";
            this.FirmaAyarlariKaydetButton.UseVisualStyleBackColor = true;
            this.FirmaAyarlariKaydetButton.Click += new System.EventHandler(this.FirmaAyarlariKaydetButton_Click);
            // 
            // FirmaAyariComboBox
            // 
            this.FirmaAyariComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FirmaAyariComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirmaAyariComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FirmaAyariComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FirmaAyariComboBox.FormattingEnabled = true;
            this.FirmaAyariComboBox.Location = new System.Drawing.Point(199, 61);
            this.FirmaAyariComboBox.Name = "FirmaAyariComboBox";
            this.FirmaAyariComboBox.Size = new System.Drawing.Size(454, 26);
            this.FirmaAyariComboBox.TabIndex = 100;
            // 
            // lbl11
            // 
            this.lbl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl11.ForeColor = System.Drawing.Color.White;
            this.lbl11.Location = new System.Drawing.Point(3, 58);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(190, 29);
            this.lbl11.TabIndex = 98;
            this.lbl11.Text = "Firma Adı Seçiniz:";
            this.lbl11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IndikatorAyarlariTab
            // 
            this.IndikatorAyarlariTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.IndikatorAyarlariTab.Controls.Add(this.indikatorTableLayoutPanel);
            this.IndikatorAyarlariTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IndikatorAyarlariTab.Location = new System.Drawing.Point(4, 33);
            this.IndikatorAyarlariTab.Name = "IndikatorAyarlariTab";
            this.IndikatorAyarlariTab.Padding = new System.Windows.Forms.Padding(3);
            this.IndikatorAyarlariTab.Size = new System.Drawing.Size(662, 603);
            this.IndikatorAyarlariTab.TabIndex = 0;
            this.IndikatorAyarlariTab.Text = "İndikatör Ayarları";
            // 
            // indikatorTableLayoutPanel
            // 
            this.indikatorTableLayoutPanel.ColumnCount = 2;
            this.indikatorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.indikatorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.indikatorTableLayoutPanel.Controls.Add(this.lbl2, 0, 1);
            this.indikatorTableLayoutPanel.Controls.Add(this.lbl1, 1, 0);
            this.indikatorTableLayoutPanel.Controls.Add(this.SeriPortComboBox, 1, 1);
            this.indikatorTableLayoutPanel.Controls.Add(this.ParityComboBox, 1, 2);
            this.indikatorTableLayoutPanel.Controls.Add(this.BoudRateComboBox, 1, 3);
            this.indikatorTableLayoutPanel.Controls.Add(this.lbl4, 0, 3);
            this.indikatorTableLayoutPanel.Controls.Add(this.lbl3, 0, 2);
            this.indikatorTableLayoutPanel.Controls.Add(this.lbl5, 0, 4);
            this.indikatorTableLayoutPanel.Controls.Add(this.lbl6, 0, 5);
            this.indikatorTableLayoutPanel.Controls.Add(this.StopBitsComboBox, 1, 4);
            this.indikatorTableLayoutPanel.Controls.Add(this.DataBitsComboBox, 1, 5);
            this.indikatorTableLayoutPanel.Controls.Add(this.lbl7, 0, 6);
            this.indikatorTableLayoutPanel.Controls.Add(this.lbl8, 0, 7);
            this.indikatorTableLayoutPanel.Controls.Add(this.lbl9, 0, 8);
            this.indikatorTableLayoutPanel.Controls.Add(this.IndikatorAyarlariKaydetButton, 1, 10);
            this.indikatorTableLayoutPanel.Controls.Add(this.DataUzunluguTextBox, 1, 6);
            this.indikatorTableLayoutPanel.Controls.Add(this.DataUzunluguXTextBox, 1, 7);
            this.indikatorTableLayoutPanel.Controls.Add(this.DataUzunluguYTextBox, 1, 8);
            this.indikatorTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indikatorTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.indikatorTableLayoutPanel.Name = "indikatorTableLayoutPanel";
            this.indikatorTableLayoutPanel.RowCount = 20;
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.indikatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.indikatorTableLayoutPanel.Size = new System.Drawing.Size(656, 597);
            this.indikatorTableLayoutPanel.TabIndex = 31;
            // 
            // lbl2
            // 
            this.lbl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl2.ForeColor = System.Drawing.Color.White;
            this.lbl2.Location = new System.Drawing.Point(3, 29);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(190, 29);
            this.lbl2.TabIndex = 26;
            this.lbl2.Text = "Seri Port Seçiniz:";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl1
            // 
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl1.Location = new System.Drawing.Point(199, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(454, 29);
            this.lbl1.TabIndex = 23;
            this.lbl1.Text = "İndikatör Ayarlar";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SeriPortComboBox
            // 
            this.SeriPortComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SeriPortComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SeriPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SeriPortComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SeriPortComboBox.FormattingEnabled = true;
            this.SeriPortComboBox.Location = new System.Drawing.Point(199, 32);
            this.SeriPortComboBox.Name = "SeriPortComboBox";
            this.SeriPortComboBox.Size = new System.Drawing.Size(454, 26);
            this.SeriPortComboBox.TabIndex = 1;
            // 
            // ParityComboBox
            // 
            this.ParityComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ParityComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParityComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ParityComboBox.FormattingEnabled = true;
            this.ParityComboBox.Items.AddRange(new object[] {
            "Mark",
            "Odd",
            "None",
            "Even",
            "Space"});
            this.ParityComboBox.Location = new System.Drawing.Point(199, 61);
            this.ParityComboBox.Name = "ParityComboBox";
            this.ParityComboBox.Size = new System.Drawing.Size(454, 26);
            this.ParityComboBox.TabIndex = 2;
            // 
            // BoudRateComboBox
            // 
            this.BoudRateComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BoudRateComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoudRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoudRateComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BoudRateComboBox.FormattingEnabled = true;
            this.BoudRateComboBox.Items.AddRange(new object[] {
            "75",
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.BoudRateComboBox.Location = new System.Drawing.Point(199, 90);
            this.BoudRateComboBox.Name = "BoudRateComboBox";
            this.BoudRateComboBox.Size = new System.Drawing.Size(454, 26);
            this.BoudRateComboBox.TabIndex = 3;
            // 
            // lbl4
            // 
            this.lbl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl4.ForeColor = System.Drawing.Color.White;
            this.lbl4.Location = new System.Drawing.Point(3, 87);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(190, 29);
            this.lbl4.TabIndex = 27;
            this.lbl4.Text = "Boud Rate Seçiniz:";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl3
            // 
            this.lbl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl3.ForeColor = System.Drawing.Color.White;
            this.lbl3.Location = new System.Drawing.Point(3, 58);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(190, 29);
            this.lbl3.TabIndex = 28;
            this.lbl3.Text = "Parity Seçiniz:";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl5
            // 
            this.lbl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl5.ForeColor = System.Drawing.Color.White;
            this.lbl5.Location = new System.Drawing.Point(3, 116);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(190, 29);
            this.lbl5.TabIndex = 29;
            this.lbl5.Text = "Stop Bits Seçiniz:";
            this.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl6
            // 
            this.lbl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl6.ForeColor = System.Drawing.Color.White;
            this.lbl6.Location = new System.Drawing.Point(3, 145);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(190, 29);
            this.lbl6.TabIndex = 30;
            this.lbl6.Text = "Data Bits Seçiniz:";
            this.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StopBitsComboBox
            // 
            this.StopBitsComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopBitsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StopBitsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.StopBitsComboBox.FormattingEnabled = true;
            this.StopBitsComboBox.Items.AddRange(new object[] {
            "None",
            "One",
            "OnePointFive",
            "Two"});
            this.StopBitsComboBox.Location = new System.Drawing.Point(199, 119);
            this.StopBitsComboBox.Name = "StopBitsComboBox";
            this.StopBitsComboBox.Size = new System.Drawing.Size(454, 26);
            this.StopBitsComboBox.TabIndex = 4;
            // 
            // DataBitsComboBox
            // 
            this.DataBitsComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataBitsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBitsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DataBitsComboBox.FormattingEnabled = true;
            this.DataBitsComboBox.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.DataBitsComboBox.Location = new System.Drawing.Point(199, 148);
            this.DataBitsComboBox.Name = "DataBitsComboBox";
            this.DataBitsComboBox.Size = new System.Drawing.Size(454, 26);
            this.DataBitsComboBox.TabIndex = 5;
            // 
            // lbl7
            // 
            this.lbl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl7.ForeColor = System.Drawing.Color.White;
            this.lbl7.Location = new System.Drawing.Point(3, 174);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(190, 29);
            this.lbl7.TabIndex = 31;
            this.lbl7.Text = "Data Uzunluğu:";
            this.lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl8
            // 
            this.lbl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl8.ForeColor = System.Drawing.Color.White;
            this.lbl8.Location = new System.Drawing.Point(3, 203);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(190, 29);
            this.lbl8.TabIndex = 32;
            this.lbl8.Text = "Başlangıç:";
            this.lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl9
            // 
            this.lbl9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl9.ForeColor = System.Drawing.Color.White;
            this.lbl9.Location = new System.Drawing.Point(3, 232);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(190, 29);
            this.lbl9.TabIndex = 33;
            this.lbl9.Text = "Bitiş:";
            this.lbl9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IndikatorAyarlariKaydetButton
            // 
            this.IndikatorAyarlariKaydetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IndikatorAyarlariKaydetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IndikatorAyarlariKaydetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IndikatorAyarlariKaydetButton.Location = new System.Drawing.Point(199, 293);
            this.IndikatorAyarlariKaydetButton.Name = "IndikatorAyarlariKaydetButton";
            this.IndikatorAyarlariKaydetButton.Size = new System.Drawing.Size(454, 47);
            this.IndikatorAyarlariKaydetButton.TabIndex = 9;
            this.IndikatorAyarlariKaydetButton.Text = "İNDİKATÖR AYARLARINI KAYDET";
            this.IndikatorAyarlariKaydetButton.UseVisualStyleBackColor = true;
            this.IndikatorAyarlariKaydetButton.Click += new System.EventHandler(this.IndikatorAyarlariKaydetButton_Click);
            // 
            // DataUzunluguTextBox
            // 
            this.DataUzunluguTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DataUzunluguTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataUzunluguTextBox.Location = new System.Drawing.Point(199, 177);
            this.DataUzunluguTextBox.MaxLength = 2;
            this.DataUzunluguTextBox.Name = "DataUzunluguTextBox";
            this.DataUzunluguTextBox.Size = new System.Drawing.Size(454, 24);
            this.DataUzunluguTextBox.TabIndex = 6;
            this.DataUzunluguTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataUzunluguTextBox_KeyPress);
            // 
            // DataUzunluguXTextBox
            // 
            this.DataUzunluguXTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DataUzunluguXTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataUzunluguXTextBox.Location = new System.Drawing.Point(199, 206);
            this.DataUzunluguXTextBox.MaxLength = 2;
            this.DataUzunluguXTextBox.Name = "DataUzunluguXTextBox";
            this.DataUzunluguXTextBox.Size = new System.Drawing.Size(454, 24);
            this.DataUzunluguXTextBox.TabIndex = 7;
            this.DataUzunluguXTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataUzunluguXTextBox_KeyPress);
            // 
            // DataUzunluguYTextBox
            // 
            this.DataUzunluguYTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DataUzunluguYTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataUzunluguYTextBox.Location = new System.Drawing.Point(199, 235);
            this.DataUzunluguYTextBox.MaxLength = 2;
            this.DataUzunluguYTextBox.Name = "DataUzunluguYTextBox";
            this.DataUzunluguYTextBox.Size = new System.Drawing.Size(454, 24);
            this.DataUzunluguYTextBox.TabIndex = 8;
            this.DataUzunluguYTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataUzunluguYTextBox_KeyPress);
            // 
            // AyarlarTabControl
            // 
            this.AyarlarTabControl.Controls.Add(this.IndikatorAyarlariTab);
            this.AyarlarTabControl.Controls.Add(this.FirmaAyarlariTab);
            this.AyarlarTabControl.Controls.Add(this.DatabaseAyarlariTabControl);
            this.AyarlarTabControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AyarlarTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AyarlarTabControl.Location = new System.Drawing.Point(5, 25);
            this.AyarlarTabControl.Name = "AyarlarTabControl";
            this.AyarlarTabControl.SelectedIndex = 0;
            this.AyarlarTabControl.Size = new System.Drawing.Size(670, 640);
            this.AyarlarTabControl.TabIndex = 23;
            // 
            // DatabaseAyarlariTabControl
            // 
            this.DatabaseAyarlariTabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.DatabaseAyarlariTabControl.Controls.Add(this.BaglantiTableLayoutPanel);
            this.DatabaseAyarlariTabControl.Location = new System.Drawing.Point(4, 33);
            this.DatabaseAyarlariTabControl.Name = "DatabaseAyarlariTabControl";
            this.DatabaseAyarlariTabControl.Padding = new System.Windows.Forms.Padding(3);
            this.DatabaseAyarlariTabControl.Size = new System.Drawing.Size(662, 603);
            this.DatabaseAyarlariTabControl.TabIndex = 5;
            this.DatabaseAyarlariTabControl.Text = "Bağlantı Yolları";
            // 
            // BaglantiTableLayoutPanel
            // 
            this.BaglantiTableLayoutPanel.ColumnCount = 2;
            this.BaglantiTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.BaglantiTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.BaglantiTableLayoutPanel.Controls.Add(this.label10, 1, 0);
            this.BaglantiTableLayoutPanel.Controls.Add(this.label1, 0, 2);
            this.BaglantiTableLayoutPanel.Controls.Add(this.label2, 0, 3);
            this.BaglantiTableLayoutPanel.Controls.Add(this.label3, 0, 4);
            this.BaglantiTableLayoutPanel.Controls.Add(this.label4, 0, 5);
            this.BaglantiTableLayoutPanel.Controls.Add(this.label5, 0, 6);
            this.BaglantiTableLayoutPanel.Controls.Add(this.ServerTextBox, 1, 2);
            this.BaglantiTableLayoutPanel.Controls.Add(this.DatabaseTextBox, 1, 3);
            this.BaglantiTableLayoutPanel.Controls.Add(this.UserIdTextBox, 1, 4);
            this.BaglantiTableLayoutPanel.Controls.Add(this.UserPasswordTextBox, 1, 5);
            this.BaglantiTableLayoutPanel.Controls.Add(this.XampTextBox, 1, 6);
            this.BaglantiTableLayoutPanel.Controls.Add(this.BaglantiAyarlariKaydetBtn, 1, 8);
            this.BaglantiTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaglantiTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.BaglantiTableLayoutPanel.Name = "BaglantiTableLayoutPanel";
            this.BaglantiTableLayoutPanel.RowCount = 20;
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.BaglantiTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.BaglantiTableLayoutPanel.Size = new System.Drawing.Size(656, 597);
            this.BaglantiTableLayoutPanel.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(199, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(454, 29);
            this.label10.TabIndex = 4;
            this.label10.Text = "Bağlantı Yolları";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 29);
            this.label1.TabIndex = 99;
            this.label1.Text = "Server:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 29);
            this.label2.TabIndex = 100;
            this.label2.Text = "Database:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 29);
            this.label3.TabIndex = 101;
            this.label3.Text = "User Id:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 29);
            this.label4.TabIndex = 102;
            this.label4.Text = "Password:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 29);
            this.label5.TabIndex = 103;
            this.label5.Text = "Xamp Yolu:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ServerTextBox.Location = new System.Drawing.Point(199, 61);
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.Size = new System.Drawing.Size(454, 24);
            this.ServerTextBox.TabIndex = 104;
            // 
            // DatabaseTextBox
            // 
            this.DatabaseTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.DatabaseTextBox.Location = new System.Drawing.Point(199, 90);
            this.DatabaseTextBox.Name = "DatabaseTextBox";
            this.DatabaseTextBox.Size = new System.Drawing.Size(454, 24);
            this.DatabaseTextBox.TabIndex = 105;
            // 
            // UserIdTextBox
            // 
            this.UserIdTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.UserIdTextBox.Location = new System.Drawing.Point(199, 119);
            this.UserIdTextBox.Name = "UserIdTextBox";
            this.UserIdTextBox.Size = new System.Drawing.Size(454, 24);
            this.UserIdTextBox.TabIndex = 106;
            // 
            // UserPasswordTextBox
            // 
            this.UserPasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.UserPasswordTextBox.Location = new System.Drawing.Point(199, 148);
            this.UserPasswordTextBox.Name = "UserPasswordTextBox";
            this.UserPasswordTextBox.PasswordChar = '*';
            this.UserPasswordTextBox.Size = new System.Drawing.Size(454, 24);
            this.UserPasswordTextBox.TabIndex = 107;
            // 
            // XampTextBox
            // 
            this.XampTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XampTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.XampTextBox.Location = new System.Drawing.Point(199, 177);
            this.XampTextBox.Name = "XampTextBox";
            this.XampTextBox.Size = new System.Drawing.Size(454, 24);
            this.XampTextBox.TabIndex = 108;
            // 
            // BaglantiAyarlariKaydetBtn
            // 
            this.BaglantiAyarlariKaydetBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BaglantiAyarlariKaydetBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaglantiAyarlariKaydetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BaglantiAyarlariKaydetBtn.Location = new System.Drawing.Point(199, 235);
            this.BaglantiAyarlariKaydetBtn.Name = "BaglantiAyarlariKaydetBtn";
            this.BaglantiAyarlariKaydetBtn.Size = new System.Drawing.Size(454, 47);
            this.BaglantiAyarlariKaydetBtn.TabIndex = 109;
            this.BaglantiAyarlariKaydetBtn.Text = "BAĞLANTI AYARLARINI KAYDET";
            this.BaglantiAyarlariKaydetBtn.UseVisualStyleBackColor = true;
            this.BaglantiAyarlariKaydetBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(523, 1);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 24;
            // 
            // Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(680, 675);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.AyarlarTabControl);
            this.Controls.Add(this.ExitBtn);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(680, 675);
            this.MinimumSize = new System.Drawing.Size(680, 675);
            this.Name = "Ayarlar";
            this.Load += new System.EventHandler(this.Ayarlar_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ayarlar_MouseDown);
            this.FirmaAyarlariTab.ResumeLayout(false);
            this.FirmaTableLayoutPanel.ResumeLayout(false);
            this.IndikatorAyarlariTab.ResumeLayout(false);
            this.indikatorTableLayoutPanel.ResumeLayout(false);
            this.indikatorTableLayoutPanel.PerformLayout();
            this.AyarlarTabControl.ResumeLayout(false);
            this.DatabaseAyarlariTabControl.ResumeLayout(false);
            this.BaglantiTableLayoutPanel.ResumeLayout(false);
            this.BaglantiTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton ExitBtn;
        private System.Windows.Forms.TabPage FirmaAyarlariTab;
        private System.Windows.Forms.TabPage IndikatorAyarlariTab;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button IndikatorAyarlariKaydetButton;
        private System.Windows.Forms.ComboBox SeriPortComboBox;
        private System.Windows.Forms.ComboBox DataBitsComboBox;
        private System.Windows.Forms.ComboBox BoudRateComboBox;
        private System.Windows.Forms.ComboBox ParityComboBox;
        private System.Windows.Forms.ComboBox StopBitsComboBox;
        private System.Windows.Forms.TabControl AyarlarTabControl;
        private System.Windows.Forms.TableLayoutPanel indikatorTableLayoutPanel;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.TextBox DataUzunluguTextBox;
        private System.Windows.Forms.TextBox DataUzunluguXTextBox;
        private System.Windows.Forms.TextBox DataUzunluguYTextBox;
        private System.Windows.Forms.TabPage DatabaseAyarlariTabControl;
        private System.Windows.Forms.TableLayoutPanel FirmaTableLayoutPanel;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Button FirmaAyarlariKaydetButton;
        private System.Windows.Forms.ComboBox FirmaAyariComboBox;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.TableLayoutPanel BaglantiTableLayoutPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ServerTextBox;
        private System.Windows.Forms.TextBox DatabaseTextBox;
        private System.Windows.Forms.TextBox UserIdTextBox;
        private System.Windows.Forms.TextBox UserPasswordTextBox;
        private System.Windows.Forms.TextBox XampTextBox;
        private System.Windows.Forms.Button BaglantiAyarlariKaydetBtn;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}