using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TamTarti2202
{
    public partial class TartimVeKayit : Form
    {
        private static string connectionTartim = "server=localhost;database=tartim;uid=root;pwd=1960;Charset=utf8;convert zero datetime=True;";

        private Anasayfa aSayfa = new Anasayfa();
        private DataBaseModifier db = new DataBaseModifier();

        private Size tartimVeKayitOrjinalSize;
        private Rectangle alimSatimOrjinalRect;
        private Rectangle eklemeOrjinalRect;

        public TartimVeKayit()
        {
            InitializeComponent();

            tartimVeKayitOrjinalSize = this.Size;
            alimSatimOrjinalRect = new Rectangle(AlimSatimTabControl.Location.X, AlimSatimTabControl.Location.Y, AlimSatimTabControl.Width, AlimSatimTabControl.Height);
            eklemeOrjinalRect = new Rectangle(EklemeTabControl.Location.X, EklemeTabControl.Location.Y, EklemeTabControl.Width, EklemeTabControl.Height);
        }

        private void ResizeControlTabs()
        {
            ResizeControl(alimSatimOrjinalRect, AlimSatimTabControl);
            ResizeControl(eklemeOrjinalRect, EklemeTabControl);
        }

        private void ResizeControl(Rectangle orjinalControlRect, System.Windows.Forms.Control control)
        {
            float ratioX = (float)(this.Width) / (float)(tartimVeKayitOrjinalSize.Width);
            float ratioY = (float)(this.Height) / (float)(tartimVeKayitOrjinalSize.Height);

            int xNew = (int)(orjinalControlRect.X * ratioX);
            int yNew = (int)(orjinalControlRect.Y * ratioY);
            int newWidth = (int)(orjinalControlRect.Width * ratioX);
            int newHeight = (int)(orjinalControlRect.Height * ratioY);

            control.Location = new Point(xNew, yNew);
            control.Size = new Size(newWidth, newHeight);
        }

        private void TartimVeKayit_Resize(object sender, EventArgs e)
        {
            ResizeControlTabs();
        }

        private void FirmaEklemeButton_Click(object sender, EventArgs e)
        {
            try
            {   
                db.RunQuery("INSERT INTO FIRMALAR(ADI, VERGI_DAIRESI, VERGI_NO, TELEFON_NO, FAX_NO, WEB_SITE, EMAIL, ADRES, ADRES_2) " +
                    "VALUES('" + FirmaAdiTextBox.Text.ToUpper() + "', '" + FirmaVergiDairesiTextBox.Text.ToUpper() + "', " +
                    "'" + FirmaVergiNoTextBox.Text + "', '" + FirmaTelNoTextBox.Text.ToUpper() + "', '" + FirmaFaxNoTextBox.Text.ToUpper() + "', " +
                    "'" + FirmaWebSiteTextBox.Text.ToUpper() + "', '" + FirmaEmailTextBoxt.Text.ToUpper() + "', " +
                    "'" + FirmaAdresiTextBox.Text.ToUpper() + "', '" + FirmaAdresiIkiTextBox.Text.ToUpper() + "')", connectionTartim);

                MessageBox.Show("Firma barşarıyla kayıt edildi.");
                FirmaFormClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FirmaFormClear()
        {
            FirmaAdiTextBox.Text = "";
            FirmaVergiDairesiTextBox.Text = "";
            FirmaVergiNoTextBox.Text = "";
            FirmaTelNoTextBox.Text = "";
            FirmaFaxNoTextBox.Text = "";
            FirmaWebSiteTextBox.Text = "";
            FirmaEmailTextBoxt.Text = "";
            FirmaAdresiTextBox.Text = "";
            FirmaAdresiIkiTextBox.Text = "";
        }

        private void AracEklemeButton_Click(object sender, EventArgs e)
        {
            try
            {
                db.RunQuery("INSERT INTO ARACLAR(PLAKA, DARA, DARA_KG, DORSE, DORSE_PLAKA) VALUES('" + AracPlakaTextBox.Text + "', '" + DaraVarCheck() + "', " +
                    "'" + Convert.ToDouble(AracDaraTextBox.Text) + "', '" + DorseVarCheck() + "', '" + AracDorsePlakaTextBox.Text + "')", connectionTartim);
                AracFormClear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AracFormClear()
        {
            AracPlakaTextBox.Text = "";
            AracDaraTextBox.Text = "";
            AracDorsePlakaTextBox.Text = "";
            AracDorseYokRadioButton.Checked = true;
            AracDaraYokRadioButton.Checked = true;
        }
        
        private Boolean DaraVarCheck()
        {
            if(AracDaraVarRadioButton.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean DorseVarCheck()
        {
            if (AracDorseVarRadioButton.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AracDaraVarRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AracDaraAlButton.Enabled = true;
        }

        private void AracDaraYokRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AracDaraTextBox.Text = "";
            AracDaraAlButton.Enabled = false;
        }

        private void AracDorseYokRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AracDorsePlakaTextBox.Text = "";
            AracDorsePlakaTextBox.Enabled = false;
        }

        private void AracDorseVarRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AracDorsePlakaTextBox.Enabled = true;
        }

        private void AracDaraAlButton_Click(object sender, EventArgs e)
        {
            try
            {
                AracDaraTextBox.Text = aSayfa.GetKgData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}