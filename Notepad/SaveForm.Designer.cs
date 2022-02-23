
namespace Notepad
{
    partial class SaveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveForm));
            this.saveButton = new System.Windows.Forms.Button();
            this.notSaveButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.canselButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = Form1.secondColor;
            this.saveButton.FlatAppearance.BorderColor = Form1.mainColor;
            this.saveButton.FlatAppearance.BorderSize = 3;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(8, 143);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(130, 33);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.Save);
            // 
            // notSaveButton
            // 
            this.notSaveButton.FlatAppearance.BorderColor = Form1.mainColor;
            this.notSaveButton.FlatAppearance.BorderSize = 3;
            this.notSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notSaveButton.Location = new System.Drawing.Point(144, 143);
            this.notSaveButton.Name = "notSaveButton";
            this.notSaveButton.Size = new System.Drawing.Size(130, 33);
            this.notSaveButton.TabIndex = 1;
            this.notSaveButton.Text = "Не сохранять";
            this.notSaveButton.UseVisualStyleBackColor = true;
            this.notSaveButton.Click += new System.EventHandler(this.NotSave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = Form1.secondColor;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = Form1.mainColor;
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(358, 101);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // canselButton
            // 
            this.canselButton.FlatAppearance.BorderColor = Form1.mainColor;
            this.canselButton.FlatAppearance.BorderSize = 3;
            this.canselButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canselButton.Location = new System.Drawing.Point(280, 143);
            this.canselButton.Name = "canselButton";
            this.canselButton.Size = new System.Drawing.Size(90, 33);
            this.canselButton.TabIndex = 3;
            this.canselButton.Text = "Отмена";
            this.canselButton.UseVisualStyleBackColor = true;
            this.canselButton.Click += new System.EventHandler(this.Cansel);
            // 
            // SaveForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = Form1.secondColor;
            this.ClientSize = new System.Drawing.Size(382, 217);
            this.Controls.Add(this.canselButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.notSaveButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 264);
            this.MinimumSize = new System.Drawing.Size(400, 264);
            this.Name = "SaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сохранить?";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button notSaveButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button canselButton;
    }
}