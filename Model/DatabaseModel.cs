using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace FileTaggingApp.Model
{
    public class DatabaseModel
    {
        public SQLiteConnection myConnection; 

        public DatabaseModel()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");
                CreateTable();  
                Debug.WriteLine("Database file Created"); 
            }
            
        }
        public void OpenConnection()
        {
            if(myConnection.State != System.Data.ConnectionState.Open) { 
            myConnection.Open();
            }
        }
        public void CreateTable()
        {
            SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE \"FileIDTable\" (\r\n\t\"Id\"\tINTEGER NOT NULL UNIQUE,\r\n\t\"fileid\"\tNVARCHAR(50),\r\n\t\"Tags\"\tNVARCHAR(50),\r\n\t\"Path\"\tNVARCHAR(50),\r\n\tPRIMARY KEY(\"Id\" AUTOINCREMENT)\r\n);", myConnection);
            OpenConnection(); 
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
        public void CloseConnection()
        {
            if(myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();   
            }
        }
    }
}
