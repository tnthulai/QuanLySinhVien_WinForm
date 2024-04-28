using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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
                    if (student.insertStudent(id, fname, lname, bdate, gender, phone, email, adrs, pic))
                    {
                        MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
