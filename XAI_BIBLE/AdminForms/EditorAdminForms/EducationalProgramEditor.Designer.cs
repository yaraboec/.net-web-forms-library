
namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    partial class EducationalProgramEditor
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
            this.textBoxInputEducationalProgram = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "inputEducationProgram here";
            // 
            // textBoxInputEducationalProgram
            // 
            this.textBoxInputEducationalProgram.Location = new System.Drawing.Point(36, 96);
            this.textBoxInputEducationalProgram.Name = "textBoxInputEducationalProgram";
            this.textBoxInputEducationalProgram.Size = new System.Drawing.Size(258, 20);
            this.textBoxInputEducationalProgram.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(384, 152);
            this.button1.TabIndex = 2;
            this.button1.Text = "dvigaetsya forma??)))";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EducationalProgramEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxInputEducationalProgram);
            this.Controls.Add(this.label1);
            this.Name = "EducationalProgramEditor";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInputEducationalProgram;
        private System.Windows.Forms.Button button1;
    }
}