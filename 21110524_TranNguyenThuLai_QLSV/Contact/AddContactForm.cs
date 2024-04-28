
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    public partial class AddContactForm : Form
    {
        public string UserName { get; set; }
        public int groupid;
        GROUP group = new GROUP();
        CONTACT contact = new CONTACT();
        public AddContactForm()
        {
            InitializeComponent();
        }

        private void AddContactForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM groups WHERE userid=@userid");
            command.Parameters.Add("@userid", SqlDbType.Int).Value = UserName;
            comboxBoxGroup.DataSource = group.getGroup(command);
            comboxBoxGroup.DisplayMember = "name";
            comboxBoxGroup.ValueMember = "id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text.Trim();
                string fname = txtFName.Text.Trim();
                string lname = txtLName.Text.Trim();
                int group_id = int.Parse(comboxBoxGroup.SelectedValue.ToString());
                string phone = txtPhone.Text.Trim();
                string email = txtEmail.Text.Trim();
                string address = txtAddress.Text.Trim();
                MemoryStream pic = new MemoryStream();
                PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                string userid = UserName;
                if (!contact.checkID(id))
                {
                    MessageBox.Show("Đã tồn tại ID", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.IsMatch(fname, @"^[\p{L}\s]+$"))
                {
                    MessageBox.Show("First Name không hợp lệ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.IsMatch(lname, @"^[\p{L}\s]+$"))
                {
                    MessageBox.Show("Last Name không hợp lệ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (group.checkGroupExist(group_id))
                {
                    MessageBox.Show("Không tồn tại nhóm", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.IsMatch(phone, @"^\d{10}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (contact.insertContact(id, fname, lname, group_id, phone, address, pic, email, userid))
                {
                    MessageBox.Show("Thêm contact thành công!", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm contact không thành công!", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private void btnUploadImage_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
