using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTaggingApp
{
    public partial class CreateNewTag : Form
    {
        public CreateNewTag()
        {
            InitializeComponent();
        }

        private void AddTagTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Addbtn1_Click(object sender, EventArgs e)
        {
            //Form1 ff = new Form1();

            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            string str = rgx.Replace(AddTagTextBox.Text, "");

            if (AddTagTextBox.Text == str)
            {
                Form1.instance.CUSTOM_TAG_CREATE(str);
                Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Tag name should be alphanumeric only !", "Information",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void CreateNewTag_Load(object sender, EventArgs e)
        {

        }
     
    }
}