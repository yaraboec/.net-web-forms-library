
namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    partial class BookTypeEditor
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
            this.textBoxInputBookType = new System.Windows.Forms.TextBox();
            this.buttonEditBookType = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxInputBookType
            // 
            this.textBoxInputBookType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.textBoxInputBookType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxInputBookType.Location = new System.Drawing.Point(40, 66);
            this.textBoxInputBookType.Name = "textBoxInputBookType";
            this.textBoxInputBookType.Size = new System.Drawing.Size(256, 29);
            this.textBoxInputBookType.TabIndex = 56;
            // 
            // buttonEditBookType
            // 
            this.buttonEditBookType.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonEditBookType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditBookType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEditBookType.Location = new System.Drawing.Point(40, 116);
            this.buttonEditBookType.Name = "buttonEditBookType";
            this.buttonEditBookType.Size = new System.Drawing.Size(256, 41);
            this.buttonEditBookType.TabIndex = 59;
            this.buttonEditBookType.Text = "Підтвердити";
            this.buttonEditBookType.UseVisualStyleBackColor = false;
            this.buttonEditBookType.MouseEnter += new System.EventHandler(this.buttonEditBookType_MouseEnter);
            this.buttonEditBookType.MouseLeave += new System.EventHandler(this.buttonEditBookType_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(36, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 21);
            this.label1.TabIndex = 60;
            this.label1.Text = "Тип рукопису:";
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(330, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BookTypeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 183);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEditBookType);
            this.Controls.Add(this.textBoxInputBookType);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookTypeEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookTypeEditor";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BookTypeEditor_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BookTypeEditor_MouseMove);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxInputBookType;
        private System.Windows.Forms.Button buttonEditBookType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}