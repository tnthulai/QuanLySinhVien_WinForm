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

namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    public partial class ClassListForm : Form
    {
        public ClassListForm()
        {
            InitializeComponent();
        }

        public string courseID;
        public string courseName = "C001";
        public string semester = "HK2";
        MY_DB mydb= new MY_DB();

        private void ClassListForm_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = mydb.getConnection;
                
                    command.CommandText = "SELECT std.id AS StudentID,  std.fname as Firstname, std.lname as Lastname, std.bdate as BirthDate, score.student_score as Score " +
                    "FROM  score " +
                    "JOIN std ON score.student_id = std.id " +
                    "JOIN Course ON score.course_id = Course.Id " +
                    "WHERE  score.course_id = @courseID;";
                    command.Parameters.Add("@courseID", SqlDbType.VarChar).Value = courseID;
            
                

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            lblCoursename.Text = courseName;
            lblsemester.Text = "Semester: " + semester;
        }


    }
}
