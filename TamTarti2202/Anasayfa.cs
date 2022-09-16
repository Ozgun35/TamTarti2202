using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TamTarti2202
{
    public partial class Anasayfa : Form
    {
        private DataBaseModifier db = new DataBaseModifier();
        private static string connectionForCreate = "server=localhost;uid=root;pwd=1960;Charset=utf8;convert zero datetime=True;";
        private static string connectionTartim = "server=localhost;database=tartim;uid=root;pwd=1960;Charset=utf8;convert zero datetime=True;";
        private static string connectionUrunler = "server=localhost;database=urunler;uid=root;pwd=1960;Charset=utf8;convert zero datetime=True;";
        private static int i = 1;
        private Thread readSerialDataUsingThread;
        private string serialData;
        private static string kgLabelData;

        public Anasayfa()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);

            if (this.Size.Width >= 1434)
            {
                KilogramPnl.Location = new Point(1175, 35);
            }
            if (this.Size.Width <= 1433)
            {
                KilogramPnl.Location = new Point(980, 35);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]

        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Programı kapatmak için Evet'e tıklayın.", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                i = 0;
                SeriPortClose();
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void ResizeBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void UstMenuPnl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AyarlarBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Ayarlar"] as Ayarlar != null)
            {
            }
            else
            {
                Ayarlar a1 = new Ayarlar();
                a1.Show();
            }
        }

        private void TartimveKayitBtn_Click(object sender, EventArgs e)
        {
            TartimVeKayit t1 = new TartimVeKayit();
            t1.TopLevel = false;
            AltMenuPanel.Controls.Add(t1);
            t1.Dock = DockStyle.Fill;
            t1.Show();
        }

        private void LoadConfigurationSettings()
        {
            StartXampp();
            try
            {
                serialPort1.PortName = Properties.KullaniciAyarlari.Default.PortName;
                serialPort1.BaudRate = Properties.KullaniciAyarlari.Default.BoudRate;
                serialPort1.Parity = Properties.KullaniciAyarlari.Default.Parity;
                serialPort1.StopBits = Properties.KullaniciAyarlari.Default.StopBits;
                serialPort1.DataBits = Properties.KullaniciAyarlari.Default.DataBits;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " load configurationsettings");
            }
            CreateDataBaseAndTables();       
        }

        private void StartXampp()
        {
            var runningProcessByName = Process.GetProcessesByName("xampp-control");
            if (runningProcessByName.Length == 0)
            {
                Process.Start(@"C:\xampp\xampp-control.exe");
            }
        }

        private void CreateDataBaseAndTables()
        {
            try
            {
                db.RunQuery("CREATE DATABASE IF NOT EXISTS TARTIM CHARACTER SET UTF8 COLLATE UTF8_UNICODE_CI;", connectionForCreate);
                db.RunQuery("CREATE DATABASE IF NOT EXISTS URUNLER CHARACTER SET UTF8 COLLATE UTF8_UNICODE_CI;", connectionForCreate);

                db.RunQuery("CREATE TABLE IF NOT EXISTS FIRMALAR(ID INT NOT NULL AUTO_INCREMENT, ADI VARCHAR(255) NOT NULL UNIQUE," +
                    " VERGI_DAIRESI VARCHAR(255), VERGI_NO VARCHAR(10), TELEFON_NO VARCHAR(18), FAX_NO VARCHAR(16), " +
                    "WEB_SITE VARCHAR(255), EMAIL VARCHAR(255), ADRES VARCHAR(255) NOT NULL, ADRES_2 VARCHAR(255)," +
                    " PRIMARY KEY(ID))", connectionTartim);

                db.RunQuery("CREATE TABLE IF NOT EXISTS ARACLAR(ID INT NOT NULL AUTO_INCREMENT, PLAKA VARCHAR(8) NOT NULL UNIQUE, " +
                    "DARA INT(1) NOT NULL, DARA_KG DOUBLE, DORSE INT(1) NOT NULL, DORSE_PLAKA VARCHAR(8), PRIMARY KEY(ID))", connectionTartim);

                db.RunQuery("CREATE TABLE IF NOT EXISTS SOFORLER(ID INT NOT NULL AUTO_INCREMENT, ADI VARCHAR(255) NOT NULL, " +
                    "TC_NO VARCHAR(11) NULL UNIQUE, TELEFON_NO VARCHAR(18), ADRES VARCHAR(255), PRIMARY KEY(ID))", connectionTartim);

                db.RunQuery("CREATE TABLE IF NOT EXISTS URUNLER(ID INT NOT NULL AUTO_INCREMENT, ADI VARCHAR(255) NOT NULL UNIQUE, PRIMARY KEY(ID))", connectionTartim);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            LoadConfigurationSettings();
            OpenPortEveryTenSeconds();
        }

        private async Task OpenPortEveryTenSeconds()
        {
            while (i == 1)
            {
                var delayTask = Task.Delay(1000);
                try
                {
                    if (!serialPort1.IsOpen)
                    {
                        StartReadSerialPort();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + " openporteverytencsecons");
                }
                
                await delayTask;
            }
        }

        private void StartReadSerialPort()
        {
            try
            {         
                serialPort1.Open();
                ReadSerialData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "StartReadSerialPort exception" + serialPort1.IsOpen.ToString());
            }
        }

        private void ReadSerialData()
        {
            try
            {
                readSerialDataUsingThread = new Thread(ReadSerial);
                readSerialDataUsingThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "ReadSerialData");
            }
        }

        private void ReadSerial()
        {
            while (serialPort1.IsOpen)
            {
                try
                {
                    serialData = serialPort1.ReadLine();
                    WriteSerialData(serialData.Substring(6, 7));
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message + " ReadSerial");
                }
            }
        }

        private delegate void WriteToLabel(string serialData);

        private void WriteSerialData(string serialData)
        {
            try
            {
                if (KgLabel.InvokeRequired)
                {
                    kgLabelData = serialData;
                    WriteToLabel writeToLabel = WriteSerialData;
                    Invoke(writeToLabel, serialData);
                }
                else
                {
                    kgLabelData = serialData;
                    KgLabel.Text = serialData;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " WriteSerialData");
            }
        }

        public void SeriPortClose()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " seriportclose");
            }
        }

        public string GetKgData()
        {
            return kgLabelData;
        }
    }
}
