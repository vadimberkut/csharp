namespace BriansExcuseManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExcuse = new System.Windows.Forms.TextBox();
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.dateTimePickerLastUsed = new System.Windows.Forms.DateTimePicker();
            this.buttonFolder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerFileDate = new System.Windows.Forms.DateTimePicker();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.buttonFolderDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excuse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Results";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Used";
            // 
            // textBoxExcuse
            // 
            this.textBoxExcuse.Location = new System.Drawing.Point(82, 29);
            this.textBoxExcuse.Name = "textBoxExcuse";
            this.textBoxExcuse.Size = new System.Drawing.Size(296, 20);
            this.textBoxExcuse.TabIndex = 3;
            this.textBoxExcuse.TextChanged += new System.EventHandler(this.textBoxExcuse_TextChanged);
            // 
            // textBoxResults
            // 
            this.textBoxResults.Location = new System.Drawing.Point(82, 53);
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.Size = new System.Drawing.Size(296, 20);
            this.textBoxResults.TabIndex = 4;
            this.textBoxResults.TextChanged += new System.EventHandler(this.textBoxResults_TextChanged);
            // 
            // dateTimePickerLastUsed
            // 
            this.dateTimePickerLastUsed.Location = new System.Drawing.Point(82, 79);
            this.dateTimePickerLastUsed.Name = "dateTimePickerLastUsed";
            this.dateTimePickerLastUsed.Size = new System.Drawing.Size(296, 20);
            this.dateTimePickerLastUsed.TabIndex = 5;
            this.dateTimePickerLastUsed.ValueChanged += new System.EventHandler(this.dateTimePickerLastUsed_ValueChanged);
            // 
            // buttonFolder
            // 
            this.buttonFolder.Location = new System.Drawing.Point(60, 142);
            this.buttonFolder.Name = "buttonFolder";
            this.buttonFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonFolder.TabIndex = 6;
            this.buttonFolder.Text = "Folder";
            this.buttonFolder.UseVisualStyleBackColor = true;
            this.buttonFolder.Click += new System.EventHandler(this.buttonFolder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "File Date";
            // 
            // dateTimePickerFileDate
            // 
            this.dateTimePickerFileDate.Enabled = false;
            this.dateTimePickerFileDate.Location = new System.Drawing.Point(82, 105);
            this.dateTimePickerFileDate.Name = "dateTimePickerFileDate";
            this.dateTimePickerFileDate.Size = new System.Drawing.Size(296, 20);
            this.dateTimePickerFileDate.TabIndex = 8;
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(141, 142);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Enabled = false;
            this.buttonOpen.Location = new System.Drawing.Point(222, 142);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 10;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Enabled = false;
            this.buttonRandom.Location = new System.Drawing.Point(303, 142);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(75, 23);
            this.buttonRandom.TabIndex = 11;
            this.buttonRandom.Text = "Random";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // buttonFolderDefault
            // 
            this.buttonFolderDefault.Location = new System.Drawing.Point(60, 171);
            this.buttonFolderDefault.Name = "buttonFolderDefault";
            this.buttonFolderDefault.Size = new System.Drawing.Size(108, 23);
            this.buttonFolderDefault.TabIndex = 12;
            this.buttonFolderDefault.Text = "Folder Default";
            this.buttonFolderDefault.UseVisualStyleBackColor = true;
            this.buttonFolderDefault.Click += new System.EventHandler(this.buttonFolderDefault_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 200);
            this.Controls.Add(this.buttonFolderDefault);
            this.Controls.Add(this.buttonRandom);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dateTimePickerFileDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonFolder);
            this.Controls.Add(this.dateTimePickerLastUsed);
            this.Controls.Add(this.textBoxResults);
            this.Controls.Add(this.textBoxExcuse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Excuse Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxExcuse;
        private System.Windows.Forms.TextBox textBoxResults;
        private System.Windows.Forms.DateTimePicker dateTimePickerLastUsed;
        private System.Windows.Forms.Button buttonFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerFileDate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Button buttonFolderDefault;
    }
}

