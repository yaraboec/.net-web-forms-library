
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInputNameAuthor = new System.Windows.Forms.TextBox();
            this.textBoxtInputSurname = new System.Windows.Forms.TextBox();
            this.textBoxInputMiddleName = new System.Windows.Forms.TextBox();
            this.buttonEditBookAuthor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(330, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::XAI_BIBLE.Properties.Resources.edit_removebg_preview;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(77, 22);
            this.toolStripButton1.Text = "Зберегти";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Image = global::XAI_BIBLE.Properties.Resources.red_x;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton3.Text = "Вийти";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(36, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 21);
            this.label1.TabIndex = 54;
            this.label1.Text = "Ім\'я:";
            // 
            // textBoxInputNameAuthor
            // 
            this.textBoxInputNameAuthor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.textBoxInputNameAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxInputNameAuthor.Location = new System.Drawing.Point(40, 66);
            this.textBoxInputNameAuthor.Name = "textBoxInputNameAuthor";
            this.textBoxInputNameAuthor.Size = new System.Drawing.Size(256, 29);
            this.textBoxInputNameAuthor.TabIndex = 55;
            // 
            // textBoxtInputSurname
            // 
            this.textBoxtInputSurname.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.textBoxtInputSurname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxtInputSurname.Location = new System.Drawing.Point(40, 124);
            this.textBoxtInputSurname.Name = "textBoxtInputSurname";
            this.textBoxtInputSurname.Size = new System.Drawing.Size(256, 29);
            this.textBoxtInputSurname.TabIndex = 56;
            // 
            // textBoxInputMiddleName
            // 
            this.textBoxInputMiddleName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.textBoxInputMiddleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxInputMiddleName.Location = new System.Drawing.Point(40, 182);
            this.textBoxInputMiddleName.Name = "textBoxInputMiddleName";
            this.textBoxInputMiddleName.Size = new System.Drawing.Size(256, 29);
            this.textBoxInputMiddleName.TabIndex = 57;
            // 
            // buttonEditBookAuthor
            // 
            this.buttonEditBookAuthor.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonEditBookAuthor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditBookAuthor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEditBookAuthor.Location = new System.Drawing.Point(40, 230);
            this.buttonEditBookAuthor.Name = "buttonEditBookAuthor";
            this.buttonEditBookAuthor.Size = new System.Drawing.Size(256, 41);
            this.buttonEditBookAuthor.TabIndex = 58;
            this.buttonEditBookAuthor.Text = "Підтвердити";
            this.buttonEditBookAuthor.UseVisualStyleBackColor = false;
            this.buttonEditBookAuthor.Click += new System.EventHandler(this.buttonEditBookAuthor_Click_1);
            this.buttonEditBookAuthor.MouseEnter += new System.EventHandler(this.buttonEditBookAuthor_MouseEnter);
            this.buttonEditBookAuthor.MouseLeave += new System.EventHandler(this.buttonEditBookAuthor_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(36, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 59;
            this.label2.Text = "Прізвище:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(36, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 21);
            this.label3.TabIndex = 60;
            this.label3.Text = "По батькові:";
            // 
            // BookAuthorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 298);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonEditBookAuthor);
            this.Controls.Add(this.textBoxInputMiddleName);
            this.Controls.Add(this.textBoxtInputSurname);
            this.Controls.Add(this.textBoxInputNameAuthor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookAuthorEditor";
            this.Text = "BookAuthorEditor";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BookAuthorEditor_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BookAuthorEditor_MouseMove);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInputNameAuthor;
        private System.Windows.Forms.TextBox textBoxtInputSurname;
        private System.Windows.Forms.TextBox textBoxInputMiddleName;
        private System.Windows.Forms.Button buttonEditBookAuthor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}