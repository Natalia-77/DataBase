
namespace FilterShop
{
    partial class Form1
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
            this.clb1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblTitle_first = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clb1
            // 
            this.clb1.CheckOnClick = true;
            this.clb1.FormattingEnabled = true;
            this.clb1.Location = new System.Drawing.Point(12, 122);
            this.clb1.Name = "clb1";
            this.clb1.Size = new System.Drawing.Size(201, 224);
            this.clb1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Отримати значення";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(13, 442);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(201, 104);
            this.listBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 28);
            this.comboBox1.TabIndex = 3;
            // 
            // lblTitle_first
            // 
            this.lblTitle_first.AutoSize = true;
            this.lblTitle_first.Location = new System.Drawing.Point(13, 4);
            this.lblTitle_first.Name = "lblTitle_first";
            this.lblTitle_first.Size = new System.Drawing.Size(50, 20);
            this.lblTitle_first.TabIndex = 4;
            this.lblTitle_first.Text = "label1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Обрати";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 637);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblTitle_first);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clb1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblTitle_first;
        private System.Windows.Forms.Button button2;
    }
}

