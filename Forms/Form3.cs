using FileTaggingApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTaggingApp.Forms
{
    public partial class Form3 : Form
    {
        string reqFile = string.Empty;
        public Form3(string reqfile)
        {
            InitializeComponent();
            loadCheckedList();
            this.MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            reqFile = reqfile;
        }

        private void loadCheckedList()
        {
            List<string> result = Form1ViewModel.getDistinctTagFromTable();
                for (int i = 0; i < result.Count; i++)
                {
                    checkedListBox1.Items.Add(result[i]);
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                Form1ViewModel.addTagtoFile(Form1ViewModel.getFileIdfromPath(reqFile), checkedListBox1.Items[i].ToString(), reqFile);

                }
            }
            Close();
        }
    }
}
