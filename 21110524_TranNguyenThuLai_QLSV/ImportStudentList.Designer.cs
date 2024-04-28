namespace _21110524_TranNguyenThuLai_QLSV
{
    partial class ImportStudentList
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
            this.components = new System.ComponentModel.Container();
            this.DataGVStudentList = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataGVStudentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGVStudentList
            // 
            this.DataGVStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGVStudentList.Location = new System.Drawing.Point(12, 12);
            this.DataGVStudentList.Name = "DataGVStudentList";
            this.DataGVStudentList.RowHeadersWidth = 51;
            this.DataGVStudentList.RowTemplate.Height = 24;
            this.DataGVStudentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGVStudentList.Size = new System.Drawing.Size(1177, 532);
            this.DataGVStudentList.TabIndex = 1;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(473, 564);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(274, 48);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import Student List";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            // 
            // ImportStudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 644);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.DataGVStudentList);
            this.Name = "ImportStudentList";
            this.Text = "ImportStudentList";
            this.Load += new System.EventHandler(this.ImportStudentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGVStudentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGVStudentList;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.BindingSource studentBindingSource;
    }
}