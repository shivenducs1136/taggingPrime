using CheckComboBoxTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using FileTaggingApp.Model;
using System.Data.SQLite;
using FileTaggingApp.ViewModel;

namespace FileTaggingApp
{
    public partial class Form2 : Form
    {
              public CheckedComboBox maincheckbox;
        //public string[] selected_tags;
        public HashSet<string> selected_tags;
        public Dictionary<string, List<string>> listofTagFiles;
        public HashSet<string> finalized_fileIDS;
        public DatabaseModel dbmodel = null;
        public Form2()
        {
            this.MaximizeBox = false;
            InitializeComponent();
            maincheckbox = this.checkedComboBox1;
            maincheckbox.MaxDropDownItems = 8;
            dbmodel= new DatabaseModel();   
            selected_tags = new HashSet<string>();
            listofTagFiles = new Dictionary<string, List<string>>();
            finalized_fileIDS = new HashSet<string>();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            load_tags_to_checkbox();
        }

        private void load_tags_to_checkbox()
        {
            try
            {
                List<string> res = Form1ViewModel.getDistinctTagFromTable();
                for(int i =0; i< res.Count; i++) {
                    maincheckbox.Items.Add(res[i]); 
                }
            }
            catch (Exception e)
            {

            }
        }

        public void showSelectedTage(string tagName)
        {
            SearchListView.Clear();
            showSelectedTage(tagName);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Gobtn2_Click(object sender, EventArgs e)
        {

            Debug.WriteLine("Selected Tags to search = ");
            foreach (string stri in selected_tags)
                Debug.WriteLine(stri);
            Debug.WriteLine("These were all the tags to search ");

            finalized_fileIDS = new HashSet<string>();
            listofTagFiles = new Dictionary<string, List<string>>();
            SearchListView.Clear();
            get_files();
            finalizeIDS();
            showfiles();

        }

        private void showfiles()
        {
            Functional getter = new Functional();
            try
            {
                foreach (string id in finalized_fileIDS)
                {
                    int complete_length = id.Length;

                    string fileID = id.Substring(0, complete_length - 1);
                    string volume = id.Substring(complete_length - 1, 1);
                    string required_filepath = getter.Get_path_from_id(fileID, volume);
                    if (System.IO.File.Exists(required_filepath))
                    {
                        add_file_to_view(required_filepath);
                    }


                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void add_file_to_view(string required_filepath)
        {
            FileInfo fileDetails = new FileInfo(required_filepath);
            SearchListView.Items.Add(required_filepath, fileDetails.Name, Form1ViewModel.getExtensionImg(fileDetails.Extension.ToUpper()));

        }

        private void finalizeIDS()
        {
            int indexofminimum = 0;
            int minValue = int.MaxValue;

            for (int x = 0; x < listofTagFiles.Count; x++)
            {
                int k = listofTagFiles.Keys.ElementAt(x).Count();
                if (minValue > k)
                {
                    indexofminimum = x;
                    minValue = k;
                }
            }
            string elements = listofTagFiles.Keys.ElementAt(indexofminimum);

            foreach (string fileidOneTag in listofTagFiles[elements])
            {
                int presentinall = 1;
                for (int x = 0; x < listofTagFiles.Count; x++)
                {
                    string elemental_ids_key = listofTagFiles.Keys.ElementAt(x);
                    if (!listofTagFiles[elemental_ids_key].Contains(fileidOneTag))
                    {
                        presentinall = 0;
                        break;
                    }
                }
                if (presentinall == 1 && listofTagFiles.Count > 0)
                {
                    finalized_fileIDS.Add(fileidOneTag.ToString());
                }

            }
            Debug.WriteLine("Selected ids FINALISZED = ");
            foreach (string id in finalized_fileIDS)
            {
                Debug.WriteLine(id);
            }
        }

        private void get_files()
        {
            Debug.WriteLine("Get giels called ");
            foreach (string one_tag in selected_tags)
            {

                try
                {
                   
                    listofTagFiles.Add(one_tag, Form1ViewModel.getFileIdPathfromTag(one_tag));

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    Debug.WriteLine("UNearth ho gaya hai bhau");
                }

            }

        }

        public void ShowList(string enteredTagName)
        {
            Functional getter = new Functional();
            try
            {

                SQLiteCommand cmd = new SQLiteCommand(String.Format("SELECT fileid,Path FROM FileIDTable where Tags = '{0}'", enteredTagName), dbmodel.myConnection);
                dbmodel.OpenConnection();
                SQLiteDataReader reader = cmd.ExecuteReader();
                var indexOfColumn1 = reader.GetOrdinal("fileid");
                var pathColumn = reader.GetOrdinal("Path");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var pathvalue = reader.GetValue(pathColumn);
                        string volume_of_file = pathvalue.ToString().Substring(0, 1);
                        var value1 = reader.GetValue(indexOfColumn1);
                        string required_filepath = getter.Get_path_from_id(value1.ToString(), volume_of_file);
                        if (System.IO.File.Exists(required_filepath))
                        {
                            FileInfo fileDetails = new FileInfo(required_filepath);
                            SearchListView.Items.Add(required_filepath, fileDetails.Name, Form1ViewModel.getExtensionImg(fileDetails.Extension.ToUpper())); 
                        }

                    }
                }
                dbmodel.CloseConnection();
               

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void SearchListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void SearchList_MouseDoubleClick(object sender, EventArgs e)
        {
            var firstSelectedItem = SearchListView.SelectedItems[0];
            if (System.IO.File.Exists(firstSelectedItem.Name))
            {
                Process.Start(firstSelectedItem.Name);
            }
        }

        private void checkedComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void checkedComboBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string item = maincheckbox.Items[e.Index].ToString();
            if (item != null)
            {
                if (maincheckbox.GetItemCheckState(e.Index) == CheckState.Unchecked)
                {
                    selected_tags.Add(item);
                }
                else if (maincheckbox.GetItemCheckState(e.Index) == CheckState.Checked)
                {
                    selected_tags.Remove(item);
                }

            }
            else
                Debug.WriteLine("Item null");

        }

    }

}
