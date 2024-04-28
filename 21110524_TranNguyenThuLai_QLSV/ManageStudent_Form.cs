using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class ManageStudent_Form : Form
    {
        public ManageStudent_Form()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();
        MY_DB mydb = new MY_DB();
        private void ManageStudent_Form_Load(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("SELECT std.*, COALESCE(CourseNames.CourseNames, ' ') AS CourseNames " +
                "FROM std " +
                "LEFT JOIN ( SELECT score.student_id, STRING_AGG(Course.lable, ', ')  AS CourseNames " +
                "FROM score JOIN Course ON score.course_id = Course.Id " +
                "GROUP BY score.student_id) " +
                "AS CourseNames ON std.id = CourseNames.student_id;");
            fillDataGrid(cmd);
            //getCourseSelect();

        }

        /*private void getCourseSelect()
        {
            SqlCommand cmd = new SqlCommand("SELECT Id, lable FROM Course", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            DataRow allRow = table.NewRow();
            allRow["Id"] = 0; // Giá trị Id của dòng "All" có thể là bất kỳ giá trị nào, ở đây mình đặt là 0
            allRow["lable"] = "All";
            table.Rows.InsertAt(allRow, 0);

            comboBoxCourse.DataSource = table;

            comboBoxCourse.DisplayMember = "lable";
            comboBoxCourse.ValueMember = "Id";
        }
        private void comboBoxCourse_SelectedValueChanged(object sender, EventArgs e)
        {
            string courseId = comboBoxCourse.SelectedValue.ToString();
            String query = null;
            SqlCommand cmd = new SqlCommand();
            if (courseId != null && courseId == "0")
            {
                query = "Select * from std";
                cmd.CommandText = query;
                
            }
            else
            {
                query = "SELECT * FROM std WHERE id IN (SELECT student_id FROM score WHERE course_id = @courseId)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@courseId", courseId);
            }
            cmd.Connection = mydb.getConnection;
            
            fillDataGrid(cmd);
        }*/
        public void fillDataGrid(SqlCommand cmd)
        {
            dataStudent.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataStudent.RowTemplate.Height = 50;
            dataStudent.DataSource = student.getStudents(cmd);
            picCol = (DataGridViewImageColumn)dataStudent.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataStudent.AllowUserToAddRows = false;
            lblTotal.Text = ("Total Students: " + dataStudent.Rows.Count.ToString());

            dataStudent.Columns["id"].HeaderText = "Student ID";
            dataStudent.Columns["fname"].HeaderText = "First Name";
            dataStudent.Columns["lname"].HeaderText = "Last Name";
            dataStudent.Columns["bdate"].HeaderText = "Birthday";
            dataStudent.Columns["email"].HeaderText = "Email";
            dataStudent.Columns["gender"].HeaderText = "Gender";
            dataStudent.Columns["phone"].HeaderText = "Phone";
            dataStudent.Columns["address"].HeaderText = "Address";
            dataStudent.Columns["picture"].HeaderText = "Picture";
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                STUDENT student = new STUDENT();
                int id = Convert.ToInt32(txtStudentID.Text);
                string fname = txtFName.Text;
                if (!Regex.IsMatch(fname, @"^[\p{L}\s]+$"))
                {
                    MessageBox.Show("Please enter a valid First Name", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string lname = txtLName.Text;
                if (!Regex.IsMatch(lname, @"^[\p{L}\s]+$"))
                {
                    MessageBox.Show("Please enter a valid Last Name", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime bdate = DateTimePicker1.Value;
                string phone = txtPhone.Text;
                if (!Regex.IsMatch(phone, @"^\d{10}$"))
                {
                    MessageBox.Show("Please enter a valid 10-digit phone number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string adrs = txtAddress.Text;
                string email = txtEmail.Text;
                string gender = "Male";

                if (RadioButtonFemale.Checked)
                {
                    gender = "Female";
                }

                MemoryStream pic = new MemoryStream();
                int born_year = DateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;
                //  sv tu 10-100,  co the thay doi
                if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
                {
                    MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                    if (student.insertStudent(id, fname, lname, bdate, gender, phone,email, adrs, pic))
                    {
                        MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SqlCommand cmd = new SqlCommand("Select * from std");
                        fillDataGrid(cmd);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool verif()
        {
            if ((txtFName.Text.Trim() == "")
                        || (txtLName.Text.Trim() == "")
                        || (txtAddress.Text.Trim() == "")
                        || (txtPhone.Text.Trim() == "")
                        || (txtEmail.Text.Trim() == "")
                        || (PictureBoxStudentImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtStudentID.Text);
                string fname = txtFName.Text;
                if (!Regex.IsMatch(fname, @"^[\p{L}\s]+$"))
                {
                    MessageBox.Show("Please enter a valid First Name", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string lname = txtLName.Text;
                if (!Regex.IsMatch(lname, @"^[\p{L}\s]+$"))
                {
                    MessageBox.Show("Please enter a valid Last Name", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DateTime bdate = DateTimePicker1.Value;
                string phone = txtPhone.Text;
                if (!Regex.IsMatch(phone, @"^\d{10}$"))
                {
                    MessageBox.Show("Please enter a valid 10-digit phone number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string adrs = txtAddress.Text;
                string gender = "Male";

                if (RadioButtonFemale.Checked)
                {
                    gender = "Female";
                }

                MemoryStream pic = new MemoryStream();
                int born_year = DateTimePicker1.Value.Year;
                string email = txtEmail.Text;
                int this_year = DateTime.Now.Year;
                //  sv tu 10-100,  co the thay doi
                if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
                {
                    MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    try
                    {
                        PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                        if (student.updateStudent(id, fname, lname, bdate, gender, phone,email, adrs, pic))
                        {

                            MessageBox.Show("Student Infor Updated!!!", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SqlCommand cmd = new SqlCommand("Select * from std");
                            fillDataGrid(cmd);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Edit Student!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = Convert.ToInt32(txtStudentID.Text);
                if ((MessageBox.Show("Are you sure you want to delete this student?", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    if (student.deleteStudent(studentId))
                    {
                        txtStudentID.Text = "";
                        txtFName.Text = "";
                        txtLName.Text = "";
                        txtPhone.Text = "";
                        txtAddress.Text = "";
                        txtEmail.Text = "";
                        DateTimePicker1.Value = DateTime.Now;
                        PictureBoxStudentImage.Image = null;
                        MessageBox.Show("Student Deleted", "DeleteStudent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SqlCommand cmd = new SqlCommand("Select * from std");
                        fillDataGrid(cmd);
                    }
                    else
                    {
                        MessageBox.Show("Student Not Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else { }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid Id!!", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            DateTimePicker1.Value = DateTime.Now;
            PictureBoxStudentImage.Image = null;
            RadioButtonMale.Checked = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from std where concat(fname,lname,address) like '%" + txtSearch.Text.Trim() + "%'");
            fillDataGrid(cmd);

        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = ("student" + txtStudentID.Text);
            if(PictureBoxStudentImage.Image == null)
            {
                MessageBox.Show("No image in the picture box");
            }
            else if (svf.ShowDialog() == DialogResult.OK)
            {
                PictureBoxStudentImage.Image.Save(svf.FileName + ("." + ImageFormat.Jpeg.ToString()));
            }

        }

        private void dataStudent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataStudent_DoubleClick(object sender, EventArgs e)
        {
            txtStudentID.Text = dataStudent.CurrentRow.Cells[0].Value.ToString();
            txtFName.Text = dataStudent.CurrentRow.Cells[1].Value.ToString();
            txtLName.Text = dataStudent.CurrentRow.Cells[2].Value.ToString();
            DateTimePicker1.Value = (DateTime)dataStudent.CurrentRow.Cells[3].Value;

            if ((dataStudent.CurrentRow.Cells[4].Value.ToString().Trim() == "Female"))
            {
                RadioButtonFemale.Checked = true;
            }
            else
            {
                RadioButtonMale.Checked = true;
            }
            txtPhone.Text = dataStudent.CurrentRow.Cells[5].Value.ToString();
            txtAddress.Text = dataStudent.CurrentRow.Cells[6].Value.ToString();

            byte[] pic;
            MemoryStream picture;
            object value = dataStudent.CurrentRow.Cells[7].Value;
            if (value != DBNull.Value)
            {
                pic = (byte[])value;
                picture = new MemoryStream(pic);
                PictureBoxStudentImage.Image = Image.FromStream(picture);
            }
            else
            {
                PictureBoxStudentImage.Image = null;
            }
            
            txtEmail.Text = dataStudent.CurrentRow.Cells[8].Value.ToString();

        }

        
    }
}
