
namespace HostForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHello = new System.Windows.Forms.Label();
            this.butSeeall = new System.Windows.Forms.Button();
            this.butProfile = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHello.Font = new System.Drawing.Font("Arial", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblHello.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHello.Location = new System.Drawing.Point(65, 77);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(574, 31);
            this.lblHello.TabIndex = 0;
            this.lblHello.Text = "Вітаємо вас! Ви успішно авторизувались!";
            // 
            // butSeeall
            // 
            this.butSeeall.BackColor = System.Drawing.Color.Gainsboro;
            this.butSeeall.Cursor = System.Windows.Forms.Cursors.No;
            this.butSeeall.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butSeeall.ForeColor = System.Drawing.Color.Indigo;
            this.butSeeall.Location = new System.Drawing.Point(54, 233);
            this.butSeeall.Name = "butSeeall";
            this.butSeeall.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.butSeeall.Size = new System.Drawing.Size(177, 68);
            this.butSeeall.TabIndex = 1;
            this.butSeeall.Text = "Список всіх лікарів";
            this.butSeeall.UseVisualStyleBackColor = false;
            this.butSeeall.Click += new System.EventHandler(this.butSeeall_Click);
            // 
            // butProfile
            // 
            this.butProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butProfile.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butProfile.ForeColor = System.Drawing.Color.Indigo;
            this.butProfile.Location = new System.Drawing.Point(312, 233);
            this.butProfile.Name = "butProfile";
            this.butProfile.Size = new System.Drawing.Size(176, 68);
            this.butProfile.TabIndex = 2;
            this.butProfile.Text = "Ваш профіль";
            this.butProfile.UseVisualStyleBackColor = false;
            this.butProfile.Click += new System.EventHandler(this.butProfile_Click);
            // 
            // butAdd
            // 
            this.butAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butAdd.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butAdd.ForeColor = System.Drawing.Color.Indigo;
            this.butAdd.Location = new System.Drawing.Point(566, 233);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(153, 68);
            this.butAdd.TabIndex = 3;
            this.butAdd.Text = "Додати новий запис";
            this.butAdd.UseVisualStyleBackColor = false;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(751, 383);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.butProfile);
            this.Controls.Add(this.butSeeall);
            this.Controls.Add(this.lblHello);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.Button butSeeall;
        private System.Windows.Forms.Button butProfile;
        private System.Windows.Forms.Button butAdd;

        #endregion
        //private System.Windows.Forms.Button butBack;
    }
}

