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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ExcelKayitButton = new System.Windows.Forms.Button();
            this.TablolarComboBox = new System.Windows.Forms.ComboBox();
            this.KayitVeDuzenlemeTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TablolarDataGridView = new System.Windows.Forms.DataGridView();
            this.KayitVeDuzenlemeTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablolarDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ExcelKayitButton
            // 
            this.ExcelKayitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExcelKayitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExcelKayitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ExcelKayitButton.Location = new System.Drawing.Point(1025, 564);
            this.ExcelKayitButton.Name = "ExcelKayitButton";
            this.ExcelKayitButton.Size = new System.Drawing.Size(316, 45);
            this.ExcelKayitButton.TabIndex = 5;
            this.ExcelKayitButton.Text = "Excel\'e Kaydet";
            this.ExcelKayitButton.UseVisualStyleBackColor = true;
            this.ExcelKayitButton.Click += new System.EventHandler(this.ExcelKayitButton_Click);
            // 
            // TablolarComboBox
            // 
            this.TablolarComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TablolarComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.TablolarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TablolarComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
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
            this.TablolarComboBox.Size = new System.Drawing.Size(316, 37);
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
            this.KayitVeDuzenlemeTableLayout.Controls.Add(this.ExcelKayitButton, 0, 4);
            this.KayitVeDuzenlemeTableLayout.Controls.Add(this.TablolarDataGridView, 0, 2);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablolarDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TablolarDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TablolarDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.TablolarDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablolarDataGridView.Location = new System.Drawing.Point(3, 86);
            this.TablolarDataGridView.MultiSelect = false;
            this.TablolarDataGridView.Name = "TablolarDataGridView";
            this.TablolarDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablolarDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.TablolarDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TablolarDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.TablolarDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablolarDataGridView.Size = new System.Drawing.Size(1338, 447);
            this.TablolarDataGridView.TabIndex = 0;
            this.TablolarDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TablolarDataGridView_CellMouseClick);
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
            this.KayitVeDuzenlemeTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TablolarDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ExcelKayitButton;
        private System.Windows.Forms.ComboBox TablolarComboBox;
        private System.Windows.Forms.TableLayoutPanel KayitVeDuzenlemeTableLayout;
        private System.Windows.Forms.DataGridView TablolarDataGridView;
    }
}