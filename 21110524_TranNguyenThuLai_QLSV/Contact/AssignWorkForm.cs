using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    public partial class AssignWorkForm : Form
    {
        public AssignWorkForm()
        {
            InitializeComponent();
        }
        Course course = new Course();
        MY_DB mydb = new MY_DB();
        public string contactID;
        private void AssignWorkForm_Load(object sender, EventArgs e)
        {
            txtID.Text = contactID;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT semester FROM Course");

            comboBoxSemester.DataSource = course.getCourse(cmd);

            comboBoxSemester.SelectedValueChanged += comboBoxSemester_SelectedValueChanged;

            showCourseAvailable();
        }

        private void showCourseAvailable()
        {
            listBoxAvailableCourse.Items.Clear();

            string query = @"SELECT c.Id, c.lable 
                    FROM Course c
                    WHERE c.semester = @semester 
                        AND NOT EXISTS (
                            SELECT 1
                            FROM course_contact cc
                            WHERE cc.id_course = c.Id
                            AND cc.id_contact = @contactID
                        )";

            SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
            cmd.Parameters.Add("@semester", SqlDbType.VarChar).Value = comboBoxSemester.SelectedValue;
            cmd.Parameters.Add("@contactID", SqlDbType.VarChar).Value = txtID.Text;

            mydb.openConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string courseId = reader["Id"].ToString();
                    string courseLabel = reader["lable"].ToString();

                    Course course = new Course(courseId, courseLabel);
                    listBoxAvailableCourse.Items.Add(course);
                }
            }


        }

        private void comboBoxSemester_SelectedValueChanged(object sender, EventArgs e)
        {
            showCourseAvailable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (listBoxAvailableCourse.SelectedItem != null)
            {
                var selectedCourse = listBoxAvailableCourse.SelectedItem;


                listBoxSelectedCourse.Items.Add(selectedCourse);
                listBoxAvailableCourse.Items.Remove(selectedCourse);

            }
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (listBoxSelectedCourse.SelectedItem != null)
            {
                var selectedCourse = listBoxSelectedCourse.SelectedItem;


                listBoxSelectedCourse.Items.Remove(selectedCourse);
                listBoxAvailableCourse.Items.Add(selectedCourse);

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string contactID = txtID.Text; // Lấy mã học sinh từ textBox txtID

            foreach (var item in listBoxSelectedCourse.Items)
            {
                Course selectedCourse = (Course)item; // Ép kiểu mục được chọn thành lớp Course
                string courseId = selectedCourse.id; // Lấy mã khóa học từ đối tượng Course

                SqlCommand command = new SqlCommand("INSERT INTO course_contact (id_contact, id_course)" +
                        " VALUES (@contactID,@courseid)", mydb.getConnection);
                command.Parameters.Add("@contactID", SqlDbType.VarChar).Value = contactID;
                command.Parameters.Add("@courseid", SqlDbType.VarChar).Value = courseId;
                mydb.openConnection();
                command.ExecuteNonQuery();


            }
            listBoxSelectedCourse.Items.Clear();

            MessageBox.Show("Dữ liệu đã được lưu thành công vào cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
