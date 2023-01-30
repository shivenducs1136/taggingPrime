namespace FileTaggingApp
{
    partial class CreateNewTag
    {
        private System.ComponentModel.IContainer components = null;

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
            this.AddTagTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Addbtn1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddTagTextBox
            // 
            this.AddTagTextBox.Location = new System.Drawing.Point(102, 88);
            this.AddTagTextBox.Name = "AddTagTextBox";
            this.AddTagTextBox.Size = new System.Drawing.Size(346, 22);
            this.AddTagTextBox.TabIndex = 0;
            this.AddTagTextBox.TextChanged += new System.EventHandler(this.AddTagTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter New TagName: ";
            // 
            // Addbtn1
            // 
            this.Addbtn1.Location = new System.Drawing.Point(230, 155);
            this.Addbtn1.Name = "Addbtn1";
            this.Addbtn1.Size = new System.Drawing.Size(75, 23);
            this.Addbtn1.TabIndex = 2;
            this.Addbtn1.Text = "Add";
            this.Addbtn1.UseVisualStyleBackColor = true;
            this.Addbtn1.Click += new System.EventHandler(this.Addbtn1_Click);
            // 
            // CreateNewTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 241);
            this.Controls.Add(this.Addbtn1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddTagTextBox);
            this.Name = "CreateNewTag";
            this.Text = "CreateNewTag";
            this.Load += new System.EventHandler(this.CreateNewTag_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddTagTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Addbtn1;
    }   
}