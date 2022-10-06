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

        public KayitlarVeDuzenleme()
        {
            InitializeComponent();
            TablolarComboBox.Items.Add("Tablo Seçiniz:");
            TablolarComboBox.Text = "Tablo Seçiniz:";
            TablolarDataGridView.EnableHeadersVisualStyles = false;
            TablolarDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = TablolarDataGridView.ColumnHeadersDefaultCellStyle.BackColor;       
        }

        private void TablolarComboBox_DropDown(object sender, EventArgs e)
        {
            if(TablolarComboBox.Items.Contains("Tablo Seçiniz:") || TablolarComboBox.SelectedIndex > -1)
            {
                TablolarComboBox.Items.Remove("Tablo Seçiniz:");
            }
        }

        private void TablolarComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(TablolarComboBox.SelectedIndex == -1)
            {
                TablolarComboBox.Items.Add("Tablo Seçiniz:");
                TablolarComboBox.Text = "Tablo Seçiniz:";
            }
        }

        private void TablolarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TablolarDataGridView.DataSource = db.GetTable("SELECT * FROM " + TablolarComboBox.Text);
            TablolarTab.Text = TablolarComboBox.Text;
        }

        private void TablolarDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                MessageBox.Show(TablolarDataGridView.Rows[TablolarDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Tablo Seçimi Yapınız! Hata:" + ex.Message);
            }
        }
    }
}
