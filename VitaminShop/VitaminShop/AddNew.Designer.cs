
namespace VitaminShop
{
    partial class AddNew
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
            this.btn_addparent = new System.Windows.Forms.Button();
            this.tb_add_parent = new System.Windows.Forms.TextBox();
            this.lbl_title_parent = new System.Windows.Forms.Label();
            this.lbl_addchild = new System.Windows.Forms.Label();
            this.cb_parents = new System.Windows.Forms.ComboBox();
            this.btn_addchild = new System.Windows.Forms.Button();
            this.tb_newchild = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_addparent
            // 
            this.btn_addparent.Location = new System.Drawing.Point(542, 72);
            this.btn_addparent.Name = "btn_addparent";
            this.btn_addparent.Size = new System.Drawing.Size(94, 29);
            this.btn_addparent.TabIndex = 0;
            this.btn_addparent.Text = "Додати";
            this.btn_addparent.UseVisualStyleBackColor = true;
            this.btn_addparent.Click += new System.EventHandler(this.btn_addparent_Click);
            // 
            // tb_add_parent
            // 
            this.tb_add_parent.Location = new System.Drawing.Point(358, 74);
            this.tb_add_parent.Name = "tb_add_parent";
            this.tb_add_parent.Size = new System.Drawing.Size(157, 27);
            this.tb_add_parent.TabIndex = 1;
            // 
            // lbl_title_parent
            // 
            this.lbl_title_parent.AutoSize = true;
            this.lbl_title_parent.Location = new System.Drawing.Point(54, 81);
            this.lbl_title_parent.Name = "lbl_title_parent";
            this.lbl_title_parent.Size = new System.Drawing.Size(0, 20);
            this.lbl_title_parent.TabIndex = 2;
            // 
            // lbl_addchild
            // 
            this.lbl_addchild.AutoSize = true;
            this.lbl_addchild.Location = new System.Drawing.Point(59, 153);
            this.lbl_addchild.Name = "lbl_addchild";
            this.lbl_addchild.Size = new System.Drawing.Size(0, 20);
            this.lbl_addchild.TabIndex = 3;
            // 
            // cb_parents
            // 
            this.cb_parents.FormattingEnabled = true;
            this.cb_parents.Location = new System.Drawing.Point(214, 154);
            this.cb_parents.Name = "cb_parents";
            this.cb_parents.Size = new System.Drawing.Size(157, 28);
            this.cb_parents.TabIndex = 4;
            // 
            // btn_addchild
            // 
            this.btn_addchild.Location = new System.Drawing.Point(237, 277);
            this.btn_addchild.Name = "btn_addchild";
            this.btn_addchild.Size = new System.Drawing.Size(94, 29);
            this.btn_addchild.TabIndex = 5;
            this.btn_addchild.Text = "Додати";
            this.btn_addchild.UseVisualStyleBackColor = true;
            this.btn_addchild.Click += new System.EventHandler(this.btn_addchild_Click);
            // 
            // tb_newchild
            // 
            this.tb_newchild.Location = new System.Drawing.Point(214, 207);
            this.tb_newchild.Name = "tb_newchild";
            this.tb_newchild.Size = new System.Drawing.Size(157, 27);
            this.tb_newchild.TabIndex = 6;
            // 
            // AddNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_newchild);
            this.Controls.Add(this.btn_addchild);
            this.Controls.Add(this.cb_parents);
            this.Controls.Add(this.lbl_addchild);
            this.Controls.Add(this.lbl_title_parent);
            this.Controls.Add(this.tb_add_parent);
            this.Controls.Add(this.btn_addparent);
            this.Name = "AddNew";
            this.Text = "AddNew";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_addparent;
        private System.Windows.Forms.TextBox tb_add_parent;
        private System.Windows.Forms.Label lbl_title_parent;
        private System.Windows.Forms.Label lbl_addchild;
        private System.Windows.Forms.ComboBox cb_parents;
        private System.Windows.Forms.Button btn_addchild;
        private System.Windows.Forms.TextBox tb_newchild;
    }
}