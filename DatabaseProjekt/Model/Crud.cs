﻿using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DatabaseProjekt.Model
{
    public class Crud
    {
        protected SqlConnection myConn;

        // Connnection string fra program klassen. 
        public Crud(SqlConnection c)
        {
            myConn = c;
        }

        // Delete metode der virker i alle klasser.
        protected void DeleteWorksForAllClasses(string tableName, ArrayList values, List<string> keys)
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

        // Update metode der virker i alle klasser.
        protected void UpdateWorksForAllClasses(string TableName, ArrayList values, List<string> keys, string key, string value)
        {
            // Første del af SQL query.
            string query = "UPDATE " + TableName + " SET ";
            int l = values.Count;

            // For loop der tilføjer keys fra listen til query.
            for (int i = 0; i < l; i++)
            {
                query += keys[i] + " = @" + keys[i] + ",";
            }
            // Fjerne det sidste , i query.
            char[] charToBeRemoved = { ',' };
            query = query.TrimEnd(charToBeRemoved);
            query += " WHERE " + key + "=" + value;

            // Tilføjer SQL parameters.
            SqlCommand cmd = new SqlCommand(query, myConn);
            for (int i = 0; i < l; i++)
            {
                cmd.Parameters.AddWithValue("@" + keys[i], values[i]);
            }
            myConn.Open();

            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} row(s) was affected");
            myConn.Close();

        }
    }
}
