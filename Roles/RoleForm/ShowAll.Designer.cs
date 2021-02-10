
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
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(193, 84);
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
            this.ColName,
            this.ColSur,
            this.ColRole});
            this.dataGridView1.Location = new System.Drawing.Point(39, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(728, 241);
            this.dataGridView1.TabIndex = 1;
            // 
            // ColId
            // 
            this.ColId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColId.HeaderText = "Id";
            this.ColId.MinimumWidth = 6;
            this.ColId.Name = "ColId";
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
            // ShowAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "ShowAll";
            this.Text = "ShowAll";
            this.Load += new System.EventHandler(this.Data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSur;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRole;
    }
}