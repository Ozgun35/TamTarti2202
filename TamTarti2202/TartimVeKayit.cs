using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TamTarti2202
{
    public partial class TartimVeKayit : Form
    {
        private string connectionTartim = Properties.KullaniciAyarlari.Default.connectionTartim;

        private Anasayfa aSayfa = new Anasayfa();
        private DataBaseModifier db = new DataBaseModifier();

        private MySqlConnection con = null;
        private MySqlCommand cmd = null;

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
            if(!string.IsNullOrWhiteSpace(FirmaAdiTextBox.Text) && !string.IsNullOrWhiteSpace(FirmaAdresiTextBox.Text))
            {
                try
                {
                    con = new MySqlConnection(connectionTartim);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO FIRMALAR(ADI, VERGI_DAIRESI, VERGI_NO, TELEFON_NO, FAX_NO, WEB_SITE, EMAIL, ADRES, ADRES_2 ) " +
                        "VALUES(@ADI, @VERGI_DAIRESI, @VERGI_NO, @TELEFON_NO, @FAX_NO, @WEB_SITE, @EMAIL, @ADRES, @ADRES_2)";
                    cmd.Parameters.AddWithValue("@ADI", NullOrEmptyString(FirmaAdiTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@VERGI_DAIRESI", NullOrEmptyString(FirmaVergiDairesiTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@VERGI_NO", NullOrEmptyString(FirmaVergiNoTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@TELEFON_NO", NullOrEmptyString(FirmaTelNoTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@FAX_NO", NullOrEmptyString(FirmaFaxNoTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@WEB_SITE", NullOrEmptyString(FirmaWebSiteTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@EMAIL", NullOrEmptyString(FirmaEmailTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@ADRES", NullOrEmptyString(FirmaAdresiTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@ADRES_2", NullOrEmptyString(FirmaAdresiIkiTextBox.Text.ToUpper()));

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Firma Kaydı Başarılı!");
                    FirmalarComboBoxMembers();
                    FirmaFormClear();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Firma Adı ve Adresi Boş Olamaz!");
            }
        }
        private string NullOrEmptyString(string s)
        {
            return string.IsNullOrEmpty(s) ? null : s;
        }
        
        private void FirmaFormClear()
        {
            FirmaAdiTextBox.Text = "";
            FirmaVergiDairesiTextBox.Text = "";
            FirmaVergiNoTextBox.Text = "";
            FirmaTelNoTextBox.Text = "";
            FirmaFaxNoTextBox.Text = "";
            FirmaWebSiteTextBox.Text = "";
            FirmaEmailTextBox.Text = "";
            FirmaAdresiTextBox.Text = "";
            FirmaAdresiIkiTextBox.Text = "";
        }

        private void AracEklemeButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(AracPlakaTextBox.Text) && AracPlakaTextBox.Text.Length == 7)
            {
                try
                {
                    con = new MySqlConnection(connectionTartim);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO ARACLAR(PLAKA, DARA_KG, DORSE_PLAKA) " +
                        "VALUES(@PLAKA, @DARA_KG, @DORSE_PLAKA)";
                    cmd.Parameters.AddWithValue("@PLAKA", NullOrEmptyString(AracPlakaTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@DARA_KG", NullOrEmptyString(AracDaraTextBox.Text));
                    if(!string.IsNullOrWhiteSpace(AracDorsePlakaTextBox.Text) && AracDorsePlakaTextBox.Text.Length == 7 && AracDorseVarRadioButton.Checked)
                    {
                        cmd.Parameters.AddWithValue("@DORSE_PLAKA", NullOrEmptyString(AracDorsePlakaTextBox.Text.ToUpper()));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DORSE_PLAKA", null);
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Araç Kaydı Başarılı!");
                    AraclarComboBoxMembers();
                    AracFormClear();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Plaka Girişi Yanlış!");
            }
        }

        private void AracFormClear()
        {
            AracPlakaTextBox.Text = "";
            AracDorsePlakaTextBox.Text = "";
            AracDaraYokRadioButton.Checked = true;
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

        private void CalisanFormClear()
        {
            CalisanAdiTextBox.Text = "";
            CalisanTcTextBox.Text = "";
            CalisanTelNoTextBox.Text = "";
            CalisanAdresTextBox.Text = "";
        }

        private void UrunEklemeButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UrunAdiTextBox.Text))
            {
                try
                {
                    con = new MySqlConnection(connectionTartim);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO URUNLER(ADI) VALUES(@ADI)";
                    cmd.Parameters.AddWithValue("@ADI", NullOrEmptyString(UrunAdiTextBox.Text.ToUpper()));
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Çalışan Kaydı Başarılı!");
                    UrunAdiTextBox.Text = "";
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ürün Adını Doğru Giriniz!");
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
            catch (MySqlException ex)
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
            catch (MySqlException)
            {
            }            
        }

        private void CalisanlarComboBoxMembers()
        {
            try
            {
                SatimCalisanComboBox.DataSource = db.GetTable("SELECT ADI FROM CALISANLAR", connectionTartim);
                SatimCalisanComboBox.ValueMember = "ADI";
                AlimCalisanComboBox.DataSource = db.GetTable("SELECT ADI FROM CALISANLAR", connectionTartim);
                AlimCalisanComboBox.ValueMember = "ADI";
            }
            catch (MySqlException ex)
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
            catch (MySqlException ex)
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
                CalisanlarComboBoxMembers();
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
            catch(Exception)
            {
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
            catch(Exception )
            {
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
            catch (Exception)
            {
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
                AlimDorseTextBox.Text = db.GetStringFromQuery("SELECT DORSE_PLAKA FROM ARACLAR WHERE PLAKA = '" 
                    + AlimPlakalarComboBox.Text.ToString() + "'", connectionTartim);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SatimPlakalarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SatimDorseTextBox.Text = db.GetStringFromQuery("SELECT DORSE_PLAKA FROM ARACLAR WHERE PLAKA = '" 
                    + SatimPlakalarComboBox.Text.ToString() + "'", connectionTartim);
                
                if(SatimKayitliDaraRadioButton.Checked)
                {
                    SatimDaraTextBox.Text = db.GetStringFromQuery("SELECT DARA_KG FROM ARACLAR WHERE PLAKA = '" 
                        + SatimPlakalarComboBox.Text.ToString() + "'", connectionTartim);
                }
            }
            catch(MySqlException ex)
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
                    SatimDaraTextBox.Text = db.GetStringFromQuery("SELECT DARA_KG FROM ARACLAR WHERE PLAKA = '" 
                        + SatimPlakalarComboBox.Text.ToString() + "'", connectionTartim);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AracDorseYokRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            AracDorsePlakaTextBox.Text = "";
            AracDorsePlakaTextBox.Enabled = false;
        }

        private void AracDorseVarRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            AracDorsePlakaTextBox.Enabled = true;
        }

        private void CalisanEklemeButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CalisanAdiTextBox.Text))
            {
                try
                {
                    con = new MySqlConnection(connectionTartim);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO CALISANLAR(ADI, UNVAN, TC_NO, TELEFON_NO, ADRES) " +
                        "VALUES(@ADI, @UNVAN, @TC_NO, @TELEFON_NO, @ADRES)";
                    cmd.Parameters.AddWithValue("@ADI", NullOrEmptyString(CalisanAdiTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@UNVAN", NullOrEmptyString(CalisanUnvanTextBox.Text).ToUpper());
                    cmd.Parameters.AddWithValue("@TC_NO", NullOrEmptyString(CalisanTcTextBox.Text).ToUpper());
                    cmd.Parameters.AddWithValue("@TELEFON_NO", NullOrEmptyString(CalisanTelNoTextBox.Text).ToUpper());
                    cmd.Parameters.AddWithValue("@ADRES", NullOrEmptyString(CalisanAdresTextBox.Text).ToUpper());

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Çalışan Kaydı Başarılı!");
                    CalisanlarComboBoxMembers();
                    CalisanFormClear();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Çalışan Adını Doğru Giriniz!");
            }
        }
    }
}