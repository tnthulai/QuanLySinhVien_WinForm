namespace _21110524_TranNguyenThuLai_QLSV
{
    partial class PrintScore
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
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVDBDataSet6 = new _21110524_TranNguyenThuLai_QLSV.QLSVDBDataSet6();
            this.txtBoxStdID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnCourse = new System.Windows.Forms.Button();
            this.qLSVDBDataSetCourseScore = new _21110524_TranNguyenThuLai_QLSV.QLSVDBDataSetCourseScore();
            this.qLSVDBDataSetCourseScoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseTableAdapter = new _21110524_TranNguyenThuLai_QLSV.QLSVDBDataSet6TableAdapters.CourseTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSetCourseScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSetCourseScoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.DataSource = this.courseBindingSource;
            this.comboBoxCourse.DisplayMember = "lable";
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(174, 123);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(233, 24);
            this.comboBoxCourse.TabIndex = 31;
            this.comboBoxCourse.ValueMember = "Id";
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataMember = "Course";
            this.courseBindingSource.DataSource = this.qLSVDBDataSet6;
            // 
            // qLSVDBDataSet6
            // 
            this.qLSVDBDataSet6.DataSetName = "QLSVDBDataSet6";
            this.qLSVDBDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtBoxStdID
            // 
            this.txtBoxStdID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtBoxStdID.Location = new System.Drawing.Point(174, 42);
            this.txtBoxStdID.Multiline = true;
            this.txtBoxStdID.Name = "txtBoxStdID";
            this.txtBoxStdID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxStdID.Size = new System.Drawing.Size(233, 39);
            this.txtBoxStdID.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 22);
            this.label3.TabIndex = 28;
            this.label3.Text = "Select Course";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 22);
            this.label2.TabIndex = 29;
            this.label2.Text = "Student_ID";
            // 
            // btnStudent
            // 
            this.btnStudent.Location = new System.Drawing.Point(487, 37);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(126, 42);
            this.btnStudent.TabIndex = 32;
            this.btnStudent.Text = "Print Score For Student";
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnCourse
            // 
            this.btnCourse.Location = new System.Drawing.Point(487, 113);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(126, 42);
            this.btnCourse.TabIndex = 32;
            this.btnCourse.Text = "Print Score For Course";
            this.btnCourse.UseVisualStyleBackColor = true;
            this.btnCourse.Click += new System.EventHandler(this.btnCourse_Click);
            // 
            // qLSVDBDataSetCourseScore
            // 
            this.qLSVDBDataSetCourseScore.DataSetName = "QLSVDBDataSetCourseScore";
            this.qLSVDBDataSetCourseScore.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qLSVDBDataSetCourseScoreBindingSource
            // 
            this.qLSVDBDataSetCourseScoreBindingSource.DataSource = this.qLSVDBDataSetCourseScore;
            this.qLSVDBDataSetCourseScoreBindingSource.Position = 0;
            // 
            // courseTableAdapter
            // 
            this.courseTableAdapter.ClearBeforeFill = true;
            // 
            // PrintScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCourse);
            this.Controls.Add(this.btnStudent);
            this.Controls.Add(this.comboBoxCourse);
            this.Controls.Add(this.txtBoxStdID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "PrintScore";
            this.Text = "PrintScore";
            this.Load += new System.EventHandler(this.PrintScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSetCourseScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSetCourseScoreBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnCourse;
        private System.Windows.Forms.BindingSource qLSVDBDataSetCourseScoreBindingSource;
        private QLSVDBDataSetCourseScore qLSVDBDataSetCourseScore;
        private QLSVDBDataSet6 qLSVDBDataSet6;
        private System.Windows.Forms.BindingSource courseBindingSource;
        private QLSVDBDataSet6TableAdapters.CourseTableAdapter courseTableAdapter;
        public System.Windows.Forms.TextBox txtBoxStdID;
        public System.Windows.Forms.ComboBox comboBoxCourse;
    }
}