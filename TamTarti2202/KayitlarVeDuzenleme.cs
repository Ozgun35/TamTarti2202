using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TamTarti2202
{
    public partial class KayitlarVeDuzenleme : Form
    {
        DataBaseModifier db = new DataBaseModifier();
        string tableName;
        string urunTable;

        public KayitlarVeDuzenleme()
        {
            InitializeComponent();

            TablolarComboBox.Enabled = false;
            SilButton.Enabled = false;

            SatilanlarDataGridView.DataSource = db.GetTable("SELECT * FROM SATIM_TARTIMLARI");

            tableName = "";
            urunTable = "";

            SatilanlarDataGridView.EnableHeadersVisualStyles = false;
            SatilanlarDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = SatilanlarDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            AlinanlarDataGridView.EnableHeadersVisualStyles = false;
            AlinanlarDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = AlinanlarDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            DigerDataGridView.EnableHeadersVisualStyles = false;
            DigerDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = DigerDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
        }

        private void TablolarTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TablolarTabControl.SelectedIndex == 0)
            {
                tableName = "SATIM_TARTIMLARI";
                urunTable = "SATILANLAR";
                SatilanlarDataGridView.DataSource = db.GetTable("SELECT * FROM SATIM_TARTIMLARI");
                TablolarComboBox.SelectedIndex = -1;
                TablolarComboBox.Enabled = false;
            }
            if(TablolarTabControl.SelectedIndex == 1)
            {
                tableName = "ALIM_TARTIMLARI";
                urunTable = "ALINANLAR";
                AlinanlarDataGridView.DataSource = db.GetTable("SELECT * FROM ALIM_TARTIMLARI");
                TablolarComboBox.SelectedIndex = -1;
                TablolarComboBox.Enabled = false;
            }
            if(TablolarTabControl.SelectedIndex == 2)
            {
                if(!TablolarComboBox.Items.Contains("Tablo Seçiniz:"))
                {
                    TablolarComboBox.Items.Add("Tablo Seçiniz:");
                }
                urunTable = "";
                TablolarComboBox.Text = "Tablo Seçiniz:";
                TablolarComboBox.Enabled = true;
            }
        }

        private void TablolarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TablolarComboBox.SelectedIndex == -1)
            {
                tableName = "";
            }
            if(TablolarComboBox.SelectedIndex == 0)
            {
                DigerDataGridView.DataSource = db.GetTable("SELECT * FROM FIRMALAR");
                tableName = "FIRMALAR";
                urunTable = "";
            }
            if (TablolarComboBox.SelectedIndex == 1)
            {
                DigerDataGridView.DataSource = db.GetTable("SELECT * FROM CALISANLAR");
                tableName = "CALISANLAR";
                urunTable = "";
            }
            if (TablolarComboBox.SelectedIndex == 2)
            {
                DigerDataGridView.DataSource = db.GetTable("SELECT * FROM URUNLER");
                tableName = "URUNLER";
                urunTable = "";
            }
            if (TablolarComboBox.SelectedIndex == 3)
            {
                DigerDataGridView.DataSource = db.GetTable("SELECT * FROM ARACLAR");
                tableName = "ARACLAR";
                urunTable = "";
            }
        }

        private void TablolarComboBox_DropDown(object sender, EventArgs e)
        {
            if(TablolarComboBox.Items.Contains("Tablo Seçiniz:"))
            {
                TablolarComboBox.Items.Remove("Tablo Seçiniz:");
            }
        }

        private void DigerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string yeniDeger = Interaction.InputBox("Güncellemek İçin Yeni Değeri Giriniz:",  DigerDataGridView.CurrentCell.OwningColumn.Name , 
                DigerDataGridView.CurrentCell.Value.ToString(), 250, 250);

            if(!string.IsNullOrWhiteSpace(yeniDeger) && DigerDataGridView.CurrentCell.OwningColumn.Name != "ID")
            {
                if (db.RunQuery("UPDATE " + tableName + " SET " + DigerDataGridView.CurrentCell.OwningColumn.Name + 
                    " = '" + yeniDeger.ToUpper() + "' WHERE ID = " + Convert.ToInt32(DigerDataGridView.Rows[DigerDataGridView.CurrentRow.Index].Cells[0].Value)))
                {
                    MessageBox.Show("Başarıyla Güncellendi!");
                    DigerDataGridView.DataSource = db.GetTable("SELECT * FROM " + tableName);
                }
                else
                {
                    MessageBox.Show("Güncellenemedi!");
                }
            }
            else
            {
                MessageBox.Show("Güncellenemedi!");
            }
        }

        private void SilButton_Click(object sender, EventArgs e)
        {

        }
    }
}
