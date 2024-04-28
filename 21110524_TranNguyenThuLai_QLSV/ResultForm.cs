using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV.Result
{
    public partial class ResultForm : Form
    {
        MY_DB mydb = new MY_DB();
        public ResultForm()
        {
            InitializeComponent();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            cbSemester.Items.Add("HK1");
            cbSemester.Items.Add("HK2");
            cbSemester.Items.Add("HK3");
            cbSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSemester.Text = "HK1";

            //comand này đặn lấy câu query truyền cho layGiaTriStudent
            SqlCommand command = new SqlCommand("SELECT id as StudentID, fname as Firstname, lname as Lastname FROM std");
            loadGridView(command);

        }

        private DataTable layBangDiem()
        {
            SqlCommand command = new SqlCommand("SELECT st.id as StudentID, c.lable as Coursename, s.student_score as Score\r\n" +
                "FROM (score s join std st on st.id = s.student_id)\r\n\t" +
                "join course c on c.Id = s.course_id\r\nWHERE c.semester=@semester", mydb.getConnection);
            command.Parameters.Add("@semester", SqlDbType.VarChar).Value = cbSemester.Text.Trim();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void loadGridView(SqlCommand command)
        {
            try
            {
                dataStudentResult.Columns.Clear();
                dataStudentResult.Refresh();

                DataTable tableStudent = layGiaTriStudent(command);
                dataStudentResult.DataSource = tableStudent;
                DataTable tableCourse = layGiaTriCourse();
                if (tableCourse.Rows.Count > 0)
                {
                    foreach (DataRow courseRow in tableCourse.Rows)
                    {
                        string courseLabel = courseRow["Coursename"].ToString();

                        // Thêm cột mới vào DataGridView nếu cần
                        if (!dataStudentResult.Columns.Contains(courseLabel))
                        {
                            dataStudentResult.Columns.Add(courseLabel, courseLabel);
                        }
                    }
                }
                dataStudentResult.Columns.Add("Average Score", "Average Score");
                dataStudentResult.Columns.Add("Result", "Result");

                DataTable tableScore = layBangDiem();
                DataTable tableAvg = getAvgScoreByStudent();

                // Gán từng điểm của mỗi môn cho học viên
                foreach (DataRow scoreRow in tableScore.Rows)
                {
                    int studentId = Convert.ToInt32(scoreRow["StudentID"]);
                    string courseLabel = scoreRow["Coursename"].ToString();
                    float studentScore = Convert.ToSingle(scoreRow["Score"]);

                    foreach (DataGridViewRow studentRow in dataStudentResult.Rows)
                    {
                        if (Convert.ToInt32(studentRow.Cells["StudentID"].Value) == studentId)
                        {
                            studentRow.Cells[courseLabel].Value = studentScore;
                            break;
                        }
                    }
                }

                //Gán điểm trung bình của từng học viên và Result
                foreach (DataRow scoreRow in tableAvg.Rows)
                {
                    int studentId = Convert.ToInt32(scoreRow["StudentID"]);
                    float studentAvg = Convert.ToSingle(scoreRow["AverageGrade"]);

                    foreach (DataGridViewRow studentRow in dataStudentResult.Rows)
                    {
                        if (Convert.ToInt32(studentRow.Cells["StudentID"].Value) == studentId)
                        {
                            studentRow.Cells["Average Score"].Value = studentAvg.ToString("N2");
                            if (studentAvg >=9)
                                studentRow.Cells["Result"].Value = " Very Good";
                            else if (studentAvg >= 8)
                                studentRow.Cells["Result"].Value = "Good";
                            else if (studentAvg >= 5)
                                studentRow.Cells["Result"].Value = "Ordinary";
                            else
                                studentRow.Cells["Result"].Value = "Fail";
                            break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable getAvgScoreByStudent()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT st.id as StudentID , AVG(s.student_score) as AverageGrade \r\n" +
                "FROM std st, score s, course c\r\n" +
                "WHERE st.id = s.student_id AND s.course_id=c.Id AND semester=@semester\r\n" +
                "GROUP BY st.id";
            command.Parameters.Add("@semester", SqlDbType.NVarChar).Value = cbSemester.Text.ToString().Trim();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        private void cbSemester_SelectedValueChanged(object sender, EventArgs e)
        {

            SqlCommand command = new SqlCommand("SELECT id as StudentID, fname as Firstname, lname as Lastname  FROM std");
            loadGridView(command);
        }
        public DataTable layGiaTriCourse()
        {
            SqlCommand command = new SqlCommand("SELECT lable as Coursename FROM course WHERE semester=@semester", mydb.getConnection);
            command.Parameters.Add("@semester", SqlDbType.VarChar).Value = cbSemester.Text.Trim();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable layGiaTriStudent(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataStudentResult_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = dataStudentResult.CurrentRow.Cells["StudentID"].Value.ToString();
            txtFirstName.Text = dataStudentResult.CurrentRow.Cells["Firstname"].Value.ToString();
            txtLastName.Text = dataStudentResult.CurrentRow.Cells["Lastname"].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT id as StudentID, fname as Firstname, lname as Lastname  FROM std WHERE id LIKE @timKiem OR fname LIKE @timKiem");
            command.Parameters.Add("@timKiem", SqlDbType.NVarChar).Value = "%" + txtSearch.Text.Trim() + "%";
            loadGridView(command);
        }
    }
}
