using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DatabaseProjekt.Model
{
    public class Postnummer
    {
        // Fields der tager input fra program klassen.
        public int postnummerID { get; set; }
        public int postnummer { get; set; }

        // string til table name.
        private string tableName = "Postnummer";

        private SqlConnection myConn;
        // Tager connection string fra program klassen så den kan bruges her.
        public Postnummer (SqlConnection c)
        {
            myConn = c;
        }

        // Normal SQL insert med parameters. ExecuteScalar printer det ID ud som postnummeret får.
        public int Insert()
        {
            string query = "INSERT INTO Postnummer (Postnummer) output INSERTED.PostnummerID VALUES (@postnr)";
            myConn.Open();
            SqlCommand cmd = new SqlCommand(query, myConn);
            cmd.Parameters.AddWithValue("@postnr", postnummer); 
            int i = (int)cmd.ExecuteScalar();
            myConn.Close();
            return i;
        }

        // Normal SQL delelte med parameters
        public void Delete()
        {
            string query = "DELETE FROM Postnummer WHERE Postnummer = @postnr";
            myConn.Open();
            SqlCommand cmd = new SqlCommand(query, myConn);
            cmd.Parameters.AddWithValue("@postnr", postnummer);
               
            cmd.ExecuteNonQuery();
            myConn.Close();
        }

        // Save metode så SQL metoderne kan genbruges i de forskellige klasser, kun med ændringer i Save metoden.
        public void Save()
        {
            ArrayList values = new ArrayList()
            {
                postnummer
            };

            List<string> keys = new List<string>
            {
                "Postnummer"
            };

            DeleteWorksForAllClasses(tableName, values, keys);

        }

        // Delete metode der virker i alle klasser.
        public void DeleteWorksForAllClasses(string tableName, ArrayList values, List<string> keys)
        {
            // Tager de ting i listen keys og ligger dem i fieldnames or parameters, så de har de rigtige "@" og ",".
            string fieldnames = string.Join(",", keys);
            string parameters = "@" + string.Join(",@", keys);

            // Min query der tager tingene oppe fra Save, og kører dem igennem.
            string query = $"DELETE FROM {tableName} WHERE {fieldnames} = {parameters}";
            SqlCommand cmd = new SqlCommand(query, myConn);

            // Laver et parameter til hver value.
            for (int i = 0; i < keys.Count; i++)
            {
                cmd.Parameters.AddWithValue("@" + keys[i], values[i]);
            }
            myConn.Open();
            cmd.ExecuteNonQuery();
            myConn.Close();
        }

        //public void Update(List<string> keys)
        //{
        //    ArrayList Values = new ArrayList();
        //    foreach (string item in keys)
        //    {
        //        Values.Add(this.GetType().GetProperty(item).GetValue(this, null));
        //    }

        //    base.Update(tableName, Values, keys, "PostnummerID", postnummerID.ToString());
        //}

    }
}
