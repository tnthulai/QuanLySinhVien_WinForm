namespace _21110524_TranNguyenThuLai_QLSV
{
    partial class ManageScore
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
            this.txtScore = new System.Windows.Forms.TextBox();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVDBDataSet4 = new _21110524_TranNguyenThuLai_QLSV.QLSVDBDataSet4();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.txtBoxStdID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAvgByCourse = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnShowStd = new System.Windows.Forms.Button();
            this.btnShowScore = new System.Windows.Forms.Button();
            this.courseTableAdapter = new _21110524_TranNguyenThuLai_QLSV.QLSVDBDataSet4TableAdapters.CourseTableAdapter();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(155, 168);
            this.txtScore.Multiline = true;
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(233, 32);
            this.txtScore.TabIndex = 28;
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.DataSource = this.courseBindingSource;
            this.comboBoxCourse.DisplayMember = "lable";
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(155, 104);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(233, 24);
            this.comboBoxCourse.TabIndex = 27;
            this.comboBoxCourse.ValueMember = "Id";
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataMember = "Course";
            this.courseBindingSource.DataSource = this.qLSVDBDataSet4;
            // 
            // qLSVDBDataSet4
            // 
            this.qLSVDBDataSet4.DataSetName = "QLSVDBDataSet4";
            this.qLSVDBDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Crimson;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.Location = new System.Drawing.Point(217, 413);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(171, 52);
            this.btnRemove.TabIndex = 25;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(38, 413);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(173, 52);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add Score";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(155, 241);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(233, 159);
            this.txtDesc.TabIndex = 24;
            this.txtDesc.Text = "";
            // 
            // txtBoxStdID
            // 
            this.txtBoxStdID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtBoxStdID.Location = new System.Drawing.Point(155, 23);
            this.txtBoxStdID.Multiline = true;
            this.txtBoxStdID.Name = "txtBoxStdID";
            this.txtBoxStdID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxStdID.Size = new System.Drawing.Size(233, 39);
            this.txtBoxStdID.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 22);
            this.label5.TabIndex = 19;
            this.label5.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 22);
            this.label4.TabIndex = 20;
            this.label4.Text = "Score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 22);
            this.label3.TabIndex = 21;
            this.label3.Text = "Select Course";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "Student_ID";
            // 
            // btnAvgByCourse
            // 
            this.btnAvgByCourse.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAvgByCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvgByCourse.ForeColor = System.Drawing.Color.Black;
            this.btnAvgByCourse.Location = new System.Drawing.Point(38, 476);
            this.btnAvgByCourse.Name = "btnAvgByCourse";
            this.btnAvgByCourse.Size = new System.Drawing.Size(350, 52);
            this.btnAvgByCourse.TabIndex = 26;
            this.btnAvgByCourse.Text = "Average Score By Course";
            this.btnAvgByCourse.UseVisualStyleBackColor = false;
            this.btnAvgByCourse.Click += new System.EventHandler(this.btnAvgByCourse_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(417, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(796, 450);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // btnShowStd
            // 
            this.btnShowStd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnShowStd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowStd.ForeColor = System.Drawing.Color.Black;
            this.btnShowStd.Location = new System.Drawing.Point(417, 18);
            this.btnShowStd.Name = "btnShowStd";
            this.btnShowStd.Size = new System.Drawing.Size(161, 43);
            this.btnShowStd.TabIndex = 25;
            this.btnShowStd.Text = "Show Student";
            this.btnShowStd.UseVisualStyleBackColor = false;
            this.btnShowStd.Click += new System.EventHandler(this.btnShowStd_Click);
            // 
            // btnShowScore
            // 
            this.btnShowScore.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnShowScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowScore.ForeColor = System.Drawing.Color.Black;
            this.btnShowScore.Location = new System.Drawing.Point(581, 18);
            this.btnShowScore.Name = "btnShowScore";
            this.btnShowScore.Size = new System.Drawing.Size(151, 43);
            this.btnShowScore.TabIndex = 25;
            this.btnShowScore.Text = "Show Score";
            this.btnShowScore.UseVisualStyleBackColor = false;
            this.btnShowScore.Click += new System.EventHandler(this.btnShowScore_Click);
            // 
            // courseTableAdapter
            // 
            this.courseTableAdapter.ClearBeforeFill = true;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(735, 18);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(151, 43);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ManageScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 558);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.comboBoxCourse);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnShowScore);
            this.Controls.Add(this.btnShowStd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAvgByCourse);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtBoxStdID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ManageScore";
            this.Text = "ManageScore";
            this.Load += new System.EventHandler(this.ManageScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDBDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox txtDesc;
        private System.Windows.Forms.TextBox txtBoxStdID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAvgByCourse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnShowStd;
        private System.Windows.Forms.Button btnShowScore;
        private QLSVDBDataSet4 qLSVDBDataSet4;
        private System.Windows.Forms.BindingSource courseBindingSource;
        private QLSVDBDataSet4TableAdapters.CourseTableAdapter courseTableAdapter;
        private System.Windows.Forms.Button btnPrint;
    }
}