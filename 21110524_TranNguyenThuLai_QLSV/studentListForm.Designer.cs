namespace _21110524_TranNguyenThuLai_QLSV
{
    partial class studentListForm
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
            this.stdBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVDBDataSetStudentListForm = new _21110524_TranNguyenThuLai_QLSV.QLSVDBDataSetStudentListForm();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.stdTableAdapter = new _21110524_TranNguyenThuLai_QLSV.QLSVDBDataSetStudentListFormTableAdapters.stdTableAdapter();
            this.stdBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVDBDataSetStudentListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stdBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.stdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnImport = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVStudentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSetStudentListForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSetStudentListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGVStudentList
            // 
            this.DataGVStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGVStudentList.Location = new System.Drawing.Point(12, 13);
            this.DataGVStudentList.Name = "DataGVStudentList";
            this.DataGVStudentList.RowHeadersWidth = 51;
            this.DataGVStudentList.RowTemplate.Height = 24;
            this.DataGVStudentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGVStudentList.Size = new System.Drawing.Size(1051, 532);
            this.DataGVStudentList.TabIndex = 0;
            this.DataGVStudentList.Click += new System.EventHandler(this.DataGVStudentList_Click);
            // 
            // stdBindingSource3
            // 
            this.stdBindingSource3.DataMember = "std";
            this.stdBindingSource3.DataSource = this.qLSVDBDataSetStudentListForm;
            // 
            // qLSVDBDataSetStudentListForm
            // 
            this.qLSVDBDataSetStudentListForm.DataSetName = "QLSVDBDataSetStudentListForm";
            this.qLSVDBDataSetStudentListForm.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(552, 551);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(222, 48);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // stdTableAdapter
            // 
            this.stdTableAdapter.ClearBeforeFill = true;
            // 
            // stdBindingSource2
            // 
            this.stdBindingSource2.DataMember = "std";
            // 
            // stdBindingSource1
            // 
            this.stdBindingSource1.DataMember = "std";
            // 
            // stdBindingSource
            // 
            this.stdBindingSource.DataMember = "std";
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(324, 551);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(222, 48);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import Student List";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(904, 562);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 16);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "label1";
            // 
            // studentListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1075, 611);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.DataGVStudentList);
            this.Name = "studentListForm";
            this.Text = "_21110524_studentListForm";
            this.Load += new System.EventHandler(this._21110524_studentListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGVStudentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSetStudentListForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSetStudentListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGVStudentList;
        private System.Windows.Forms.BindingSource stdBindingSource;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn pictureDataGridViewImageColumn;
        private System.Windows.Forms.BindingSource qLSVDBDataSetStudentListBindingSource;
        private System.Windows.Forms.BindingSource stdBindingSource1;
        private System.Windows.Forms.BindingSource stdBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn pictureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn emailDataGridViewImageColumn;
        private QLSVDBDataSetStudentListForm qLSVDBDataSetStudentListForm;
        private System.Windows.Forms.BindingSource stdBindingSource3;
        private QLSVDBDataSetStudentListFormTableAdapters.stdTableAdapter stdTableAdapter;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblTotal;
    }
}