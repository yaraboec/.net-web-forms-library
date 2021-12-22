
namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    partial class BookNameEditor
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
            this.textBoxInputName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxSelectBookType = new System.Windows.Forms.ComboBox();
            this.comboBoxForGuid = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "inputNameBook";
            // 
            // textBoxInputName
            // 
            this.textBoxInputName.Location = new System.Drawing.Point(50, 63);
            this.textBoxInputName.Name = "textBoxInputName";
            this.textBoxInputName.Size = new System.Drawing.Size(121, 20);
            this.textBoxInputName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "selectTypeBook";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(397, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "подтвердить типа на укр!!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxSelectBookType
            // 
            this.comboBoxSelectBookType.FormattingEnabled = true;
            this.comboBoxSelectBookType.Location = new System.Drawing.Point(53, 138);
            this.comboBoxSelectBookType.Name = "comboBoxSelectBookType";
            this.comboBoxSelectBookType.Size = new System.Drawing.Size(153, 21);
            this.comboBoxSelectBookType.TabIndex = 5;
            this.comboBoxSelectBookType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectBookType_SelectedIndexChanged);
            // 
            // comboBoxForGuid
            // 
            this.comboBoxForGuid.FormattingEnabled = true;
            this.comboBoxForGuid.Location = new System.Drawing.Point(53, 255);
            this.comboBoxForGuid.Name = "comboBoxForGuid";
            this.comboBoxForGuid.Size = new System.Drawing.Size(237, 21);
            this.comboBoxForGuid.TabIndex = 6;
            // 
            // BookNameEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxForGuid);
            this.Controls.Add(this.comboBoxSelectBookType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxInputName);
            this.Controls.Add(this.label1);
            this.Name = "BookNameEditor";
            this.Text = "BookNameEditor";
            this.Load += new System.EventHandler(this.BookNameEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInputName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxSelectBookType;
        private System.Windows.Forms.ComboBox comboBoxForGuid;
    }
}