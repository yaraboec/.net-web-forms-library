
namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    partial class BookAuthorEditor
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
            this.textBoxInputNameAuthor = new System.Windows.Forms.TextBox();
            this.buttonEditBookAuthor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxtInputSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxInputMiddleName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "inputNameAuthor";
            // 
            // textBoxInputNameAuthor
            // 
            this.textBoxInputNameAuthor.Location = new System.Drawing.Point(40, 58);
            this.textBoxInputNameAuthor.Name = "textBoxInputNameAuthor";
            this.textBoxInputNameAuthor.Size = new System.Drawing.Size(239, 20);
            this.textBoxInputNameAuthor.TabIndex = 1;
            // 
            // buttonEditBookAuthor
            // 
            this.buttonEditBookAuthor.Location = new System.Drawing.Point(40, 187);
            this.buttonEditBookAuthor.Name = "buttonEditBookAuthor";
            this.buttonEditBookAuthor.Size = new System.Drawing.Size(227, 57);
            this.buttonEditBookAuthor.TabIndex = 2;
            this.buttonEditBookAuthor.Text = "подтвердить (на укр только)";
            this.buttonEditBookAuthor.UseVisualStyleBackColor = true;
            this.buttonEditBookAuthor.Click += new System.EventHandler(this.buttonEditBookAuthor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "inpurSurname";
            // 
            // textBoxtInputSurname
            // 
            this.textBoxtInputSurname.Location = new System.Drawing.Point(40, 101);
            this.textBoxtInputSurname.Name = "textBoxtInputSurname";
            this.textBoxtInputSurname.Size = new System.Drawing.Size(239, 20);
            this.textBoxtInputSurname.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "inputMiddleName";
            // 
            // textBoxInputMiddleName
            // 
            this.textBoxInputMiddleName.Location = new System.Drawing.Point(40, 145);
            this.textBoxInputMiddleName.Name = "textBoxInputMiddleName";
            this.textBoxInputMiddleName.Size = new System.Drawing.Size(239, 20);
            this.textBoxInputMiddleName.TabIndex = 6;
            // 
            // BookAuthorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 450);
            this.Controls.Add(this.textBoxInputMiddleName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxtInputSurname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonEditBookAuthor);
            this.Controls.Add(this.textBoxInputNameAuthor);
            this.Controls.Add(this.label1);
            this.Name = "BookAuthorEditor";
            this.Text = "BookAuthorEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInputNameAuthor;
        private System.Windows.Forms.Button buttonEditBookAuthor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxtInputSurname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxInputMiddleName;
    }
}