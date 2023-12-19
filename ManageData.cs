using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows;

namespace DataManagementTools
{
    public class ManageData
    {
        SqlConnection connection;

        public ManageData()
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
                connection.Open();
            }
            catch(Exception ex)
            {
                connection = null;
                MessageBox.Show($"Подключение не получилось создать: {ex.Message}");
            }
            
        }

        public void SqlRequest(string sqlR)
        {
            SqlCommand cmd = new SqlCommand(sqlR, connection);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader SqlRequestReader(string sqlR)
        {
            SqlCommand cmd = new SqlCommand(sqlR, connection);
            SqlDataReader reared = cmd.ExecuteReader();

            return reared;
        }

        public SqlDataReader ReaderProcedure(string proce, Hashtable hashTable)
        {
            SqlCommand cmd = new SqlCommand(proce, connection);
            foreach (DictionaryEntry table in hashTable)
            {
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = $"@{table.Key}",
                    Value = table.Value
                });
            }
            
            return cmd.ExecuteReader();
        }
        public void Procedure(string proce, Hashtable hashTable)
        {
            SqlCommand cmd = new SqlCommand(proce, connection);
            foreach (DictionaryEntry table in hashTable)
            {
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = $"@{table.Key}",
                    Value = table.Value
                });
            }

         
        }
        public void Update()
        {
            connection.Close();
            
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Подключение не получилось создать");
            }
            
        }
    }
}
