using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            if (AddTagTextBox.Text != "")
            {
                Form1.instance.CUSTOM_TAG_CREATE(AddTagTextBox.Text);
                Close();
            }
            
        }

        private void CreateNewTag_Load(object sender, EventArgs e)
        {

        }
    }
}
