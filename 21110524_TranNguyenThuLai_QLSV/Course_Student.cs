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
    public partial class Course_Student : Form
    {
        public Course_Student()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        private void Course_Student_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName, bdate as BirthDay, gender as Gender, phone as Phone, address as Address, picture as Picture, email as Email from std WHERE id IN (SELECT student_id FROM score WHERE course_id = (select Id from Course where  lable = @courseName))");
            cmd.Parameters.Add("@courseName", SqlDbType.VarChar).Value = textBoxCourseName.Text.Trim();
            fillDataGrid(cmd);

        }

        public void fillDataGrid(SqlCommand cmd)
        {
            dataGridViewCourse_Student.ReadOnly = true;
            dataGridViewCourse_Student.RowTemplate.Height = 50;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewCourse_Student.DataSource = table;
            picCol = (DataGridViewImageColumn)dataGridViewCourse_Student.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewCourse_Student.AllowUserToAddRows = false;
            
            lblTotal.Text = ("Total Course: " + dataGridViewCourse_Student.Rows.Count.ToString());


            
            
           
        }
    }
}
