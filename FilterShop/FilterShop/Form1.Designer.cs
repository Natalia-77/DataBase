
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
            this.btnbrand = new System.Windows.Forms.Button();
            this.btntaste = new System.Windows.Forms.Button();
            this.btn_forma = new System.Windows.Forms.Button();
            this.btnexit_brand = new System.Windows.Forms.Button();
            this.panel_first = new System.Windows.Forms.Panel();
            this.btnexit_taste = new System.Windows.Forms.Button();
            this.panel_second = new System.Windows.Forms.Panel();
            this.btnexit_forma = new System.Windows.Forms.Button();
            this.panel_third = new System.Windows.Forms.Panel();
            this.lbox_res = new System.Windows.Forms.ListBox();
            this.lbl_Title_check = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.tb_add_value = new System.Windows.Forms.TextBox();
            this.btn_add_value = new System.Windows.Forms.Button();
            this.lbl_name_parent = new System.Windows.Forms.Label();
            this.lbl_name_value = new System.Windows.Forms.Label();
            this.btn_reload = new System.Windows.Forms.Button();
            this.cb_name_parent = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnbrand
            // 
            this.btnbrand.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnbrand.Location = new System.Drawing.Point(18, 12);
            this.btnbrand.Name = "btnbrand";
            this.btnbrand.Size = new System.Drawing.Size(136, 41);
            this.btnbrand.TabIndex = 12;
            this.btnbrand.Text = "Бренди";
            this.btnbrand.UseVisualStyleBackColor = false;
            this.btnbrand.Click += new System.EventHandler(this.btnbrand_Click);
            // 
            // btntaste
            // 
            this.btntaste.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btntaste.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btntaste.Location = new System.Drawing.Point(18, 247);
            this.btntaste.Name = "btntaste";
            this.btntaste.Size = new System.Drawing.Size(136, 41);
            this.btntaste.TabIndex = 13;
            this.btntaste.Text = "Смак";
            this.btntaste.UseVisualStyleBackColor = false;
            this.btntaste.Click += new System.EventHandler(this.btntaste_Click);
            // 
            // btn_forma
            // 
            this.btn_forma.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_forma.Location = new System.Drawing.Point(255, 12);
            this.btn_forma.Name = "btn_forma";
            this.btn_forma.Size = new System.Drawing.Size(136, 41);
            this.btn_forma.TabIndex = 14;
            this.btn_forma.Text = "Форма випуску";
            this.btn_forma.UseVisualStyleBackColor = false;
            this.btn_forma.Click += new System.EventHandler(this.btn_forma_Click);
            // 
            // btnexit_brand
            // 
            this.btnexit_brand.BackColor = System.Drawing.Color.SeaShell;
            this.btnexit_brand.Location = new System.Drawing.Point(169, 12);
            this.btnexit_brand.Name = "btnexit_brand";
            this.btnexit_brand.Size = new System.Drawing.Size(69, 41);
            this.btnexit_brand.TabIndex = 15;
            this.btnexit_brand.Text = "Hide";
            this.btnexit_brand.UseVisualStyleBackColor = false;
            this.btnexit_brand.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // panel_first
            // 
            this.panel_first.Location = new System.Drawing.Point(18, 59);
            this.panel_first.Name = "panel_first";
            this.panel_first.Size = new System.Drawing.Size(205, 73);
            this.panel_first.TabIndex = 16;
            // 
            // btnexit_taste
            // 
            this.btnexit_taste.BackColor = System.Drawing.Color.SeaShell;
            this.btnexit_taste.Location = new System.Drawing.Point(169, 247);
            this.btnexit_taste.Name = "btnexit_taste";
            this.btnexit_taste.Size = new System.Drawing.Size(69, 41);
            this.btnexit_taste.TabIndex = 17;
            this.btnexit_taste.Text = "Hide";
            this.btnexit_taste.UseVisualStyleBackColor = false;
            this.btnexit_taste.Click += new System.EventHandler(this.btnexit_taste_Click);
            // 
            // panel_second
            // 
            this.panel_second.Location = new System.Drawing.Point(18, 294);
            this.panel_second.Name = "panel_second";
            this.panel_second.Size = new System.Drawing.Size(205, 90);
            this.panel_second.TabIndex = 18;
            // 
            // btnexit_forma
            // 
            this.btnexit_forma.BackColor = System.Drawing.Color.SeaShell;
            this.btnexit_forma.Location = new System.Drawing.Point(407, 11);
            this.btnexit_forma.Name = "btnexit_forma";
            this.btnexit_forma.Size = new System.Drawing.Size(69, 41);
            this.btnexit_forma.TabIndex = 19;
            this.btnexit_forma.Text = "Hide";
            this.btnexit_forma.UseVisualStyleBackColor = false;
            this.btnexit_forma.Click += new System.EventHandler(this.btnexit_forma_Click);
            // 
            // panel_third
            // 
            this.panel_third.BackColor = System.Drawing.SystemColors.Control;
            this.panel_third.Location = new System.Drawing.Point(255, 58);
            this.panel_third.Name = "panel_third";
            this.panel_third.Size = new System.Drawing.Size(205, 73);
            this.panel_third.TabIndex = 20;
            // 
            // lbox_res
            // 
            this.lbox_res.BackColor = System.Drawing.Color.Linen;
            this.lbox_res.FormattingEnabled = true;
            this.lbox_res.ItemHeight = 20;
            this.lbox_res.Location = new System.Drawing.Point(538, 208);
            this.lbox_res.Name = "lbox_res";
            this.lbox_res.Size = new System.Drawing.Size(231, 144);
            this.lbox_res.TabIndex = 21;
            // 
            // lbl_Title_check
            // 
            this.lbl_Title_check.AutoSize = true;
            this.lbl_Title_check.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Title_check.Location = new System.Drawing.Point(538, 165);
            this.lbl_Title_check.Name = "lbl_Title_check";
            this.lbl_Title_check.Size = new System.Drawing.Size(53, 23);
            this.lbl_Title_check.TabIndex = 22;
            this.lbl_Title_check.Text = "label1";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.PapayaWhip;
            this.button5.Location = new System.Drawing.Point(595, 358);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(142, 54);
            this.button5.TabIndex = 23;
            this.button5.Text = "Отримати значення";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tb_add_value
            // 
            this.tb_add_value.Location = new System.Drawing.Point(618, 58);
            this.tb_add_value.Name = "tb_add_value";
            this.tb_add_value.Size = new System.Drawing.Size(151, 27);
            this.tb_add_value.TabIndex = 24;
            // 
            // btn_add_value
            // 
            this.btn_add_value.Location = new System.Drawing.Point(643, 102);
            this.btn_add_value.Name = "btn_add_value";
            this.btn_add_value.Size = new System.Drawing.Size(94, 29);
            this.btn_add_value.TabIndex = 25;
            this.btn_add_value.Text = "Додати";
            this.btn_add_value.UseVisualStyleBackColor = true;
            this.btn_add_value.Click += new System.EventHandler(this.btn_add_value_Click);
            // 
            // lbl_name_parent
            // 
            this.lbl_name_parent.AutoSize = true;
            this.lbl_name_parent.Location = new System.Drawing.Point(497, 21);
            this.lbl_name_parent.Name = "lbl_name_parent";
            this.lbl_name_parent.Size = new System.Drawing.Size(50, 20);
            this.lbl_name_parent.TabIndex = 26;
            this.lbl_name_parent.Text = "label1";
            // 
            // lbl_name_value
            // 
            this.lbl_name_value.AutoSize = true;
            this.lbl_name_value.Location = new System.Drawing.Point(497, 65);
            this.lbl_name_value.Name = "lbl_name_value";
            this.lbl_name_value.Size = new System.Drawing.Size(50, 20);
            this.lbl_name_value.TabIndex = 28;
            this.lbl_name_value.Text = "label1";
            // 
            // btn_reload
            // 
            this.btn_reload.BackColor = System.Drawing.Color.LightCyan;
            this.btn_reload.Location = new System.Drawing.Point(618, 427);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(94, 45);
            this.btn_reload.TabIndex = 29;
            this.btn_reload.Text = "Скинути";
            this.btn_reload.UseVisualStyleBackColor = false;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // cb_name_parent
            // 
            this.cb_name_parent.FormattingEnabled = true;
            this.cb_name_parent.Location = new System.Drawing.Point(618, 19);
            this.cb_name_parent.Name = "cb_name_parent";
            this.cb_name_parent.Size = new System.Drawing.Size(151, 28);
            this.cb_name_parent.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 593);
            this.Controls.Add(this.cb_name_parent);
            this.Controls.Add(this.btn_reload);
            this.Controls.Add(this.lbl_name_value);
            this.Controls.Add(this.lbl_name_parent);
            this.Controls.Add(this.btn_add_value);
            this.Controls.Add(this.tb_add_value);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.lbl_Title_check);
            this.Controls.Add(this.lbox_res);
            this.Controls.Add(this.panel_third);
            this.Controls.Add(this.btnexit_forma);
            this.Controls.Add(this.panel_second);
            this.Controls.Add(this.btnexit_taste);
            this.Controls.Add(this.btntaste);
            this.Controls.Add(this.panel_first);
            this.Controls.Add(this.btnexit_brand);
            this.Controls.Add(this.btn_forma);
            this.Controls.Add(this.btnbrand);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnbrand;
        private System.Windows.Forms.Button btntaste;
        private System.Windows.Forms.Button btn_forma;
        private System.Windows.Forms.Button btnexit_brand;
        private System.Windows.Forms.Panel panel_first;
        private System.Windows.Forms.Button btnexit_taste;
        private System.Windows.Forms.Panel panel_second;
        private System.Windows.Forms.Button btnexit_forma;
        private System.Windows.Forms.Panel panel_third;
        private System.Windows.Forms.ListBox lbox_res;
        private System.Windows.Forms.Label lbl_Title_check;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox tb_add_value;
        private System.Windows.Forms.Button btn_add_value;
        private System.Windows.Forms.Label lbl_name_parent;
        private System.Windows.Forms.Label lbl_name_value;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.ComboBox cb_name_parent;
    }
}

