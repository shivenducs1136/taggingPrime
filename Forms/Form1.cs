using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using FileTaggingApp.Model;
using FileTaggingApp.ViewModel;
using System.Data.SQLite;
using Microsoft.Win32;
using System.Threading;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace FileTaggingApp
{
    public partial class Form1 : Form
    {
        public string filePath = "";
        public bool isFile = false;
        public string currentlySelectedItem = "";
        public string temppfilepath = "";
        public static Form1 instance;
        public ContextMenuStrip Main_Context_menu;
        public ToolStripMenuItem primary_menu_item;
        public bool isCut = false;
        public bool isCopy = false;
        public string cutFilePath = "";
        public string cutFileName = "";
        public DatabaseModel dbmodel = null;
        public string tempTagName="";
        public bool isShowList = false; 
        public Form1()
        {
            Debug.WriteLine("Form1 Called"); 
            InitializeComponent();
            this.MaximizeBox = false;
            Main_Context_menu = this.contextMenuStrip1;
            primary_menu_item = this.addTagToolStripMenuItem;
            instance = this;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            dbmodel = new DatabaseModel();
            get_other_tags_also();

        }

        private void get_other_tags_also()
        {
            Debug.WriteLine("get_other_tags_also Called");

            try
            {
                List<string> result = Form1ViewModel.getDistinctTagFromTable();
                int ct = result.Count;
                result.Reverse();   
                    for (int i = 0; i < 6; i++)
                    {
                    if (i == ct)
                    {
                        break;
                    }
                    ADD_TO_TAGS(result[i].ToString());
                    
                    }
                
            }
            catch (Exception e)
            {
                ErrorPrompt(e.Message);
                // Exception when distinct tags are not loaded   
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Form1_Load Called");

            loadDrive(); 
            
        }

        public void loadDrive()
        {
            var drv = DriveInfo.GetDrives();
            foreach (DriveInfo dInfo in drv)
            {
                listView1.Items.Add(dInfo.Name, 9);
            }
            loadTags();
        }
        public void ADD_TO_TAGS(string v)
        {
            Debug.WriteLine("ADD_TO_TAGS Called");
            ToolStripMenuItem secondary_menu_item0 = new ToolStripMenuItem(v);
            secondary_menu_item0.Click += new EventHandler(tag_selected_file);
            primary_menu_item.DropDownItems.AddRange(new ToolStripItem[] { secondary_menu_item0 });

        }

        private void tag_selected_file(object sender, EventArgs e)
        {
            Debug.WriteLine("tag_selected_file Called");
            string currentFilePath = temppfilepath;

            if (isFile){

                FileInfo f = new FileInfo(currentFilePath);
                string fid = Form1ViewModel.getFileIdfromPath(currentFilePath); // file id here
                Form1ViewModel.addTagtoFile(fid, (sender as ToolStripMenuItem).Text, currentFilePath); 
                loadTags();
                ShowTagsOfaFile(currentFilePath);
            }
          

        }

        private void loadTags()
        {
            Debug.WriteLine("loadTags Called");
            listBox1.Items.Clear();
            List<string> l = new List<string>();
            try
            {
                l = Form1ViewModel.getDistinctTagFromTable(); 
                for (int i = 0; i < l.Count(); i++)
                {
                    listBox1.Items.Add(l[i]);
                }

            }
            catch (Exception ex)
            {
                ErrorPrompt(ex.Message);

            }


        }

        private void loadfilesandDirectories()
        {
            Debug.WriteLine("loadfilesandDirectories Called");
            Debug.WriteLine("Kush ho gayo re baba Called");


            




            DirectoryInfo filelist;
            string tempFilePath = "";
            FileAttributes fileAttr;
            try
            {

                if (isFile)
                {
                    tempFilePath =Path.Combine(filePath,currentlySelectedItem);
                    FileInfo fileDetails = new FileInfo(tempFilePath);
                    fileAttr = File.GetAttributes(tempFilePath);
                    Process.Start(tempFilePath);
                }
                else
                {
                    fileAttr = File.GetAttributes(filePath);

                }
                if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory )
                {
                    filelist = new DirectoryInfo(filePath);
                    FileInfo[] files = filelist.GetFiles();
                    DirectoryInfo[] dirs = filelist.GetDirectories();
                    string fileExtension = "";
                    listView1.Items.Clear();
                    for (int i = 0; i < files.Length; i++)
                    {
                        fileExtension = files[i].Extension.ToUpper();
                      
                        listView1.Items.Add(files[i].Name, Form1ViewModel.getExtensionImg(fileExtension));

                    }
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        listView1.Items.Add(dirs[i].Name, 3);
                    }
                }
                

            }
            catch (Exception e)
            {
                // ErrorPrompt(e.Message);
            }
        }

        private void loadButtonAction()
        {
            isShowList = false;
            tempTagName = "";
            Debug.WriteLine("loadButtonAction Called");
            removeBackSlash();
     
            if(filepathtextbox.Text.Length == 2)
            {
                filepathtextbox.Text += '\\'; 
            }
            filePath = filepathtextbox.Text;
            loadfilesandDirectories();
            isFile = false;
        }
        private void gobtn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("gobtn_Click Called");
            loadButtonAction();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Debug.WriteLine("listView1_ItemSelectionChanged Called");
            currentlySelectedItem = e.Item.Text;
            contextMenuStrip1.Items[2].Enabled = true;
            contextMenuStrip1.Items[3].Enabled = true;
            if (filePath.Length == 0)
            { 
                filepathtextbox.Text = currentlySelectedItem;
                return; 

            }
            
            try
            {
                FileAttributes fileAttr = File.GetAttributes( Path.Combine(filePath,currentlySelectedItem));
                if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    filenamelabel.Text = " ";
                    filesizelabel.Text = " ";
                    isFile = false;
                    if(filePath.Length!= 0) {
                        if (filePath[filePath.Length-1] == '\\')
                        {
                            filepathtextbox.Text = filePath + currentlySelectedItem;
                        }
                        else
                        filepathtextbox.Text = filePath + "\\" + currentlySelectedItem;
                    }
                    else
                    {
                        filepathtextbox.Text = currentlySelectedItem;                        
                    }
                    temppfilepath = filepathtextbox.Text;
                }
                else
                {
                    isFile = true;
                    temppfilepath = Path.Combine(filePath, currentlySelectedItem);
                    FileInfo f = new FileInfo(temppfilepath);   
                    filenamelabel.Text = f.Name;
                    float file_size = (float)f.Length;
                    int number_of_times = 0;
                    if (file_size > 400)
                    while(file_size<0.4 || file_size>800)
                    {
                        file_size = file_size / 1024;
                        number_of_times++;
                        if (number_of_times >= 5)
                            break;
                    }
                    string unit = number_of_times >= 4 ? " Tb" : number_of_times == 3 ? " Gb" : number_of_times == 2 ? " Mb" : number_of_times == 1 ? " Kb" : " Bytes";
                    filesizelabel.Text = Math.Round(file_size,2)+unit;
                    ShowTagsOfaFile(temppfilepath);
                    
                }
            }
            catch(FileNotFoundException)
            {
                isFile = false;
                listView1.Clear();
                listBox2.Items.Clear();
                loadfilesandDirectories();
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    var currfilePath = Path.Combine(filePath, currentlySelectedItem);
                    string fid = Form1ViewModel.getFileIdwithPathFromDB(currfilePath);
                    if (fid != "")
                    {
                        Functional f = new Functional();
                        string volume_of_file = currfilePath.ToString().Substring(0, 1);
                        string path = f.Get_path_from_id(fid, volume_of_file);
                        if (File.Exists(path))
                        {
                            Form1ViewModel.updateFilePath(currfilePath, path);

                            Form1ViewModel.deleteWithFilePath(currfilePath);
                        }
                    }
                }).Start();
            }

            catch (Exception ex )
            {
                ErrorPrompt(ex.Message);

            }
            Debug.WriteLine("listView1_ItemSelectionChanged Called" + currentlySelectedItem + " * " + temppfilepath);

        }
        public void ShowTagsOfaFile(string filePath)
        {
            Debug.WriteLine("ShowTagsOfaFile Called");
            listBox2.Items.Clear();
            try { 
                List<string> tags = Form1ViewModel.getTagsofFilePath(filePath);
                for(int i =0; i<tags.Count; i++)
                {
                    listBox2.Items.Add(tags[i]);
                }
            }
            catch (Exception e)
            {
                ErrorPrompt(e.Message);
            }
        }

        public string removeSlash(string path)
        {
            Debug.WriteLine("removeSlash Called");
            if (path.LastIndexOf("\\") == path.Length - 1)
            {
                path = path.Substring(0, path.Length - 1);
            }
            return path; 
        }
        public void removeBackSlash()
        {
            Debug.WriteLine("removeBackSlash Called");

            string path = filepathtextbox.Text;
            if(path.Length == 0)
            {
                return; 
            }
            if (path.LastIndexOf("\\") == path.Length - 1)
            {
                filepathtextbox.Text = path.Substring(0, path.Length - 1);
            }
        }
        public void goBack()
        {
            Debug.WriteLine("goBack Called");
            try
            {

                removeBackSlash();
                string path = filepathtextbox.Text;
                path = path.Substring(0, path.LastIndexOf("\\"));
                this.isFile = false;
                filepathtextbox.Text = path;
                removeBackSlash();
            }
            catch (Exception e)
            {
                InfoPrompt("Press Home button to view Drives");

            }
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            Debug.WriteLine("listView1_MouseDoubleClick Called");

            if (openselectefile(sender,e)=="")
            {
                loadButtonAction();
            }
            
        }

        private string openselectefile(object sender, EventArgs e)
        {

            string exists_file = "";
            try

            {
                var firstSelectedItem = listView1.SelectedItems[0];
                if (System.IO.File.Exists(firstSelectedItem.Name))
                {
                    Process.Start(firstSelectedItem.Name);
                    exists_file = "file Exisits";

                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return exists_file;
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Backbtn_Click Called");
            goBack();
            listBox2.Items.Clear();
            filenamelabel.Text = "";
            isShowList = false;
            tempTagName = "";
            filesizelabel.Text = "";
            loadButtonAction();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Debug.WriteLine("contextMenuStrip1_Opening Called");
            if (listView1.SelectedIndices.Count != 0)
            {
                contextMenuStrip1.Items[2].Enabled = true;
                contextMenuStrip1.Items[3].Enabled = true;
                contextMenuStrip1.Items[5].Enabled = true;
                contextMenuStrip1.Items[6].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;
                contextMenuStrip1.Items[5].Enabled = false;
                contextMenuStrip1.Items[6].Enabled = false;
                listBox2.Items.Clear();

            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("button1_Click Called");
            Form2 f = new Form2();
            f.TopMost = true;
            f.Show();
        }

        private void removeAllTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string SQL_Query_to_remove = "DELETE FROM FileIDTable WHERE Path='';";

            string toBeDeleted = "";
            try
            {
                if (listView1.SelectedItems != null)
                {
                    toBeDeleted = Path.Combine(filePath, currentlySelectedItem);
                    Debug.WriteLine("Delete all tags for this file Called for " + toBeDeleted);
                    Form1ViewModel.deleteWithFilePath(toBeDeleted);
                    
                }


            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            loadTags();
            listBox2.Items.Clear();
            isFile = false; 
        }

        private void createCustomTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("createCustomTagsToolStripMenuItem_Click Called");
            CreateNewTag n = new CreateNewTag();
            n.Show();
        }
        public void CreateNewTag(string st)
        {
  
            Debug.WriteLine("CreateNewTag Called");
            ToolStripMenuItem pmItem = (ToolStripMenuItem)contextMenuStrip1.Items[0];
            string directory = @"C:\Program Files\Microsoft";
            pmItem.Text = directory; 
            string[] pmEntries = Directory.GetFileSystemEntries(directory);
            addSubItems(pmItem, pmEntries);
            this.contextMenuStrip1.Items.Clear();
            var item = new System.Windows.Forms.ToolStripMenuItem()
            {
                Name = "Test",
                Text = "Test"
            };
            ToolStripMenuItem toolItem = new ToolStripMenuItem();
            toolItem.Name = st;
            toolItem.Tag = 5;
            toolItem.Text = st;
            ToolStripMenuItem[] items = {toolItem};
                this.contextMenuStrip1.Items.AddRange(items);

                this.addTagToolStripMenuItem.DropDownItems.Add(toolItem);
                this.contextMenuStrip1.Items.Add(toolItem);
                Console.WriteLine("Saved Item = " + contextMenuStrip1.Items[st]);
                contextMenuStrip1.Show(0, 0);
        }

        private void addSubItems(ToolStripMenuItem item, string[] entries)
        {
            Debug.WriteLine("addSubItems Called");
            for (int e = 0; e < entries.Length; e++)
            {
                ToolStripMenuItem subItem = (ToolStripMenuItem)item.DropDownItems.Add(System.IO.Path.GetFileName(entries[e])); 
                if (System.IO.Directory.Exists(entries[e])) 
                {
                    addSubItems(subItem, System.IO.Directory.GetFileSystemEntries(entries[e]));
                }
            }
        }
        [Obsolete]
       

        private void button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("button2_Click Called");
            listView1.Items.Clear ();
            listBox2.Items.Clear ();
            filenamelabel.Text = "";
            isShowList = false;
            tempTagName = ""; 
            filesizelabel.Text = ""; 
            filepathtextbox.Text = "";
            filePath = ""; 
            isFile = false;
            var drv = DriveInfo.GetDrives();
            foreach (DriveInfo dInfo in drv)
            {
                listView1.Items.Add(dInfo.Name, 9);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("listBox1_MouseDoubleClick Called");
            var selectedTagName = ""; 
            if (listBox1.SelectedItems != null)
            {
                try
                {
                    if(listBox1.SelectedItem != null)
                    {
                        selectedTagName = listBox1.SelectedItem.ToString();
                    }
                }
                catch (System.NullReferenceException ex){ 
                    Debug.WriteLine(ex.Message);    
                }

            }

            ShowList(selectedTagName); 
            
        }
        public void ShowList(string enteredTagName)
        {
            Debug.WriteLine("ShowList Called");
            isShowList = true;
            tempTagName = enteredTagName; 
            listView1.Clear(); 
            listBox2.Items.Clear();
            filepathtextbox.Text = "";
            try
            {
               List<string > list = Form1ViewModel.getFilePathwithTagname(enteredTagName);
                for(int i =0; i<list.Count; i++)
                {
                    FileInfo fileDetails = new FileInfo(list[i].ToString());
                    listView1.Items.Add(list[i].ToString(),fileDetails.Name, Form1ViewModel.getExtensionImg(fileDetails.Extension.ToUpper()));
                }

            }
            catch (Exception e)
            {
                ErrorPrompt(e.Message);

                // unable to get tags of a certain filename
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("deletebtn_Click Called");
            string toBeDeleted = ""; 
            try
            {
                if (listBox1.SelectedItems != null)
                {
                    toBeDeleted = listBox1.SelectedItem.ToString();
                }
                Form1ViewModel.deleteWithTag(toBeDeleted);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            loadTags();
            ShowList("");
        }


        internal void CUSTOM_TAG_CREATE(string text)
        {
            ADD_TO_TAGS(text);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("cutToolStripMenuItem_Click Called");
            string currentFileName = currentlySelectedItem;
            int currentIndex = listView1.SelectedIndices[0];
            if (isFile) {
                listView1.Items[currentIndex].ImageIndex = 10;

                contextMenuStrip1.Items[4].Enabled = true;
                isCut = true;
                isCopy = false; 
                cutFilePath = temppfilepath;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("pasteToolStripMenuItem_Click Called");
         
            string fileName = Path.GetFileName(cutFilePath);
            string path = filepathtextbox.Text;
            if (File.Exists(Path.Combine(path,fileName)))
            {
                Debug.WriteLine("File already Exists here.");
                ErrorPrompt("File already Exists here.");
                isFile = false; 
                listView1.Clear();
                loadfilesandDirectories();  
            }
            else
            {
                string sourceFile = cutFilePath;
                string destinationFile = Path.Combine(path, fileName);
                try
                {
                    if(isCut)
                    {
                        try
                        {
                            Debug.WriteLine($"Cut {sourceFile} {destinationFile}");
                            Functional f = new Functional();
                            string oldfileid = Form1ViewModel.getFileIdfromPath(sourceFile); 
                            File.Move(sourceFile, destinationFile);
                            Form1ViewModel.updateFilePath(sourceFile, destinationFile);
                            string volume1_of_file = sourceFile.ToString().Substring(0, 1);
                            string volume2_of_file = destinationFile.ToString().Substring(0, 1);
                            if (volume1_of_file != volume2_of_file)
                            {
                                string newFileId = Form1ViewModel.getFileIdfromPath(destinationFile);
                                Debug.WriteLine(oldfileid + " " + newFileId);
                                Form1ViewModel.updateFileID(oldfileid, newFileId);
                            }
                        }
                        catch(Exception iox)
                        {
                            ErrorPrompt(iox.Message);
                        }
                    }
                    if (isCopy)
                    {
                        File.Copy(sourceFile, destinationFile);

                    }
                    loadfilesandDirectories();
                    contextMenuStrip1.Items[4].Enabled = false; 
                    isCut = false;
                    isCopy = false;
                    contextMenuStrip1.Items[2].Enabled = false;
                    contextMenuStrip1.Items[3].Enabled = false;
                }
                catch (IOException iox)
                {
                    ErrorPrompt(iox.Message); 
                    Debug.WriteLine(iox.Message);
                }


            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("copyToolStripMenuItem_Click Called");
            string currentFileName = currentlySelectedItem;
            int currentIndex = listView1.SelectedIndices[0];
            if (isFile)
            {
                listView1.Items[currentIndex].ImageIndex = 11;
                contextMenuStrip1.Items[4].Enabled = true;
                isCopy = true;
                isCut = false; 
                cutFilePath = temppfilepath;
            }
        }
        


        private void button3_Click_1(object sender, EventArgs e)
        {
            Debug.WriteLine("button3_Click_1 Called");
            isFile = false; 
            listView1.Clear();
            loadTags();
            isFile = false;
            isCut = false;
            isCopy = false;
            cutFilePath = "";
            cutFileName = "";

            if (isShowList)
            {
                ShowList(tempTagName);

            }
            else if (filepathtextbox.Text== "")
            {
                loadDrive();
            }
            else
            {
                loadfilesandDirectories();

            }
            listBox2.Items.Clear();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("button4_Click Called");
            Form1ViewModel.deleteTagsOfFilePath(listBox2.SelectedItem.ToString(), temppfilepath); 
            ShowTagsOfaFile(temppfilepath); 
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("renameToolStripMenuItem_Click Called");
            try
            {
                int currentIndex = listView1.SelectedIndices[0];
                string promptValue = Prompt.ShowDialog("Enter new file name", "Rename");
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                string str = rgx.Replace(promptValue, "");
                if (promptValue != str)
                {
                    DialogResult result = MessageBox.Show("File name should be alphanumeric only !", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }
                if (promptValue != null)
                {
                    string reqfile = Path.Combine(filepathtextbox.Text,listView1.Items[currentIndex].Text);
                    FileInfo f = new FileInfo(reqfile);
                    File.Move(reqfile, Path.Combine( filepathtextbox.Text, promptValue+f.Extension));
                    Form1ViewModel.updateFilePath(reqfile, Path.Combine(filepathtextbox.Text,promptValue+f.Extension));
                    isFile = false;
                    loadfilesandDirectories();
                 
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ErrorPrompt("Only files can be renamed");    
            }

        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("deleteToolStripMenuItem_Click Called");
            DialogResult result = MessageBox.Show("Do you really want to delete this file", "Delete",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                delete();
            }
            else if (result == DialogResult.No)
            {
                return;
            }

            return ;

        }
        public void delete()
        {
            Debug.WriteLine("delete Called");
            int currentIndex = listView1.SelectedIndices[0];
            string reqfile = Path.Combine(filepathtextbox.Text, listView1.Items[currentIndex].Text);
            File.Delete(reqfile);
            isFile = false;
            loadfilesandDirectories();
            Form1ViewModel.deleteWithFilePath(reqfile); 
        }

        public void ErrorPrompt(string msg)
        {
            Debug.WriteLine("ErrorPrompt Called");
            DialogResult result = MessageBox.Show("Error: "+msg, "Error",
              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return; 
        }

        public void InfoPrompt(string msg)
        {
            Debug.WriteLine("InfoPrompt Called");
            DialogResult result = MessageBox.Show("Please: " + msg, "Information",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void showAllTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add tags. 
            try
            {
                int currentIndex = listView1.SelectedIndices[0];
                string reqfile = Path.Combine(filepathtextbox.Text, listView1.Items[currentIndex].Text);
                Forms.Form3 f = new Forms.Form3(reqfile);
                f.Show();
            }
            catch(Exception ex) { }

        }
    }


 
    
}
