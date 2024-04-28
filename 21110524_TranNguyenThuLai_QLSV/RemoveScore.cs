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
    public partial class RemoveScore : Form
    {
        public RemoveScore()
        {
            InitializeComponent();
        }
        Score score = new Score();
        MY_DB mydb = new MY_DB();

        private void RemoveScore_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;

            command.CommandText = "Select student_id as StudentID, course_id as CourseID, student_score as Score decription as Description from score";

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            dataGridView1.DataSource = table;

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
                string courseID = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                if (score.deleteScore(studentID, courseID))
                {
                    MessageBox.Show("Xoá thành công");

                }
                else
                {
                    MessageBox.Show("Xoá thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
