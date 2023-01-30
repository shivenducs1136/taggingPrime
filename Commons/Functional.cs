using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace FileTaggingApp
{
    internal class Functional
    {
        string variable;
        public string Get_path_from_id(string s , string file_drive)
        {
            Process test = new Process();
            test.StartInfo.FileName = "cmd.exe";
            test.StartInfo.UseShellExecute = false;
            test.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            long longValue = long.Parse(s);
            string long_string = longValue.ToString();
            test.StartInfo.Arguments = "/c fsutil file queryFileNameById "+ file_drive+":\\ "+ long_string;
            test.StartInfo.RedirectStandardOutput = true;
            test.Start();
            string textString = test.StandardOutput.ReadLine().ToString();
            test.Close();
            int txt = textString.Length;
            string sub = "";
            try
            {
                sub = textString.Substring(39);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message); 
            }
            if (!File.Exists(sub))
                s = "";

            return sub;
        }
    }

    
}
