
namespace SiemensToIgnitionTagConverter
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
            this.labelTIATagList = new System.Windows.Forms.Label();
            this.textBoxTIATagList = new System.Windows.Forms.TextBox();
            this.buttonTIATagList = new System.Windows.Forms.Button();
            this.labelIgnitionFolderName = new System.Windows.Forms.Label();
            this.labelIgnitionOPCConnectionName = new System.Windows.Forms.Label();
            this.buttonSaveIgnitionTagList = new System.Windows.Forms.Button();
            this.textBoxIgnitionFolderName = new System.Windows.Forms.TextBox();
            this.textBoxIgnitionOPCConnectionName = new System.Windows.Forms.TextBox();
            this.openFileDialogTIATagList = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSaveIgnitionTagList = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxDB = new System.Windows.Forms.CheckBox();
            this.labelDBNumber = new System.Windows.Forms.Label();
            this.textBoxDBNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelTIATagList
            // 
            this.labelTIATagList.AutoSize = true;
            this.labelTIATagList.Location = new System.Drawing.Point(13, 13);
            this.labelTIATagList.Name = "labelTIATagList";
            this.labelTIATagList.Size = new System.Drawing.Size(84, 17);
            this.labelTIATagList.TabIndex = 0;
            this.labelTIATagList.Text = "TIA Tag List";
            // 
            // textBoxTIATagList
            // 
            this.textBoxTIATagList.Location = new System.Drawing.Point(224, 10);
            this.textBoxTIATagList.Name = "textBoxTIATagList";
            this.textBoxTIATagList.Size = new System.Drawing.Size(411, 22);
            this.textBoxTIATagList.TabIndex = 1;
            // 
            // buttonTIATagList
            // 
            this.buttonTIATagList.Location = new System.Drawing.Point(642, 7);
            this.buttonTIATagList.Name = "buttonTIATagList";
            this.buttonTIATagList.Size = new System.Drawing.Size(146, 29);
            this.buttonTIATagList.TabIndex = 2;
            this.buttonTIATagList.Text = "Load Tag List";
            this.buttonTIATagList.UseVisualStyleBackColor = true;
            this.buttonTIATagList.Click += new System.EventHandler(this.buttonTIATagList_Click);
            // 
            // labelIgnitionFolderName
            // 
            this.labelIgnitionFolderName.AutoSize = true;
            this.labelIgnitionFolderName.Location = new System.Drawing.Point(13, 83);
            this.labelIgnitionFolderName.Name = "labelIgnitionFolderName";
            this.labelIgnitionFolderName.Size = new System.Drawing.Size(138, 17);
            this.labelIgnitionFolderName.TabIndex = 3;
            this.labelIgnitionFolderName.Text = "Ignition Folder Name";
            // 
            // labelIgnitionOPCConnectionName
            // 
            this.labelIgnitionOPCConnectionName.AutoSize = true;
            this.labelIgnitionOPCConnectionName.Location = new System.Drawing.Point(13, 111);
            this.labelIgnitionOPCConnectionName.Name = "labelIgnitionOPCConnectionName";
            this.labelIgnitionOPCConnectionName.Size = new System.Drawing.Size(202, 17);
            this.labelIgnitionOPCConnectionName.TabIndex = 4;
            this.labelIgnitionOPCConnectionName.Text = "Ignition OPC Connection Name";
            // 
            // buttonSaveIgnitionTagList
            // 
            this.buttonSaveIgnitionTagList.Location = new System.Drawing.Point(13, 160);
            this.buttonSaveIgnitionTagList.Name = "buttonSaveIgnitionTagList";
            this.buttonSaveIgnitionTagList.Size = new System.Drawing.Size(185, 32);
            this.buttonSaveIgnitionTagList.TabIndex = 7;
            this.buttonSaveIgnitionTagList.Text = "Save Ignition Tag List";
            this.buttonSaveIgnitionTagList.UseVisualStyleBackColor = true;
            this.buttonSaveIgnitionTagList.Click += new System.EventHandler(this.buttonSaveIgnitionTagList_Click);
            // 
            // textBoxIgnitionFolderName
            // 
            this.textBoxIgnitionFolderName.Location = new System.Drawing.Point(224, 80);
            this.textBoxIgnitionFolderName.Name = "textBoxIgnitionFolderName";
            this.textBoxIgnitionFolderName.Size = new System.Drawing.Size(411, 22);
            this.textBoxIgnitionFolderName.TabIndex = 5;
            // 
            // textBoxIgnitionOPCConnectionName
            // 
            this.textBoxIgnitionOPCConnectionName.Location = new System.Drawing.Point(224, 108);
            this.textBoxIgnitionOPCConnectionName.Name = "textBoxIgnitionOPCConnectionName";
            this.textBoxIgnitionOPCConnectionName.Size = new System.Drawing.Size(411, 22);
            this.textBoxIgnitionOPCConnectionName.TabIndex = 6;
            // 
            // openFileDialogTIATagList
            // 
            this.openFileDialogTIATagList.FileName = "openFileDialog1";
            this.openFileDialogTIATagList.Filter = "CSV file|*.csv";
            this.openFileDialogTIATagList.Title = "Open TIA Tag List";
            // 
            // saveFileDialogSaveIgnitionTagList
            // 
            this.saveFileDialogSaveIgnitionTagList.DefaultExt = "json";
            this.saveFileDialogSaveIgnitionTagList.FileName = "IgnitionTagList.json";
            this.saveFileDialogSaveIgnitionTagList.Filter = "JSON File | *.json";
            this.saveFileDialogSaveIgnitionTagList.Title = "Save Ignition Tag List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Please report any tag conversions that did not work correctly to osm@usn.no";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(521, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "include the Siemens tag list, and explain what went wrong and what you expected.";
            // 
            // checkBoxDB
            // 
            this.checkBoxDB.AutoSize = true;
            this.checkBoxDB.Location = new System.Drawing.Point(16, 41);
            this.checkBoxDB.Name = "checkBoxDB";
            this.checkBoxDB.Size = new System.Drawing.Size(94, 21);
            this.checkBoxDB.TabIndex = 3;
            this.checkBoxDB.Text = "DB tag list";
            this.checkBoxDB.UseVisualStyleBackColor = true;
            this.checkBoxDB.CheckedChanged += new System.EventHandler(this.checkBoxDB_CheckedChanged);
            // 
            // labelDBNumber
            // 
            this.labelDBNumber.AutoSize = true;
            this.labelDBNumber.Location = new System.Drawing.Point(136, 42);
            this.labelDBNumber.Name = "labelDBNumber";
            this.labelDBNumber.Size = new System.Drawing.Size(79, 17);
            this.labelDBNumber.TabIndex = 11;
            this.labelDBNumber.Text = "DB number";
            this.labelDBNumber.Visible = false;
            // 
            // textBoxDBNumber
            // 
            this.textBoxDBNumber.Location = new System.Drawing.Point(224, 39);
            this.textBoxDBNumber.Name = "textBoxDBNumber";
            this.textBoxDBNumber.Size = new System.Drawing.Size(411, 22);
            this.textBoxDBNumber.TabIndex = 4;
            this.textBoxDBNumber.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 206);
            this.Controls.Add(this.textBoxDBNumber);
            this.Controls.Add(this.labelDBNumber);
            this.Controls.Add(this.checkBoxDB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIgnitionOPCConnectionName);
            this.Controls.Add(this.textBoxIgnitionFolderName);
            this.Controls.Add(this.buttonSaveIgnitionTagList);
            this.Controls.Add(this.labelIgnitionOPCConnectionName);
            this.Controls.Add(this.labelIgnitionFolderName);
            this.Controls.Add(this.buttonTIATagList);
            this.Controls.Add(this.textBoxTIATagList);
            this.Controls.Add(this.labelTIATagList);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Siemens to Ignition Tags";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTIATagList;
        private System.Windows.Forms.TextBox textBoxTIATagList;
        private System.Windows.Forms.Button buttonTIATagList;
        private System.Windows.Forms.Label labelIgnitionFolderName;
        private System.Windows.Forms.Label labelIgnitionOPCConnectionName;
        private System.Windows.Forms.Button buttonSaveIgnitionTagList;
        private System.Windows.Forms.TextBox textBoxIgnitionFolderName;
        private System.Windows.Forms.TextBox textBoxIgnitionOPCConnectionName;
        private System.Windows.Forms.OpenFileDialog openFileDialogTIATagList;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSaveIgnitionTagList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxDB;
        private System.Windows.Forms.Label labelDBNumber;
        private System.Windows.Forms.TextBox textBoxDBNumber;
    }
}

