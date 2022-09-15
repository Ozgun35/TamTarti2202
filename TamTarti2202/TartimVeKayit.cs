using System;
using System.Drawing;
using System.Linq.Expressions;
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
            if (db.RunQuery("INSERT INTO FIRMALAR(ADI, VERGI_DAIRESI, VERGI_NO, TELEFON_NO, FAX_NO, WEB_SITE, EMAIL, ADRES, ADRES_2) " +
                "VALUES('" + FirmaAdiTextBox.Text.ToUpper() + "', '" + FirmaVergiDairesiTextBox.Text.ToUpper() + "', " +
                "'" + FirmaVergiNoTextBox.Text + "', '" + FirmaTelNoTextBox.Text.ToUpper() + "', '" + FirmaFaxNoTextBox.Text.ToUpper() + "', " +
                "'" + FirmaWebSiteTextBox.Text.ToUpper() + "', '" + FirmaEmailTextBoxt.Text.ToUpper() + "', " +
                "'" + FirmaAdresiTextBox.Text.ToUpper() + "', '" + FirmaAdresiIkiTextBox.Text.ToUpper() + "')", connectionTartim) == true)
            {
                MessageBox.Show("Firma Kaydı Başarılı!");
                FirmaFormClear();
            }
            else
            {
                MessageBox.Show("Firma Kaydı Yapılamadı!");
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
            if (AracEkleSwitch() == 1)
            {
                if (db.RunQuery("INSERT INTO ARACLAR(PLAKA, DARA, DARA_KG, DORSE, DORSE_PLAKA) " +
                    "VALUES('" + AracPlakaTextBox.Text.ToUpper() + "', '" + 1 + "', '" + Convert.ToDouble(AracDaraTextBox.Text) + "', " +
                    "'" + 1 + "', '" + AracDorsePlakaTextBox.Text.ToUpper() + "')", connectionTartim) == true)
                {

                    MessageBox.Show("Araç Kaydı Başarılı!");
                    AracFormClear();
                }
                else
                {
                    MessageBox.Show("Araç Kaydı Yapılamadı!");
                }
            }
            else if (AracEkleSwitch() == 2)
            {
                if (db.RunQuery("INSERT INTO ARACLAR(PLAKA, DARA, DARA_KG, DORSE) " +
                    "VALUES('" + AracPlakaTextBox.Text.ToUpper() + "', '" + 1 + "', '" + Convert.ToDouble(AracDaraTextBox.Text) + "', " +
                    "'" + 0 + "')", connectionTartim) == true)
                {
                    MessageBox.Show("Araç Kaydı Başarılı!");
                    AracFormClear();
                }
                else
                {
                    MessageBox.Show("Araç Kaydı Yapılamadı!");
                }
            }
            else if (AracEkleSwitch() == 3)
            {
                if (db.RunQuery("INSERT INTO ARACLAR(PLAKA, DARA, DORSE, DORSE_PLAKA) " +
                    "VALUES('" + AracPlakaTextBox.Text.ToUpper() + "', '" + 0 + "', " +
                    "'" + 1 + "', '" + AracDorsePlakaTextBox.Text.ToUpper() + "')", connectionTartim) == true)
                {
                    MessageBox.Show("Araç Kaydı Başarılı!");
                    AracFormClear();
                }
                else
                {
                    MessageBox.Show("Araç Kaydı Yapılamadı!");
                }
            }
            else if (AracEkleSwitch() == 4)
            {
                if (db.RunQuery("INSERT INTO ARACLAR(PLAKA, DARA, DORSE) " +
                    "VALUES('" + AracPlakaTextBox.Text.ToUpper() + "', '" + 0 + "', '" + 0 + "')", connectionTartim) == true)
                {
                    MessageBox.Show("Araç Kaydı Başarılı!");
                    AracFormClear();
                }
                else
                {
                    MessageBox.Show("Araç Kaydı Yapılamadı!");
                }
            }
            else if(AracEkleSwitch() == 0)
            {
                MessageBox.Show("Hatalı Giriş!");
            }
        }

        private int AracEkleSwitch()
        {
            if(AracDaraVarRadioButton.Checked == true && AracDorseVarRadioButton.Checked == true
                && AracDaraTextBox.Text != "" && AracDorsePlakaTextBox.Text.Length == 7
                && AracPlakaTextBox.Text.Length == 7)
            {
                return 1;
            }
            if(AracDaraVarRadioButton.Checked == true && AracDorseVarRadioButton.Checked == false
                && AracDaraTextBox.Text != "" && AracPlakaTextBox.Text.Length == 7)
            {
                return 2;
            }
            if(AracDaraVarRadioButton.Checked == false  && AracDorseVarRadioButton.Checked == true
                && AracDorsePlakaTextBox.Text.Length == 7 && AracPlakaTextBox.Text.Length == 7)
            {
                return 3;
            }
            if(AracDorseVarRadioButton.Checked == false && AracDaraVarRadioButton.Checked == false
                && AracPlakaTextBox.Text.Length == 7)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        private void AracFormClear()
        {
            AracPlakaTextBox.Text = "";
            AracDaraYokRadioButton.Checked = true;
            AracDorseYokRadioButton.Checked = true; 
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

        private void SoforEklemeButton_Click(object sender, EventArgs e)
        {
            if (SoforAdiTextBox.Text.Length >= 6 && SoforTcTextBox.Text == "")
            {
                if (db.RunQuery("INSERT INTO SOFORLER(ADI, TELEFON_NO, ADRES) VALUES('" + SoforAdiTextBox.Text.ToUpper() + "', " +
                 "'" + SoforTelNoTextBox.Text.ToUpper() + "', '" + SoforAdresTextBox.Text.ToUpper() + "')", connectionTartim) == true)
                {
                    MessageBox.Show("Şöför Kaydı Başarılı!");
                    SoforFormClear();
                }   
                else if (SoforAdiTextBox.Text.Length >= 6 && SoforTcTextBox.Text.Length == 11)
                {
                    if (db.RunQuery("INSERT INTO SOFORLER(ADI, TC_NO, TELEFON_NO, ADRES) VALUES('" + SoforAdiTextBox.Text.ToUpper() + "', " +
                    "'" + SoforTcTextBox.Text.ToUpper() + "', '" + SoforTelNoTextBox.Text.ToUpper() + "', " +
                    "'" + SoforAdresTextBox.Text.ToUpper() + "')", connectionTartim) == true)
                    {
                        MessageBox.Show("Şöför Kaydı Başarılı!");
                        SoforFormClear();
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş");
                }
            }
        }

        private void SoforFormClear()
        {
            SoforAdiTextBox.Text = "";
            SoforTcTextBox.Text = "";
            SoforTelNoTextBox.Text = "";
            SoforAdresTextBox.Text = "";
        }

        private void UrunEklemeButton_Click(object sender, EventArgs e)
        {
            if(UrunAdiTextBox.Text.Length >= 2)
            {
                if(db.RunQuery("INSERT INTO URUNLER(ADI) VALUES('" + UrunAdiTextBox.Text.ToUpper() + "'", connectionTartim) == true)
                {
                    MessageBox.Show("Ürün Kaydı Başarılı!");
                    UrunAdiTextBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!");
            }
        }
    }
}