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
    public partial class AddCourseForStudent : Form
    {
        public AddCourseForStudent()
        {
            InitializeComponent();
        }
        Score score = new Score();
        Course course = new Course();
        MY_DB mydb = new MY_DB();

        private void lbAvailableCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddCourseForStudent_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT semester FROM Course");

            comboBoxSemester.DataSource = course.getCourse(cmd);

            comboBoxSemester.SelectedValueChanged += comboBoxSemester_SelectedValueChanged;

            showCourseAvailable();

        }




        private void showCourseAvailable()
        {
            /*SqlCommand cmd = new SqlCommand("Select * from Course where semester = @semester");
            cmd.Parameters.Add("@semester", SqlDbType.VarChar).Value = comboBoxSemester.SelectedValue;

            listBoxAvailableCourse.DataSource = course.getCourse(cmd);
            listBoxAvailableCourse.ValueMember = "Id";
            listBoxAvailableCourse.DisplayMember = "lable";
            listBoxAvailableCourse.SelectedItem = null;*/

            listBoxAvailableCourse.Items.Clear();

            string query = @"SELECT c.Id, c.lable 
                    FROM Course c
                    WHERE c.semester = @semester 
                        AND NOT EXISTS (
                            SELECT 1
                            FROM Score s
                            WHERE s.course_id = c.Id
                            AND s.student_id = @studentId
                        )";

            SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
            cmd.Parameters.Add("@semester", SqlDbType.VarChar).Value = comboBoxSemester.SelectedValue;
            cmd.Parameters.Add("@studentId", SqlDbType.VarChar).Value = txtID.Text;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string studentId = txtID.Text; // Lấy mã học sinh từ textBox txtID

            foreach (var item in listBoxSelectedCourse.Items)
            {
                Course selectedCourse = (Course)item; // Ép kiểu mục được chọn thành lớp Course
                string courseId = selectedCourse.id; // Lấy mã khóa học từ đối tượng Course

                // Gọi phương thức insertScore để thêm điểm cho học sinh với mã học sinh và mã khóa học tương ứng
                score.insertScore(studentId, courseId, null, "Incomplete");


            }
            listBoxSelectedCourse.Items.Clear();

            MessageBox.Show("Dữ liệu đã được lưu thành công vào cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
