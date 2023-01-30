using System;
using System.Windows.Forms;

namespace FileTaggingApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ImageList imageList1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.SearchListView = new System.Windows.Forms.ListView();
            this.Gobtn2 = new System.Windows.Forms.Button();
            this.checkedComboBox1 = new CheckComboBoxTest.CheckedComboBox();
            imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            imageList1.Images.SetKeyName(0, "box.png");
            imageList1.Images.SetKeyName(1, "doc.png");
            imageList1.Images.SetKeyName(2, "exe.png");
            imageList1.Images.SetKeyName(3, "folder.png");
            imageList1.Images.SetKeyName(4, "image.png");
            imageList1.Images.SetKeyName(5, "mp3.png");
            imageList1.Images.SetKeyName(6, "mp4.png");
            imageList1.Images.SetKeyName(7, "pdf.png");
            imageList1.Images.SetKeyName(8, "unknown-mail.png");
            imageList1.Images.SetKeyName(9, "hard-drive.png");
            imageList1.Images.SetKeyName(10, "cutting.png");
            imageList1.Images.SetKeyName(11, "copy.png");
            imageList1.Images.SetKeyName(12, "zip-file.png");
            imageList1.Images.SetKeyName(13, "setting.png");
            imageList1.Images.SetKeyName(14, "web-browser.png");
            imageList1.Images.SetKeyName(15, "google-docs.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Tag Name : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SearchListView
            // 
            this.SearchListView.HideSelection = false;
            this.SearchListView.LargeImageList = imageList1;
            this.SearchListView.Location = new System.Drawing.Point(41, 76);
            this.SearchListView.Name = "SearchListView";
            this.SearchListView.Size = new System.Drawing.Size(719, 298);
            this.SearchListView.SmallImageList = imageList1;
            this.SearchListView.TabIndex = 3;
            this.SearchListView.UseCompatibleStateImageBehavior = false;
            this.SearchListView.SelectedIndexChanged += new System.EventHandler(this.SearchListView_SelectedIndexChanged);
            this.SearchListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SearchList_MouseDoubleClick);
            // 
            // Gobtn2
            // 
            this.Gobtn2.Location = new System.Drawing.Point(713, 21);
            this.Gobtn2.Name = "Gobtn2";
            this.Gobtn2.Size = new System.Drawing.Size(75, 23);
            this.Gobtn2.TabIndex = 3;
            this.Gobtn2.Text = "Go";
            this.Gobtn2.UseVisualStyleBackColor = true;
            this.Gobtn2.Click += new System.EventHandler(this.Gobtn2_Click);
            // 
            // checkedComboBox1
            // 
            this.checkedComboBox1.CheckOnClick = true;
            this.checkedComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.checkedComboBox1.DropDownHeight = 1;
            this.checkedComboBox1.FormattingEnabled = true;
            this.checkedComboBox1.IntegralHeight = false;
            this.checkedComboBox1.Location = new System.Drawing.Point(150, 25);
            this.checkedComboBox1.Name = "checkedComboBox1";
            this.checkedComboBox1.Size = new System.Drawing.Size(540, 23);
            this.checkedComboBox1.TabIndex = 4;
            this.checkedComboBox1.ValueSeparator = ", ";
            this.checkedComboBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedComboBox1_ItemCheck);
            this.checkedComboBox1.SelectedIndexChanged += new System.EventHandler(this.checkedComboBox1_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FileTaggingApp.Properties.Resources.image_1__3_;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkedComboBox1);
            this.Controls.Add(this.Gobtn2);
            this.Controls.Add(this.SearchListView);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Search Tags";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView SearchListView;
        private System.Windows.Forms.Button Gobtn2;
        private CheckComboBoxTest.CheckedComboBox checkedComboBox1;
    }
}