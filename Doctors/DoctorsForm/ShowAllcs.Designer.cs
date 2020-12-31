﻿
namespace DoctorsForm
{
    partial class ShowAllcs
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
            this.ColSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNameDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNameDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSurname,
            this.ColNameDoctor,
            this.ColStage,
            this.ColNameDep,
            this.ColDepartment});
            this.dataGridView1.Location = new System.Drawing.Point(12, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(776, 294);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColSurname
            // 
            this.ColSurname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColSurname.HeaderText = "Surname doctor";
            this.ColSurname.MinimumWidth = 6;
            this.ColSurname.Name = "ColSurname";
            // 
            // ColNameDoctor
            // 
            this.ColNameDoctor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNameDoctor.HeaderText = "Name doctor";
            this.ColNameDoctor.MinimumWidth = 6;
            this.ColNameDoctor.Name = "ColNameDoctor";
            // 
            // ColStage
            // 
            this.ColStage.HeaderText = "Stage";
            this.ColStage.MinimumWidth = 6;
            this.ColStage.Name = "ColStage";
            this.ColStage.Width = 125;
            // 
            // ColNameDep
            // 
            this.ColNameDep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNameDep.HeaderText = "Department";
            this.ColNameDep.MinimumWidth = 6;
            this.ColNameDep.Name = "ColNameDep";
            // 
            // ColDepartment
            // 
            this.ColDepartment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDepartment.HeaderText = "Number cabinet";
            this.ColDepartment.MinimumWidth = 6;
            this.ColDepartment.Name = "ColDepartment";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
           // this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowAllcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ShowAllcs";
            this.Text = "Doctors list";
            this.Load += new System.EventHandler(this.ShowAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNameDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNameDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDepartment;
        private System.Windows.Forms.Button button1;
    }
}