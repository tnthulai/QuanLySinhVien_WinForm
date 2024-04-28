using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }

        STUDENT student = new STUDENT();
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                SqlCommand cmd = new SqlCommand("select id, fname,lname, bdate,gender, phone, address, picture,email from std where id = " + id);

                DataTable table = student.getStudents(cmd);

                if (table.Rows.Count > 0)
                {
                    txtFirstName.Text = table.Rows[0]["fname"].ToString();
                    txtLastName.Text = table.Rows[0]["lname"].ToString();
                    dateTimePicker1.Value = (DateTime)table.Rows[0]["bdate"];

                    if (table.Rows[0]["gender"].ToString().Trim() == "Female")
                    {
                        radioButtonFemale.Checked = true;
                    }
                    else
                    {
                        radioButtonMale.Checked = true;
                    }

                    txtPhone.Text = table.Rows[0]["phone"].ToString();
                    txtAddress.Text = table.Rows[0]["address"].ToString();
                    txtEmail.Text = table.Rows[0]["email"].ToString();
                    byte[] pic = (byte[])table.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    picBox.Image = Image.FromStream(picture);

                }
                else
                {
                    MessageBox.Show("Student not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UpdateDeleteStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text);
                string fname = txtFirstName.Text;
                if (!Regex.IsMatch(fname, @"^[\p{L}\s]+$"))
                {
                    MessageBox.Show("Please enter a valid First Name", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string lname = txtLastName.Text;
                if (!Regex.IsMatch(lname, @"^[\p{L}\s]+$"))
                {
                    MessageBox.Show("Please enter a valid Last Name", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DateTime bdate = dateTimePicker1.Value;
                string phone = txtPhone.Text;
                if (!Regex.IsMatch(phone, @"^\d{10}$"))
                {
                    MessageBox.Show("Please enter a valid 10-digit phone number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string adrs = txtAddress.Text;
                string email = txtEmail.Text;
                string gender = "Male";

                if (radioButtonFemale.Checked)
                {
                    gender = "Female";
                }

                MemoryStream pic = new MemoryStream();
                int born_year = dateTimePicker1.Value.Year;
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
                        picBox.Image.Save(pic, picBox.Image.RawFormat);
                        if (student.updateStudent(id, fname, lname, bdate, gender, phone,email, adrs, pic))
                        {
                            MessageBox.Show("Student Infor Updated!!!", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        bool verif()
        {
            if ((txtFirstName.Text.Trim() == "")
                        || (txtLastName.Text.Trim() == "")
                        || (txtAddress.Text.Trim() == "")
                        || (txtPhone.Text.Trim() == "")
                        || (txtEmail.Text.Trim() == "")
                        || (picBox.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = Convert.ToInt32(txtID.Text);
                if ((MessageBox.Show("Are you sure you want to delete this student?", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    if (student.deleteStudent(studentId))
                    {
                        txtID.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtFirstName.Text = "";
                        txtPhone.Text = "";
                        txtAddress.Text = "";
                        txtEmail.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        picBox.Image = null;
                        MessageBox.Show("Student Deleted", "DeleteStudent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
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

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                picBox.Image = Image.FromFile(opf.FileName);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            AddCourseForStudent addCourseForStudent = new AddCourseForStudent();
            addCourseForStudent.txtID.Text = txtID.Text;
            addCourseForStudent.ShowDialog();
        }
    }
}
