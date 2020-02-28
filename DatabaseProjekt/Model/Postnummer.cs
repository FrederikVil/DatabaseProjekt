using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DatabaseProjekt.Model
{
    class Postnummer : Crud
    {
        // Fields der tager input fra program klassen.
        public int postnummerID { get; set; }
        public int postnummer { get; set; }

        // string til table name.
        private string tableName = "Postnummer";

        // Henter connection string med ned i Postnummer klassen
        public Postnummer(SqlConnection c) : base(c)
        {
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
