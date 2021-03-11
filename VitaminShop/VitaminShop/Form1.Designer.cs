
namespace VitaminShop
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
            this.btn_add_element = new System.Windows.Forms.Button();
            this.btn_find = new System.Windows.Forms.Button();
            this.dgv_products = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColImage = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_products)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_add_element
            // 
            this.btn_add_element.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_add_element.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_add_element.Location = new System.Drawing.Point(12, 389);
            this.btn_add_element.Name = "btn_add_element";
            this.btn_add_element.Size = new System.Drawing.Size(121, 36);
            this.btn_add_element.TabIndex = 0;
            this.btn_add_element.Text = "Додати елемент";
            this.btn_add_element.UseVisualStyleBackColor = false;
            this.btn_add_element.Click += new System.EventHandler(this.btn_add_element_Click);
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(164, 389);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(108, 36);
            this.btn_find.TabIndex = 1;
            this.btn_find.Text = "Застосувати";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // dgv_products
            // 
            this.dgv_products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_products.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColName,
            this.ColPrice,
            this.ColImage});
            this.dgv_products.Location = new System.Drawing.Point(304, 110);
            this.dgv_products.Name = "dgv_products";
            this.dgv_products.RowHeadersWidth = 51;
            this.dgv_products.RowTemplate.Height = 29;
            this.dgv_products.Size = new System.Drawing.Size(484, 202);
            this.dgv_products.TabIndex = 2;
            // 
            // ColId
            // 
            this.ColId.HeaderText = "Id";
            this.ColId.MinimumWidth = 6;
            this.ColId.Name = "ColId";
            this.ColId.Visible = false;
            this.ColId.Width = 125;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColName.HeaderText = "Name";
            this.ColName.MinimumWidth = 6;
            this.ColName.Name = "ColName";
            // 
            // ColPrice
            // 
            this.ColPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPrice.HeaderText = "Price";
            this.ColPrice.MinimumWidth = 6;
            this.ColPrice.Name = "ColPrice";
            // 
            // ColImage
            // 
            this.ColImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColImage.HeaderText = "Image";
            this.ColImage.MinimumWidth = 6;
            this.ColImage.Name = "ColImage";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_products);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.btn_add_element);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_products)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_add_element;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.DataGridView dgv_products;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewImageColumn ColImage;
    }
}

