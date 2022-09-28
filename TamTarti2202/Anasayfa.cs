using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
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
        private const int cGrip = 16;
        private const int cCaption = 32;
         
        private DataBaseModifier db = new DataBaseModifier();

        private string xampPath = Properties.KullaniciAyarlari.Default.XampPath;
        private int serialDataLenght = Properties.KullaniciAyarlari.Default.SerialDataLenght;
        private int serialDataLenghtX = Properties.KullaniciAyarlari.Default.SerialDataLenghtX;
        private int serialDataLenghtY = Properties.KullaniciAyarlari.Default.SerialDataLenghtY;

        private static bool openPort = true;
        private static string kgLabelData;
        private Thread readSerialDataUsingThread;
        private string serialData;

        public Anasayfa()
        {
            StartXampp();
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);

            if (this.Size.Width >= 1619)
            {
                KgPnl.Location = new Point(1315, 35);
            }
            if (this.Size.Width <= 1619)
            {
                KgPnl.Location = new Point(1055, 35);
            }
            if (this.Size.Width >= 1879)
            {
                KgPnl.Location = new Point(1575, 35);
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
            CreateDataBaseAndTables();
            TartimVeKayit t1 = new TartimVeKayit();
            t1.TopLevel = false;
            AltMenuPanel.Controls.Add(t1);
            t1.Dock = DockStyle.Fill;
            t1.Show();
        }

        private void LoadConfigurationSettings()
        {
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
                Console.WriteLine(ex.Message);
            }    
        }

        private void StartXampp()
        {
            try
            {
                var runningProcessByName = Process.GetProcessesByName("xampp-control");
                if (runningProcessByName.Length == 0)
                {
                    Process.Start(xampPath);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CreateDataBaseAndTables()
        {
            try
            {
                db.RunQueryCreate("CREATE DATABASE IF NOT EXISTS TARTIM CHARACTER SET UTF8 COLLATE UTF8_UNICODE_CI;");

                db.RunQuery("CREATE TABLE IF NOT EXISTS FIRMALAR(ID INT NOT NULL AUTO_INCREMENT, ADI VARCHAR(255) NOT NULL UNIQUE," +
                    " VERGI_DAIRESI VARCHAR(255), VERGI_NO VARCHAR(10), TELEFON_NO VARCHAR(18), FAX_NO VARCHAR(16), " +
                    "WEB_SITE VARCHAR(255), EMAIL VARCHAR(255), ADRES VARCHAR(255) NOT NULL, PRIMARY KEY(ID))");

                db.RunQuery("CREATE TABLE IF NOT EXISTS ARACLAR(ID INT NOT NULL AUTO_INCREMENT, PLAKA VARCHAR(7) NOT NULL UNIQUE, " +
                    "DARA_KG DOUBLE, DORSE_PLAKA VARCHAR(7), PRIMARY KEY(ID))");

                db.RunQuery("CREATE TABLE IF NOT EXISTS CALISANLAR(ID INT NOT NULL AUTO_INCREMENT, ADI VARCHAR(255) NOT NULL, " +
                    "UNVAN VARCHAR(255), TC_NO VARCHAR(11) NULL UNIQUE, TELEFON_NO VARCHAR(18), ADRES VARCHAR(255), PRIMARY KEY(ID))");

                db.RunQuery("CREATE TABLE IF NOT EXISTS URUNLER(ID INT NOT NULL AUTO_INCREMENT, ADI VARCHAR(255) NOT NULL UNIQUE, PRIMARY KEY(ID))");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private async Task OpenPortEveryTenSeconds()
        {
            while (openPort == true)
            {
                var delayTask = Task.Delay(1000);
                try
                {
                    if (!serialPort1.IsOpen)
                    {
                        Console.WriteLine("port opening");
                        serialPort1.Open();
                        StartReadSerialPort();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message); ;
                }               
                await delayTask;
            }
        }

        private void StartReadSerialPort()
        {
            try
            {         
                ReadSerialData();  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ReadSerialData()
        {
            try
            {
                Console.WriteLine("thread creating");
                readSerialDataUsingThread = new Thread(ReadSerial);
                readSerialDataUsingThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ReadSerial()
        {
            try
            {
                Console.WriteLine("serial data reading");
                while (serialPort1.IsOpen)
                {
                    serialData = serialPort1.ReadLine();
                    if (serialData.Length == serialDataLenght)
                    {
                        WriteSerialData(serialData.Substring(serialDataLenghtX, serialDataLenghtY));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                KgLabel.Text = ex.ToString();
                Console.WriteLine(ex.Message);
            }
        }

        public void SeriPortClose()
        {
            try
            {
                openPort = false;
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    readSerialDataUsingThread.Abort();
                    Console.WriteLine("Seri Port Thread is alive = " + readSerialDataUsingThread.IsAlive.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetKgData()
        {
            return kgLabelData;
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            LoadConfigurationSettings();
            OpenPortEveryTenSeconds();
        }
    }
}
