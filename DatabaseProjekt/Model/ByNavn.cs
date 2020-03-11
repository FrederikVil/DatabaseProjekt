using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DatabaseProjekt.Model
{
     class ByNavn : Crud
    {
        // Mine fields.
        public int byNavnID { get; set; }
        public string byNavn { get; set; }
        public string postnummerID { get; set; }

        // Databse table name.
        private string tableName = "ByNavn";


        // Henter connection string med ned i ByNavn klassen.
        public ByNavn(SqlConnection c) : base(c)
        {
        }

        // Insert postnummer og by i databasen.
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

        // Select statement der tager ID, bynavn og postnummer og inner joiner bynavn.postnummerID = postnummer.postnummerID.
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
                // Første er Id så den skal reade en INT. Næste er bynavnet hvilket er en string, og det sidste er postnummeret som er INT igen.
                Console.WriteLine("{0}  {1}  {2}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            }
            reader.Close();
            myConn.Close();
        }

        // Save metode så SQL metoderne kan genbruges i de forskellige klasser, kun med ændringer i Save metoden.
        public void Save()
        {
            ArrayList values = new ArrayList()
            {
                byNavn
                
            };

            List<string> keys = new List<string>
            {
                "ByNavn"
                
            };

            DeleteWorksForAllClasses(tableName, values, keys);
        }
    }
}



