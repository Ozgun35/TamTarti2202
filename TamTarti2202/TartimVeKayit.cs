using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace TamTarti2202
{
    public partial class TartimVeKayit : Form
    {
        private string anaFirma = Properties.KullaniciAyarlari.Default.FirmaAdi;

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

            SatimTartimSayisiComboBox.SelectedIndex = 0;
            AlimTartimSayisiComboBox.SelectedIndex = 0;
        }

        private void TartimVeKayit_Load(object sender, EventArgs e)
        {
            ComboBoxMembers();
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

        private string NullOrEmptyString(string s)
        {
            return string.IsNullOrEmpty(s) ? null : s;
        }

        private bool ConvertDouble(string kg)
        {
            try
            {
                Convert.ToDouble(kg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private int getLastID(string tableName)
        {
            try
            {
                int lastID = Convert.ToInt16(db.GetStringFromQuery("SELECT MAX(ID) FROM " + tableName));
                lastID++;
                return lastID;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        private void SatimTartimSayisiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SatimTartimSayisiComboBox.SelectedIndex == 0)
            {
                SatimUrunBirComboBox.Enabled = true;
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
                SatimUrunIkiComboBox.Enabled = true;
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
                SatimUrunIkiComboBox.Enabled = true;
                SatimUrunUcComboBox.Enabled = true;
                SatimUrunDortComboBox.Enabled = false;
                SatimUrunDortComboBox.SelectedIndex = -1;
                SatimUrunBesComboBox.Enabled = false;
                SatimUrunBesComboBox.SelectedIndex = -1;
            }
            if (SatimTartimSayisiComboBox.SelectedIndex == 3)
            {
                SatimUrunBirComboBox.Enabled = true;
                SatimUrunIkiComboBox.Enabled = true;
                SatimUrunUcComboBox.Enabled = true;
                SatimUrunDortComboBox.Enabled = true;
                SatimUrunBesComboBox.Enabled = false;
                SatimUrunBesComboBox.SelectedIndex = -1;
            }
            if (SatimTartimSayisiComboBox.SelectedIndex == 4)
            {
                SatimUrunBirComboBox.Enabled = true;
                SatimUrunIkiComboBox.Enabled = true;
                SatimUrunUcComboBox.Enabled = true;
                SatimUrunDortComboBox.Enabled = true;
                SatimUrunBesComboBox.Enabled = true;
            }
        }

        private void AlimTartimSayisiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlimTartimSayisiComboBox.SelectedIndex == 0)
            {
                AlimUrunBirComboBox.Enabled = true;
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
                AlimUrunIkiComboBox.Enabled = true;
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
                AlimUrunIkiComboBox.Enabled = true;
                AlimUrunUcComboBox.Enabled = true;
                AlimUrunDortComboBox.Enabled = false;
                AlimUrunDortComboBox.SelectedIndex = -1;
                AlimUrunBesComboBox.Enabled = false;
                AlimUrunBesComboBox.SelectedIndex = -1;
            }
            if (AlimTartimSayisiComboBox.SelectedIndex == 3)
            {
                AlimUrunBirComboBox.Enabled = true;
                AlimUrunIkiComboBox.Enabled = true;
                AlimUrunUcComboBox.Enabled = true;
                AlimUrunDortComboBox.Enabled = true;
                AlimUrunBesComboBox.Enabled = false;
                AlimUrunBesComboBox.SelectedIndex = -1;
            }
            if (AlimTartimSayisiComboBox.SelectedIndex == 4)
            {
                AlimUrunBirComboBox.Enabled = true;
                AlimUrunIkiComboBox.Enabled = true;
                AlimUrunUcComboBox.Enabled = true;
                AlimUrunDortComboBox.Enabled = true;
                AlimUrunBesComboBox.Enabled = true;
            }
        }

        private void TartimSayisiLoad()
        {
            if (SatimTartimSayisiComboBox.SelectedIndex == 0)
            {
                SatimUrunBirComboBox.Enabled = true;
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
                SatimUrunIkiComboBox.Enabled = true;
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
                SatimUrunIkiComboBox.Enabled = true;
                SatimUrunUcComboBox.Enabled = true;
                SatimUrunDortComboBox.Enabled = false;
                SatimUrunDortComboBox.SelectedIndex = -1;
                SatimUrunBesComboBox.Enabled = false;
                SatimUrunBesComboBox.SelectedIndex = -1;
            }
            if (SatimTartimSayisiComboBox.SelectedIndex == 3)
            {
                SatimUrunBirComboBox.Enabled = true;
                SatimUrunIkiComboBox.Enabled = true;
                SatimUrunUcComboBox.Enabled = true;
                SatimUrunDortComboBox.Enabled = true;
                SatimUrunBesComboBox.Enabled = false;
                SatimUrunBesComboBox.SelectedIndex = -1;
            }
            if (SatimTartimSayisiComboBox.SelectedIndex == 4)
            {
                SatimUrunBirComboBox.Enabled = true;
                SatimUrunIkiComboBox.Enabled = true;
                SatimUrunUcComboBox.Enabled = true;
                SatimUrunDortComboBox.Enabled = true;
                SatimUrunBesComboBox.Enabled = true;
            }

            if (AlimTartimSayisiComboBox.SelectedIndex == 0)
            {
                AlimUrunBirComboBox.Enabled = true;
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
                AlimUrunIkiComboBox.Enabled = true;
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
                AlimUrunIkiComboBox.Enabled = true;
                AlimUrunUcComboBox.Enabled = true;
                AlimUrunDortComboBox.Enabled = false;
                AlimUrunDortComboBox.SelectedIndex = -1;
                AlimUrunBesComboBox.Enabled = false;
                AlimUrunBesComboBox.SelectedIndex = -1;
            }
            if (AlimTartimSayisiComboBox.SelectedIndex == 3)
            {
                AlimUrunBirComboBox.Enabled = true;
                AlimUrunIkiComboBox.Enabled = true;
                AlimUrunUcComboBox.Enabled = true;
                AlimUrunDortComboBox.Enabled = true;
                AlimUrunBesComboBox.Enabled = false;
                AlimUrunBesComboBox.SelectedIndex = -1;
            }
            if (AlimTartimSayisiComboBox.SelectedIndex == 4)
            {
                AlimUrunBirComboBox.Enabled = true;
                AlimUrunIkiComboBox.Enabled = true;
                AlimUrunUcComboBox.Enabled = true;
                AlimUrunDortComboBox.Enabled = true;
                AlimUrunBesComboBox.Enabled = true;
            }
        }

        private void UrunlerComboBoxMembers()
        {
            try
            {
                SatimUrunBirComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER");
                SatimUrunBirComboBox.DisplayMember = "ADI";
                SatimUrunIkiComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER");
                SatimUrunIkiComboBox.DisplayMember = "ADI";
                SatimUrunUcComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER");
                SatimUrunUcComboBox.DisplayMember = "ADI";
                SatimUrunDortComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER");
                SatimUrunDortComboBox.DisplayMember = "ADI";
                SatimUrunBesComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER");
                SatimUrunBesComboBox.DisplayMember = "ADI";

                AlimUrunBirComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER");
                AlimUrunBirComboBox.DisplayMember = "ADI";
                AlimUrunIkiComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER");
                AlimUrunIkiComboBox.DisplayMember = "ADI";
                AlimUrunUcComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER");
                AlimUrunUcComboBox.DisplayMember = "ADI";
                AlimUrunDortComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER");
                AlimUrunDortComboBox.DisplayMember = "ADI";
                AlimUrunBesComboBox.DataSource = db.GetTable("SELECT ADI FROM URUNLER");
                AlimUrunBesComboBox.DisplayMember = "ADI";

                TartimSayisiLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FirmalarComboBoxMembers()
        {
            try
            {
                SatimFirmalarComboBox.DataSource = db.GetTable("SELECT ADI FROM FIRMALAR WHERE ADI != '" + anaFirma + "'");
                SatimFirmalarComboBox.DisplayMember = "ADI";
                AlimFirmalarComboBox.DataSource = db.GetTable("SELECT ADI FROM FIRMALAR WHERE ADI != '" + anaFirma + "'");
                AlimFirmalarComboBox.DisplayMember = "ADI";
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
                SatimPlakalarComboBox.DataSource = db.GetTable("SELECT PLAKA FROM ARACLAR");
                SatimPlakalarComboBox.DisplayMember = "PLAKA";
                AlimPlakalarComboBox.DataSource = db.GetTable("SELECT PLAKA FROM ARACLAR");
                AlimPlakalarComboBox.DisplayMember = "PLAKA";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CalisanlarComboBoxMembers()
        {
            try
            {
                SatimCalisanComboBox.DataSource = db.GetTable("SELECT ADI FROM CALISANLAR");
                SatimCalisanComboBox.DisplayMember = "ADI";
                AlimCalisanComboBox.DataSource = db.GetTable("SELECT ADI FROM CALISANLAR");
                AlimCalisanComboBox.DisplayMember = "ADI";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBoxMembers()
        {
            FirmalarComboBoxMembers();
            AraclarComboBoxMembers();
            CalisanlarComboBoxMembers();
            UrunlerComboBoxMembers();

            SatimCikisAdresiTextBox.Text = db.GetStringFromQuery("SELECT ADRES FROM FIRMALAR WHERE ADI = '"
                    + anaFirma + "'");
        }

        private void FirmaEklemeButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FirmaAdiTextBox.Text) && !string.IsNullOrWhiteSpace(FirmaAdresiTextBox.Text))
            {
                try
                {
                    con = new MySqlConnection(db.getCon());
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO FIRMALAR(ADI, VERGI_DAIRESI, VERGI_NO, TELEFON_NO, FAX_NO, WEB_SITE, EMAIL, ADRES) " +
                        "VALUES(@ADI, @VERGI_DAIRESI, @VERGI_NO, @TELEFON_NO, @FAX_NO, @WEB_SITE, @EMAIL, @ADRES)";
                    cmd.Parameters.AddWithValue("@ADI", NullOrEmptyString(FirmaAdiTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@VERGI_DAIRESI", NullOrEmptyString(FirmaVergiDairesiTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@VERGI_NO", NullOrEmptyString(FirmaVergiNoTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@TELEFON_NO", NullOrEmptyString(FirmaTelNoTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@FAX_NO", NullOrEmptyString(FirmaFaxNoTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@WEB_SITE", NullOrEmptyString(FirmaWebSiteTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@EMAIL", NullOrEmptyString(FirmaEmailTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@ADRES", NullOrEmptyString(FirmaAdresiTextBox.Text.ToUpper()));

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Firma Kaydı Başarılı!");
                    FirmalarComboBoxMembers();
                    FirmaAdiTextBox.Text = "";
                    FirmaVergiDairesiTextBox.Text = "";
                    FirmaVergiNoTextBox.Text = "";
                    FirmaTelNoTextBox.Text = "";
                    FirmaFaxNoTextBox.Text = "";
                    FirmaWebSiteTextBox.Text = "";
                    FirmaEmailTextBox.Text = "";
                    FirmaAdresiTextBox.Text = "";
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

        private void AracEklemeButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AracPlakaTextBox.Text) && AracPlakaTextBox.Text.Length == 7)
            {
                try
                {
                    con = new MySqlConnection(db.getCon());
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO ARACLAR(PLAKA, DARA_KG, DORSE_PLAKA) " +
                        "VALUES(@PLAKA, @DARA_KG, @DORSE_PLAKA)";
                    cmd.Parameters.AddWithValue("@PLAKA", NullOrEmptyString(AracPlakaTextBox.Text.ToUpper()));

                    if(AracDaraVarRadioButton.Checked == true)
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@DARA_KG", Convert.ToDouble(AracDaraTextBox.Text));

                            if(AracDorseVarRadioButton.Checked)
                            {
                                if(!string.IsNullOrWhiteSpace(AracDorsePlakaTextBox.Text) && AracDorsePlakaTextBox.Text.Length == 7)
                                {
                                    cmd.Parameters.AddWithValue("@DORSE_PLAKA", NullOrEmptyString(AracDorsePlakaTextBox.Text.ToUpper()));

                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                    MessageBox.Show("Araç Kaydı Başarılı!");
                                    AraclarComboBoxMembers();
                                    AracPlakaTextBox.Text = "";
                                    AracDorsePlakaTextBox.Text = "";
                                    AracDorseYokRadioButton.Checked = true;
                                    AracDaraYokRadioButton.Checked = true;
                                }
                                else
                                {
                                    MessageBox.Show("Dorse Girişi Yanlış!");
                                }
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@DORSE_PLAKA", null);

                                cmd.ExecuteNonQuery();
                                con.Close();

                                MessageBox.Show("Araç Kaydı Başarılı!");
                                AraclarComboBoxMembers();
                                AracPlakaTextBox.Text = "";
                                AracDorsePlakaTextBox.Text = "";
                                AracDorseYokRadioButton.Checked = true;
                                AracDaraYokRadioButton.Checked = true;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if(AracDaraVarRadioButton.Checked == false)
                    {
                        cmd.Parameters.AddWithValue("@DARA_KG", NullOrEmptyString(AracDaraTextBox.Text));

                        if (AracDorseVarRadioButton.Checked)
                        {
                            if (!string.IsNullOrWhiteSpace(AracDorsePlakaTextBox.Text) && AracDorsePlakaTextBox.Text.Length == 7)
                            {
                                cmd.Parameters.AddWithValue("@DORSE_PLAKA", NullOrEmptyString(AracDorsePlakaTextBox.Text.ToUpper()));

                                cmd.ExecuteNonQuery();
                                con.Close();

                                MessageBox.Show("Araç Kaydı Başarılı!");
                                AraclarComboBoxMembers();
                                AracPlakaTextBox.Text = "";
                                AracDorsePlakaTextBox.Text = "";
                                AracDorseYokRadioButton.Checked = true;
                                AracDaraYokRadioButton.Checked = true;
                            }
                            else
                            {
                                MessageBox.Show("Dorse Girişi Yanlış!");
                            }
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@DORSE_PLAKA", null);

                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Araç Kaydı Başarılı!");
                            AraclarComboBoxMembers();
                            AracPlakaTextBox.Text = "";
                            AracDorsePlakaTextBox.Text = "";
                            AracDorseYokRadioButton.Checked = true;
                            AracDaraYokRadioButton.Checked = true;
                        }
                    }
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

        private void UrunEklemeButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UrunAdiTextBox.Text))
            {
                try
                {
                    con = new MySqlConnection(db.getCon());
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO URUNLER(ADI) VALUES(@ADI)";
                    cmd.Parameters.AddWithValue("@ADI", NullOrEmptyString(UrunAdiTextBox.Text.ToUpper()));
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Çalışan Kaydı Başarılı!");
                    UrunlerComboBoxMembers();
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

        private void CalisanEklemeButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CalisanAdiTextBox.Text))
            {
                try
                {
                    con = new MySqlConnection(db.getCon());
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO CALISANLAR(ADI, UNVAN, TC_NO, TELEFON_NO, ADRES) " +
                        "VALUES(@ADI, @UNVAN, @TC_NO, @TELEFON_NO, @ADRES)";
                    cmd.Parameters.AddWithValue("@ADI", NullOrEmptyString(CalisanAdiTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@UNVAN", NullOrEmptyString(CalisanUnvanTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@TC_NO", NullOrEmptyString(CalisanTcTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@TELEFON_NO", NullOrEmptyString(CalisanTelNoTextBox.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("@ADRES", NullOrEmptyString(CalisanAdresTextBox.Text.ToUpper()));

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Çalışan Kaydı Başarılı!");
                    CalisanlarComboBoxMembers();
                    CalisanAdiTextBox.Text = "";
                    CalisanUnvanTextBox.Text = "";
                    CalisanTcTextBox.Text = "";
                    CalisanTelNoTextBox.Text = "";
                    CalisanAdresTextBox.Text = "";
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

        private void SatimFirmalarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SatimVarisAdresiTextBox.Text = db.GetStringFromQuery("SELECT ADRES FROM FIRMALAR WHERE ADI = '"
                        + SatimFirmalarComboBox.Text.ToString() + "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AlimFirmalarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AlimCikisAdresiTextBox.Text = db.GetStringFromQuery("SELECT ADRES FROM FIRMALAR WHERE ADI = '"
                        + AlimFirmalarComboBox.Text.ToString() + "'");
                AlimVarisAdresiTextBox.Text = db.GetStringFromQuery("SELECT ADRES FROM FIRMALAR WHERE ADI = '"
                        + anaFirma + "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AlimSatimTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxMembers();
        }

        private void AlimPlakalarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AlimDorseTextBox.Text = db.GetStringFromQuery("SELECT DORSE_PLAKA FROM ARACLAR WHERE PLAKA = '"
                    + AlimPlakalarComboBox.Text.ToString() + "'");
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
                if ((NullOrEmptyString(db.GetStringFromQuery("SELECT DARA_KG FROM ARACLAR WHERE PLAKA = '"
                    + SatimPlakalarComboBox.Text.ToString() + "'"))) == null)
                {
                    SatimDaraTartRadioButton.Checked = true;
                }
                else
                {
                    SatimKayitliDaraRadioButton.Checked = true;
                }

                if (SatimKayitliDaraRadioButton.Checked)
                {
                    SatimDaraTextBox.Text = db.GetStringFromQuery("SELECT DARA_KG FROM ARACLAR WHERE PLAKA = '"
                        + SatimPlakalarComboBox.Text.ToString() + "'");
                }

                SatimDorseTextBox.Text = db.GetStringFromQuery("SELECT DORSE_PLAKA FROM ARACLAR WHERE PLAKA = '"
                    + SatimPlakalarComboBox.Text.ToString() + "'");
            }
            catch (MySqlException ex)
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
            if (SatimDaraYokRadioButton.Checked)
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
                        + SatimPlakalarComboBox.Text.ToString() + "'");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FirmaVergiNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CalisanTcTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SatimDorseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void AracDorsePlakaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void SatimTartimButton_Click(object sender, EventArgs e)
        {
            DateTime dtBaslangic = DateTime.Now;
            //DARASIZ TARTIM 
            if(SatimDaraYokRadioButton.Checked)
            {
                if(SatimTartimSayisiComboBox.SelectedIndex == 0)//DARASIZ TARTIM 1
                {
                    if(SatimTartimBirTextBox.Text == "" &&
                        SatimUrunBirComboBox.SelectedIndex > -1 &&
                        SatimTartimBosluklar())
                    {
                        SatimDisableButtons();
                        SatimTartimBirTextBox.Text = aSayfa.GetKgData();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                    }
                    else if(SatimTartimBirTextBox.Text != "" && 
                        ConvertDouble(SatimTartimBirTextBox.Text) &&
                        SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                        SatimTartimKayit(dtBaslangic))
                    {
                        MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true; 
                        SatimEnableButtons();
                    }
                    else
                    {
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        MessageBox.Show("Tartım Başarısız!");
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 1)//DARASIZ TARTIM 2
                {
                    if(SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && 
                        SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 &&
                        SatimTartimBosluklar())
                    {
                        SatimDisableButtons();
                        SatimTartimBirTextBox.Text = aSayfa.GetKgData();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                    }
                    else if(SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" &&
                        ConvertDouble(SatimTartimBirTextBox.Text) &&
                        SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimTartimBirTextBox.Text)).ToString();
                        SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                    }
                    else if(SatimTartimIkiTextBox.Text != "" && 
                        ConvertDouble(SatimTartimIkiTextBox.Text) &&
                        SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")) && 
                        SatimTartimKayit(dtBaslangic))
                    {
                        MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                    else
                    {
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                        MessageBox.Show("Tartım Başarısız!");
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 2)//DARASIZ TARTIM 3
                {
                    if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" &&
                        SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 && SatimUrunUcComboBox.SelectedIndex > -1 &&
                        SatimTartimBosluklar())
                    {
                        SatimDisableButtons();
                        SatimTartimBirTextBox.Text = aSayfa.GetKgData();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" &&
                        ConvertDouble(SatimTartimBirTextBox.Text) &&
                        SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimTartimBirTextBox.Text)).ToString();
                        SatimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text == "" &&
                        ConvertDouble(SatimTartimIkiTextBox.Text) &&
                        SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimUcTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - 
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text))).ToString();
                        SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimUcTextBox.Text != "" &&
                        ConvertDouble(SatimTartimUcTextBox.Text) &&
                        SatimUrunKayit(SatimUrunUcComboBox.Text, Convert.ToDouble(SatimTartimUcTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                        SatimTartimKayit(dtBaslangic))
                    {
                        MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                    else
                    {
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                        MessageBox.Show("Tartım Başarısız!");
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 3)//DARASIZ TARTIM 4
                {
                    if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" && SatimTartimDortTextBox.Text == "" &&
                        SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 && 
                        SatimUrunUcComboBox.SelectedIndex > -1 && SatimUrunUcComboBox.SelectedIndex > -1 && SatimUrunDortComboBox.SelectedIndex > -1 &&
                        SatimTartimBosluklar())
                    {
                        SatimDisableButtons();
                        SatimTartimBirTextBox.Text = aSayfa.GetKgData();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" && SatimTartimDortTextBox.Text == "" &&
                        ConvertDouble(SatimTartimBirTextBox.Text) &&
                        SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimTartimBirTextBox.Text)).ToString();
                        SatimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text == "" &&
                        ConvertDouble(SatimTartimIkiTextBox.Text) &&
                        SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimUcTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text))).ToString();
                        SatimTartimButton.Text = "DÖRDÜNCÜ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text != "" && SatimTartimDortTextBox.Text == "" &&
                        ConvertDouble(SatimTartimUcTextBox.Text) &&
                        SatimUrunKayit(SatimUrunUcComboBox.Text, Convert.ToDouble(SatimTartimUcTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimDortTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) + 
                            Convert.ToDouble(SatimTartimUcTextBox.Text))).ToString();
                        SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimDortTextBox.Text != "" &&
                        ConvertDouble(SatimTartimDortTextBox.Text) &&
                        SatimUrunKayit(SatimUrunDortComboBox.Text, Convert.ToDouble(SatimTartimDortTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                        SatimTartimKayit(dtBaslangic))
                    {
                        MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                    else
                    {
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                        MessageBox.Show("Tartım Başarısız!");
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 4)//DARASIZ TARTIM 5
                {
                    if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" && 
                        SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                        SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 &&
                        SatimUrunUcComboBox.SelectedIndex > -1 && SatimUrunUcComboBox.SelectedIndex > -1 && 
                        SatimUrunDortComboBox.SelectedIndex > -1 && SatimUrunBesComboBox.SelectedIndex > -1 &&
                        SatimTartimBosluklar())
                    {
                        SatimDisableButtons();
                        SatimTartimBirTextBox.Text = aSayfa.GetKgData();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" && 
                        SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                        ConvertDouble(SatimTartimBirTextBox.Text) &&
                        SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimTartimBirTextBox.Text)).ToString();
                        SatimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text == "" && 
                        SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                        ConvertDouble(SatimTartimIkiTextBox.Text) &&
                        SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimUcTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text))).ToString();
                        SatimTartimButton.Text = "DÖRDÜNCÜ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text != "" && 
                        SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                        ConvertDouble(SatimTartimUcTextBox.Text) &&
                        SatimUrunKayit(SatimUrunUcComboBox.Text, Convert.ToDouble(SatimTartimUcTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimDortTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) + 
                            Convert.ToDouble(SatimTartimUcTextBox.Text))).ToString();
                        SatimTartimButton.Text = "BEŞİNCİ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text != "" && 
                        SatimTartimDortTextBox.Text != "" && SatimTartimBesTextBox.Text == "" &&
                        ConvertDouble(SatimTartimDortTextBox.Text) &&
                        SatimUrunKayit(SatimUrunDortComboBox.Text, Convert.ToDouble(SatimTartimDortTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimBesTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) + 
                            Convert.ToDouble(SatimTartimUcTextBox.Text) + Convert.ToDouble(SatimTartimDortTextBox.Text))).ToString();
                        SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBesTextBox.Text != "" &&
                        ConvertDouble(SatimTartimBesTextBox.Text) &&
                        SatimUrunKayit(SatimUrunBesComboBox.Text, Convert.ToDouble(SatimTartimBesTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                        SatimTartimKayit(dtBaslangic))
                    {
                        MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                    else
                    {
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                        MessageBox.Show("Tartım Başarısız!");
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                }
            }

            if (SatimKayitliDaraRadioButton.Checked) //KAYITLI DARA TARTIM
            {
                if(SatimDaraTextBox.Text != "")
                {
                    if (SatimTartimSayisiComboBox.SelectedIndex == 0)//KAYITLI DARA TARTIM 1
                    {
                        if (SatimTartimBirTextBox.Text == "" &&
                            SatimUrunBirComboBox.SelectedIndex > -1 &&
                            SatimTartimBosluklar())
                        {
                            SatimDisableButtons();
                            SatimTartimBirTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimDaraTextBox.Text)).ToString();
                            SatimTartimButton.BackColor = Color.Green;
                            SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBirTextBox.Text != "" &&
                            ConvertDouble(SatimTartimBirTextBox.Text) &&
                            SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                            SatimTartimKayit(dtBaslangic))
                        {
                            MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                            SatimTartimButton.Text = "TARTIMA BAŞLA";
                            SatimTartimButton.UseVisualStyleBackColor = true;
                            SatimEnableButtons();
                        }
                        else
                        {
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                            MessageBox.Show("Tartım Başarısız!");
                            SatimTartimButton.Text = "TARTIMA BAŞLA";
                            SatimTartimButton.UseVisualStyleBackColor = true;
                            SatimEnableButtons();
                        }
                    }
                    if (SatimTartimSayisiComboBox.SelectedIndex == 1)//KAYITLI DARA TARTIM 2
                    {
                        if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" &&
                            SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 &&
                            SatimTartimBosluklar())
                        {
                            SatimDisableButtons();
                            SatimTartimBirTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimDaraTextBox.Text)).ToString();
                            SatimTartimButton.BackColor = Color.Green;
                            SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" &&
                            ConvertDouble(SatimTartimBirTextBox.Text) &&
                            SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                        {
                            SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - 
                                (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                            SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimIkiTextBox.Text != "" &&
                            ConvertDouble(SatimTartimIkiTextBox.Text) &&
                            SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                            SatimTartimKayit(dtBaslangic))
                        {
                            MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                            SatimTartimButton.Text = "TARTIMA BAŞLA";
                            SatimTartimButton.UseVisualStyleBackColor = true;
                            SatimEnableButtons();
                        }
                        else
                        {
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                            MessageBox.Show("Tartım Başarısız!");
                            SatimTartimButton.Text = "TARTIMA BAŞLA";
                            SatimTartimButton.UseVisualStyleBackColor = true;
                            SatimEnableButtons();
                        }
                    }
                    if (SatimTartimSayisiComboBox.SelectedIndex == 2)//KAYITLI DARA TARTIM 3
                    {
                        if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" &&
                            SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 && SatimUrunUcComboBox.SelectedIndex > -1 &&
                            SatimTartimBosluklar())
                        {
                            SatimDisableButtons();
                            SatimTartimBirTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimDaraTextBox.Text)).ToString();
                            SatimTartimButton.BackColor = Color.Green;
                            SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" &&
                            ConvertDouble(SatimTartimBirTextBox.Text) &&
                            SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                        {
                            SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - 
                                (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                            SatimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text == "" &&
                            ConvertDouble(SatimTartimIkiTextBox.Text) &&
                            SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                        {
                            SatimTartimUcTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                                (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) + 
                                Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                            SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimUcTextBox.Text != "" &&
                            ConvertDouble(SatimTartimUcTextBox.Text) &&
                            SatimUrunKayit(SatimUrunUcComboBox.Text, Convert.ToDouble(SatimTartimUcTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                            SatimTartimKayit(dtBaslangic))
                        {
                            MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                            SatimTartimButton.Text = "TARTIMA BAŞLA";
                            SatimTartimButton.UseVisualStyleBackColor = true;
                            SatimEnableButtons();
                        }
                        else
                        {
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                            MessageBox.Show("Tartım Başarısız!");
                            SatimTartimButton.Text = "TARTIMA BAŞLA";
                            SatimTartimButton.UseVisualStyleBackColor = true;
                            SatimEnableButtons();
                        }
                    }
                    if (SatimTartimSayisiComboBox.SelectedIndex == 3)//KAYITLI DARA TARTIM 4
                    {
                        if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" && SatimTartimDortTextBox.Text == "" &&
                            SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 &&
                            SatimUrunUcComboBox.SelectedIndex > -1 && SatimUrunUcComboBox.SelectedIndex > -1 && SatimUrunDortComboBox.SelectedIndex > -1 &&
                            SatimTartimBosluklar())
                        {
                            SatimDisableButtons();
                            SatimTartimBirTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimDaraTextBox.Text)).ToString();
                            SatimTartimButton.BackColor = Color.Green;
                            SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" && SatimTartimDortTextBox.Text == "" &&
                            ConvertDouble(SatimTartimBirTextBox.Text) &&
                            SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                        {
                            SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - 
                                (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                            SatimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text == "" &&
                            ConvertDouble(SatimTartimIkiTextBox.Text) &&
                            SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                        {
                            SatimTartimUcTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                                (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) + 
                                Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                            SatimTartimButton.Text = "DÖRDÜNCÜ TARTIM İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text != "" && SatimTartimDortTextBox.Text == "" &&
                            ConvertDouble(SatimTartimUcTextBox.Text) &&
                            SatimUrunKayit(SatimUrunUcComboBox.Text, Convert.ToDouble(SatimTartimUcTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                        {
                            SatimTartimDortTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                                (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) +
                                Convert.ToDouble(SatimTartimUcTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                            SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimDortTextBox.Text != "" &&
                            ConvertDouble(SatimTartimDortTextBox.Text) &&
                            SatimUrunKayit(SatimUrunDortComboBox.Text, Convert.ToDouble(SatimTartimDortTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                            SatimTartimKayit(dtBaslangic))
                        {
                            MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                            SatimTartimButton.Text = "TARTIMA BAŞLA";
                            SatimTartimButton.UseVisualStyleBackColor = true;
                            SatimEnableButtons();
                        }
                        else
                        {
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                            MessageBox.Show("Tartım Başarısız!");
                            SatimTartimButton.Text = "TARTIMA BAŞLA";
                            SatimTartimButton.UseVisualStyleBackColor = true;
                            SatimEnableButtons();
                        }
                    }
                    if (SatimTartimSayisiComboBox.SelectedIndex == 4)//KAYITLI DARA TARTIM 5
                    {
                        if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == ""
                            && SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                            SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 &&
                            SatimUrunUcComboBox.SelectedIndex > -1 && SatimUrunUcComboBox.SelectedIndex > -1 &&
                            SatimUrunDortComboBox.SelectedIndex > -1 && SatimUrunBesComboBox.SelectedIndex > -1 &&
                            SatimTartimBosluklar())
                        {
                            SatimDisableButtons();
                            SatimTartimBirTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimDaraTextBox.Text)).ToString();
                            SatimTartimButton.BackColor = Color.Green;
                            SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" &&
                            SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                            ConvertDouble(SatimTartimBirTextBox.Text) &&
                            SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                        {
                            SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - 
                                (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                            SatimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text == "" &&
                            SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                            ConvertDouble(SatimTartimIkiTextBox.Text) &&
                            SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                        {
                            SatimTartimUcTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                                (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) + 
                                Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                            SatimTartimButton.Text = "DÖRDÜNCÜ TARTIM İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text != "" &&
                            SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                            ConvertDouble(SatimTartimUcTextBox.Text) &&
                            SatimUrunKayit(SatimUrunUcComboBox.Text, Convert.ToDouble(SatimTartimUcTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                        {
                            SatimTartimDortTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                                (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) +
                                Convert.ToDouble(SatimTartimUcTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                            SatimTartimButton.Text = "BEŞİNCİ TARTIM İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text != "" &&
                            SatimTartimDortTextBox.Text != "" && SatimTartimBesTextBox.Text == "" &&
                            ConvertDouble(SatimTartimDortTextBox.Text) &&
                            SatimUrunKayit(SatimUrunDortComboBox.Text, Convert.ToDouble(SatimTartimDortTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                        {
                            SatimTartimBesTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                                (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) +
                                Convert.ToDouble(SatimTartimUcTextBox.Text) + Convert.ToDouble(SatimTartimDortTextBox.Text) + 
                                Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                            SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                        }
                        else if (SatimTartimBesTextBox.Text != "" &&
                            ConvertDouble(SatimTartimBesTextBox.Text) &&
                            SatimUrunKayit(SatimUrunBesComboBox.Text, Convert.ToDouble(SatimTartimBesTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                            SatimTartimKayit(dtBaslangic))
                        {
                            MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                            SatimTartimButton.Text = "TARTIMA BAŞLA";
                            SatimTartimButton.UseVisualStyleBackColor = true;
                            SatimEnableButtons();
                        }
                        else
                        {
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                            TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                            MessageBox.Show("Tartım Başarısız!");
                            SatimTartimButton.Text = "TARTIMA BAŞLA";
                            SatimTartimButton.UseVisualStyleBackColor = true;
                            SatimEnableButtons();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz Kayıtlı Dara!");
                }
            }

            if(SatimDaraTartRadioButton.Checked)//DARA TART
            {
                if (SatimTartimSayisiComboBox.SelectedIndex == 0)//DARA TART TARTIM 1
                {
                    if(SatimDaraTextBox.Text == "" && SatimTartimBirTextBox.Text == "" && 
                        SatimUrunBirComboBox.SelectedIndex > -1 &&
                        SatimTartimBosluklar())
                    {
                        SatimDaraTextBox.Text = aSayfa.GetKgData();
                        SatimDisableButtons();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İLK TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text == "" && SatimDaraTextBox.Text != "" && 
                        ConvertDouble(SatimDaraTextBox.Text))
                    {
                        SatimTartimBirTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimDaraTextBox.Text)).ToString();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && ConvertDouble(SatimTartimBirTextBox.Text) &&
                        SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                        SatimTartimKayit(dtBaslangic))
                    {
                        MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                        SatimDaraTextBox.Text = "";
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                    else
                    {
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                        MessageBox.Show("Tartım Başarısız!");
                        SatimDaraTextBox.Text = "";
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 1)//DARA TART TARTIM 2
                {
                    if (SatimDaraTextBox.Text == "" && SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" &&
                        SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 &&
                        SatimTartimBosluklar())
                    {
                        SatimDaraTextBox.Text = aSayfa.GetKgData();
                        SatimDisableButtons();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İLK TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" &&
                        SatimDaraTextBox.Text != "" && ConvertDouble(SatimDaraTextBox.Text))
                    {
                        SatimTartimBirTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimDaraTextBox.Text)).ToString();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" &&
                        ConvertDouble(SatimTartimBirTextBox.Text) && 
                        SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                        SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimIkiTextBox.Text != "" &&
                        ConvertDouble(SatimTartimIkiTextBox.Text) &&
                        SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                        SatimTartimKayit(dtBaslangic))
                    {
                        MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                        SatimDaraTextBox.Text = "";
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                    else
                    {
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                        MessageBox.Show("Tartım Başarısız!");
                        SatimDaraTextBox.Text = "";
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 2)//DARA TART TARTIM 3
                {
                    if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" &&
                        SatimDaraTextBox.Text == "" &&
                        SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 && 
                        SatimUrunUcComboBox.SelectedIndex > -1 &&
                        SatimTartimBosluklar())
                    {
                        SatimDaraTextBox.Text = aSayfa.GetKgData();
                        SatimDisableButtons();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İLK TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" &&
                        SatimDaraTextBox.Text != "" && ConvertDouble(SatimDaraTextBox.Text))
                    {
                        SatimTartimBirTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimDaraTextBox.Text)).ToString();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" &&
                        ConvertDouble(SatimTartimBirTextBox.Text) &&
                        SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                        SatimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text == "" &&
                        ConvertDouble(SatimTartimIkiTextBox.Text) &&
                        SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimUcTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) +
                            Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                        SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimUcTextBox.Text != "" &&
                        ConvertDouble(SatimTartimUcTextBox.Text) &&
                        SatimUrunKayit(SatimUrunUcComboBox.Text, Convert.ToDouble(SatimTartimUcTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                        SatimTartimKayit(dtBaslangic))
                    {
                        MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                        SatimDaraTextBox.Text = "";
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                    else
                    {
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                        MessageBox.Show("Tartım Başarısız!");
                        SatimDaraTextBox.Text = "";
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 3)//DARA TART TARTIM 4
                {
                    if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" && SatimTartimDortTextBox.Text == "" &&
                        SatimDaraTextBox.Text == "" &&
                        SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 &&
                        SatimUrunUcComboBox.SelectedIndex > -1 && SatimUrunDortComboBox.SelectedIndex > -1 &&
                        SatimTartimBosluklar())
                    {
                        SatimDaraTextBox.Text = aSayfa.GetKgData();
                        SatimDisableButtons();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İLK TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" && SatimTartimDortTextBox.Text == "" &&
                        SatimDaraTextBox.Text != "" && ConvertDouble(SatimDaraTextBox.Text))
                    {
                        SatimTartimBirTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimDaraTextBox.Text)).ToString();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" && SatimTartimDortTextBox.Text == "" &&
                        ConvertDouble(SatimTartimBirTextBox.Text) &&
                        SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                        SatimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text == "" &&
                        ConvertDouble(SatimTartimIkiTextBox.Text) &&
                        SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimUcTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) +
                            Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                        SatimTartimButton.Text = "DÖRDÜNCÜ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text != "" && SatimTartimDortTextBox.Text == "" &&
                        ConvertDouble(SatimTartimUcTextBox.Text) &&
                        SatimUrunKayit(SatimUrunUcComboBox.Text, Convert.ToDouble(SatimTartimUcTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimDortTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) +
                            Convert.ToDouble(SatimTartimUcTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                        SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimDortTextBox.Text != "" &&
                        ConvertDouble(SatimTartimDortTextBox.Text) &&
                        SatimUrunKayit(SatimUrunDortComboBox.Text, Convert.ToDouble(SatimTartimDortTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                        SatimTartimKayit(dtBaslangic))
                    {
                        MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                        SatimDaraTextBox.Text = "";
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                    else
                    {
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                        MessageBox.Show("Tartım Başarısız!");
                        SatimDaraTextBox.Text = "";
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                }
                if (SatimTartimSayisiComboBox.SelectedIndex == 4)//DARA TART TARTIM 5
                {
                    if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == ""
                        && SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                        SatimDaraTextBox.Text == "" &&
                        SatimUrunBirComboBox.SelectedIndex > -1 && SatimUrunIkiComboBox.SelectedIndex > -1 && 
                        SatimUrunUcComboBox.SelectedIndex > -1 && SatimUrunDortComboBox.SelectedIndex > -1 && 
                        SatimUrunBesComboBox.SelectedIndex > -1 &&
                        SatimTartimBosluklar())
                    {
                        SatimDaraTextBox.Text = aSayfa.GetKgData();
                        SatimDisableButtons();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İLK TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text == "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == ""
                        && SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                        SatimDaraTextBox.Text != "" && 
                        ConvertDouble(SatimDaraTextBox.Text))
                    {
                        SatimTartimBirTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) - Convert.ToDouble(SatimDaraTextBox.Text)).ToString();
                        SatimTartimButton.BackColor = Color.Green;
                        SatimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text == "" && SatimTartimUcTextBox.Text == "" &&
                        SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                        ConvertDouble(SatimTartimBirTextBox.Text) &&
                        SatimUrunKayit(SatimUrunBirComboBox.Text, Convert.ToDouble(SatimTartimBirTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimIkiTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                        SatimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text == "" &&
                        SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                        ConvertDouble(SatimTartimIkiTextBox.Text) &&
                        SatimUrunKayit(SatimUrunIkiComboBox.Text, Convert.ToDouble(SatimTartimIkiTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimUcTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) +
                            Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                        SatimTartimButton.Text = "DÖRDÜNCÜ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text != "" &&
                        SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                        ConvertDouble(SatimTartimUcTextBox.Text) &&
                        SatimUrunKayit(SatimUrunUcComboBox.Text, Convert.ToDouble(SatimTartimUcTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimDortTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) +
                            Convert.ToDouble(SatimTartimUcTextBox.Text) + Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                        SatimTartimButton.Text = "BEŞİNCİ TARTIM İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBirTextBox.Text != "" && SatimTartimIkiTextBox.Text != "" && SatimTartimUcTextBox.Text != "" &&
                        SatimTartimDortTextBox.Text != "" && SatimTartimBesTextBox.Text == "" &&
                        ConvertDouble(SatimTartimDortTextBox.Text) &&
                        SatimUrunKayit(SatimUrunDortComboBox.Text, Convert.ToDouble(SatimTartimDortTextBox.Text), getLastID("SATIM_TARTIMLARI")))
                    {
                        SatimTartimBesTextBox.Text = (Convert.ToDouble(aSayfa.GetKgData()) -
                            (Convert.ToDouble(SatimTartimBirTextBox.Text) + Convert.ToDouble(SatimTartimIkiTextBox.Text) +
                            Convert.ToDouble(SatimTartimUcTextBox.Text) + Convert.ToDouble(SatimTartimDortTextBox.Text) +
                            Convert.ToDouble(SatimDaraTextBox.Text))).ToString();
                        SatimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                    }
                    else if (SatimTartimBesTextBox.Text != "" &&
                        ConvertDouble(SatimTartimBesTextBox.Text) &&
                        SatimUrunKayit(SatimUrunBesComboBox.Text, Convert.ToDouble(SatimTartimBesTextBox.Text), getLastID("SATIM_TARTIMLARI")) &&
                        SatimTartimKayit(dtBaslangic))
                    {
                        MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                        SatimDaraTextBox.Text = "";
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                    else
                    {
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");
                        TartimIptal(getLastID("SATIM_TARTIMLARI"), "SATILANLAR");

                        MessageBox.Show("Tartım Başarısız!");
                        SatimDaraTextBox.Text = "";
                        SatimTartimButton.Text = "TARTIMA BAŞLA";
                        SatimTartimButton.UseVisualStyleBackColor = true;
                        SatimEnableButtons();
                    }
                }

            }
        }

        private void SatimDisableButtons()
        {
            EklemeTabControl.Enabled = false;
            AlimTab.Enabled = false;
            SatimFirmalarComboBox.Enabled = false;
            SatimPlakalarComboBox.Enabled = false;
            SatimCalisanComboBox.Enabled = false;
            SatimDorseTextBox.Enabled = false;
            SatimCikisAdresiTextBox.Enabled = false;
            SatimVarisAdresiTextBox.Enabled = false;
            SatimTartimSayisiComboBox.Enabled = false;
            SatimDaraYokRadioButton.Enabled = false;
            SatimDaraTartRadioButton.Enabled = false;
            SatimKayitliDaraRadioButton.Enabled = false;
            SatimUrunBirComboBox.Enabled = false;
            SatimUrunIkiComboBox.Enabled = false;
            SatimUrunUcComboBox.Enabled = false;
            SatimUrunDortComboBox.Enabled = false;
            SatimUrunBesComboBox.Enabled = false;

            Anasayfa aSay = (Anasayfa)this.Owner;
            Control[] c = aSay.Controls.Find("UstMenuPnl", true);
            Panel b = (Panel)c[0];
            b.Enabled = false;
        }

        private void SatimEnableButtons()
        {
            EklemeTabControl.Enabled = true;
            AlimTab.Enabled = true;
            SatimFirmalarComboBox.Enabled = true;
            SatimPlakalarComboBox.Enabled = true;
            SatimCalisanComboBox.Enabled = true;
            SatimDorseTextBox.Enabled = true;
            SatimCikisAdresiTextBox.Enabled = true;
            SatimVarisAdresiTextBox.Enabled = true;
            SatimTartimSayisiComboBox.Enabled = true;
            SatimDaraYokRadioButton.Enabled = true;
            SatimDaraTartRadioButton.Enabled = true;
            SatimKayitliDaraRadioButton.Enabled = true;
            SatimUrunBirComboBox.Enabled = true;
            SatimTartimBirTextBox.Text = "";
            SatimTartimIkiTextBox.Text = "";
            SatimTartimUcTextBox.Text = "";
            SatimTartimDortTextBox.Text = "";
            SatimTartimBesTextBox.Text = "";
            SatimTartimSayisiComboBox.SelectedIndex = 0;

            Anasayfa aSay = (Anasayfa)this.Owner;
            Control[] c = aSay.Controls.Find("UstMenuPnl", true);
            Panel b = (Panel)c[0];
            b.Enabled = true;
        }

        private bool SatimTartimBosluklar()
        {
            if(SatimFirmalarComboBox.SelectedIndex == -1 || SatimPlakalarComboBox.SelectedIndex == -1 || SatimCalisanComboBox.SelectedIndex == -1 
                || string.IsNullOrWhiteSpace(SatimVarisAdresiTextBox.Text) || string.IsNullOrWhiteSpace(SatimCikisAdresiTextBox.Text) 
                /*|| ConvertDouble(aSayfa.GetKgData())*/)
            {
                return false;

                if(SatimDorseTextBox.Text != "" || SatimDorseTextBox.Text.Length != 7)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private bool SatimTartimKayit(DateTime dT)
        {
            try
            {
                con = new MySqlConnection(db.getCon());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO SATIM_TARTIMLARI(FIRMA_ADI, PLAKA, DORSE_PLAKA, CALISAN_ADI, CIKIS_ADRES, VARIS_ADRES, " +
                    "URUN_1, URUN_1_KG, URUN_2, URUN_2_KG, URUN_3, URUN_3_KG, URUN_4, URUN_4_KG, URUN_5, URUN_5_KG, NOT_1, NOT_2, TARTIM_BASLANGIC) " +
                    "VALUES(@FIRMA_ADI, @PLAKA, @DORSE_PLAKA, @CALISAN_ADI, @CIKIS_ADRES, @VARIS_ADRES, " +
                    "@URUN_1, @URUN_1_KG, @URUN_2, @URUN_2_KG, @URUN_3, @URUN_3_KG, @URUN_4, @URUN_4_KG, @URUN_5, @URUN_5_KG, @NOT_1, @NOT_2, @TARTIM_BASLANGIC)";
                cmd.Parameters.AddWithValue("@FIRMA_ADI", SatimFirmalarComboBox.Text);
                cmd.Parameters.AddWithValue("@PLAKA", SatimPlakalarComboBox.Text);
                cmd.Parameters.AddWithValue("@DORSE_PLAKA", NullOrEmptyString(SatimDorseTextBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@CALISAN_ADI", SatimCalisanComboBox.Text);
                cmd.Parameters.AddWithValue("@CIKIS_ADRES", NullOrEmptyString(SatimCikisAdresiTextBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@VARIS_ADRES", NullOrEmptyString(SatimVarisAdresiTextBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@URUN_1", NullOrEmptyString(SatimUrunBirComboBox.Text));
                cmd.Parameters.AddWithValue("@URUN_1_KG", NullOrEmptyString(SatimTartimBirTextBox.Text));
                cmd.Parameters.AddWithValue("@URUN_2", NullOrEmptyString(SatimUrunIkiComboBox.Text));
                cmd.Parameters.AddWithValue("@URUN_2_KG", NullOrEmptyString(SatimTartimIkiTextBox.Text));
                cmd.Parameters.AddWithValue("@URUN_3", NullOrEmptyString(SatimUrunUcComboBox.Text));
                cmd.Parameters.AddWithValue("@URUN_3_KG", NullOrEmptyString(SatimTartimUcTextBox.Text));
                cmd.Parameters.AddWithValue("@URUN_4", NullOrEmptyString(SatimUrunDortComboBox.Text));
                cmd.Parameters.AddWithValue("@URUN_4_KG", NullOrEmptyString(SatimTartimDortTextBox.Text));
                cmd.Parameters.AddWithValue("@URUN_5", NullOrEmptyString(SatimUrunBesComboBox.Text));
                cmd.Parameters.AddWithValue("@URUN_5_KG", NullOrEmptyString(SatimTartimBesTextBox.Text));
                cmd.Parameters.AddWithValue("@NOT_1", NullOrEmptyString(SatimNotBirTextBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@NOT_2", NullOrEmptyString(SatimNotIkiTextBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@TARTIM_BASLANGIC", dT);

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool SatimUrunKayit(string urun_Adi, double urun_Kg, int lastID)
        {
            try
            {
                con = new MySqlConnection(db.getCon());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO SATILANLAR(TARTIM_ID, FIRMA_ADI, URUN_ADI, URUN_KG) " +
                    "VALUES(@TARTIM_ID, @FIRMA_ADI, @URUN_ADI, @URUN_KG)";
                cmd.Parameters.AddWithValue("@TARTIM_ID", lastID);
                cmd.Parameters.AddWithValue("@FIRMA_ADI", NullOrEmptyString(SatimFirmalarComboBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@URUN_ADI", urun_Adi);
                cmd.Parameters.AddWithValue("@URUN_KG", urun_Kg);

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool AlimTartimKayit(DateTime dT)
        {
            try
            {
                con = new MySqlConnection(db.getCon());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO ALIM_TARTIMLARI(FIRMA_ADI, PLAKA, DORSE_PLAKA, CALISAN_ADI, CIKIS_ADRES, VARIS_ADRES, " +
                    "URUN_1, URUN_1_KG, URUN_2, URUN_2_KG, URUN_3, URUN_3_KG, URUN_4, URUN_4_KG, URUN_5, URUN_5_KG, NOT_1, NOT_2, TARTIM_BASLANGIC) " +
                    "VALUES(@FIRMA_ADI, @PLAKA, @DORSE_PLAKA, @CALISAN_ADI, @CIKIS_ADRES, @VARIS_ADRES, " +
                    "@URUN_1, @URUN_1_KG, @URUN_2, @URUN_2_KG, @URUN_3, @URUN_3_KG, @URUN_4, @URUN_4_KG, @URUN_5, @URUN_5_KG, @NOT_1, @NOT_2, @TARTIM_BASLANGIC)";
                cmd.Parameters.AddWithValue("@FIRMA_ADI", AlimFirmalarComboBox.Text);
                cmd.Parameters.AddWithValue("@PLAKA", AlimPlakalarComboBox.Text);
                cmd.Parameters.AddWithValue("@DORSE_PLAKA", NullOrEmptyString(AlimDorseTextBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@CALISAN_ADI", AlimCalisanComboBox.Text);
                cmd.Parameters.AddWithValue("@CIKIS_ADRES", NullOrEmptyString(AlimCikisAdresiTextBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@VARIS_ADRES", NullOrEmptyString(AlimVarisAdresiTextBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@URUN_1", NullOrEmptyString(AlimUrunBirComboBox.Text));
                cmd.Parameters.AddWithValue("@URUN_1_KG", NullOrEmptyString(AlimTartimBirTextBox.Text));
                cmd.Parameters.AddWithValue("@URUN_2", NullOrEmptyString(AlimUrunIkiComboBox.Text));
                cmd.Parameters.AddWithValue("@URUN_2_KG", NullOrEmptyString(AlimTartimIkiTextBox.Text));
                cmd.Parameters.AddWithValue("@URUN_3", NullOrEmptyString(AlimUrunUcComboBox.Text));
                cmd.Parameters.AddWithValue("@URUN_3_KG", NullOrEmptyString(AlimTartimUcTextBox.Text));
                cmd.Parameters.AddWithValue("@URUN_4", NullOrEmptyString(AlimUrunDortComboBox.Text));
                cmd.Parameters.AddWithValue("@URUN_4_KG", NullOrEmptyString(AlimTartimDortTextBox.Text));
                cmd.Parameters.AddWithValue("@URUN_5", NullOrEmptyString(AlimUrunBesComboBox.Text));
                cmd.Parameters.AddWithValue("@URUN_5_KG", NullOrEmptyString(AlimTartimBesTextBox.Text));
                cmd.Parameters.AddWithValue("@NOT_1", NullOrEmptyString(AlimNotBirTextBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@NOT_2", NullOrEmptyString(AlimNotIkiTextBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@TARTIM_BASLANGIC", dT);

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool AlimUrunKayit(string urun_Adi, double urun_Kg, int lastID)
        {
            try
            {
                con = new MySqlConnection(db.getCon());
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO ALINANLAR(TARTIM_ID, FIRMA_ADI, URUN_ADI, URUN_KG) " +
                    "VALUES(@TARTIM_ID, @FIRMA_ADI, @URUN_ADI, @URUN_KG)";
                cmd.Parameters.AddWithValue("@TARTIM_ID", lastID);
                cmd.Parameters.AddWithValue("@FIRMA_ADI", NullOrEmptyString(AlimFirmalarComboBox.Text.ToUpper()));
                cmd.Parameters.AddWithValue("@URUN_ADI", urun_Adi);
                cmd.Parameters.AddWithValue("@URUN_KG", urun_Kg);

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool AlimTartimBosluklar()
        {
            if (AlimFirmalarComboBox.SelectedIndex == -1 || AlimFirmalarComboBox.SelectedIndex == -1 || AlimCalisanComboBox.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(AlimVarisAdresiTextBox.Text) || string.IsNullOrWhiteSpace(AlimCikisAdresiTextBox.Text) 
                /*|| ConvertDouble(aSayfa.GetKgData())*/)
            {
                return false;

                if (AlimDorseTextBox.Text != "" || AlimDorseTextBox.Text.Length != 7)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private void AlimDisableButtons()
        {
            EklemeTabControl.Enabled = false;
            SatimTab.Enabled = false;
            AlimFirmalarComboBox.Enabled = false;
            AlimPlakalarComboBox.Enabled = false;
            AlimCalisanComboBox.Enabled = false;
            AlimDorseTextBox.Enabled = false;
            AlimCikisAdresiTextBox.Enabled = false;
            AlimVarisAdresiTextBox.Enabled = false;
            AlimTartimSayisiComboBox.Enabled = false;
            AlimUrunBirComboBox.Enabled = false;
            AlimUrunIkiComboBox.Enabled = false;
            AlimUrunUcComboBox.Enabled = false;
            AlimUrunDortComboBox.Enabled = false;
            AlimUrunBesComboBox.Enabled = false;


            Anasayfa aSay = (Anasayfa)this.Owner;
            Control[] c = aSay.Controls.Find("UstMenuPnl", true);
            Panel b = (Panel)c[0];
            b.Enabled = false;
        }

        private void AlimEnableButtons()
        {
            EklemeTabControl.Enabled = true;
            SatimTab.Enabled = true;
            AlimFirmalarComboBox.Enabled = true;
            AlimPlakalarComboBox.Enabled = true;
            AlimCalisanComboBox.Enabled = true;
            AlimDorseTextBox.Enabled = true;
            AlimCikisAdresiTextBox.Enabled = true;
            AlimVarisAdresiTextBox.Enabled = true;
            AlimTartimSayisiComboBox.Enabled = true;
            AlimUrunBirComboBox.Enabled = true;
            AlimTartimBirTextBox.Text = "";
            AlimTartimIkiTextBox.Text = "";
            AlimTartimUcTextBox.Text = "";
            AlimTartimDortTextBox.Text = "";
            AlimTartimBesTextBox.Text = "";
            AlimToplamTextBox.Text = "";
            AlimTartimSayisiComboBox.SelectedIndex = 0;

            Anasayfa aSay = (Anasayfa)this.Owner;
            Control[] c = aSay.Controls.Find("UstMenuPnl", true);
            Panel b = (Panel)c[0];
            b.Enabled = true;
        }

        private void AlimTartimButton_Click(object sender, EventArgs e)
        {
            DateTime dtBaslangic = DateTime.Now;

            if (AlimTartimSayisiComboBox.SelectedIndex == 0)//ALIM TARTIM 1
            {
                if (AlimTartimBirTextBox.Text == "" && AlimToplamTextBox.Text == "" && 
                    AlimUrunBirComboBox.SelectedIndex > -1 &&
                    AlimTartimBosluklar())
                {
                    AlimToplamTextBox.Text = aSayfa.GetKgData();
                    AlimDisableButtons();
                    AlimTartimButton.BackColor = Color.Green;
                    AlimTartimButton.Text = "İLK TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text == "" && AlimToplamTextBox.Text != "" && 
                    ConvertDouble(AlimToplamTextBox.Text))
                {
                    AlimTartimBirTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) - Convert.ToDouble(aSayfa.GetKgData())).ToString();
                    AlimTartimButton.BackColor = Color.Green;
                    AlimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text != "" && ConvertDouble(AlimTartimBirTextBox.Text) &&
                    AlimUrunKayit(AlimUrunBirComboBox.Text, Convert.ToDouble(AlimTartimBirTextBox.Text), getLastID("ALIM_TARTIMLARI")) &&
                    AlimTartimKayit(dtBaslangic))
                {
                    MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                    AlimTartimButton.Text = "TARTIMA BAŞLA";
                    AlimTartimButton.UseVisualStyleBackColor = true;
                    AlimEnableButtons();
                }
                else
                {
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");

                    MessageBox.Show("Tartım Başarısız!");
                    AlimTartimButton.Text = "TARTIMA BAŞLA";
                    AlimEnableButtons();
                }
            }
            if (AlimTartimSayisiComboBox.SelectedIndex == 1)//ATLIM TARTIM 2
            {
                if (AlimTartimBirTextBox.Text == "" && AlimTartimIkiTextBox.Text == "" && AlimToplamTextBox.Text == "" && 
                    AlimUrunBirComboBox.SelectedIndex > -1 && AlimUrunIkiComboBox.SelectedIndex > -1 &&
                    AlimTartimBosluklar())
                {
                    AlimToplamTextBox.Text = aSayfa.GetKgData();
                    AlimDisableButtons();
                    AlimTartimButton.BackColor = Color.Green;
                    AlimTartimButton.Text = "İLK TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text == "" && AlimTartimIkiTextBox.Text == "" &&
                    AlimToplamTextBox.Text != "" && ConvertDouble(AlimToplamTextBox.Text))
                {
                    AlimTartimBirTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) - Convert.ToDouble(aSayfa.GetKgData())).ToString();
                    AlimTartimButton.BackColor = Color.Green;
                    AlimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text != "" && AlimTartimIkiTextBox.Text == "" &&
                    ConvertDouble(AlimTartimBirTextBox.Text) &&
                    AlimUrunKayit(AlimUrunBirComboBox.Text, Convert.ToDouble(AlimTartimBirTextBox.Text), getLastID("ALIM_TARTIMLARI")))
                {
                    AlimTartimIkiTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) -
                        (Convert.ToDouble(AlimTartimBirTextBox.Text) + Convert.ToDouble(aSayfa.GetKgData()))).ToString();
                    AlimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                }
                else if (AlimTartimIkiTextBox.Text != "" &&
                    ConvertDouble(AlimTartimIkiTextBox.Text) &&
                    AlimUrunKayit(AlimUrunIkiComboBox.Text, Convert.ToDouble(AlimTartimIkiTextBox.Text), getLastID("ALIM_TARTIMLARI")) &&
                    AlimTartimKayit(dtBaslangic))
                {
                    MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                    AlimTartimButton.Text = "TARTIMA BAŞLA";
                    AlimTartimButton.UseVisualStyleBackColor = true;
                    AlimEnableButtons();
                }
                else
                {
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");

                    MessageBox.Show("Tartım Başarısız!");
                    AlimTartimButton.Text = "TARTIMA BAŞLA";
                    AlimTartimButton.UseVisualStyleBackColor = true;
                    AlimEnableButtons();
                }
            }
            if (AlimTartimSayisiComboBox.SelectedIndex == 2)//ALIM TARTIM 3
            {
                if (AlimTartimBirTextBox.Text == "" && AlimTartimIkiTextBox.Text == "" && AlimTartimUcTextBox.Text == "" &&
                    AlimToplamTextBox.Text == "" &&
                    AlimUrunBirComboBox.SelectedIndex > -1 && AlimUrunIkiComboBox.SelectedIndex > -1 && AlimUrunUcComboBox.SelectedIndex > -1 &&
                    AlimTartimBosluklar())
                {
                    AlimToplamTextBox.Text = aSayfa.GetKgData();
                    AlimDisableButtons();
                    AlimTartimButton.BackColor = Color.Green;
                    AlimTartimButton.Text = "İLK TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text == "" && AlimTartimIkiTextBox.Text == "" && AlimTartimUcTextBox.Text == "" &&
                    AlimToplamTextBox.Text != "" && ConvertDouble(AlimToplamTextBox.Text))
                {
                    AlimTartimBirTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) - Convert.ToDouble(aSayfa.GetKgData())).ToString();
                    AlimTartimButton.BackColor = Color.Green;
                    AlimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text != "" && AlimTartimIkiTextBox.Text == "" && AlimTartimUcTextBox.Text == "" &&
                    ConvertDouble(AlimTartimBirTextBox.Text) &&
                    AlimUrunKayit(AlimUrunBirComboBox.Text, Convert.ToDouble(AlimTartimBirTextBox.Text), getLastID("ALIM_TARTIMLARI")))
                {
                    AlimTartimIkiTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) -
                        (Convert.ToDouble(AlimTartimBirTextBox.Text) + Convert.ToDouble(aSayfa.GetKgData()))).ToString();
                    AlimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text != "" && AlimTartimIkiTextBox.Text != "" && AlimTartimUcTextBox.Text == "" &&
                    ConvertDouble(AlimTartimIkiTextBox.Text) &&
                    AlimUrunKayit(AlimUrunIkiComboBox.Text, Convert.ToDouble(AlimTartimIkiTextBox.Text), getLastID("ALIM_TARTIMLARI")))
                {
                    AlimTartimUcTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) -
                        (Convert.ToDouble(AlimTartimBirTextBox.Text) + Convert.ToDouble(AlimTartimIkiTextBox.Text) +
                        Convert.ToDouble(aSayfa.GetKgData()))).ToString();
                    AlimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                }
                else if (AlimTartimUcTextBox.Text != "" &&
                    ConvertDouble(AlimTartimUcTextBox.Text) &&
                    AlimUrunKayit(AlimUrunUcComboBox.Text, Convert.ToDouble(AlimTartimUcTextBox.Text), getLastID("ALIM_TARTIMLARI")) &&
                    AlimTartimKayit(dtBaslangic))
                {
                    MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                    AlimTartimButton.Text = "TARTIMA BAŞLA";
                    AlimTartimButton.UseVisualStyleBackColor = true;
                    AlimEnableButtons();
                }
                else
                {
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");

                    MessageBox.Show("Tartım Başarısız!");
                    AlimTartimButton.Text = "TARTIMA BAŞLA";
                    AlimTartimButton.UseVisualStyleBackColor = true;
                    AlimEnableButtons();
                }
            }
            if (AlimTartimSayisiComboBox.SelectedIndex == 3)//ALIM TARTIM 4
            {
                if (AlimTartimBirTextBox.Text == "" && AlimTartimIkiTextBox.Text == "" && AlimTartimUcTextBox.Text == "" &&
                    AlimTartimDortTextBox.Text == "" && AlimToplamTextBox.Text == "" &&
                    AlimUrunBirComboBox.SelectedIndex > -1 && AlimUrunIkiComboBox.SelectedIndex > -1 &&
                    AlimUrunUcComboBox.SelectedIndex > -1 && AlimUrunDortComboBox.SelectedIndex > -1 &&
                    AlimTartimBosluklar())
                {
                    AlimToplamTextBox.Text = aSayfa.GetKgData();
                    AlimDisableButtons();
                    AlimTartimButton.BackColor = Color.Green;
                    AlimTartimButton.Text = "İLK TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text == "" && AlimTartimIkiTextBox.Text == "" && AlimTartimUcTextBox.Text == "" && 
                    AlimTartimDortTextBox.Text == "" && AlimToplamTextBox.Text != "" && 
                    ConvertDouble(AlimToplamTextBox.Text))
                {
                    AlimTartimBirTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) - Convert.ToDouble(aSayfa.GetKgData())).ToString();
                    AlimTartimButton.BackColor = Color.Green;
                    AlimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text != "" && AlimTartimIkiTextBox.Text == "" && AlimTartimUcTextBox.Text == "" && AlimTartimDortTextBox.Text == "" &&
                    ConvertDouble(AlimTartimBirTextBox.Text) &&
                    AlimUrunKayit(AlimUrunBirComboBox.Text, Convert.ToDouble(AlimTartimBirTextBox.Text), getLastID("ALIM_TARTIMLARI")))
                {
                    AlimTartimIkiTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) -
                        (Convert.ToDouble(AlimTartimBirTextBox.Text) + Convert.ToDouble(aSayfa.GetKgData()))).ToString();
                    AlimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text != "" && AlimTartimIkiTextBox.Text != "" && AlimTartimUcTextBox.Text == "" &&
                    ConvertDouble(AlimTartimIkiTextBox.Text) &&
                    AlimUrunKayit(AlimUrunIkiComboBox.Text, Convert.ToDouble(AlimTartimIkiTextBox.Text), getLastID("ALIM_TARTIMLARI")))
                {
                    AlimTartimUcTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) -
                        (Convert.ToDouble(AlimTartimBirTextBox.Text) + Convert.ToDouble(AlimTartimIkiTextBox.Text) +
                        Convert.ToDouble(aSayfa.GetKgData()))).ToString();
                    AlimTartimButton.Text = "DÖRDÜNCÜ TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text != "" && AlimTartimIkiTextBox.Text != "" && AlimTartimUcTextBox.Text != "" && 
                    AlimTartimDortTextBox.Text == "" &&
                    ConvertDouble(AlimTartimUcTextBox.Text) &&
                    AlimUrunKayit(AlimUrunUcComboBox.Text, Convert.ToDouble(AlimTartimUcTextBox.Text), getLastID("ALIM_TARTIMLARI")))
                {
                    AlimTartimDortTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) -
                        (Convert.ToDouble(AlimTartimBirTextBox.Text) + Convert.ToDouble(AlimTartimIkiTextBox.Text) +
                        Convert.ToDouble(AlimTartimUcTextBox.Text) + Convert.ToDouble(aSayfa.GetKgData()))).ToString();
                    AlimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                }
                else if (AlimTartimDortTextBox.Text != "" &&
                    ConvertDouble(AlimTartimDortTextBox.Text) &&
                    AlimUrunKayit(AlimUrunDortComboBox.Text, Convert.ToDouble(AlimTartimDortTextBox.Text), getLastID("ALIM_TARTIMLARI")) &&
                    AlimTartimKayit(dtBaslangic))
                {
                    MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                    AlimTartimButton.Text = "TARTIMA BAŞLA";
                    AlimTartimButton.UseVisualStyleBackColor = true;
                    AlimEnableButtons();
                }
                else
                {
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");

                    MessageBox.Show("Tartım Başarısız!");
                    AlimTartimButton.Text = "TARTIMA BAŞLA";
                    AlimTartimButton.UseVisualStyleBackColor = true;
                    AlimEnableButtons();
                }
            }
            if (AlimTartimSayisiComboBox.SelectedIndex == 4)//ALIM TARTIM 5
            {
                if (AlimTartimBirTextBox.Text == "" && AlimTartimIkiTextBox.Text == "" && AlimTartimUcTextBox.Text == "" && 
                    AlimTartimDortTextBox.Text == "" && AlimTartimBesTextBox.Text == "" && AlimToplamTextBox.Text == "" &&
                    AlimUrunBirComboBox.SelectedIndex > -1 && AlimUrunIkiComboBox.SelectedIndex > -1 &&
                    AlimUrunUcComboBox.SelectedIndex > -1 && AlimUrunDortComboBox.SelectedIndex > -1 && 
                    AlimUrunBirComboBox.SelectedIndex > -1 &&
                    AlimTartimBosluklar())
                {
                    AlimToplamTextBox.Text = aSayfa.GetKgData();
                    AlimDisableButtons();
                    AlimTartimButton.BackColor = Color.Green;
                    AlimTartimButton.Text = "İLK TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text == "" && AlimTartimIkiTextBox.Text == "" && AlimTartimUcTextBox.Text == ""
                    && AlimTartimDortTextBox.Text == "" && AlimTartimBesTextBox.Text == "" && AlimToplamTextBox.Text != "" && 
                    ConvertDouble(AlimToplamTextBox.Text))
                {
                    AlimTartimBirTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) - Convert.ToDouble(aSayfa.GetKgData())).ToString();
                    AlimTartimButton.BackColor = Color.Green;
                    AlimTartimButton.Text = "İKİNCİ TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text != "" && AlimTartimIkiTextBox.Text == "" && AlimTartimUcTextBox.Text == "" &&
                    SatimTartimDortTextBox.Text == "" && SatimTartimBesTextBox.Text == "" &&
                    ConvertDouble(AlimTartimBirTextBox.Text) &&
                    AlimUrunKayit(AlimUrunBirComboBox.Text, Convert.ToDouble(AlimTartimBirTextBox.Text), getLastID("ALIM_TARTIMLARI")))
                {
                    AlimTartimIkiTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) -
                        (Convert.ToDouble(AlimTartimBirTextBox.Text) + Convert.ToDouble(aSayfa.GetKgData()))).ToString();
                    AlimTartimButton.Text = "ÜÇÜNCÜ TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text != "" && AlimTartimIkiTextBox.Text != "" && AlimTartimUcTextBox.Text == "" &&
                    AlimTartimDortTextBox.Text == "" && AlimTartimBesTextBox.Text == "" &&
                    ConvertDouble(AlimTartimIkiTextBox.Text) &&
                    SatimUrunKayit(AlimUrunIkiComboBox.Text, Convert.ToDouble(AlimTartimIkiTextBox.Text), getLastID("ALIM_TARTIMLARI")))
                {
                    AlimTartimUcTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) -
                        (Convert.ToDouble(AlimTartimBirTextBox.Text) + Convert.ToDouble(AlimTartimIkiTextBox.Text) +
                        Convert.ToDouble(aSayfa.GetKgData()))).ToString();
                    AlimTartimButton.Text = "DÖRDÜNCÜ TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text != "" && AlimTartimIkiTextBox.Text != "" && AlimTartimUcTextBox.Text != "" &&
                    AlimTartimDortTextBox.Text == "" && AlimTartimBesTextBox.Text == "" &&
                    ConvertDouble(AlimTartimUcTextBox.Text) &&
                    AlimUrunKayit(AlimUrunUcComboBox.Text, Convert.ToDouble(AlimTartimUcTextBox.Text), getLastID("ALIM_TARTIMLARI")))
                {
                    AlimTartimDortTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) -
                        (Convert.ToDouble(AlimTartimBirTextBox.Text) + Convert.ToDouble(AlimTartimIkiTextBox.Text) +
                        Convert.ToDouble(AlimTartimUcTextBox.Text) + Convert.ToDouble(aSayfa.GetKgData()))).ToString();
                    AlimTartimButton.Text = "BEŞİNCİ TARTIM İÇİN TIKLAYIN";
                }
                else if (AlimTartimBirTextBox.Text != "" && AlimTartimIkiTextBox.Text != "" && AlimTartimUcTextBox.Text != "" &&
                    AlimTartimDortTextBox.Text != "" && AlimTartimBesTextBox.Text == "" &&
                    ConvertDouble(AlimTartimDortTextBox.Text) &&
                    AlimUrunKayit(AlimUrunDortComboBox.Text, Convert.ToDouble(AlimTartimDortTextBox.Text), getLastID("ALIM_TARTIMLARI")))
                {
                    AlimTartimDortTextBox.Text = (Convert.ToDouble(AlimToplamTextBox.Text) -
                        (Convert.ToDouble(AlimTartimBirTextBox.Text) + Convert.ToDouble(AlimTartimIkiTextBox.Text) +
                        Convert.ToDouble(AlimTartimUcTextBox.Text) + Convert.ToDouble(aSayfa.GetKgData()) +
                        Convert.ToDouble(AlimTartimDortTextBox.Text))).ToString();
                    AlimTartimButton.Text = "TARTIMI KAYDETMEK İÇİN TIKLAYIN";
                }
                else if (AlimTartimBesTextBox.Text != "" &&
                    ConvertDouble(AlimTartimBesTextBox.Text) &&
                    AlimUrunKayit(AlimUrunBesComboBox.Text, Convert.ToDouble(AlimTartimBesTextBox.Text), getLastID("ALIM_TARTIMLARI")) &&
                    AlimTartimKayit(dtBaslangic))
                {
                    MessageBox.Show("Tartım Başarıyla Kayıt Edildi!");
                    AlimTartimButton.Text = "TARTIMA BAŞLA";
                    AlimTartimButton.UseVisualStyleBackColor = true;
                    AlimEnableButtons();
                }
                else
                {
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");
                    TartimIptal(getLastID("SATIM_TARTIMLARI"), "ALINANLAR");

                    MessageBox.Show("Tartım Başarısız!");
                    AlimTartimButton.Text = "TARTIMA BAŞLA";
                    AlimTartimButton.UseVisualStyleBackColor = true;
                    AlimEnableButtons();
                }
            }
        }

        private void TartimIptal(int id, string tartimAlimSatim)
        {
            db.RunQuery("DELETE FROM " + tartimAlimSatim + " WHERE TARTIM_ID =" + id);
        }
    }
}