
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
            this.labelIgnitionFolderName.Location = new System.Drawing.Point(13, 62);
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
            this.buttonSaveIgnitionTagList.TabIndex = 5;
            this.buttonSaveIgnitionTagList.Text = "Save Ignition Tag List";
            this.buttonSaveIgnitionTagList.UseVisualStyleBackColor = true;
            this.buttonSaveIgnitionTagList.Click += new System.EventHandler(this.buttonSaveIgnitionTagList_Click);
            // 
            // textBoxIgnitionFolderName
            // 
            this.textBoxIgnitionFolderName.Location = new System.Drawing.Point(224, 59);
            this.textBoxIgnitionFolderName.Name = "textBoxIgnitionFolderName";
            this.textBoxIgnitionFolderName.Size = new System.Drawing.Size(411, 22);
            this.textBoxIgnitionFolderName.TabIndex = 6;
            // 
            // textBoxIgnitionOPCConnectionName
            // 
            this.textBoxIgnitionOPCConnectionName.Location = new System.Drawing.Point(224, 108);
            this.textBoxIgnitionOPCConnectionName.Name = "textBoxIgnitionOPCConnectionName";
            this.textBoxIgnitionOPCConnectionName.Size = new System.Drawing.Size(411, 22);
            this.textBoxIgnitionOPCConnectionName.TabIndex = 7;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxIgnitionOPCConnectionName);
            this.Controls.Add(this.textBoxIgnitionFolderName);
            this.Controls.Add(this.buttonSaveIgnitionTagList);
            this.Controls.Add(this.labelIgnitionOPCConnectionName);
            this.Controls.Add(this.labelIgnitionFolderName);
            this.Controls.Add(this.buttonTIATagList);
            this.Controls.Add(this.textBoxTIATagList);
            this.Controls.Add(this.labelTIATagList);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

