using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace TamTarti2202
{
    public partial class Ayarlar : Form
    {
        DataBaseModifier db = new DataBaseModifier();

        public Ayarlar()
        {
            InitializeComponent();

            try
            {
                foreach (var seriPort in SerialPort.GetPortNames())
                {
                    SeriPortComboBox.Items.Add(seriPort);
                }
                FirmaAyariComboBox.DataSource = db.GetTable("SELECT ADI FROM FIRMALAR");
                FirmaAyariComboBox.DisplayMember = "ADI";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            LoadConfigurationSettings();
        }

        private void LoadConfigurationSettings()
        {
            SeriPortComboBox.Text = Properties.KullaniciAyarlari.Default.PortName;
            BoudRateComboBox.Text = Properties.KullaniciAyarlari.Default.BoudRate.ToString();
            ParityComboBox.Text = Properties.KullaniciAyarlari.Default.Parity.ToString();
            StopBitsComboBox.Text = Properties.KullaniciAyarlari.Default.StopBits.ToString();
            DataBitsComboBox.Text = Properties.KullaniciAyarlari.Default.DataBits.ToString();
            FirmaAyariComboBox.Text = Properties.KullaniciAyarlari.Default.FirmaAdi.ToString();
            DataUzunluguTextBox.Text = Properties.KullaniciAyarlari.Default.SerialDataLenght.ToString();
            DataUzunluguXTextBox.Text = Properties.KullaniciAyarlari.Default.SerialDataLenghtX.ToString();
            DataUzunluguYTextBox.Text = Properties.KullaniciAyarlari.Default.SerialDataLenghtY.ToString();
            ServerTextBox.Text = Properties.KullaniciAyarlari.Default.Server;
            DatabaseTextBox.Text = Properties.KullaniciAyarlari.Default.Database;
            UserIdTextBox.Text = Properties.KullaniciAyarlari.Default.UserId;
            UserPasswordTextBox.Text = Properties.KullaniciAyarlari.Default.UserPassword;
            XampTextBox.Text = Properties.KullaniciAyarlari.Default.XampPath;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]

        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Değişiklikleri kaydetmeden sayafayı kapat.", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if(dialogResult == DialogResult.No)
            {
            }
        }

        private void Ayarlar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void IndikatorAyarlariKaydetButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Değişiklikler kaydedilip program yeniden başlatılacak.", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (SeriPortComboBox.SelectedIndex != -1 && BoudRateComboBox.SelectedIndex != -1 && ParityComboBox.SelectedIndex != -1
                && StopBitsComboBox.SelectedIndex != -1 && DataBitsComboBox.SelectedIndex != -1)
                {
                    try
                    {
                        Properties.KullaniciAyarlari.Default.PortName = SeriPortComboBox.SelectedItem.ToString();
                        Properties.KullaniciAyarlari.Default.BoudRate = int.Parse(BoudRateComboBox.SelectedItem.ToString());
                        Properties.KullaniciAyarlari.Default.Parity = (Parity)Enum.Parse(typeof(Parity), ParityComboBox.SelectedItem.ToString());
                        Properties.KullaniciAyarlari.Default.StopBits = (StopBits)Enum.Parse(typeof(StopBits), StopBitsComboBox.SelectedItem.ToString());
                        Properties.KullaniciAyarlari.Default.DataBits = int.Parse(DataBitsComboBox.SelectedItem.ToString());
                        Properties.KullaniciAyarlari.Default.SerialDataLenght = int.Parse(DataUzunluguTextBox.Text);
                        Properties.KullaniciAyarlari.Default.SerialDataLenghtX = int.Parse(DataUzunluguXTextBox.Text);
                        Properties.KullaniciAyarlari.Default.SerialDataLenghtY = int.Parse(DataUzunluguYTextBox.Text);

                        Properties.KullaniciAyarlari.Default.Save();

                        MessageBox.Show("Ayarlar başarıyla kayıt edildi program yeniden başlatılıcak!");
                        Application.Restart();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void DataUzunluguTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DataUzunluguXTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DataUzunluguYTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Değişiklikler kaydedilip program yeniden başlatılacak.", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Properties.KullaniciAyarlari.Default.Server = ServerTextBox.Text;
                    Properties.KullaniciAyarlari.Default.Database = DatabaseTextBox.Text;
                    Properties.KullaniciAyarlari.Default.UserId = UserIdTextBox.Text;
                    Properties.KullaniciAyarlari.Default.UserPassword = UserPasswordTextBox.Text;
                    Properties.KullaniciAyarlari.Default.XampPath = XampTextBox.Text;

                    Properties.KullaniciAyarlari.Default.Save();
                    MessageBox.Show("Ayarlar başarıyla kayıt edildi program yeniden başlatılıcak!");
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void FirmaAyarlariKaydetButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Değişiklikler kaydedilip program yeniden başlatılacak.", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (FirmaAyariComboBox.SelectedIndex != -1)
                {
                    try
                    {
                        Properties.KullaniciAyarlari.Default.FirmaAdi = FirmaAyariComboBox.Text;
                        Properties.KullaniciAyarlari.Default.Save();
                        MessageBox.Show("Ayarlar başarıyla kayıt edildi program yeniden başlatılıcak!");
                        Application.Restart();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }
    }
}
