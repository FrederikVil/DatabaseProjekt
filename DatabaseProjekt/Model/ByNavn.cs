using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProjekt.Model
{
     class ByNavn
    {
        public int byNavnID { get; set; }
        public string byNavn { get; set; }
        public string postnummerID { get; set; }

        private SqlConnection myConn;

        public ByNavn(SqlConnection c)
        {
            myConn = c;
        }

        public void Save()
        {
            string query = "INSERT INTO ByNavn (ByNavn) VALUES (@bynavn)";
            myConn.Open();
            SqlCommand cmd = new SqlCommand(query, myConn);
            cmd.Parameters.AddWithValue("@bynavn", byNavn);

            cmd.ExecuteNonQuery();
            myConn.Close();
        }
    }
}
