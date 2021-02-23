
namespace TreeViewForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbChildurl = new System.Windows.Forms.TextBox();
            this.lbchildUrl = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tbChild = new System.Windows.Forms.TextBox();
            this.lbChild = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.lbUrl = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.Label();
            this.tbParent = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tvCategory = new System.Windows.Forms.TreeView();
            this.lbEdit = new System.Windows.Forms.Label();
            this.tbEdit = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.tbEdit);
            this.groupBox1.Controls.Add(this.lbEdit);
            this.groupBox1.Controls.Add(this.tbChildurl);
            this.groupBox1.Controls.Add(this.lbchildUrl);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tbChild);
            this.groupBox1.Controls.Add(this.lbChild);
            this.groupBox1.Controls.Add(this.tbUrl);
            this.groupBox1.Controls.Add(this.lbUrl);
            this.groupBox1.Controls.Add(this.lbCategory);
            this.groupBox1.Controls.Add(this.tbParent);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tvCategory);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 602);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Категорії товарів";
            // 
            // tbChildurl
            // 
            this.tbChildurl.Location = new System.Drawing.Point(527, 312);
            this.tbChildurl.Name = "tbChildurl";
            this.tbChildurl.Size = new System.Drawing.Size(173, 27);
            this.tbChildurl.TabIndex = 10;
            // 
            // lbchildUrl
            // 
            this.lbchildUrl.AutoSize = true;
            this.lbchildUrl.Location = new System.Drawing.Point(286, 306);
            this.lbchildUrl.Name = "lbchildUrl";
            this.lbchildUrl.Size = new System.Drawing.Size(163, 20);
            this.lbchildUrl.TabIndex = 9;
            this.lbchildUrl.Text = "Назва ідентифікатора:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MistyRose;
            this.button2.Location = new System.Drawing.Point(527, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 55);
            this.button2.TabIndex = 8;
            this.button2.Text = "Додати дочірній елемент";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbChild
            // 
            this.tbChild.Location = new System.Drawing.Point(527, 268);
            this.tbChild.Name = "tbChild";
            this.tbChild.Size = new System.Drawing.Size(173, 27);
            this.tbChild.TabIndex = 7;
            // 
            // lbChild
            // 
            this.lbChild.AutoSize = true;
            this.lbChild.Location = new System.Drawing.Point(286, 268);
            this.lbChild.Name = "lbChild";
            this.lbChild.Size = new System.Drawing.Size(207, 20);
            this.lbChild.TabIndex = 6;
            this.lbChild.Text = "Назва дочірнього елемента:";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(522, 120);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(178, 27);
            this.tbUrl.TabIndex = 5;
            // 
            // lbUrl
            // 
            this.lbUrl.AutoSize = true;
            this.lbUrl.Location = new System.Drawing.Point(286, 133);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(163, 20);
            this.lbUrl.TabIndex = 4;
            this.lbUrl.Text = "Назва ідентифікатора:";
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(286, 90);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(119, 20);
            this.lbCategory.TabIndex = 3;
            this.lbCategory.Text = "Назва категорії:";
            // 
            // tbParent
            // 
            this.tbParent.Location = new System.Drawing.Point(522, 87);
            this.tbParent.Name = "tbParent";
            this.tbParent.Size = new System.Drawing.Size(178, 27);
            this.tbParent.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.Location = new System.Drawing.Point(522, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 59);
            this.button1.TabIndex = 1;
            this.button1.Text = "Додати основну категорію";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tvCategory
            // 
            this.tvCategory.Location = new System.Drawing.Point(6, 65);
            this.tvCategory.Name = "tvCategory";
            this.tvCategory.Size = new System.Drawing.Size(274, 372);
            this.tvCategory.TabIndex = 0;
            this.tvCategory.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvCategory_BeforeExpand);
            // 
            // lbEdit
            // 
            this.lbEdit.AutoSize = true;
            this.lbEdit.Location = new System.Drawing.Point(287, 447);
            this.lbEdit.Name = "lbEdit";
            this.lbEdit.Size = new System.Drawing.Size(118, 20);
            this.lbEdit.TabIndex = 11;
            this.lbEdit.Text = "Нове значення:";
            // 
            // tbEdit
            // 
            this.tbEdit.Location = new System.Drawing.Point(527, 444);
            this.tbEdit.Name = "tbEdit";
            this.tbEdit.Size = new System.Drawing.Size(173, 27);
            this.tbEdit.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MistyRose;
            this.button3.Location = new System.Drawing.Point(527, 487);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 49);
            this.button3.TabIndex = 13;
            this.button3.Text = "Змінити";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 620);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Вітаю:)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tvCategory;
        private System.Windows.Forms.TextBox tbParent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.Label lbChild;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbChild;
        private System.Windows.Forms.TextBox tbChildurl;
        private System.Windows.Forms.Label lbchildUrl;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbEdit;
        private System.Windows.Forms.Label lbEdit;
    }
}

