namespace TamTarti2202
{
    partial class KayitlarVeDuzenleme
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
            this.TablolarTabControl = new System.Windows.Forms.TabControl();
            this.SatilanUrunlerTab = new System.Windows.Forms.TabPage();
            this.SatilanlarDataGridView = new System.Windows.Forms.DataGridView();
            this.AlinanUrunlerTab = new System.Windows.Forms.TabPage();
            this.AlinanlarDataGridView = new System.Windows.Forms.DataGridView();
            this.DigerleriTab = new System.Windows.Forms.TabPage();
            this.DigerDataGridView = new System.Windows.Forms.DataGridView();
            this.ExcelKayitButton = new System.Windows.Forms.Button();
            this.TablolarComboBox = new System.Windows.Forms.ComboBox();
            this.SilButton = new System.Windows.Forms.Button();
            this.KayitVeDuzenlemeTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TablolarTabControl.SuspendLayout();
            this.SatilanUrunlerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SatilanlarDataGridView)).BeginInit();
            this.AlinanUrunlerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlinanlarDataGridView)).BeginInit();
            this.DigerleriTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DigerDataGridView)).BeginInit();
            this.KayitVeDuzenlemeTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TablolarTabControl
            // 
            this.TablolarTabControl.Controls.Add(this.SatilanUrunlerTab);
            this.TablolarTabControl.Controls.Add(this.AlinanUrunlerTab);
            this.TablolarTabControl.Controls.Add(this.DigerleriTab);
            this.TablolarTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablolarTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TablolarTabControl.Location = new System.Drawing.Point(3, 86);
            this.TablolarTabControl.Name = "TablolarTabControl";
            this.TablolarTabControl.SelectedIndex = 0;
            this.TablolarTabControl.Size = new System.Drawing.Size(1338, 421);
            this.TablolarTabControl.TabIndex = 6;
            this.TablolarTabControl.SelectedIndexChanged += new System.EventHandler(this.TablolarTabControl_SelectedIndexChanged);
            // 
            // SatilanUrunlerTab
            // 
            this.SatilanUrunlerTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.SatilanUrunlerTab.Controls.Add(this.SatilanlarDataGridView);
            this.SatilanUrunlerTab.Location = new System.Drawing.Point(4, 29);
            this.SatilanUrunlerTab.Name = "SatilanUrunlerTab";
            this.SatilanUrunlerTab.Padding = new System.Windows.Forms.Padding(3);
            this.SatilanUrunlerTab.Size = new System.Drawing.Size(1330, 388);
            this.SatilanUrunlerTab.TabIndex = 0;
            this.SatilanUrunlerTab.Text = "Satilan Ürünler";
            // 
            // SatilanlarDataGridView
            // 
            this.SatilanlarDataGridView.AllowUserToAddRows = false;
            this.SatilanlarDataGridView.AllowUserToDeleteRows = false;
            this.SatilanlarDataGridView.AllowUserToResizeColumns = false;
            this.SatilanlarDataGridView.AllowUserToResizeRows = false;
            this.SatilanlarDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SatilanlarDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.SatilanlarDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SatilanlarDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SatilanlarDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SatilanlarDataGridView.Location = new System.Drawing.Point(3, 3);
            this.SatilanlarDataGridView.MultiSelect = false;
            this.SatilanlarDataGridView.Name = "SatilanlarDataGridView";
            this.SatilanlarDataGridView.ReadOnly = true;
            this.SatilanlarDataGridView.RowHeadersVisible = false;
            this.SatilanlarDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SatilanlarDataGridView.Size = new System.Drawing.Size(1324, 382);
            this.SatilanlarDataGridView.TabIndex = 0;
            // 
            // AlinanUrunlerTab
            // 
            this.AlinanUrunlerTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.AlinanUrunlerTab.Controls.Add(this.AlinanlarDataGridView);
            this.AlinanUrunlerTab.Location = new System.Drawing.Point(4, 29);
            this.AlinanUrunlerTab.Name = "AlinanUrunlerTab";
            this.AlinanUrunlerTab.Padding = new System.Windows.Forms.Padding(3);
            this.AlinanUrunlerTab.Size = new System.Drawing.Size(1330, 388);
            this.AlinanUrunlerTab.TabIndex = 1;
            this.AlinanUrunlerTab.Text = "Alınan Ürünler";
            // 
            // AlinanlarDataGridView
            // 
            this.AlinanlarDataGridView.AllowUserToAddRows = false;
            this.AlinanlarDataGridView.AllowUserToDeleteRows = false;
            this.AlinanlarDataGridView.AllowUserToResizeColumns = false;
            this.AlinanlarDataGridView.AllowUserToResizeRows = false;
            this.AlinanlarDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.AlinanlarDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AlinanlarDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AlinanlarDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlinanlarDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlinanlarDataGridView.Location = new System.Drawing.Point(3, 3);
            this.AlinanlarDataGridView.MultiSelect = false;
            this.AlinanlarDataGridView.Name = "AlinanlarDataGridView";
            this.AlinanlarDataGridView.ReadOnly = true;
            this.AlinanlarDataGridView.RowHeadersVisible = false;
            this.AlinanlarDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AlinanlarDataGridView.Size = new System.Drawing.Size(1324, 382);
            this.AlinanlarDataGridView.TabIndex = 1;
            // 
            // DigerleriTab
            // 
            this.DigerleriTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.DigerleriTab.Controls.Add(this.DigerDataGridView);
            this.DigerleriTab.Location = new System.Drawing.Point(4, 29);
            this.DigerleriTab.Name = "DigerleriTab";
            this.DigerleriTab.Padding = new System.Windows.Forms.Padding(3);
            this.DigerleriTab.Size = new System.Drawing.Size(1330, 388);
            this.DigerleriTab.TabIndex = 2;
            this.DigerleriTab.Text = "Diğer Tablolar";
            // 
            // DigerDataGridView
            // 
            this.DigerDataGridView.AllowUserToAddRows = false;
            this.DigerDataGridView.AllowUserToDeleteRows = false;
            this.DigerDataGridView.AllowUserToResizeColumns = false;
            this.DigerDataGridView.AllowUserToResizeRows = false;
            this.DigerDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DigerDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DigerDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DigerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DigerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DigerDataGridView.Location = new System.Drawing.Point(3, 3);
            this.DigerDataGridView.MultiSelect = false;
            this.DigerDataGridView.Name = "DigerDataGridView";
            this.DigerDataGridView.RowHeadersVisible = false;
            this.DigerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DigerDataGridView.Size = new System.Drawing.Size(1324, 382);
            this.DigerDataGridView.TabIndex = 1;
            this.DigerDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DigerDataGridView_CellDoubleClick);
            // 
            // ExcelKayitButton
            // 
            this.ExcelKayitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExcelKayitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.ExcelKayitButton.Location = new System.Drawing.Point(1025, 564);
            this.ExcelKayitButton.Name = "ExcelKayitButton";
            this.ExcelKayitButton.Size = new System.Drawing.Size(316, 45);
            this.ExcelKayitButton.TabIndex = 5;
            this.ExcelKayitButton.Text = "Excel\'e Kaydet";
            this.ExcelKayitButton.UseVisualStyleBackColor = true;
            // 
            // TablolarComboBox
            // 
            this.TablolarComboBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.TablolarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TablolarComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.TablolarComboBox.FormattingEnabled = true;
            this.TablolarComboBox.Items.AddRange(new object[] {
            "Firmalar",
            "Çalışanlar",
            "Ürünler",
            "Araçlar"});
            this.TablolarComboBox.Location = new System.Drawing.Point(1025, 35);
            this.TablolarComboBox.Name = "TablolarComboBox";
            this.TablolarComboBox.Size = new System.Drawing.Size(316, 33);
            this.TablolarComboBox.TabIndex = 1;
            this.TablolarComboBox.DropDown += new System.EventHandler(this.TablolarComboBox_DropDown);
            this.TablolarComboBox.SelectedIndexChanged += new System.EventHandler(this.TablolarComboBox_SelectedIndexChanged);
            // 
            // SilButton
            // 
            this.SilButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SilButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.SilButton.ForeColor = System.Drawing.Color.Red;
            this.SilButton.Location = new System.Drawing.Point(1025, 513);
            this.SilButton.Name = "SilButton";
            this.SilButton.Size = new System.Drawing.Size(316, 45);
            this.SilButton.TabIndex = 4;
            this.SilButton.Text = "Sil";
            this.SilButton.UseVisualStyleBackColor = true;
            this.SilButton.Click += new System.EventHandler(this.SilButton_Click);
            // 
            // KayitVeDuzenlemeTableLayout
            // 
            this.KayitVeDuzenlemeTableLayout.ColumnCount = 1;
            this.KayitVeDuzenlemeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.KayitVeDuzenlemeTableLayout.Controls.Add(this.TablolarComboBox, 0, 1);
            this.KayitVeDuzenlemeTableLayout.Controls.Add(this.TablolarTabControl, 0, 2);
            this.KayitVeDuzenlemeTableLayout.Controls.Add(this.SilButton, 0, 3);
            this.KayitVeDuzenlemeTableLayout.Controls.Add(this.ExcelKayitButton, 0, 4);
            this.KayitVeDuzenlemeTableLayout.Location = new System.Drawing.Point(0, 0);
            this.KayitVeDuzenlemeTableLayout.Name = "KayitVeDuzenlemeTableLayout";
            this.KayitVeDuzenlemeTableLayout.RowCount = 10;
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.KayitVeDuzenlemeTableLayout.Size = new System.Drawing.Size(1344, 648);
            this.KayitVeDuzenlemeTableLayout.TabIndex = 0;
            // 
            // KayitlarVeDuzenleme
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(1344, 648);
            this.Controls.Add(this.KayitVeDuzenlemeTableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1344, 648);
            this.Name = "KayitlarVeDuzenleme";
            this.Text = "KayitlarVeDuzenleme";
            this.TablolarTabControl.ResumeLayout(false);
            this.SatilanUrunlerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SatilanlarDataGridView)).EndInit();
            this.AlinanUrunlerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlinanlarDataGridView)).EndInit();
            this.DigerleriTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DigerDataGridView)).EndInit();
            this.KayitVeDuzenlemeTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TablolarTabControl;
        private System.Windows.Forms.TabPage SatilanUrunlerTab;
        private System.Windows.Forms.TabPage AlinanUrunlerTab;
        private System.Windows.Forms.TabPage DigerleriTab;
        private System.Windows.Forms.Button ExcelKayitButton;
        private System.Windows.Forms.ComboBox TablolarComboBox;
        private System.Windows.Forms.Button SilButton;
        private System.Windows.Forms.TableLayoutPanel KayitVeDuzenlemeTableLayout;
        private System.Windows.Forms.DataGridView SatilanlarDataGridView;
        private System.Windows.Forms.DataGridView AlinanlarDataGridView;
        private System.Windows.Forms.DataGridView DigerDataGridView;
    }
}