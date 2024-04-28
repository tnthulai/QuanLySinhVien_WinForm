namespace _21110524_TranNguyenThuLai_QLSV
{
    partial class PrintForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnWord = new System.Windows.Forms.Button();
            this.btnTextFile = new System.Windows.Forms.Button();
            this.stdBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileExcel = new System.Windows.Forms.SaveFileDialog();
            this.saveFilePDF = new System.Windows.Forms.SaveFileDialog();
            this.saveFileWord = new System.Windows.Forms.SaveFileDialog();
            this.saveFileText = new System.Windows.Forms.SaveFileDialog();
            this.dataGVPrint = new System.Windows.Forms.DataGridView();
            this.stdBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVDBDataSetPrintForm = new _21110524_TranNguyenThuLai_QLSV.QLSVDBDataSetPrintForm();
            this.stdBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.stdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.datePickerToBirth = new System.Windows.Forms.DateTimePicker();
            this.datePickerFromBirth = new System.Windows.Forms.DateTimePicker();
            this.radFemale = new System.Windows.Forms.RadioButton();
            this.radMale = new System.Windows.Forms.RadioButton();
            this.btnFilter = new System.Windows.Forms.Button();
            this.chkBirth = new System.Windows.Forms.CheckBox();
            this.chkGender = new System.Windows.Forms.CheckBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.stdTableAdapter = new _21110524_TranNguyenThuLai_QLSV.QLSVDBDataSetPrintFormTableAdapters.stdTableAdapter();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSetPrintForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(18, 429);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 60);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnBack);
            this.groupBox2.Controls.Add(this.btnPdf);
            this.groupBox2.Controls.Add(this.btnWord);
            this.groupBox2.Controls.Add(this.btnTextFile);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(890, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 491);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnExcel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(18, 265);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(140, 60);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(18, 347);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(140, 60);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPdf.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPdf.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPdf.Location = new System.Drawing.Point(18, 183);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(140, 60);
            this.btnPdf.TabIndex = 2;
            this.btnPdf.Text = "Pdf";
            this.btnPdf.UseVisualStyleBackColor = false;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnWord
            // 
            this.btnWord.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnWord.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWord.Location = new System.Drawing.Point(18, 101);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(140, 60);
            this.btnWord.TabIndex = 1;
            this.btnWord.Text = "Word";
            this.btnWord.UseVisualStyleBackColor = false;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // btnTextFile
            // 
            this.btnTextFile.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnTextFile.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTextFile.Location = new System.Drawing.Point(18, 19);
            this.btnTextFile.Name = "btnTextFile";
            this.btnTextFile.Size = new System.Drawing.Size(140, 60);
            this.btnTextFile.TabIndex = 0;
            this.btnTextFile.Text = "Text File";
            this.btnTextFile.UseVisualStyleBackColor = false;
            this.btnTextFile.Click += new System.EventHandler(this.btnTextFile_Click);
            // 
            // stdBindingSource1
            // 
            this.stdBindingSource1.DataMember = "std";
            // 
            // saveFileExcel
            // 
            this.saveFileExcel.Filter = "Excel 2016|\".xlsx";
            // 
            // saveFilePDF
            // 
            this.saveFilePDF.Filter = "PDF 2016|\".pdf";
            // 
            // saveFileWord
            // 
            this.saveFileWord.Filter = "Microsoft Word 2016|\".docx";
            // 
            // saveFileText
            // 
            this.saveFileText.Filter = "|\".txt";
            // 
            // dataGVPrint
            // 
            this.dataGVPrint.AllowUserToAddRows = false;
            this.dataGVPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVPrint.Location = new System.Drawing.Point(28, 133);
            this.dataGVPrint.Name = "dataGVPrint";
            this.dataGVPrint.RowHeadersWidth = 51;
            this.dataGVPrint.RowTemplate.Height = 24;
            this.dataGVPrint.Size = new System.Drawing.Size(828, 470);
            this.dataGVPrint.TabIndex = 0;
            // 
            // stdBindingSource3
            // 
            this.stdBindingSource3.DataMember = "std";
            this.stdBindingSource3.DataSource = this.qLSVDBDataSetPrintForm;
            // 
            // qLSVDBDataSetPrintForm
            // 
            this.qLSVDBDataSetPrintForm.DataSetName = "QLSVDBDataSetPrintForm";
            this.qLSVDBDataSetPrintForm.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stdBindingSource2
            // 
            this.stdBindingSource2.DataMember = "std";
            // 
            // stdBindingSource
            // 
            this.stdBindingSource.DataMember = "std";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.datePickerToBirth);
            this.groupBox1.Controls.Add(this.datePickerFromBirth);
            this.groupBox1.Controls.Add(this.radFemale);
            this.groupBox1.Controls.Add(this.radMale);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.chkBirth);
            this.groupBox1.Controls.Add(this.chkGender);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 117);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCheck.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(94, 214);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(124, 46);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // datePickerToBirth
            // 
            this.datePickerToBirth.CalendarFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerToBirth.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerToBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerToBirth.Location = new System.Drawing.Point(488, 67);
            this.datePickerToBirth.Name = "datePickerToBirth";
            this.datePickerToBirth.Size = new System.Drawing.Size(161, 32);
            this.datePickerToBirth.TabIndex = 7;
            this.datePickerToBirth.Value = new System.DateTime(2024, 3, 19, 0, 0, 0, 0);
            // 
            // datePickerFromBirth
            // 
            this.datePickerFromBirth.CalendarFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerFromBirth.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.datePickerFromBirth.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerFromBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerFromBirth.Location = new System.Drawing.Point(321, 67);
            this.datePickerFromBirth.Name = "datePickerFromBirth";
            this.datePickerFromBirth.Size = new System.Drawing.Size(161, 32);
            this.datePickerFromBirth.TabIndex = 5;
            this.datePickerFromBirth.Value = new System.DateTime(2024, 3, 19, 0, 0, 0, 0);
            // 
            // radFemale
            // 
            this.radFemale.AutoSize = true;
            this.radFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radFemale.Location = new System.Drawing.Point(124, 67);
            this.radFemale.Name = "radFemale";
            this.radFemale.Size = new System.Drawing.Size(98, 29);
            this.radFemale.TabIndex = 4;
            this.radFemale.TabStop = true;
            this.radFemale.Text = "Female";
            this.radFemale.UseVisualStyleBackColor = true;
            // 
            // radMale
            // 
            this.radMale.AutoSize = true;
            this.radMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radMale.Location = new System.Drawing.Point(17, 66);
            this.radMale.Name = "radMale";
            this.radMale.Size = new System.Drawing.Size(76, 29);
            this.radMale.TabIndex = 3;
            this.radMale.TabStop = true;
            this.radMale.Text = "Male";
            this.radMale.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(717, 65);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(90, 33);
            this.btnFilter.TabIndex = 0;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // chkBirth
            // 
            this.chkBirth.AutoSize = true;
            this.chkBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkBirth.Location = new System.Drawing.Point(321, 27);
            this.chkBirth.Name = "chkBirth";
            this.chkBirth.Size = new System.Drawing.Size(105, 29);
            this.chkBirth.TabIndex = 2;
            this.chkBirth.Text = "Birthday";
            this.chkBirth.UseVisualStyleBackColor = true;
            // 
            // chkGender
            // 
            this.chkGender.AutoSize = true;
            this.chkGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkGender.Location = new System.Drawing.Point(17, 27);
            this.chkGender.Name = "chkGender";
            this.chkGender.Size = new System.Drawing.Size(99, 29);
            this.chkGender.TabIndex = 1;
            this.chkGender.Text = "Gender";
            this.chkGender.UseVisualStyleBackColor = true;
            this.chkGender.CheckedChanged += new System.EventHandler(this.chkGender_CheckedChanged);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // stdTableAdapter
            // 
            this.stdTableAdapter.ClearBeforeFill = true;
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 644);
            this.Controls.Add(this.dataGVPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "PrintForm";
            this.Text = "PrintForm";
            this.Load += new System.EventHandler(this.PrintForm_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSetPrintForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnWord;
        private System.Windows.Forms.Button btnTextFile;
        private System.Windows.Forms.SaveFileDialog saveFileExcel;
        private System.Windows.Forms.SaveFileDialog saveFilePDF;
        private System.Windows.Forms.SaveFileDialog saveFileWord;
        private System.Windows.Forms.SaveFileDialog saveFileText;
        private System.Windows.Forms.BindingSource stdBindingSource1;
        private System.Windows.Forms.DataGridView dataGVPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn pictureDataGridViewImageColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.DateTimePicker datePickerToBirth;
        private System.Windows.Forms.DateTimePicker datePickerFromBirth;
        private System.Windows.Forms.RadioButton radFemale;
        private System.Windows.Forms.RadioButton radMale;
        private System.Windows.Forms.CheckBox chkBirth;
        private System.Windows.Forms.CheckBox chkGender;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.BindingSource stdBindingSource;
        private System.Windows.Forms.BindingSource stdBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn pictureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private QLSVDBDataSetPrintForm qLSVDBDataSetPrintForm;
        private System.Windows.Forms.BindingSource stdBindingSource3;
        private QLSVDBDataSetPrintFormTableAdapters.stdTableAdapter stdTableAdapter;
    }
}