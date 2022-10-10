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
            this.TablolarTab = new System.Windows.Forms.TabPage();
            this.TablolarDataGridView = new System.Windows.Forms.DataGridView();
            this.ExcelKayitButton = new System.Windows.Forms.Button();
            this.TablolarComboBox = new System.Windows.Forms.ComboBox();
            this.KayitVeDuzenlemeTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TablolarTabControl.SuspendLayout();
            this.TablolarTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablolarDataGridView)).BeginInit();
            this.KayitVeDuzenlemeTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TablolarTabControl
            // 
            this.TablolarTabControl.Controls.Add(this.TablolarTab);
            this.TablolarTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablolarTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TablolarTabControl.Location = new System.Drawing.Point(3, 86);
            this.TablolarTabControl.Name = "TablolarTabControl";
            this.TablolarTabControl.SelectedIndex = 0;
            this.TablolarTabControl.Size = new System.Drawing.Size(1338, 447);
            this.TablolarTabControl.TabIndex = 6;
            // 
            // TablolarTab
            // 
            this.TablolarTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.TablolarTab.Controls.Add(this.TablolarDataGridView);
            this.TablolarTab.Location = new System.Drawing.Point(4, 29);
            this.TablolarTab.Name = "TablolarTab";
            this.TablolarTab.Padding = new System.Windows.Forms.Padding(3);
            this.TablolarTab.Size = new System.Drawing.Size(1330, 414);
            this.TablolarTab.TabIndex = 0;
            this.TablolarTab.Text = "Tablolar";
            // 
            // TablolarDataGridView
            // 
            this.TablolarDataGridView.AllowUserToAddRows = false;
            this.TablolarDataGridView.AllowUserToDeleteRows = false;
            this.TablolarDataGridView.AllowUserToResizeColumns = false;
            this.TablolarDataGridView.AllowUserToResizeRows = false;
            this.TablolarDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TablolarDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TablolarDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.TablolarDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TablolarDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablolarDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablolarDataGridView.Location = new System.Drawing.Point(3, 3);
            this.TablolarDataGridView.MultiSelect = false;
            this.TablolarDataGridView.Name = "TablolarDataGridView";
            this.TablolarDataGridView.ReadOnly = true;
            this.TablolarDataGridView.RowHeadersVisible = false;
            this.TablolarDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablolarDataGridView.Size = new System.Drawing.Size(1324, 408);
            this.TablolarDataGridView.TabIndex = 0;
            this.TablolarDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TablolarDataGridView_CellMouseClick);
            // 
            // ExcelKayitButton
            // 
            this.ExcelKayitButton.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.TablolarComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TablolarComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.TablolarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TablolarComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.TablolarComboBox.FormattingEnabled = true;
            this.TablolarComboBox.Items.AddRange(new object[] {
            "FIRMALAR",
            "CALISANLAR",
            "ARACLAR",
            "URUNLER",
            "SATIM_TARTIMLARI",
            "ALIM_TARTIMLARI"});
            this.TablolarComboBox.Location = new System.Drawing.Point(3, 35);
            this.TablolarComboBox.Name = "TablolarComboBox";
            this.TablolarComboBox.Size = new System.Drawing.Size(316, 33);
            this.TablolarComboBox.TabIndex = 1;
            this.TablolarComboBox.DropDown += new System.EventHandler(this.TablolarComboBox_DropDown);
            this.TablolarComboBox.SelectedIndexChanged += new System.EventHandler(this.TablolarComboBox_SelectedIndexChanged);
            this.TablolarComboBox.DropDownClosed += new System.EventHandler(this.TablolarComboBox_DropDownClosed);
            // 
            // KayitVeDuzenlemeTableLayout
            // 
            this.KayitVeDuzenlemeTableLayout.ColumnCount = 1;
            this.KayitVeDuzenlemeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.KayitVeDuzenlemeTableLayout.Controls.Add(this.TablolarComboBox, 0, 1);
            this.KayitVeDuzenlemeTableLayout.Controls.Add(this.TablolarTabControl, 0, 2);
            this.KayitVeDuzenlemeTableLayout.Controls.Add(this.ExcelKayitButton, 0, 4);
            this.KayitVeDuzenlemeTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KayitVeDuzenlemeTableLayout.Location = new System.Drawing.Point(0, 0);
            this.KayitVeDuzenlemeTableLayout.Name = "KayitVeDuzenlemeTableLayout";
            this.KayitVeDuzenlemeTableLayout.RowCount = 10;
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.KayitVeDuzenlemeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
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
            this.Load += new System.EventHandler(this.KayitlarVeDuzenleme_Load);
            this.TablolarTabControl.ResumeLayout(false);
            this.TablolarTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TablolarDataGridView)).EndInit();
            this.KayitVeDuzenlemeTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TablolarTabControl;
        private System.Windows.Forms.TabPage TablolarTab;
        private System.Windows.Forms.Button ExcelKayitButton;
        private System.Windows.Forms.ComboBox TablolarComboBox;
        private System.Windows.Forms.TableLayoutPanel KayitVeDuzenlemeTableLayout;
        private System.Windows.Forms.DataGridView TablolarDataGridView;
    }
}