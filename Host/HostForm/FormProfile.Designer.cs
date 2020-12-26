
namespace HostForm
{
    partial class FormProfile
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
            this.lblname = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblStage = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(102, 58);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(99, 20);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "Doctor name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(257, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 27);
            this.textBox1.TabIndex = 1;
            // 
            // lblStage
            // 
            this.lblStage.AutoSize = true;
            this.lblStage.Location = new System.Drawing.Point(102, 133);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(98, 20);
            this.lblStage.TabIndex = 2;
            this.lblStage.Text = "Doctor stage:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(257, 136);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(145, 27);
            this.textBox2.TabIndex = 3;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(102, 209);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(89, 20);
            this.lblDepartment.TabIndex = 4;
            this.lblDepartment.Text = "Department";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(257, 206);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(145, 27);
            this.textBox3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(497, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 230);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // FormProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblStage);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblname);
            this.Name = "FormProfile";
            this.Text = "FormProfile";
            this.Load += new System.EventHandler(this.Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblStage;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}