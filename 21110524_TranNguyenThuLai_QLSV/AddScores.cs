using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class AddScores : Form
    {
        public AddScores()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        private void AddScores_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet3.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter1.Fill(this.qLSVDBDataSet3.Course);
            
            // TODO: This line of code loads data into the 'qLSVDBDataSet1.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.qLSVDBDataSet1.Course);

            SqlCommand cmd = new SqlCommand("Select student_id as StudentID, fname as Firstname, lname as Lastname, student_score as Score, decription as Description from score join std on student_id = id", mydb.getConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();

            adapter.Fill(table);

            dataGridView1.DataSource = table;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                Score score = new Score();
                string stdID = txtBoxStdID.Text.Trim();
                string courseId = comboBoxCourse.SelectedValue.ToString();
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtBoxStdID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtScore.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDesc.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            comboBoxCourse.DataBindings.Clear();
            SqlCommand cmd = new SqlCommand("select Id as ID, lable as Name from Course where Id IN (select course_id from score where student_id = @stdid)", mydb.getConnection);
            cmd.Parameters.Add("@stdid", SqlDbType.VarChar).Value = txtBoxStdID.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.Fill(table);

            comboBoxCourse.DataSource = table;
            comboBoxCourse.DisplayMember = "lable";
            comboBoxCourse.ValueMember = "Id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
