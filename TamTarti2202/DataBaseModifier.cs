using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;
using TamTarti2202.Properties;

namespace TamTarti2202
{
    internal class DataBaseModifier
    {
        private MySqlConnection con = null;
        private MySqlCommand cmd = null;
        private MySqlDataReader reader = null;
        private MySqlDataAdapter dataAdapter = null;
        private DataTable dt = null;
        private static string server = Properties.KullaniciAyarlari.Default.Server;
        private static string database = Properties.KullaniciAyarlari.Default.Database;
        private static string userId = Properties.KullaniciAyarlari.Default.UserId;
        private static string userPassword = Properties.KullaniciAyarlari.Default.UserPassword;
        private string connectionCreate = string.Format("server={0};uid={1};pwd={2};Charset=utf8;convert zero datetime=True;", server, userId, userPassword);
        private string connection = string.Format("server={0};database={1};uid={2};pwd={3};Charset=utf8;convert zero datetime=True;", server, database, userId, userPassword);
        private void closeDb()
        {
            try
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public string GetStringFromQuery(string query)
        {
            try
            {
                con = new MySqlConnection(connection);
                cmd = new MySqlCommand(query, con);
                con.Open();

                string s = "";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    s = reader[0].ToString();
                }
                closeDb();
                return s;
            }
            catch (MySqlException ex)
            {
                closeDb();
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void RunQueryCreate(string query)
        {
            try
            {
                con = new MySqlConnection(connectionCreate);
                cmd = new MySqlCommand(query, con);
                con.Open();

                reader = cmd.ExecuteReader();

                closeDb();
            }
            catch (Exception ex)
            {
                closeDb();
                Console.WriteLine(ex.Message);
            }
        }

        public void RunQuery(string query)
        {
            try
            {
                con = new MySqlConnection(connection);
                cmd = new MySqlCommand(query, con);
                con.Open();

                reader = cmd.ExecuteReader();

                closeDb();
            }
            catch (Exception ex)
            {
                closeDb();
                Console.WriteLine(ex.Message);
            }
        }

        public DataTable GetTable(string query)
        {
            try
            {
                dt = new DataTable();
                con = new MySqlConnection(connection);
                cmd = new MySqlCommand(query, con);
                con.Open();
                dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                closeDb();

                return dt;
            }
            catch (Exception ex)
            {
                closeDb();
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string getCon()
        {
            return connection;
        }
    }
}
