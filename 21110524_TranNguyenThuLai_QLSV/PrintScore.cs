using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class PrintScore : Form
    {
        public PrintScore()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        Score score = new Score();
        public string name { get; set; }
        private void btnStudent_Click(object sender, EventArgs e)
        {
            
            if (score.studentExist(txtBoxStdID.Text.Trim()))
            {
                Report report = new Report();
                report.reportpath = "ReportStudentScore.rdlc";
                report.dataset = "DataSetStudentScore";

                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT std.id AS student_id,  std.fname, std.lname,std.gender, std.bdate, std.email, Course.lable AS course_label, score.student_score, score.decription " +
                        "FROM  score " +
                        "JOIN std ON score.student_id = std.id " +
                        "JOIN Course ON score.course_id = Course.Id " +
                        "WHERE  std.id = @id_student;";
                command.Parameters.Add("@id_student", SqlDbType.VarChar).Value = txtBoxStdID.Text;
                command.Connection = mydb.getConnection;

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable table = new DataTable();

                adapter.Fill(table);

                report.dataTable = table;

                report.ShowDialog();
            }
            else
            {
                MessageBox.Show("Student does not exist", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.reportpath = "ReportCourseScore.rdlc";
            report.dataset = "DataSetCourseScore";

            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;

            command.CommandText = "SELECT std.id AS student_id,  std.fname, std.lname, Course.lable AS course_label, score.student_score, score.decription " +
                "FROM  score " +
                "JOIN std ON score.student_id = std.id " +
                "JOIN Course ON score.course_id = Course.Id " +
                "WHERE  Course.Id = @course_id;";
            command.Parameters.Add("@course_id", SqlDbType.VarChar).Value = comboBoxCourse.SelectedValue.ToString();
            command.Connection = mydb.getConnection;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            report.dataTable = table;

            report.ShowDialog();

        }

        private void PrintScore_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet6.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.qLSVDBDataSet6.Course);
            comboBoxCourse.Text = name;
        }
    }
}
