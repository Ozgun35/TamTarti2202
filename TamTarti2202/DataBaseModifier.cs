using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace TamTarti2202
{
    internal class DataBaseModifier
    {

        private MySqlConnection con = null;
        private MySqlCommand cmd = null;
        private MySqlDataReader reader = null;
        private MySqlDataAdapter dataAdapter = null;
        private DataTable dt = null;

        private void closeDb()
        {
            try
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public string GetStringFromQuery(string query, string connection)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public Boolean RunQuery(string query, string connection)
        {
            try
            {
                con = new MySqlConnection(connection);
                cmd = new MySqlCommand(query, con);
                con.Open();

                reader = cmd.ExecuteReader();

                closeDb();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " runquery exception");
                return false;
            }
        }

        public DataTable GetTable(string query, string connection)
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
                MessageBox.Show(ex.Message + " dettable exception");
                return null;
            }
        }
    }
}
