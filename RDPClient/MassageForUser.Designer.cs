namespace RDPClient
{
    partial class MassageForUser
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
            this.ОК = new System.Windows.Forms.Button();
            this.Cencel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вы еще тут?";
            // 
            // ОК
            // 
            this.ОК.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ОК.Location = new System.Drawing.Point(89, 62);
            this.ОК.Name = "ОК";
            this.ОК.Size = new System.Drawing.Size(75, 23);
            this.ОК.TabIndex = 1;
            this.ОК.Text = "OK";
            this.ОК.UseVisualStyleBackColor = true;
            // 
            // Cencel
            // 
            this.Cencel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cencel.Location = new System.Drawing.Point(177, 62);
            this.Cencel.Name = "Cencel";
            this.Cencel.Size = new System.Drawing.Size(69, 23);
            this.Cencel.TabIndex = 2;
            this.Cencel.Text = "Cancel";
            this.Cencel.UseVisualStyleBackColor = true;
            // 
            // MassageForUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 97);
            this.Controls.Add(this.Cencel);
            this.Controls.Add(this.ОК);
            this.Controls.Add(this.label1);
            this.Name = "MassageForUser";
            this.Text = "Внимание!";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ОК;
        private System.Windows.Forms.Button Cencel;
    }
}