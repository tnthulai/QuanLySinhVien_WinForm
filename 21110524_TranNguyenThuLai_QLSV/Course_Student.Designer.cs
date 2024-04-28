namespace _21110524_TranNguyenThuLai_QLSV
{
    partial class Course_Student
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
            this.textBoxCourseName = new System.Windows.Forms.TextBox();
            this.labelSemester = new System.Windows.Forms.Label();
            this.dataGridViewCourse_Student = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourse_Student)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course Name";
            // 
            // textBoxCourseName
            // 
            this.textBoxCourseName.Enabled = false;
            this.textBoxCourseName.Location = new System.Drawing.Point(165, 24);
            this.textBoxCourseName.Name = "textBoxCourseName";
            this.textBoxCourseName.Size = new System.Drawing.Size(100, 22);
            this.textBoxCourseName.TabIndex = 1;
            // 
            // labelSemester
            // 
            this.labelSemester.AutoSize = true;
            this.labelSemester.Enabled = false;
            this.labelSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSemester.Location = new System.Drawing.Point(308, 25);
            this.labelSemester.Name = "labelSemester";
            this.labelSemester.Size = new System.Drawing.Size(85, 18);
            this.labelSemester.TabIndex = 0;
            this.labelSemester.Text = "Semester:";
            // 
            // dataGridViewCourse_Student
            // 
            this.dataGridViewCourse_Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCourse_Student.Location = new System.Drawing.Point(25, 69);
            this.dataGridViewCourse_Student.Name = "dataGridViewCourse_Student";
            this.dataGridViewCourse_Student.RowHeadersWidth = 51;
            this.dataGridViewCourse_Student.RowTemplate.Height = 24;
            this.dataGridViewCourse_Student.Size = new System.Drawing.Size(596, 369);
            this.dataGridViewCourse_Student.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Enabled = false;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(464, 25);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(136, 22);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "Total Courses";
            // 
            // Course_Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 495);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dataGridViewCourse_Student);
            this.Controls.Add(this.textBoxCourseName);
            this.Controls.Add(this.labelSemester);
            this.Controls.Add(this.label1);
            this.Name = "Course_Student";
            this.Text = "Course_Student";
            this.Load += new System.EventHandler(this.Course_Student_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourse_Student)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewCourse_Student;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.TextBox textBoxCourseName;
        public System.Windows.Forms.Label labelSemester;
    }
}