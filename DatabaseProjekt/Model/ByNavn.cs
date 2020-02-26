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

        public void Insert()
        {
            string query = "INSERT INTO ByNavn (ByNavn, PostnummerID) VALUES (@bynavn, @postnummerID)";
            myConn.Open();
            SqlCommand cmd = new SqlCommand(query, myConn);
            cmd.Parameters.AddWithValue("@bynavn", byNavn); 
            cmd.Parameters.AddWithValue("@postnummerID", postnummerID); 
            cmd.ExecuteNonQuery();
            myConn.Close();
        }

        public void Select()
        {
            string query = "SELECT Bynavn.ByNavnID, ByNavn.ByNavn, Postnummer.Postnummer " +
                "FROM ByNavn INNER JOIN Postnummer ON ByNavn.PostnummerID = Postnummer.PostnummerID";
            myConn.Open();
            SqlCommand cmd = new SqlCommand(query, myConn);
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nID | Bynavn | Postnummer \n");
            while (reader.Read())
            {
                Console.WriteLine("{0}  {1}  {2}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            }
            reader.Close();
            myConn.Close();
        }
    }
}



