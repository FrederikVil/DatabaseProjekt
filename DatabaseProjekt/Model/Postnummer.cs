using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProjekt.Model
{
    public class Postnummer
    {
        public int postnummerID { get; set; }
        public int postnummer { get; set; }

        private SqlConnection myConn;

        public Postnummer (SqlConnection c)
        {
            myConn = c;
        }

        public void Save()
        {
            string query = "INSERT INTO Postnummer (Postnummer) VALUES (@postnr)";
            myConn.Open();
            SqlCommand cmd = new SqlCommand(query, myConn);
            cmd.Parameters.AddWithValue("@postnr", postnummer);

            cmd.ExecuteNonQuery();
            myConn.Close();
        }

        public void Delete()
        {
            string query = "DELETE FROM Postnummer WHERE Postnummer = @postnr";
            myConn.Open();
            SqlCommand cmd = new SqlCommand(query, myConn);
            cmd.Parameters.AddWithValue("@postnr", postnummer);

            cmd.ExecuteNonQuery();
            myConn.Close();
        }



    }
}
