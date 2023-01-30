namespace FileTaggingApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Backbtn = new System.Windows.Forms.Button();
            this.gobtn = new System.Windows.Forms.Button();
            this.filepathtextbox = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCustomTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deletebtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filenamelabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.filesizelabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Backbtn
            // 
            this.Backbtn.Location = new System.Drawing.Point(293, 21);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(42, 30);
            this.Backbtn.TabIndex = 0;
            this.Backbtn.Text = "<";
            this.Backbtn.UseVisualStyleBackColor = true;
            this.Backbtn.Click += new System.EventHandler(this.Backbtn_Click);
            // 
            // gobtn
            // 
            this.gobtn.Location = new System.Drawing.Point(1158, 21);
            this.gobtn.Name = "gobtn";
            this.gobtn.Size = new System.Drawing.Size(80, 30);
            this.gobtn.TabIndex = 1;
            this.gobtn.Text = "Go";
            this.gobtn.UseVisualStyleBackColor = true;
            this.gobtn.Click += new System.EventHandler(this.gobtn_Click);
            // 
            // filepathtextbox
            // 
            this.filepathtextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filepathtextbox.Location = new System.Drawing.Point(341, 21);
            this.filepathtextbox.Name = "filepathtextbox";
            this.filepathtextbox.Size = new System.Drawing.Size(728, 34);
            this.filepathtextbox.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(226, 64);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1033, 515);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTagToolStripMenuItem,
            this.removeAllTagsToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 172);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // addTagToolStripMenuItem
            // 
            this.addTagToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createCustomTagsToolStripMenuItem,
            this.showAllTagsToolStripMenuItem});
            this.addTagToolStripMenuItem.Name = "addTagToolStripMenuItem";
            this.addTagToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.addTagToolStripMenuItem.Text = "Add Tag";
            // 
            // createCustomTagsToolStripMenuItem
            // 
            this.createCustomTagsToolStripMenuItem.Name = "createCustomTagsToolStripMenuItem";
            this.createCustomTagsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createCustomTagsToolStripMenuItem.Text = "Create Custom Tags";
            this.createCustomTagsToolStripMenuItem.Click += new System.EventHandler(this.createCustomTagsToolStripMenuItem_Click);
            // 
            // showAllTagsToolStripMenuItem
            // 
            this.showAllTagsToolStripMenuItem.Name = "showAllTagsToolStripMenuItem";
            this.showAllTagsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.showAllTagsToolStripMenuItem.Text = "Show All Tags";
            this.showAllTagsToolStripMenuItem.Click += new System.EventHandler(this.showAllTagsToolStripMenuItem_Click);
            // 
            // removeAllTagsToolStripMenuItem
            // 
            this.removeAllTagsToolStripMenuItem.Name = "removeAllTagsToolStripMenuItem";
            this.removeAllTagsToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.removeAllTagsToolStripMenuItem.Text = "Remove All tags";
            this.removeAllTagsToolStripMenuItem.Click += new System.EventHandler(this.removeAllTagsToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Enabled = false;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "box.png");
            this.imageList1.Images.SetKeyName(1, "doc.png");
            this.imageList1.Images.SetKeyName(2, "exe.png");
            this.imageList1.Images.SetKeyName(3, "folder.png");
            this.imageList1.Images.SetKeyName(4, "image.png");
            this.imageList1.Images.SetKeyName(5, "mp3.png");
            this.imageList1.Images.SetKeyName(6, "mp4.png");
            this.imageList1.Images.SetKeyName(7, "pdf.png");
            this.imageList1.Images.SetKeyName(8, "unknown-mail.png");
            this.imageList1.Images.SetKeyName(9, "hard-drive.png");
            this.imageList1.Images.SetKeyName(10, "cutting.png");
            this.imageList1.Images.SetKeyName(11, "copy.png");
            this.imageList1.Images.SetKeyName(12, "zip-file.png");
            this.imageList1.Images.SetKeyName(13, "setting.png");
            this.imageList1.Images.SetKeyName(14, "web-browser.png");
            this.imageList1.Images.SetKeyName(15, "google-docs.png");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 597);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Search File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 30);
            this.button2.TabIndex = 9;
            this.button2.Text = "Home";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(10, 64);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(205, 504);
            this.listBox1.TabIndex = 10;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "All Tags: ";
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(10, 597);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(100, 30);
            this.deletebtn.TabIndex = 13;
            this.deletebtn.Text = "Delete Tag";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1075, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 30);
            this.button3.TabIndex = 14;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(226, 585);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(563, 104);
            this.listBox2.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(795, 641);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "File Name";
            // 
            // filenamelabel
            // 
            this.filenamelabel.AutoSize = true;
            this.filenamelabel.BackColor = System.Drawing.Color.Transparent;
            this.filenamelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.filenamelabel.Location = new System.Drawing.Point(894, 641);
            this.filenamelabel.MaximumSize = new System.Drawing.Size(124, 16);
            this.filenamelabel.Name = "filenamelabel";
            this.filenamelabel.Size = new System.Drawing.Size(13, 16);
            this.filenamelabel.TabIndex = 18;
            this.filenamelabel.Text = "  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(795, 673);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "File Size";
            // 
            // filesizelabel
            // 
            this.filesizelabel.AutoSize = true;
            this.filesizelabel.BackColor = System.Drawing.Color.Transparent;
            this.filesizelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.filesizelabel.Location = new System.Drawing.Point(894, 673);
            this.filesizelabel.MaximumSize = new System.Drawing.Size(124, 16);
            this.filesizelabel.Name = "filesizelabel";
            this.filesizelabel.Size = new System.Drawing.Size(13, 16);
            this.filesizelabel.TabIndex = 20;
            this.filesizelabel.Text = "  ";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(679, 718);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 34);
            this.button4.TabIndex = 21;
            this.button4.Text = "Remove Tag";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FileTaggingApp.Properties.Resources.hyhkj;
            this.pictureBox1.Location = new System.Drawing.Point(15, 652);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::FileTaggingApp.Properties.Resources.image_1__3_;
            this.ClientSize = new System.Drawing.Size(1281, 764);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.filesizelabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.filenamelabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.filepathtextbox);
            this.Controls.Add(this.gobtn);
            this.Controls.Add(this.Backbtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tagging Prime";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Backbtn;
        private System.Windows.Forms.Button gobtn;
        private System.Windows.Forms.TextBox filepathtextbox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCustomTagsToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label filenamelabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label filesizelabel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem showAllTagsToolStripMenuItem;
    }
}

