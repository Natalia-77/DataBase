
namespace HostForm
{
    partial class FormAll
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColNumber,
            this.ColStage,
            this.ColDepName});
            this.dataGridView1.Location = new System.Drawing.Point(12, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(752, 372);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColName.HeaderText = "Doctor Name";
            this.ColName.MinimumWidth = 6;
            this.ColName.Name = "ColName";
            // 
            // ColNumber
            // 
            this.ColNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNumber.HeaderText = "Number cabinet";
            this.ColNumber.MinimumWidth = 6;
            this.ColNumber.Name = "ColNumber";
            // 
            // ColStage
            // 
            this.ColStage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColStage.HeaderText = "Stage";
            this.ColStage.MinimumWidth = 6;
            this.ColStage.Name = "ColStage";
            // 
            // ColDepName
            // 
            this.ColDepName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDepName.HeaderText = "Department Name";
            this.ColDepName.MinimumWidth = 6;
            this.ColDepName.Name = "ColDepName";
            // 
            // FormAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormAll";
            this.Text = "Список лікарів";
            this.Load += new System.EventHandler(this.FormAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDepName;
    }
}