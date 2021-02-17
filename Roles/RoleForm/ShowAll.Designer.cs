
namespace FormRoles
{
    partial class ShowAll
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(196, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Перелік всіх користувачів та їх посад";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColImage,
            this.ColName,
            this.ColSur,
            this.ColRole});
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(728, 248);
            this.dataGridView1.TabIndex = 1;
            // 
            // ColId
            // 
            this.ColId.HeaderText = "Id";
            this.ColId.MinimumWidth = 6;
            this.ColId.Name = "ColId";
            this.ColId.Width = 110;
            // 
            // ColImage
            // 
            this.ColImage.HeaderText = "Photo profile";
            this.ColImage.MinimumWidth = 6;
            this.ColImage.Name = "ColImage";
            this.ColImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColImage.Width = 125;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColName.HeaderText = "Name";
            this.ColName.MinimumWidth = 6;
            this.ColName.Name = "ColName";
            // 
            // ColSur
            // 
            this.ColSur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColSur.HeaderText = "Surname";
            this.ColSur.MinimumWidth = 6;
            this.ColSur.Name = "ColSur";
            // 
            // ColRole
            // 
            this.ColRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColRole.HeaderText = "Role";
            this.ColRole.MinimumWidth = 6;
            this.ColRole.Name = "ColRole";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.button2.Location = new System.Drawing.Point(320, 459);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 44);
            this.button2.TabIndex = 5;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Видалити по курсору в гріді:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.button1.Location = new System.Drawing.Point(320, 537);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 44);
            this.button1.TabIndex = 7;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 549);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // ShowAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 608);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "ShowAll";
            this.Text = "ShowAll";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewImageColumn ColImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSur;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRole;
    }
}