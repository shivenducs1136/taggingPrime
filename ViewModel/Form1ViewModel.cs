using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FileTaggingApp.Model;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Threading;

namespace FileTaggingApp.ViewModel
{
    internal class Form1ViewModel : Form1
    {

        /*
        * Get all the tags from db that is entered by the user
       */

        internal static List<string> getDistinctTagFromTable(){

            List<string> result = new List<string>();
            string query = "SELECT DISTINCT Tags FROM FileIDTable";
            SQLiteCommand cmd = new SQLiteCommand(query, instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            SQLiteDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                var indexOfColumn1 = reader.GetOrdinal("Tags");

                while (reader.Read())
                {

                    var value1 = reader.GetValue(indexOfColumn1) as string;
                    result.Add(value1); 

                }
            }
            instance.dbmodel.CloseConnection();
            return result;
        }


        /*
        * Get fileid with a path from db
       */
        internal static string getFileIdwithPathFromDB(string path)
        {
            string res = ""; 
            SQLiteCommand cmd = new SQLiteCommand(String.Format("SELECT fileid FROM FileIDTable where Path = '{0}'", path), instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            SQLiteDataReader reader= cmd.ExecuteReader();
            if (reader.HasRows)
            {
                var indexOfColumn1 = reader.GetOrdinal("fileid");
                while (reader.Read())
                {
                    res  = reader.GetValue(indexOfColumn1) as string;
                    break; 
                }
            }
            return res; 
        }
        /*
        * Get fileid and path from a certain tag
       */
        internal static List<string> getFileIdPathfromTag(string tagname)
        {
            List<string> current_ids = new List<string>();

            SQLiteCommand cmd = new SQLiteCommand(String.Format("SELECT fileid,Path FROM FileIDTable where Tags = '{0}'", tagname), instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            SQLiteDataReader reader = cmd.ExecuteReader();
            var indexOfColumn1 = reader.GetOrdinal("fileid");
            var pathColumn = reader.GetOrdinal("Path");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //listofTagFiles[one_tag].Append(indexOfColumn1.ToString());
                    var value1 = reader.GetValue(indexOfColumn1);
                    var pathvalue = reader.GetValue(pathColumn);
                    string volume_of_file = pathvalue.ToString().Substring(0, 1);
                    current_ids.Add(value1.ToString() + volume_of_file);
                }
            }
            instance.dbmodel.CloseConnection();
            return current_ids;
        }

        /*
        * Add tag to a file from context menu.
       */
        internal static void addTagtoFile(string fileId, string tag, string path) 
        {
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO FileIDTable (fileid,Tags,Path) VALUES (@fileid, @Tags, @Path)", instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            cmd.Parameters.AddWithValue("@fileid", fileId);
            cmd.Parameters.AddWithValue("@Tags", tag);
            cmd.Parameters.AddWithValue("@Path", path);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Inserting Data Successfully");
            instance.dbmodel.CloseConnection();
        }
        internal static List<string> getTagsofFileId(string fileid)
        {

            string query = String.Format("SELECT DISTINCT Tags FROM FileIDTable where fileid = '{0}'", fileid);
            SQLiteCommand cmd = new SQLiteCommand(query, instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<string> tags = new List<string>();
            if (reader.HasRows)
            {
                var indexOfColumn1 = reader.GetOrdinal("Tags");
                while (reader.Read())
                {
                    var value1 = reader.GetValue(indexOfColumn1) as string;
                    tags.Add(value1);

                }
            }
            instance.dbmodel.CloseConnection();
            return tags;
        }

        /*
        * get tags of a certain file path 
       */

        internal static List<string> getTagsofFilePath(string filePath)
        {

            string query = String.Format("SELECT DISTINCT Tags FROM FileIDTable where Path = '{0}'", filePath);
            SQLiteCommand cmd = new SQLiteCommand(query, instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<string> tags = new List<string>();
            if (reader.HasRows)
            {
                var indexOfColumn1 = reader.GetOrdinal("Tags");
                while (reader.Read())
                {
                    var value1 = reader.GetValue(indexOfColumn1) as string;
                    tags.Add(value1);
                    

                }
            }
      
            instance.dbmodel.CloseConnection();
            return tags; 
        }


        /*
        * Delete tags from certain file
       */
        internal static void deleteTagsOfFilePath(string tags,string filepath)
        {
            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM FileIDTable WHERE Tags = '" + tags + "' AND Path = '" + filepath + "'", instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Tag removed Successfully");
            instance.dbmodel.CloseConnection();
        }

     
        /*
        * Update file path with old file path
       */
        internal static bool updateFilePath(string oldFilePath, string newFilePath)
        {

            SQLiteCommand cmd = new SQLiteCommand("UPDATE FileIDTable SET Path =" + "'" + newFilePath + "'" + "WHERE Path =" + "'" + oldFilePath + "'", instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            Console.WriteLine("Updating Data Successfully");
            instance.dbmodel.CloseConnection();
            return true; 
        }
        /*
        * Update fileid with old fileid
       */
        internal static bool updateFileID(string oldFileId, string newFileId)
        {

            SQLiteCommand cmd = new SQLiteCommand("UPDATE FileIDTable SET fileid =" + "'" + newFileId + "'" + "WHERE fileid =" + "'" + oldFileId + "'", instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            Console.WriteLine("Updating Data Successfully");
            instance.dbmodel.CloseConnection();
            return true;
        }
        /*
       * get file path from fileID
      */
        internal static string getPathfromFileIdDB(string fileID)
        {
            string res = ""; 
            string query = String.Format("SELECT DISTINCT Path FROM FileIDTable where fileid = '{0}'", fileID);
            SQLiteCommand cmd = new SQLiteCommand(query, instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                var indexOfColumn1 = reader.GetOrdinal("Path");
                while (reader.Read())
                {
                    var value1 = reader.GetValue(indexOfColumn1) as string;
                    res = value1;
                    break; 
                }
            }
            instance.dbmodel.CloseConnection();
            return res;
        }

        /*
        * get file path from a tagname
       */
        internal static List<string> getFilePathwithTagname(string tagname)
        {
            string query = String.Format("SELECT DISTINCT Path FROM FileIDTable where Tags = '{0}'", tagname);
            SQLiteCommand cmd = new SQLiteCommand(query, instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            SQLiteDataReader result = cmd.ExecuteReader();
            List<string> list = new List<string>();
            if (result.HasRows)
            {
                var indexOfColumn1 = result.GetOrdinal("Path");
                while (result.Read())
                {
                    var value1 = result.GetValue(indexOfColumn1) as string;
                    if (File.Exists(value1))
                    {
                        list.Add(value1);
                    }
                    else
                    {
                        new Thread(() =>
                        {
                            
                            Thread.CurrentThread.IsBackground = true;
                            var currfilePath = value1;
                            string fid = getFileIdwithPathFromDB(currfilePath);
                            if (fid != "")
                            {
                                Functional f = new Functional();
                                string volume_of_file = currfilePath.ToString().Substring(0, 1);
                                string path = f.Get_path_from_id(fid, volume_of_file);
                                if (File.Exists(path))
                                {

                                    updateFilePath(currfilePath, path);
                                    deleteWithFilePath(currfilePath);
                                    list.Add(path);
                                }
                            }
                           
                            
                            Console.WriteLine("Running in Background");
                        }).Start();

                    }

                }

            }

            instance.dbmodel.CloseConnection();
            return list; 
        }

        /*
        * Delete all enteries with certain file tag
       */
        internal static void deleteWithTag(string tagname)
        {
            string query = "DELETE FROM FileIDTable" + " WHERE Tags" + " = '" + tagname + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            cmd.ExecuteNonQuery();
            instance.dbmodel.CloseConnection();
        }


        /*
        * Delete all enteries with certain file path
       */
        internal static void deleteWithFilePath(string filePath)
        {
            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM FileIDTable" + " WHERE Path" + " = '" + filePath + "'", instance.dbmodel.myConnection);
            instance.dbmodel.OpenConnection();
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            instance.dbmodel.CloseConnection();
            Debug.WriteLine("Deleted successfully " + filePath);
        }


        /*
        * get file id of a file from current path 
       */
        internal static string getFileIdfromPath(string currpath)
        {
            WinAPI.BY_HANDLE_FILE_INFORMATION objectFileInfo = new WinAPI.BY_HANDLE_FILE_INFORMATION();

            FileInfo fi = new FileInfo(currpath);
            FileStream fs = fi.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            WinAPI.GetFileInformationByHandle(fs.Handle, out objectFileInfo);

            fs.Close();

            ulong fileIndex = ((ulong)objectFileInfo.FileIndexHigh << 32) + (ulong)objectFileInfo.FileIndexLow;

            return fileIndex.ToString();
        }

        /*
        * get image index for a given extension. 
       */
        internal static int getExtensionImg(string ext)
        {
            switch (ext)
            {
                case ".MP3":
                case ".MP2":
                    return 5;
                case ".EXE":
                case ".COM":
                    return 2;
                case ".MP4":
                case ".MVI":
                case ".MKV":
                    return 6; 
                case ".PDF":
                    return 7;
                case ".DOC":
                case ".DOCX":
                    return 1;
                case ".PNG":
                case ".JPG":
                case ".JPEG":
                case ".GIF":
                case ".ICO":
                case ".SVG": 
                    return 4;
                case ".ZIP":
                case ".RAR":
                    return 12;
                case ".MSI":
                case ".BAT":
                case ".PROPERTIES":
                case ".EDITORCONFIG":
                case ".KEYSTORE":
                case ".GRADLE":
                case ".APPLICATION":
                    return 13;
                case ".XML":
                    return 14;
                case ".TXT":
                case ".MD":
                case ".GITIGNORE":
                    return 15; 
                default:
                    return 8; 
            }
        }
    }
}
