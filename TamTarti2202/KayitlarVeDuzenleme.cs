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
using System.Windows.Controls;
using System.Windows.Forms;

namespace TamTarti2202
{
    public partial class KayitlarVeDuzenleme : Form
    {
        DataBaseModifier db = new DataBaseModifier();
        int currentCellId = -1;
        string tableColumnName = "";

        public KayitlarVeDuzenleme()
        {
            InitializeComponent();
        }

        private void disableSort()
        {
            foreach (DataGridViewColumn column in TablolarDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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
            disableSort();
            if(TablolarComboBox.SelectedIndex <= 3)
            {
                TablolarDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            else
            {
                TablolarDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void m_itemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            try
            {
                if(item.ToString() == "Sil")
                {
                    string yeniDeger = Interaction.InputBox("Silmek İçin Yeni EVET Yazıp Tamama Basınız.:", tableColumnName,
                        "", 250, 250);

                    if(yeniDeger.ToUpper() == "EVET")
                    {
                        if (db.RunQuery("DELETE FROM " + TablolarComboBox.Text + " WHERE ID = " + currentCellId))
                        {
                            MessageBox.Show("Başarıyla Silindi!!");
                            TablolarDataGridView.DataSource = db.GetTable("SELECT * FROM " + TablolarComboBox.Text);
                        }
                        else
                        {
                            MessageBox.Show("Silinemedi!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Silinemedi!");
                    }
                }
                if(item.ToString() == "Güncelle")
                {
                    string yeniDeger = Interaction.InputBox("Güncellemek İçin Yeni " + tableColumnName + " Değerini Giriniz:", tableColumnName,
                        TablolarDataGridView.CurrentCell.Value.ToString(), 250, 250);

                    if (!string.IsNullOrWhiteSpace(yeniDeger) && tableColumnName != "ID")
                    {
                        if (db.RunQuery("UPDATE " + TablolarComboBox.Text + " SET " + tableColumnName +
                            " = '" + yeniDeger.ToUpper() + "' WHERE ID = " + currentCellId))
                        {
                            MessageBox.Show("Başarıyla Güncellendi!");
                            TablolarDataGridView.DataSource = db.GetTable("SELECT * FROM " + TablolarComboBox.Text);
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
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Tablo Seçimi Yapınız! Hata:" + ex.Message);
            }
        }

        private void TablolarDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                currentCellId = Convert.ToInt16(TablolarDataGridView.Rows[TablolarDataGridView.CurrentRow.Index].Cells[0].Value);
                tableColumnName = TablolarDataGridView.CurrentCell.OwningColumn.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (TablolarComboBox.SelectedIndex <= 3)
            {
                if (e.RowIndex != -1)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        ContextMenuStrip m = new ContextMenuStrip();
                        m.Font = new Font("Segoe UI", 18F);
                        m.Items.Add("Güncelle");
                        m.Items.Add("Sil");
                        m.Items.Add("İptal");
                        m.Show(TablolarDataGridView, new Point(e.X, e.Y));
                        m.ItemClicked += new ToolStripItemClickedEventHandler(m_itemClicked);
                    }
                }
            }
            else
            {
                if (e.RowIndex != -1)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        ContextMenuStrip m = new ContextMenuStrip();
                        m.Font = new Font("Segoe UI", 18F); 
                        m.Items.Add("Sil");
                        m.Items.Add("İptal");
                        m.Show(TablolarDataGridView, new Point(e.X, e.Y));
                        m.ItemClicked += new ToolStripItemClickedEventHandler(m_itemClicked);
                    }
                }
            }
            
        }

        private void KayitlarVeDuzenleme_Load(object sender, EventArgs e)
        {
            TablolarComboBox.Items.Add("Tablo Seçiniz:");
            TablolarComboBox.Text = "Tablo Seçiniz:";
            TablolarDataGridView.EnableHeadersVisualStyles = false;
            TablolarDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = TablolarDataGridView.ColumnHeadersDefaultCellStyle.BackColor;
        }

        private void ExcelKayitButton_Click(object sender, EventArgs e)
        {
            ExcelDisaAktar(TablolarDataGridView);
        }

        public void ExcelDisaAktar(DataGridView dataGridView1)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "Excel Dosyaları";
            save.DefaultExt = "xlsx";
            save.Filter = "xlsx Dosyaları (*.xlsx)|*.xlsx|Tüm Dosyalar(*.*)|*.*";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sayfa1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Excel Dışa Aktarım";
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(save.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
            }
        }
    }
}
