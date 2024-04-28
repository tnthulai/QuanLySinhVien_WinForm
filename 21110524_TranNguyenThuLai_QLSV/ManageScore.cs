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
    public partial class ManageScore : Form
    {
        public ManageScore()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        Score scoreStudent = new Score();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Score score = new Score();
                string stdID = txtBoxStdID.Text.Trim();
                string courseId = comboBoxCourse.SelectedValue.ToString();

                if(!score.studentScoreExist(stdID, courseId))
                {
                    double score_Student = Convert.ToDouble(txtScore.Text.Trim());


                    if (score_Student < 0 || score_Student > 10)
                    {
                        MessageBox.Show("Nhap diem sai", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string desc = txtDesc.Text.Trim();
                    if (verif())
                    {
                        if (score.updateScore(stdID, courseId, score_Student, desc))
                        {
                            MessageBox.Show("New course added successfully", "Add score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Add score", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Empty Fields", "Add score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("This student is not associated with this course.", "Add score", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        bool verif()
        {
            if ((txtBoxStdID.Text.Trim() == "")
                        || (txtScore.Text.Trim() == "")
                        || (txtDesc.Text.Trim() == "")
                        || (comboBoxCourse.Text.Trim() == "")
                        )
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnShowStd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = mydb.getConnection;
                if (!string.IsNullOrEmpty(txtBoxStdID.Text))
                {
                    command.CommandText = "SELECT std.id AS StudentID,  std.fname as Firstname, std.lname as Lastname, Course.lable AS CourseName, score.student_score as Score, score.decription as Description " +
                    "FROM  score " +
                    "JOIN std ON score.student_id = std.id " +
                    "JOIN Course ON score.course_id = Course.Id " +
                    "WHERE  std.id = @id_student;";
                    command.Parameters.Add("@id_student", SqlDbType.VarChar).Value = txtBoxStdID.Text;
                }
                else
                {
                    command.CommandText = "SELECT std.id AS StudentID,  std.fname as Firstname, std.lname as Lastname, Course.lable AS CourseName, score.student_score as Score, score.decription as Description " +
                    "FROM  score " +
                    "JOIN std ON score.student_id = std.id " +
                    "JOIN Course ON score.course_id = Course.Id ";
                }


                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowScore_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = mydb.getConnection;

                command.CommandText = "SELECT std.id AS StudentID,  std.fname as Firstname, std.lname as Lastname, Course.lable AS CourseName, score.student_score as Score, score.decription as Description " +
                    "FROM  score " +
                    "JOIN std ON score.student_id = std.id " +
                    "JOIN Course ON score.course_id = Course.Id " +
                    "WHERE  Course.Id = @course_id;";
                command.Parameters.Add("@course_id", SqlDbType.VarChar).Value = comboBoxCourse.SelectedValue.ToString();



                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ManageScore_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet4.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.qLSVDBDataSet4.Course);

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                String stdID = txtBoxStdID.Text.Trim();
                String courseID = comboBoxCourse.SelectedValue.ToString();

                if (!scoreStudent.studentScoreExist(stdID, courseID))
                {
                    scoreStudent.deleteScore(stdID, courseID);
                    MessageBox.Show("Delete successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Score does not exits", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells[0].Value != null)
                {


                    txtBoxStdID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string courseName = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                    comboBoxCourse.Text = courseName;

                    comboBoxCourse.SelectedValue = scoreStudent.getCourseId(courseName); comboBoxCourse.Focus();

                    txtScore.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    txtDesc.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAvgByCourse_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = scoreStudent.getAvgScoreByCourse();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintScore printScore = new PrintScore();
            printScore.txtBoxStdID.Text = txtBoxStdID.Text;
            //printScore.comboBoxCourse.Text = comboBoxCourse.Text;
            printScore.name = comboBoxCourse.Text;

            printScore.ShowDialog();
        }
    }
}
