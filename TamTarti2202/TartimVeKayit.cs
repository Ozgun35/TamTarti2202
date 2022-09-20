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
                FirmalarComboBoxMembers();
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
                if (db.RunQuery("INSERT INTO ARACLAR(PLAKA, DARA_KG, DORSE_PLAKA) " +
                    "VALUES('" + AracPlakaTextBox.Text.ToUpper() + "', '" + Convert.ToDouble(AracDaraTextBox.Text) + "', " +
                    "'" + AracDorsePlakaTextBox.Text.ToUpper() + "')", connectionTartim) == true)
                {
                    MessageBox.Show("Araç Kaydı Başarılı!");
                    AraclarComboBoxMembers();
                    AracFormClear();
                }
                else
                {
                    MessageBox.Show("Araç Kaydı Yapılamadı!");
                }
            }
            else if (AracEkleSwitch() == 2)
            {
                if (db.RunQuery("INSERT INTO ARACLAR(PLAKA DARA_KG) " +
                    "VALUES('" + AracPlakaTextBox.Text.ToUpper() + "', '" + Convert.ToDouble(AracDaraTextBox.Text) + "')", connectionTartim) == true)
                {
                    MessageBox.Show("Araç Kaydı Başarılı!");
                    AraclarComboBoxMembers();
                    AracFormClear();
                }
            }
            else if (AracEkleSwitch() == 3)
            {
                if (db.RunQuery("INSERT INTO ARACLAR(PLAKA, DORSE_PLAKA) " +
                    "VALUES('" + AracPlakaTextBox.Text.ToUpper() + "', '" + AracDorsePlakaTextBox.Text.ToUpper() + "')", connectionTartim) == true)
                {
                    MessageBox.Show("Araç Kaydı Başarılı!");
                    AraclarComboBoxMembers();
                    AracFormClear();
                }
            }
            else if (AracEkleSwitch() == 4)
            {
                if (db.RunQuery("INSERT INTO ARACLAR(PLAKA) VALUES('" + AracPlakaTextBox.Text.ToUpper() + "')", connectionTartim) == true)
                {
                    MessageBox.Show("Araç Kaydı Başarılı!");
                    AraclarComboBoxMembers();
                    AracFormClear();
                }
                else
                {
                    MessageBox.Show("Araç Kaydı Yapılamadı!");
                }
            }
            else if (AracEkleSwitch() == 0)
            {
                MessageBox.Show("Hatalı Giriş!");
            }
            /*
            if (AracEkleSwitch() == 1)
            {
                if (db.RunQuery("INSERT INTO ARACLAR(PLAKA, DARA, DARA_KG, DORSE, DORSE_PLAKA) " +
                    "VALUES('" + AracPlakaTextBox.Text.ToUpper() + "', '" + 1 + "', '" + Convert.ToDouble(AracDaraTextBox.Text) + "', " +
                    "'" + 1 + "', '" + AracDorsePlakaTextBox.Text.ToUpper() + "')", connectionTartim) == true)
                {

                    MessageBox.Show("Araç Kaydı Başarılı!");
                    AraclarComboBoxMembers();
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
                    AraclarComboBoxMembers();
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
                    AraclarComboBoxMembers();
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
                    AraclarComboBoxMembers();
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
            } */
        }

        private int AracEkleSwitch()
        {
            /*
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
            } */
            if (AracDaraVarRadioButton.Checked == true && AracDorseVarRadioButton.Checked == true
                && AracDaraTextBox.Text != "" && AracDorsePlakaTextBox.Text.Length == 7
                && AracPlakaTextBox.Text.Length == 7)
            {
                return 1;
            }
            if (AracDaraVarRadioButton.Checked == true && AracDorseVarRadioButton.Checked == false
                && AracDaraTextBox.Text != "" && AracPlakaTextBox.Text.Length == 7)
            {
                return 2;
            }
            if (AracDaraVarRadioButton.Checked == false && AracDorseVarRadioButton.Checked == true
                && AracDorsePlakaTextBox.Text.Length == 7 && AracPlakaTextBox.Text.Length == 7)
            {
                return 3;
            }
            if (AracDorseVarRadioButton.Checked == false && AracDaraVarRadioButton.Checked == false
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
                    SoforlerComboBoxMembers();
                    SoforFormClear();
                }                 
            }
            else if (SoforAdiTextBox.Text.Length >= 6 && SoforTcTextBox.Text.Length == 11)
            {
                if (db.RunQuery("INSERT INTO SOFORLER(ADI, TC_NO, TELEFON_NO, ADRES) VALUES('" + SoforAdiTextBox.Text.ToUpper() + "', " +
                "'" + SoforTcTextBox.Text + "', '" + SoforTelNoTextBox.Text.ToUpper() + "', " +
                "'" + SoforAdresTextBox.Text.ToUpper() + "')", connectionTartim) == true)
                {
                    MessageBox.Show("Şöför Kaydı Başarılı!");
                    SoforlerComboBoxMembers();
                    SoforFormClear(); 
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
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
                if(db.RunQuery("INSERT INTO URUNLER(ADI) VALUES('" + UrunAdiTextBox.Text.ToUpper() + "')", connectionTartim) == true)
                {
                    MessageBox.Show("Ürün Kaydı Başarılı!");
                    UrunlerComboBoxMembers();
                    UrunAdiTextBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!");
            }
        }

        private void AlimSatimUrunlerDuzenleme()
        {
            try
            {
                SatimTartimSayisiComboBox.SelectedIndex = 0;
                SatimUrunIkiComboBox.SelectedIndex = -1;
                SatimUrunIkiComboBox.Enabled = false;
                SatimUrunUcComboBox.SelectedIndex = -1;
                SatimUrunUcComboBox.Enabled = false;
                SatimUrunDortComboBox.SelectedIndex = -1;
                SatimUrunDortComboBox.Enabled = false;
                SatimUrunBesComboBox.SelectedIndex = -1;
                SatimUrunBesComboBox.Enabled = false;

                AlimTartimSayisiComboBox.SelectedIndex = 0;
                AlimUrunIkiComboBox.SelectedIndex = -1;
                AlimUrunIkiComboBox.Enabled = false;
                AlimUrunUcComboBox.SelectedIndex = -1;
                AlimUrunUcComboBox.Enabled = false;
                AlimUrunDortComboBox.SelectedIndex = -1;
                AlimUrunDortComboBox.Enabled = false;
                AlimUrunBesComboBox.SelectedIndex = -1;
                AlimUrunBesComboBox.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FirmalarComboBoxMembers()
        {
            try
            {
                SatimFirmalarComboBox.DataSource = db.GetTable("SELECT ADI FROM FIRMALAR", connectionTartim);
                SatimFirmalarComboBox.ValueMember = "ADI";
                AlimFirmalarComboBox.DataSource = db.GetTable("SELECT ADI FROM FIRMALAR", connectionTartim);
                AlimFirmalarComboBox.ValueMember = "ADI";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }     
        }

        private void AraclarComboBoxMembers()
        {
            try
            {
                SatimPlakalarComboBox.DataSource = db.GetTable("SELECT PLAKA FROM ARACLAR", connectionTartim);
                SatimPlakalarComboBox.ValueMember = "PLAKA";
                AlimPlakalarComboBox.DataSource = db.GetTable("SELECT PLAKA FROM ARACLAR", connectionTartim);
                AlimPlakalarComboBox.ValueMember = "PLAKA";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void SoforlerComboBoxMembers()
        {
            try
            {
                SatimSoforComboBox.DataSource = db.GetTable("SELECT ADI FROM SOFORLER", connectionTartim);
                SatimSoforComboBox.ValueMember = "ADI";
                AlimSoforComboBox.DataSource = db.GetTable("SELECT ADI FROM SOFORLER", connectionTartim);
                AlimSoforComboBox.ValueMember = "ADI";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UrunlerComboBoxMembers()
        {
            try
            {
                SatimUrunBirComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER", connectionTartim);
                SatimUrunBirComboBox.ValueMember = "ADI";
                SatimUrunIkiComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER", connectionTartim);
                SatimUrunIkiComboBox.ValueMember = "ADI";
                SatimUrunUcComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER", connectionTartim);
                SatimUrunUcComboBox.ValueMember = "ADI";
                SatimUrunDortComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER", connectionTartim);
                SatimUrunDortComboBox.ValueMember = "ADI";
                SatimUrunBesComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER", connectionTartim);
                SatimUrunBesComboBox.ValueMember = "ADI";

                AlimUrunBirComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER", connectionTartim);
                AlimUrunBirComboBox.ValueMember = "ADI";
                AlimUrunIkiComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER", connectionTartim);
                AlimUrunIkiComboBox.ValueMember = "ADI";
                AlimUrunUcComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER", connectionTartim);
                AlimUrunUcComboBox.ValueMember = "ADI";
                AlimUrunDortComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER", connectionTartim);
                AlimUrunDortComboBox.ValueMember = "ADI";
                AlimUrunBesComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER", connectionTartim);
                AlimUrunBesComboBox.ValueMember = "ADI";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBoxMembers()
        {
            try
            {
                FirmalarComboBoxMembers();
                AraclarComboBoxMembers();
                SoforlerComboBoxMembers();
                UrunlerComboBoxMembers();
                if (SatimFirmalarComboBox.SelectedIndex == -1 || SatimPlakalarComboBox.SelectedIndex == -1)
                {
                    SatimTartimButton.Enabled = false;
                }
                else
                {
                    SatimTartimButton.Enabled = true;
                }
                if(AlimFirmalarComboBox.SelectedIndex == -1 || AlimPlakalarComboBox.SelectedIndex == -1)
                {
                    AlimTartimButton.Enabled = false;
                }
                else
                {
                    AlimTartimButton.Enabled = true;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " comboboxmembers");
            }

        }

        private void SatimTartimButton_Click(object sender, EventArgs e)
        {

        }

        private void SatimTartimSayisiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SatimTartimSayisiComboBox.SelectedIndex == 0)
                {
                    SatimUrunBirComboBox.Enabled = true;
                    SatimUrunBirComboBox.SelectedIndex = 0;             
                    SatimUrunIkiComboBox.Enabled = false;
                    SatimUrunIkiComboBox.SelectedIndex = -1;                   
                    SatimUrunUcComboBox.Enabled = false;
                    SatimUrunUcComboBox.SelectedIndex = -1;
                    SatimUrunDortComboBox.Enabled = false;
                    SatimUrunDortComboBox.SelectedIndex = -1;
                    SatimUrunBesComboBox.Enabled = false;
                    SatimUrunBesComboBox.SelectedIndex = -1;
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 1)
                {
                    SatimUrunBirComboBox.Enabled = true;
                    SatimUrunBirComboBox.SelectedIndex = 0;
                    SatimUrunIkiComboBox.Enabled = true;
                    SatimUrunIkiComboBox.SelectedIndex = 1;
                    SatimUrunUcComboBox.Enabled = false;
                    SatimUrunUcComboBox.SelectedIndex = -1;
                    SatimUrunDortComboBox.Enabled = false;
                    SatimUrunDortComboBox.SelectedIndex = -1;
                    SatimUrunBesComboBox.Enabled = false;
                    SatimUrunBesComboBox.SelectedIndex = -1;
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 2)
                {
                    SatimUrunBirComboBox.Enabled = true;
                    SatimUrunBirComboBox.SelectedIndex = 0;
                    SatimUrunIkiComboBox.Enabled = true;
                    SatimUrunIkiComboBox.SelectedIndex = 1;
                    SatimUrunUcComboBox.Enabled = true;
                    SatimUrunUcComboBox.SelectedIndex = 2;
                    SatimUrunDortComboBox.Enabled = false;
                    SatimUrunDortComboBox.SelectedIndex = -1;
                    SatimUrunBesComboBox.Enabled = false;
                    SatimUrunBesComboBox.SelectedIndex = -1;
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 3)
                {
                    SatimUrunBirComboBox.Enabled = true;
                    SatimUrunBirComboBox.SelectedIndex = 0;
                    SatimUrunIkiComboBox.Enabled = true;
                    SatimUrunIkiComboBox.SelectedIndex = 1;
                    SatimUrunUcComboBox.Enabled = true;
                    SatimUrunUcComboBox.SelectedIndex = 2;
                    SatimUrunDortComboBox.Enabled = true;
                    SatimUrunDortComboBox.SelectedIndex = 3;
                    SatimUrunBesComboBox.Enabled = false;
                    SatimUrunBesComboBox.SelectedIndex = -1;
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 4)
                {
                    SatimUrunBirComboBox.Enabled = true;
                    SatimUrunBirComboBox.SelectedIndex = 0;
                    SatimUrunIkiComboBox.Enabled = true;
                    SatimUrunIkiComboBox.SelectedIndex = 1;
                    SatimUrunUcComboBox.Enabled = true;
                    SatimUrunUcComboBox.SelectedIndex = 2;
                    SatimUrunDortComboBox.Enabled = true;
                    SatimUrunDortComboBox.SelectedIndex = 3;
                    SatimUrunBesComboBox.Enabled = true;
                    SatimUrunBesComboBox.SelectedIndex = 4;
                }

            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void AlimTartimSayisiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (AlimTartimSayisiComboBox.SelectedIndex == 0)
                {
                    AlimUrunBirComboBox.Enabled = true;
                    AlimUrunBirComboBox.SelectedIndex = 0;
                    AlimUrunIkiComboBox.Enabled = false;
                    AlimUrunIkiComboBox.SelectedIndex = -1;
                    AlimUrunUcComboBox.Enabled = false;
                    AlimUrunUcComboBox.SelectedIndex = -1;
                    AlimUrunDortComboBox.Enabled = false;
                    AlimUrunDortComboBox.SelectedIndex = -1;
                    AlimUrunBesComboBox.Enabled = false;
                    AlimUrunBesComboBox.SelectedIndex = -1;
                }
                if (AlimTartimSayisiComboBox.SelectedIndex == 1)
                {
                    AlimUrunBirComboBox.Enabled = true;
                    AlimUrunBirComboBox.SelectedIndex = 0;
                    AlimUrunIkiComboBox.Enabled = true;
                    AlimUrunIkiComboBox.SelectedIndex = 1;
                    AlimUrunUcComboBox.Enabled = false;
                    AlimUrunUcComboBox.SelectedIndex = -1;
                    AlimUrunDortComboBox.Enabled = false;
                    AlimUrunDortComboBox.SelectedIndex = -1;
                    AlimUrunBesComboBox.Enabled = false;
                    AlimUrunBesComboBox.SelectedIndex = -1;
                }
                if (AlimTartimSayisiComboBox.SelectedIndex == 2)
                {
                    AlimUrunBirComboBox.Enabled = true;
                    AlimUrunBirComboBox.SelectedIndex = 0;
                    AlimUrunIkiComboBox.Enabled = true;
                    AlimUrunIkiComboBox.SelectedIndex = 1;
                    AlimUrunUcComboBox.Enabled = true;
                    AlimUrunUcComboBox.SelectedIndex = 2;
                    AlimUrunDortComboBox.Enabled = false;
                    AlimUrunDortComboBox.SelectedIndex = -1;
                    AlimUrunBesComboBox.Enabled = false;
                    AlimUrunBesComboBox.SelectedIndex = -1;
                }
                if (AlimTartimSayisiComboBox.SelectedIndex == 3)
                {
                    AlimUrunBirComboBox.Enabled = true;
                    AlimUrunBirComboBox.SelectedIndex = 0;
                    AlimUrunIkiComboBox.Enabled = true;
                    AlimUrunIkiComboBox.SelectedIndex = 1;
                    AlimUrunUcComboBox.Enabled = true;
                    AlimUrunUcComboBox.SelectedIndex = 2;
                    AlimUrunDortComboBox.Enabled = true;
                    AlimUrunDortComboBox.SelectedIndex = 3;
                    AlimUrunBesComboBox.Enabled = false;
                    AlimUrunBesComboBox.SelectedIndex = -1;
                }
                if (AlimTartimSayisiComboBox.SelectedIndex == 4)
                {
                    AlimUrunBirComboBox.Enabled = true;
                    AlimUrunBirComboBox.SelectedIndex = 0;
                    AlimUrunIkiComboBox.Enabled = true;
                    AlimUrunIkiComboBox.SelectedIndex = 1;
                    AlimUrunUcComboBox.Enabled = true;
                    AlimUrunUcComboBox.SelectedIndex = 2;
                    AlimUrunDortComboBox.Enabled = true;
                    AlimUrunDortComboBox.SelectedIndex = 3;
                    AlimUrunBesComboBox.Enabled = true;
                    AlimUrunBesComboBox.SelectedIndex = 4;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void TartimVeKayit_Load(object sender, EventArgs e)
        {
            ComboBoxMembers();
            AlimSatimUrunlerDuzenleme();
        }

        private void AlimPlakalarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AlimDorseTextBox.Text = db.GetStringFromQuery("SELECT DORSE_PLAKA FROM ARACLAR WHERE PLAKA = '" + AlimPlakalarComboBox.Text.ToString() + "'", connectionTartim);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SatimPlakalarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SatimDorseTextBox.Text = db.GetStringFromQuery("SELECT DORSE_PLAKA FROM ARACLAR WHERE PLAKA = '" + SatimPlakalarComboBox.Text.ToString() + "'", connectionTartim);
                
                if(SatimKayitliDaraRadioButton.Checked)
                {
                    SatimDaraTextBox.Text = db.GetStringFromQuery("SELECT DORSE_PLAKA FROM ARACLAR WHERE PLAKA = '" + SatimPlakalarComboBox.Text.ToString() + "'", connectionTartim);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SatimDaraTartRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SatimDaraTartRadioButton.Checked)
            {
                SatimDaraTextBox.Text = "";
            }
        }

        private void SatimDaraYokRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(SatimDaraYokRadioButton.Checked)
            {
                SatimDaraTextBox.Text = "";
            }
        }

        private void SatimKayitliDaraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SatimKayitliDaraRadioButton.Checked)
            {
                try
                {
                    SatimDaraTextBox.Text = db.GetStringFromQuery("SELECT DORSE_PLAKA FROM ARACLAR WHERE PLAKA = '" + SatimPlakalarComboBox.Text.ToString() + "'", connectionTartim);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}